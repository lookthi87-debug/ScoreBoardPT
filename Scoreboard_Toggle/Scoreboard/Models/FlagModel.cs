using System;
using System.Drawing;
using System.IO;

namespace Scoreboard.Models
{
    public class FlagModel
    {
        public byte[] Flag { get; set; }
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