using System;

namespace Scoreboard.Database
{
    /// <summary>
    /// Enumeration of match statuses in the system
    /// </summary>
    public enum MatchStatus
    {
        /// <summary>
        /// Match has not started yet
        /// </summary>
        NotStarted = 0,
        
        /// <summary>
        /// Match is currently in progress
        /// </summary>
        InProgress = 1,
        
        /// <summary>
        /// Match has been completed
        /// </summary>
        Completed = 2,
        
        /// <summary>
        /// Match has been cancelled
        /// </summary>
        Cancelled = 3
    }
}