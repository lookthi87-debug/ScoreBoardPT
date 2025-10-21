using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Scoreboard.Data
{
    public static class LicenseVerifier
    {
        private const string SecretSeed = "licxQLTD";
        private static readonly byte[] Salt = Encoding.UTF8.GetBytes("QLTD_FIXED_SALT");
        private const int Iterations = 10000;

        /// <summary>
        /// Giải mã nội dung license JSON.
        /// </summary>
        private static string DecryptPayload(string json)
        {
            JObject obj = JObject.Parse(json);
            byte[] iv = Convert.FromBase64String(obj["iv"].ToString());
            byte[] cipher = Convert.FromBase64String(obj["cipher"].ToString());
            byte[] mac = Convert.FromBase64String(obj["mac"].ToString());

            using (var kdf = new Rfc2898DeriveBytes(SecretSeed, Salt, Iterations))
            {
                byte[] aesKey = kdf.GetBytes(32);
                byte[] hmacKey = kdf.GetBytes(32);

                // ✅ Kiểm tra MAC trước khi giải mã (bảo toàn toàn vẹn dữ liệu)
                using (var hmac = new HMACSHA256(hmacKey))
                {
                    byte[] ivCipher = new byte[iv.Length + cipher.Length];
                    Buffer.BlockCopy(iv, 0, ivCipher, 0, iv.Length);
                    Buffer.BlockCopy(cipher, 0, ivCipher, iv.Length, cipher.Length);

                    byte[] expectedMac = hmac.ComputeHash(ivCipher);
                    if (!CompareBytes(mac, expectedMac))
                        throw new CryptographicException("License file bị thay đổi hoặc hỏng.");
                }

                using (var aes = Aes.Create())
                {
                    aes.Key = aesKey;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var dec = aes.CreateDecryptor())
                    {
                        byte[] plain = dec.TransformFinalBlock(cipher, 0, cipher.Length);
                        return Encoding.UTF8.GetString(plain);
                    }
                }
            }
        }

        private static bool CompareBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }

        /// <summary>
        /// Giải mã license trong DB (đọc từ Repository)
        /// </summary>
        public static bool TryVerifyLicense(out int totalMachines, out DateTime expiry, out string message)
        {
            totalMachines = 0;
            expiry = DateTime.MinValue;
            message = "";

            try
            {
                string jsonText = Repository.GetLicenseData();
                if (string.IsNullOrEmpty(jsonText))
                {
                    message = "Không tìm thấy license trong hệ thống.";
                    return false;
                }

                string decrypted = DecryptPayload(jsonText);
                var parts = decrypted.Split('|');
                totalMachines = int.Parse(parts[0].Split(':')[1]);
                expiry = DateTime.Parse(parts[1].Split(':')[1]);
                return true;
            }
            catch (Exception ex)
            {
                message = "Lỗi license: " + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Kiểm tra license từ file JSON (chưa lưu DB)
        /// </summary>
        public static bool TryVerifyLicense(string json, out int totalMachines, out DateTime expiry)
        {
            totalMachines = 0;
            expiry = DateTime.MinValue;

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                    return false;

                string decrypted = DecryptPayload(json);
                var parts = decrypted.Split('|');
                if (parts.Length < 2) return false;

                totalMachines = int.Parse(parts[0].Split(':')[1]);
                expiry = DateTime.Parse(parts[1].Split(':')[1]);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Khi admin đăng nhập, nếu file license.licx khác DB → update vào DB
        /// </summary>
        public static void SyncLicenseFileToDB(string licPath, int adminId)
        {
            if (!File.Exists(licPath)) return;

            string fileHash = Repository.GetFileHash(licPath);
            string dbHash = Repository.GetLicenseHash();

            // Nếu giống nhau → không cần update
            if (string.Equals(fileHash, dbHash, StringComparison.OrdinalIgnoreCase))
                return;

            string json = File.ReadAllText(licPath);

            // 2Giải mã license trong file
            int fileMachines = 0;
            DateTime fileExpiry = DateTime.MinValue;

            try
            {
                string decrypted = DecryptPayload(json); 
                var parts = decrypted.Split('|');
                fileMachines = int.Parse(parts[0].Split(':')[1]);
                fileExpiry = DateTime.Parse(parts[1].Split(':')[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("File license không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3Lấy license trong DB (nếu có)
            int dbMachines = 0;
            DateTime dbExpiry = DateTime.MinValue;
            string dbMsg = "";
            bool hasDbLicense = TryVerifyLicense(out dbMachines, out dbExpiry, out dbMsg);

            // Nếu có license trong DB, chỉ update nếu license mới hơn
            if (hasDbLicense)
            {
                if (fileExpiry <= dbExpiry && fileMachines <= dbMachines)
                {
                    return;
                }
            }
            // 5Nếu license mới hơn → update DB
            Repository.UpdateSystemLicense(json, fileHash, adminId);
        }
    }
}
