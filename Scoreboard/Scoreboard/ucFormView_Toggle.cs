using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Scoreboard.Database;

namespace Scoreboard
{
    public partial class ucFormView_Toggle : UserControl
    {
        private Timer matchTimer;
        private bool isPaused = true;
        private MatchModel match { get; set; }
        public ucFormView_Toggle(MatchModel m)
        {
            InitializeComponent();
            this.Resize += MatchUC_Resize;
            match = m;
            if (m != null)
            {
                lblTitle.Text = m.Title;
                lblHiepDau.Text = m.SetsName + " " + m.Sets.ToString();
                lblTeam1.Text = m.Team1;
                lblTeam2.Text = m.Team2;
                lblScoreTeam1.Text = m.Score1.ToString();
                lblScoreTeam2.Text = m.Score2.ToString();
                lblTime.Text = m.StartTime;
            }
            InitTimer();
            StartClock();
        }
        private void MatchUC_Resize(object sender, EventArgs e)
        {
            float baseSize = Math.Min(this.Width, this.Height) / 25f;
            lblTitle.Font = new Font("Arial", baseSize, FontStyle.Bold);
            lblTime.Font = new Font("Arial", baseSize * 2, FontStyle.Bold);
            lblHiepDau.Font = new Font("Arial", baseSize, FontStyle.Bold);

            lblTeam1.Font = new Font("Arial", baseSize, FontStyle.Bold);
            lblTeam2.Font = new Font("Arial", baseSize, FontStyle.Bold);

            lblScoreTeam1.Font = new Font("Arial", baseSize * 2, FontStyle.Bold);
            lblScoreTeam2.Font = new Font("Arial", baseSize * 2, FontStyle.Bold);

            lblBonus.Font = new Font("Arial", baseSize - 10, FontStyle.Bold);
            // Căn giữa
            foreach (Control ctl in this.Controls)
            {
                if (ctl is Label lbl) lbl.TextAlign = ContentAlignment.MiddleCenter;
            }
            var list = Repository.GetShowMatchesToggle();
        }
        private void InitTimer()
        {
            matchTimer = new Timer();
            matchTimer.Interval = 1000; // 1 giây
            matchTimer.Tick += (s, e) =>
            {
                if (!isPaused)
                {
                    var m = Repository.GetMatchById(match.Id);
                    if (m != null) 
                    {
                        lblTitle.Text = m.Title;
                        lblHiepDau.Text = m.SetsName + " " + m.Sets.ToString();
                        lblTeam1.Text = m.Team1;
                        lblTeam2.Text = m.Team2;
                        lblScoreTeam1.Text = m.Score1.ToString();
                        lblScoreTeam2.Text = m.Score2.ToString();
                        lblTime.Text = m.StartTime;
                        match = m;
                        if (m.Status == 1)
                        {
                            StopClock();
                        }
                    }
                }
            };
            matchTimer.Start();
        }
        private void StartClock()
        {
            isPaused = false;
        }

        private void StopClock()
        {
            isPaused = true;
        }
    }
}
