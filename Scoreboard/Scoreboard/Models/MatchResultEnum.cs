using System;

namespace Scoreboard.Database
{
    /// <summary>
    /// Enumeration of possible match results
    /// </summary>
    public enum MatchResult
    {
        /// <summary>
        /// Match result is not determined yet
        /// </summary>
        Undetermined,
        
        /// <summary>
        /// Team 1 won the match
        /// </summary>
        Team1Win,
        
        /// <summary>
        /// Team 2 won the match
        /// </summary>
        Team2Win,
        
        /// <summary>
        /// Match ended in a draw
        /// </summary>
        Draw
    }
}