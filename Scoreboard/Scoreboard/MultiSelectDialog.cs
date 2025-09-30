using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Scoreboard.Database;

namespace Scoreboard
{
    public class MultiSelectDialog : Form
    {
        private CheckedListBox chkList;
        private List<MatchModel> matches;
        public MultiSelectDialog(List<MatchModel> matches)
        {
            this.matches = matches ?? new List<MatchModel>();
            Text = "Chọn trận để hiển thị";
            Width = 700;
            Height = 500;
            StartPosition = FormStartPosition.CenterParent;
            chkList = new CheckedListBox { Left = 10, Top = 10, Width = 660, Height = 380, CheckOnClick = true };
            if (this.matches != null)
            {
                foreach (var m in this.matches)
                {
                    chkList.Items.Add(m); // Assumes MatchModel.ToString() is meaningful
                }
            }
            var btnOpen = new Button { Text = "Mở màn hình hiển thị", Left = 440, Top = 400, Width = 200, DialogResult = DialogResult.OK };
            Controls.AddRange(new Control[] { chkList, btnOpen });
            AcceptButton = btnOpen;
        }

        public List<MatchModel> GetSelectedMatches()
        {
            var sel = new List<MatchModel>();
            for (int i=0;i<chkList.Items.Count;i++) if (chkList.GetItemChecked(i)) sel.Add(matches[i]);
            return sel;
        }
    }

}
        
