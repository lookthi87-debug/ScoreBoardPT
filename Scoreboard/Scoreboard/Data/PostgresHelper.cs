using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using Npgsql;

namespace Scoreboard.Data
{
    public static class PostgresHelper
    {
        private const string REG_PATH = @"Software\Scoreboard\DatabaseConfig";
        public static string ConnectionString;
        private static NpgsqlConnection _sharedConn;
        public static void SaveConfig(string host, string port, string database, string username, string password)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(REG_PATH);
                key.SetValue("Host", host);
                key.SetValue("Port", port);
                key.SetValue("User", username );
                key.SetValue("Password", password );
                key.SetValue("Database", database );
                key.Close();

                setConn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi cấu hình vào Registry: " + ex.Message);
            }
        }
        // Đọc cấu hình (trả về tuple)
        public static (string Host, string Port, string User, string Password, string Database) LoadConfig()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_PATH);
                if (key == null)
                    return ("127.0.0.1", "5432", "postgres", "Abc12345", "DB_Scoreboard");

                string host = key.GetValue("Host", "").ToString();
                string port = key.GetValue("Port", "").ToString();
                string user = key.GetValue("User", "").ToString();
                string password = key.GetValue("Password", "").ToString();
                string database = key.GetValue("Database", "").ToString();
                key.Close();

                return (host, port, user, password, database);
            }
            catch
            {
                return ("", "", "", "", "");
            }
        }
        
        // Kiểm tra tồn tại
        public static bool Exists()
        {
            return Registry.CurrentUser.OpenSubKey(REG_PATH) != null;
        }
        public static void setConn()
        {
            var cf = LoadConfig();
            ConnectionString = $"Host={cf.Host};Port={cf.Port};Database={cf.Database};Username={cf.User};Password={cf.Password}";
            _sharedConn = new NpgsqlConnection(ConnectionString);
        }
        // ============================
        // ============================
        public static bool OpenSharedConnection(bool isShowMessage = true)
        {
            try
            {
                if (_sharedConn == null)
                {
                    var cf = LoadConfig();
                    ConnectionString = $"Host={cf.Host};Port={cf.Port};Database={cf.Database};Username={cf.User};Password={cf.Password}";
                    _sharedConn = new NpgsqlConnection(ConnectionString);
                }

                if (_sharedConn.State == System.Data.ConnectionState.Closed ||
                    _sharedConn.State == System.Data.ConnectionState.Broken)
                {
                    _sharedConn.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (isShowMessage)
                {
                    MessageBox.Show("Không thể kết nối database\n" + ex.ToString());
                }
                return false;
            }
        }

        // ============================
        // ============================
        public static NpgsqlConnection SharedConn
        {
            get
            {
                if (_sharedConn == null || _sharedConn.State != System.Data.ConnectionState.Open)
                    OpenSharedConnection();
                return _sharedConn;
            }
        }

        // ============================
        // ============================
        public static void CloseSharedConnection()
        {
            try
            {
                if (_sharedConn != null && _sharedConn.State == System.Data.ConnectionState.Open)
                {
                    _sharedConn.Close();
                    _sharedConn.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối database");
            }
        }

        // ============================
        // ============================
        public static bool IsConnected()
        {
            return _sharedConn != null && _sharedConn.State == System.Data.ConnectionState.Open;
        }
    }
}