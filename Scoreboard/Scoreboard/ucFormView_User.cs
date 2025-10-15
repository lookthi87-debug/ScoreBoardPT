using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Scoreboard.Database;

namespace Scoreboard
{
    public partial class ucFormView_User : UserControl
    {
        private Timer matchTimer;
        private int elapsedSeconds = 0;
        private bool isPaused = true;
        private DateTime? startTime = null;
        public int strIdTranDau { get; private set; }
        private int scoreTeam1 { get; set; }
        private int scoreTeam2 { get; set; }
        private MatchModel match { get; set; }
        public ucFormView_User(MatchModel m)
        {
            InitializeComponent();
            this.Padding = new Padding(4); // để lộ viền

            this.Resize += MatchUC_Resize;

            InitTimer();

            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
            this.Click += (s, e) => this.Focus();

            // bắt click của tất cả control con
            foreach (Control ctl in this.Controls)
                AttachFocusHandler(ctl);
            //
            lblTitle.Text= m.Title;
            lblHiepDau.Text=m.SetsName + " " + m.Sets.ToString();
            lblTeam1.Text = m.Team1;
            lblTeam2.Text = m.Team2;
            lblScoreTeam1.Text = m.Score1.ToString();
            lblScoreTeam2.Text = m.Score2.ToString();
            //--------------
            scoreTeam1 = m.Score1;
            scoreTeam2 = m.Score2;
            elapsedSeconds = m.ElapsedSeconds;
            match = m;
        }
        private void AttachFocusHandler(Control ctl)
        {
            ctl.Click += (s, e) => this.Focus();

            // đệ quy cho control con (ví dụ TableLayoutPanel chứa Label)
            foreach (Control child in ctl.Controls)
            {
                AttachFocusHandler(child);
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Invalidate(); // highlight khi được chọn
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.Invalidate(); // bỏ highlight
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Focused)
            {
                using (Pen pen = new Pen(Color.Green, 4)) // viền đỏ, dày 4px
                {
                    Rectangle rect = this.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
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
        }
        //Load title trận đấu
        public void SetTitle(string strTitle)
        {
            lblTitle.Text = strTitle;
        }
        //Load tên hiệp đấu
        public void SetTenHiepDau(string strHiepDau)
        {
            lblHiepDau.Text = strHiepDau;
        }
        //Load tên 2 đội thi đấu
        public void SetTitleDoiDau(string strTeam1, string strTeam2)
        {
            lblTeam1.Text = strTeam1;
            lblTeam2.Text = strTeam2;
        }
        //Set điểm, + điểm khi bấm phím tắt từ màn hình khác
        public void AddPointTeam1()
        {
            scoreTeam1++;
            UpdateScoreLabel();
        }
        public void AddPointTeam2()
        {
            scoreTeam2++;
            UpdateScoreLabel();
        }
        public void ResetScore()
        {
            scoreTeam1 = 0;
            scoreTeam2 = 0;
            UpdateScoreLabel();
        }
        private void UpdateScoreLabel()
        {
            lblScoreTeam1.Text = $"{scoreTeam1}";
            lblScoreTeam2.Text = $"{scoreTeam2}";
        }
        public void LoadScoreFromeDB(int s1, int s2)
        {
            scoreTeam1 = s1;
            scoreTeam2 = s2;
            UpdateScoreLabel();
        }
        private void SaveScoreToDB(int strIdTranDau, int s1, int s2)
        {
            //chưa code
        }
        //Bộ đếm thời gian
        private void InitTimer()
        {
            matchTimer = new Timer();
            matchTimer.Interval = 1000; // 1 giây
            matchTimer.Tick += (s, e) =>
            {
                if (!isPaused)
                {
                    elapsedSeconds++;
                    int minutes = elapsedSeconds / 60;
                    int seconds = elapsedSeconds % 60;
                    lblTime.Text = $"{minutes:D2}:{seconds:D2}";
                    UpdateMatch();
                }
            };
            matchTimer.Start();
        }
        public void StartClock()
        {
            isPaused = false;
        }

        public void StopClock()
        {
            isPaused = true;
        }
        public void ResetClock()
        {
            elapsedSeconds = 0;
            lblTime.Text = "00:00";
        }
        private void UpdateTime()
        {
            if (startTime.HasValue)
            {
                TimeSpan elapsed = DateTime.UtcNow - startTime.Value;
                lblTime.Text = elapsed.ToString(@"hh:mm");
            }
            else
            {
                lblTime.Text = "00:00";
            }
        }
        //Get lại bộ đếm khi bị cúp điện
        public void LoadFormDB(object strValue)
        {
            if (strValue == null || strValue == DBNull.Value)
            {
                startTime = null;
            }
            else if ( strValue is DateTime dt)
            {
                startTime = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
            }
            else
            {
                if (DateTime.TryParse(strValue.ToString(), out var parsed))
                    strValue = DateTime.SpecifyKind(parsed, DateTimeKind.Utc);
                else
                    startTime = null;
            }
            matchTimer.Start();
            UpdateTime();
        }
        //lưu xuống DB
        public void SaveStartTimeToDB(int strIdTranDau, DateTime startUtc)
        {
            //chưa code
        }
        //start khi nhấn phím tắt, phím tắt được bố trí ngoài màn hình main
        public void StartMatch()
        {
            if (!startTime.HasValue)
            {
                startTime = DateTime.UtcNow;
                SaveStartTimeToDB(strIdTranDau, startTime.Value);
                matchTimer.Start();
                UpdateTime();
            }    
        }
        public void SaveState()
        {
            Repository.SaveMatchState(new MatchState
            {
                MatchId = match.Id,
                Score1 = scoreTeam1,
                Score2 = scoreTeam2,
                ElapsedSeconds = elapsedSeconds
            });
        }
        public void UpdateMatch()
        {
            match.Title = lblTitle.Text;
            match.StartTime=lblTime.Text;
            match.Sets =int.Parse( lblHiepDau.Text.Split(' ')[1]);
            match.Score1 = int.Parse(lblScoreTeam1.Text);
            match.Score2 = int.Parse(lblScoreTeam2.Text);
            match.ElapsedSeconds = elapsedSeconds;
            //--------------
            Repository.UpdateMatch(match);
        }
    }
}
