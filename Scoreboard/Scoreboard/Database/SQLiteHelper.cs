using System;
using System.Data.SQLite;
using System.IO;

namespace Scoreboard.Database
{
    public static class SQLiteHelper
    {
        private static string DbPath => "D:\\BongDa\\DataBase\\scoreboard.db";
        private static string ConnString => $"Data Source={DbPath};Version=3;";
        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnString);
            conn.Open();
            return conn;
        }
    }
}
