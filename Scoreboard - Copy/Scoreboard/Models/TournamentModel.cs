using System;

namespace Scoreboard.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public int match_class_id { get; set; }
        public string match_class_name { get; set; }
    }
}