using System;

namespace Scoreboard.Database
{
    public class User 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        
        /// <summary>
        /// Gets the user role as an enum value
        /// </summary>
        public UserRole UserRole
        {
            get
            {
                if (Enum.TryParse<UserRole>(Role, out UserRole role))
                {
                    return role;
                }
                return UserRole.User; // Default to User if parsing fails
            }
        }
    }
}