using System;

namespace Scoreboard.Database
{
    /// <summary>
    /// Enumeration of user roles in the system
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Administrator with full access to all system features
        /// </summary>
        Admin,
        
        /// <summary>
        /// Regular user with limited access
        /// </summary>
        User
    }
}