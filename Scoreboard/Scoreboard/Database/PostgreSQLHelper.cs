using System;
using Npgsql;

namespace Scoreboard.Database
{
    public static class PostgreSQLHelper
    {
        // Update these connection settings according to your PostgreSQL setup
        private static string Host => "localhost";
        private static string Port => "5432";
        private static string Database => "scoreboard";
        private static string Username => "postgres";
        private static string Password => "123";
        
        private static string ConnString => $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password};";
        
        public static NpgsqlConnection GetConnection()
        {
            var conn = new NpgsqlConnection(ConnString);
            conn.Open();
            return conn;
        }
    }
}