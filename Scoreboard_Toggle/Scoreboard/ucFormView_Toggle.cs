using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public partial class ucFormView_Toggle : UserControl
    {
        private Timer matchTimer;
        private bool isPaused = true;
        private MatchsetModel match;
        private int countShow = 0;
        private int[] _baseRowHeights;
        private int _baseHeight;
        private int _baseWidth;
        public ucFormView_Toggle(MatchsetModel m,int nCount)
        {
            InitializeComponent();
            InitTableViewLayout();
            _baseHeight = this.Height;
            _baseWidth = this.Width;
            countShow = nCount;
            this.Resize += MatchUC_Resize;

            LoadFlagImagesVN();
            match = m;
            lblTitle.Text = m.TournamentName;
            lblHiepDau.Text = m.ClassSetsName;
            lblTeam1.Text = m.Team1;
            lblTeam2.Text = m.Team2;
            if (IsSoccerMatch())
            {
                lblScoreTeam1.Text = m.TotalScore1.ToString();
                lblScoreTeam2.Text = m.TotalScore2.ToString();
            }
            else
            {
                lblScoreTeam1.Text = m.Score1.ToString();
                lblScoreTeam2.Text = m.Score2.ToString();
            }
            lblTime.Text = m.Time ?? "00:00";

            LoadFlagImagesTeams(m);
            // Khởi tạo bảng điểm các set cho các bộ môn không phải bóng đá
           UpdateSetScoresPanel();

            InitTimer();
            StartClock();
        }
        
        private void InitTableViewLayout()
        {
            tableView.SuspendLayout();

            tableView.AutoSize = false;
            tableView.RowStyles.Clear();

            _baseRowHeights = new int[]
            {
                120,
                50,
                50,
                50,
                60,
                40,
                80,
                60
            };
            if (countShow == 1)
            {
                _baseRowHeights[0] = 120;
            }
            if (countShow >= 2 && countShow <= 4)
            {
                _baseRowHeights[0] = 100;
            }
            if (countShow >= 5 && countShow <= 6)
            {
                _baseRowHeights[0] = 80;
            }
            if (countShow > 6)
            {
                _baseRowHeights[0] = 60;
            }

            tableView.RowCount = _baseRowHeights.Length;

            int totalHeight = _baseRowHeights.Sum();

            foreach (int h in _baseRowHeights)
            {
                float percent = (float)h * 100f / totalHeight;
                tableView.RowStyles.Add(
                    new RowStyle(SizeType.Percent, percent)
                );
            }

            tableView.ResumeLayout();
        }
        private void CenterAllLabels(System.Windows.Forms.Control parent)
        {
            foreach (System.Windows.Forms.Control c in parent.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                }

                if (c.HasChildren)
                {
                    CenterAllLabels(c);
                }
            }
        }
        private float _lastScale = -1f;
        private void MatchUC_Resize(object sender, EventArgs e)
        {
            if (_baseHeight <= 0 || this.Width <= 0 || this.Height <= 0) return;

            float scaleH = (float)this.Height / _baseHeight;
            float scaleW = (float)this.Width / this._baseWidth;

            float scale = Math.Min(scaleH, scaleW); 
            scale = Math.Max(0.25f, Math.Min(scale, 1.5f)); // cho phép scale nhỏ

            if (Math.Abs(scale - _lastScale) < 0.03f) return;
            _lastScale = scale;

            ScaleContent(scale);
        }
        private void ScaleContent(float scale)
        {

            if (countShow >= 1 && countShow <= 2)
            {
                lblTitle.Font = new System.Drawing.Font("Arial", 18 * scale, FontStyle.Bold);
                lblTime.Font = new System.Drawing.Font("Arial", 26 * scale, FontStyle.Bold);
                lblHiepDau.Font = new System.Drawing.Font("Arial", 24 * scale, FontStyle.Bold);
                lblTeam1.Font = new System.Drawing.Font("Arial", 30 * scale, FontStyle.Bold);
                lblTeam2.Font = new System.Drawing.Font("Arial", 30 * scale, FontStyle.Bold);

                lblScoreTeam1.Font = new System.Drawing.Font("Arial", 40 * scale, FontStyle.Bold);
                lblScoreTeam2.Font = new System.Drawing.Font("Arial", 40 * scale, FontStyle.Bold);

                lblTeam11.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblTeam21.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblSet1.Font = new System.Drawing.Font("Arial", 10 * scale, FontStyle.Bold);
                lblSet2.Font = new System.Drawing.Font("Arial", 10 * scale, FontStyle.Bold);
                lblSet3.Font = new System.Drawing.Font("Arial", 10 * scale, FontStyle.Bold);
                lblSet4.Font = new System.Drawing.Font("Arial", 10 * scale, FontStyle.Bold);
                lblSet5.Font = new System.Drawing.Font("Arial", 10 * scale, FontStyle.Bold);
                lblScore11.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore12.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore13.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore14.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore15.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore21.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore22.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore23.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore24.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblScore25.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
            }
            //if (countShow >= 1 && countShow <= 2)
            //{
            //    lblTitle.Font = new System.Drawing.Font("Arial", 18 * scale, FontStyle.Bold);
            //    lblTime.Font = new System.Drawing.Font("Arial", 26 * scale, FontStyle.Bold);
            //    lblHiepDau.Font = new System.Drawing.Font("Arial", 14 * scale, FontStyle.Bold);
            //    lblTeam1.Font = new System.Drawing.Font("Arial", 20 * scale, FontStyle.Bold);
            //    lblTeam2.Font = new System.Drawing.Font("Arial", 20 * scale, FontStyle.Bold);

            //    lblScoreTeam1.Font = new System.Drawing.Font("Arial", 32 * scale, FontStyle.Bold);
            //    lblScoreTeam2.Font = new System.Drawing.Font("Arial", 32 * scale, FontStyle.Bold);
            //}
            if (countShow >= 3 && countShow <=6)
            {
                lblTitle.Font = new System.Drawing.Font("Arial", 16 * scale, FontStyle.Bold);
                lblTime.Font = new System.Drawing.Font("Arial", 24 * scale, FontStyle.Bold);
                lblHiepDau.Font = new System.Drawing.Font("Arial", 14 * scale, FontStyle.Bold);
                lblTeam1.Font = new System.Drawing.Font("Arial", 16 * scale, FontStyle.Bold);
                lblTeam2.Font = new System.Drawing.Font("Arial", 16 * scale, FontStyle.Bold);

                lblScoreTeam1.Font = new System.Drawing.Font("Arial", 28 * scale, FontStyle.Bold);
                lblScoreTeam2.Font = new System.Drawing.Font("Arial", 28 * scale, FontStyle.Bold);

                lblTeam11.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblTeam21.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblSet1.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet2.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet3.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet4.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet5.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblScore11.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore12.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore13.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore14.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore15.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore21.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore22.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore23.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore24.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore25.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
            }
            if (countShow >= 7)
            {
                lblTitle.Font = new System.Drawing.Font("Arial", 14 * scale, FontStyle.Bold);
                lblTime.Font = new System.Drawing.Font("Arial", 24 * scale, FontStyle.Bold);
                lblHiepDau.Font = new System.Drawing.Font("Arial", 12 * scale, FontStyle.Bold);
                lblTeam1.Font = new System.Drawing.Font("Arial", 14 * scale, FontStyle.Bold);
                lblTeam2.Font = new System.Drawing.Font("Arial", 14 * scale, FontStyle.Bold);

                lblScoreTeam1.Font = new System.Drawing.Font("Arial", 26 * scale, FontStyle.Bold);
                lblScoreTeam2.Font = new System.Drawing.Font("Arial", 26 * scale, FontStyle.Bold);

                lblTeam11.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblTeam21.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblSet1.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet2.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet3.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet4.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblSet5.Font = new System.Drawing.Font("Arial", 7 * scale, FontStyle.Bold);
                lblScore11.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore12.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore13.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore14.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore15.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore21.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore22.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore23.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore24.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
                lblScore25.Font = new System.Drawing.Font("Arial", 8 * scale, FontStyle.Bold);
            }
            lblBonus.Font = new System.Drawing.Font("Arial", 10 * scale, FontStyle.Bold);

            


            int flagVN = (int)(40 * scale);
            int flagTeam = (int)(30 * scale);
            if (countShow == 1)
            {
                pgFlagVN.Size = new Size(flagVN * 6, flagVN * 4);
            }
            if (countShow >= 2 && countShow<=4)
            {
                pgFlagVN.Size = new Size(flagVN * 5, flagVN * 3);
            }
            if (countShow >= 5 && countShow <= 6)
            {
                pgFlagVN.Size = new Size(flagVN * 4, flagVN * 2);
            }
            if (countShow > 6 )
            {
                pgFlagVN.Size = new Size(flagVN * 3, flagVN * 2);
            }
            pgFlagTeam1.Size = new Size(flagTeam * 4, flagTeam * 3);
            pgFlagTeam2.Size = new Size(flagTeam * 4, flagTeam * 3);
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
                        if (IsSoccerMatch())
                        {
                            lblScoreTeam1.Text = m.TotalScore1.ToString();
                            lblScoreTeam2.Text = m.TotalScore2.ToString();
                        }
                        else
                        {
                            lblScoreTeam1.Text = m.Score1.ToString();
                            lblScoreTeam2.Text = m.Score2.ToString();
                        }

                        if (TimeSpan.TryParse(m.Time, out var time))
                        {
                            time = time.Add(TimeSpan.FromSeconds(1));
                            lblTime.Text = time.ToString(@"hh\:mm");
                        }
                        else
                        {
                            lblTime.Text = m.Time;
                        }
                        UpdateSetScoresPanel();
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
        private void LoadFlagImagesVN()
        {
            try
            {
                FlagModel flgm = new FlagModel();
                flgm = Repository.GetFlag();
                if (flgm.Flag != null)
                {
                    tblFlagVN.Visible = true;
                    using (var ms = new MemoryStream(flgm.Flag))
                    {
                        pgFlagVN.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    tblFlagVN.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }
        private void LoadFlagImagesTeams(MatchsetModel m)
        {
            try
            {
                MatchModel mdl = Repository.GetMatchById(m.MatchId);
                if (mdl != null)
                {
                    using (var ms = new MemoryStream(mdl.Team1Flag))
                    {
                        pgFlagTeam1.Image = Image.FromStream(ms);
                    }
                    using (var ms = new MemoryStream(mdl.Team2Flag))
                    {
                        pgFlagTeam2.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public bool IsSoccerMatch()
        {
            var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);
            if (matchClass.PeriodType.ToLower() == "half")
            {
                return true;
            }
            return false;
        }
        private void UpdateSetScoresPanel()
        {
            try
            {
                bool isSoccer = IsSoccerMatch();
                if (isSoccer)
                {
                    tableLayoutPanel2.Visible = false;
                    return;
                }
                lblSet1.Visible = false;
                lblSet2.Visible = false;
                lblSet3.Visible = false;
                lblSet4.Visible = false;
                lblSet5.Visible = false;
                lblScore11.Visible = false;
                lblScore12.Visible = false;
                lblScore13.Visible = false;
                lblScore14.Visible = false;
                lblScore15.Visible = false;
                lblScore21.Visible = false;
                lblScore22.Visible = false;
                lblScore23.Visible = false;
                lblScore24.Visible = false;
                lblScore25.Visible = false;

                var sets = Repository.GetMatchSetsByMatchId(match.MatchId)
                    .Where(s => s.Id < match.Id).OrderBy(s => s.Id).ToList();
                if (sets.Count > 0)
                {
                    tableLayoutPanel2.Visible = true;
                    lblTeam11.Text = lblTeam1.Text;
                    lblTeam21.Text = lblTeam2.Text;
                    for (int i = 0; i < sets.Count; i++)
                    {
                        var set = sets[i];
                        if (i== 0)
                        {
                            lblSet1.Visible=true;
                            lblScore11.Visible = true;
                            lblScore21.Visible = true;
                            lblSet1.Text = set.ClassSetsName;
                            lblScore11.Text = set.Score1.ToString();
                            lblScore21.Text = set.Score2.ToString();
                            continue;
                        }
                        if (i == 1)
                        {
                            lblSet2.Visible = true;
                            lblScore12.Visible = true;
                            lblScore22.Visible = true;
                            lblSet2.Text = set.ClassSetsName;
                            lblScore12.Text = set.Score1.ToString();
                            lblScore22.Text = set.Score2.ToString();
                        }
                        if (i == 2)
                        {
                            lblSet3.Visible = true;
                            lblScore13.Visible = true;
                            lblScore23.Visible = true;
                            lblSet3.Text = set.ClassSetsName;
                            lblScore13.Text = set.Score1.ToString();
                            lblScore23.Text = set.Score2.ToString();
                        }
                        if (i == 3)
                        {
                            lblSet4.Visible = true;
                            lblScore14.Visible = true;
                            lblScore24.Visible = true;
                            lblSet4.Text = set.ClassSetsName;
                            lblScore14.Text = set.Score1.ToString();
                            lblScore24.Text = set.Score2.ToString();
                        }
                        if (i == 4)
                        {
                            lblSet5.Visible = true;
                            lblScore15.Visible = true;
                            lblScore25.Visible = true;
                            lblSet5.Text = set.ClassSetsName;
                            lblScore15.Text = set.Score1.ToString();
                            lblScore25.Text = set.Score2.ToString();
                        }
                    }
                }
                else
                {
                    tableLayoutPanel2.Visible = false;
                }
            } catch 
            { 
            }
        }
        // Vẽ border cho từng cell trong bảng
        private void PnlSetScores_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (Pen pen = new Pen(System.Drawing.Color.Black, 2))
            {
                Rectangle rect = e.CellBounds;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
