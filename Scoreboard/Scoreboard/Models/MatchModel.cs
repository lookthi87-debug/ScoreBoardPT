using System;

namespace Scoreboard.Models
{
    public class MatchModel
    {
        public string Id { get; set; } 
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Time { get; set; }
        public int? RefereeId { get; set; }
        public string RefereeName { get; set; }
        public string Note { get; set; }
        public int ShowToggle { get; set; }
        public string Status { get; set; }
        public int? TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int? MatchClassId { get; set; }
        public string MatchClassName { get; set; }
        public DateTime? TournamentStart { get; set; }
        public DateTime? TournamentEnd { get; set; }
    }
}