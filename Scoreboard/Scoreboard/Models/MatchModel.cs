using System;

namespace Scoreboard.Database
{
    public class MatchModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public string SetsName { get; set; }
        public int Sets { get; set; }
        public string StartTime { get; set; }
        public int ElapsedSeconds { get; set; }
        public int IsPaused { get; set; }
        public int Status { get; set; }
        public bool ShowToggle { get; set; }
        public int UserId { get; set; }
        
        /// <summary>
        /// Gets the match status as an enum value
        /// </summary>
        public MatchStatus MatchStatus
        {
            get
            {
                if (Enum.IsDefined(typeof(MatchStatus), Status))
                {
                    return (MatchStatus)Status;
                }
                return MatchStatus.NotStarted; // Default to NotStarted if value is not defined
            }
        }
    }
}