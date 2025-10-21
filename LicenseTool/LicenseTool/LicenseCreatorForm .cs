using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseTool
{
    public partial class LicenseCreatorfrm : Form
    {
        private const string SecretSeed = "licxQLTD";
        private static readonly byte[] Salt = Encoding.UTF8.GetBytes("QLTD_FIXED_SALT");
        private const int Iterations = 10000;
        public LicenseCreatorfrm()
        {
            InitializeComponent();
            nCountMachin.Value = 4;
            dExpiry.Value = DateTime.Now.AddYears(1).AddDays(1);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int total = (int)nCountMachin.Value;
                DateTime expiry = dExpiry.Value.Date;
                string payload = $"QLTD:{total}|EXPIRE:{expiry:yyyy-MM-dd}";

                // encrypt payload
                var result = EncryptPayload(payload, SecretSeed);

                string json = "{\n" +
                              $"  \"iv\": \"{Convert.ToBase64String(result.Iv)}\",\n" +
                              $"  \"cipher\": \"{Convert.ToBase64String(result.Cipher)}\",\n" +
                              $"  \"mac\": \"{Convert.ToBase64String(result.Mac)}\"\n" +
                              "}";

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "License File|*.licx";
                    sfd.FileName = "license.licx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, json, Encoding.UTF8);
                        MessageBox.Show("Tạo license thành công!\n" + sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo license: " + ex.Message);
            }
        }
        private static (byte[] Iv, byte[] Cipher, byte[] Mac) EncryptPayload(string payload, string seed)
        {
            // derive keys
            using (var kdf = new Rfc2898DeriveBytes(seed, Salt, Iterations))
            {
                byte[] aesKey = kdf.GetBytes(32);
                byte[] hmacKey = kdf.GetBytes(32);

                byte[] iv = new byte[16];
                using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(iv);

                byte[] plain = Encoding.UTF8.GetBytes(payload);
                byte[] cipher;

                using (var aes = Aes.Create())
                {
                    aes.Key = aesKey;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    using (var enc = aes.CreateEncryptor())
                    {
                        cipher = enc.TransformFinalBlock(plain, 0, plain.Length);
                    }
                }

                byte[] ivCipher = new byte[iv.Length + cipher.Length];
                Buffer.BlockCopy(iv, 0, ivCipher, 0, iv.Length);
                Buffer.BlockCopy(cipher, 0, ivCipher, iv.Length, cipher.Length);

                byte[] mac;
                using (var hmac = new HMACSHA256(hmacKey))
                {
                    mac = hmac.ComputeHash(ivCipher);
                }

                return (iv, cipher, mac);
            }
        }
    }
}
