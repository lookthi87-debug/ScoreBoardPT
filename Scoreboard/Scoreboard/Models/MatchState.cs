using System;

namespace Scoreboard.Database
{
    public class MatchState
    {
        public int MatchId { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int ElapsedSeconds { get; set; }
    }
}