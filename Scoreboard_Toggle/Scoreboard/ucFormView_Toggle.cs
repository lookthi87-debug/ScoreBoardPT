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
        private MatchsetModel match;
        public ucFormView_Toggle(MatchsetModel m)
        {
            InitializeComponent();
            this.Resize += MatchUC_Resize;
            match = m;
            if (m != null)
            {
                lblTitle.Text = m.TournamentName;
                lblHiepDau.Text = m.ClassSetsName;
                lblTeam1.Text = m.Team1;
                lblTeam2.Text = m.Team2;
                lblScoreTeam1.Text = m.TotalScore1.ToString();
                lblScoreTeam2.Text = m.TotalScore2.ToString();
                lblTime.Text = m.Time;
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

            lblScoreTeam1.Font = new Font("Arial", baseSize * 2 + 10, FontStyle.Bold);
            lblScoreTeam2.Font = new Font("Arial", baseSize * 2 + 10, FontStyle.Bold);

            lblBonus.Font = new Font("Arial", baseSize - 10, FontStyle.Bold);
            // Căn giữa
            foreach (Control ctl in this.Controls)
            {
                if (ctl is Label lbl) lbl.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
        private void InitTimer()
        {

            matchTimer = new Timer();
            matchTimer.Interval = 200; // mm giây
            matchTimer.Tick += (s, e) =>
            {
                if (!isPaused)
                {
                    var m = Repository.GetMatchSetByMatchAndId(match.MatchId, match.Id);
                    if (m != null) 
                    {
                        lblTitle.Text = m.TournamentName;
                        lblHiepDau.Text = m.ClassSetsName;
                        lblTeam1.Text = m.Team1;
                        lblTeam2.Text = m.Team2;
                        lblScoreTeam1.Text = m.TotalScore1.ToString();
                        lblScoreTeam2.Text = m.TotalScore2.ToString();

                        if (TimeSpan.TryParse(m.Time, out var time))
                        {
                            time = time.Add(TimeSpan.FromSeconds(1));
                            lblTime.Text = time.ToString(@"hh\:mm");
                        }
                        else
                        {
                            lblTime.Text = m.Time;
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
