using System;
using System.Collections.Generic;
using Scoreboard.Database;

namespace Scoreboard.Utilities
{
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Checks if the database has any users. If not, creates a default admin account.
        /// </summary>
        /// <returns>True if initialization was performed, false if users already existed</returns>
        public static bool InitializeDatabase()
        {
            try
            {
                // Check if there are any users in the database
                var users = Repository.GetAllUsers();
                
                // If no users exist, create a default admin account
                if (users == null || users.Count == 0)
                {
                    // Create default admin user
                    // Username: admin
                    // Password: admin123
                    // Role: Admin
                    // Name: Administrator
                    Repository.AddUser("admin", "admin123", "Admin", "Administrator");
                    
                    Console.WriteLine("Database initialized with default admin account:");
                    Console.WriteLine("Username: admin");
                    Console.WriteLine("Password: admin123");
                    Console.WriteLine("Role: Admin");
                    
                    return true;
                }
                
                Console.WriteLine($"Database already contains {users.Count} user(s). No initialization needed.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Checks if the database has any users without creating any.
        /// </summary>
        /// <returns>True if users exist, false otherwise</returns>
        public static bool HasUsers()
        {
            try
            {
                var users = Repository.GetAllUsers();
                return users != null && users.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}