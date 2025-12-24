using System;
using System.Drawing;
using System.IO;

namespace Scoreboard.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public int? TournamentsId { get; set; }
        public string Name { get; set; }
        public byte[] Flag { get; set; }
        public string Note { get; set; }
        // dùng cho DataGridView
        public Image FlagImage
        {
            get
            {
                if (Flag == null) return null;
                using (var ms = new MemoryStream(Flag))
                    return Image.FromStream(ms);
            }
        }
    }
}