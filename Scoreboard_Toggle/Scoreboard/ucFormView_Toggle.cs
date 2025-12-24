using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Scoreboard.Data;
using Scoreboard.Models;

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
            InitTableViewLayout();
            _baseHeight = this.Height;
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
        private int[] _baseRowHeights;
        private int _baseHeight;

        private void InitTableViewLayout()
        {
            tableView.SuspendLayout();

            tableView.AutoSize = false;
            tableView.RowStyles.Clear();

            // Lưu chiều cao gốc (DESIGN)
            _baseRowHeights = new int[]
            {
                150, // Flag VN
                50, // Title
                50, // Time
                50, // Hiệp đấu
                50,  // Team
                50,  //Score
                60,   //Score detail
                40
            };

            tableView.RowCount = _baseRowHeights.Length;

            // Header + footer: Absolute
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[0]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[1]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[2]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[3]));

            // Content chính
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[4]));

            // Footer
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[5]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[6]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[7]));

            tableView.ResumeLayout();
        }
        private void ScaleTableViewRows(float scale)
        {
            tableView.SuspendLayout();

            tableView.RowStyles.Clear();

            for (int i = 0; i < _baseRowHeights.Length; i++)
            {
                if (_baseRowHeights[i] == 0)
                {
                    tableView.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                }
                else
                {
                    tableView.RowStyles.Add(
                        new RowStyle(SizeType.Absolute, _baseRowHeights[i] * scale)
                    );
                }
            }

            tableView.ResumeLayout();
        }
        private void CenterAllLabels(Control parent)
        {
            foreach (Control c in parent.Controls)
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
            if (this.Height <= 0) return;

            float scale = (float)this.Height / _baseHeight;
            scale = Math.Max(0.6f, Math.Min(scale, 1.8f));

            if (Math.Abs(scale - _lastScale) < 0.05f) return;
            _lastScale = scale;

            // 1️⃣ Scale row
            ScaleTableViewRows(scale);

            // 2️⃣ Scale font + flag
            ScaleContent(scale);
        }
        private void ScaleContent(float scale)
        {
            float titleSize = Math.Max(12, Math.Min(32, 16 * scale));
            float normalSize = Math.Max(10, Math.Min(28, 14 * scale));

            lblTitle.Font = new Font("Arial", titleSize + 10, FontStyle.Bold);
            lblTime.Font = new Font("Arial", normalSize + 40, FontStyle.Bold);
            lblHiepDau.Font = new Font("Arial", normalSize, FontStyle.Bold);
            lblTeam1.Font = new Font("Arial", normalSize + 20, FontStyle.Bold);
            lblTeam2.Font = new Font("Arial", normalSize + 20, FontStyle.Bold);
            lblScoreTeam1.Font = new Font("Arial", titleSize + 50, FontStyle.Bold);
            lblScoreTeam2.Font = new Font("Arial", titleSize + 50, FontStyle.Bold);
            lblBonus.Font = new Font("Arial", normalSize, FontStyle.Bold);
            int flagVN = Math.Max(24, Math.Min(120, (int)(40 * scale)));
            int flagTeam = Math.Max(20, Math.Min(100, (int)(30 * scale)));

            pgFlagVN.Size = new Size(flagVN * 8, flagVN * 8);
            pgFlagTeam1.Size = new Size(flagTeam * 8, flagTeam * 8);
            pgFlagTeam2.Size = new Size(flagTeam * 8, flagTeam * 8);

            CenterAllLabels(this);
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
                if (pnlSetScores == null) return;

                bool isSoccer = IsSoccerMatch();
                pnlSetScores.Visible = !isSoccer; // Chỉ hiển thị khi KHÔNG phải bóng đá

                if (isSoccer)
                {
                    pnlSetScores.Controls.Clear();
                    pnlSetScores.ColumnCount = 0;
                    pnlSetScores.RowCount = 0;
                    return;
                }

                // Lấy tất cả các set theo thứ tự Id
                var sets = Repository.GetMatchSetsByMatchId(match.MatchId);
                sets = sets.OrderBy(s => s.Id).ToList();

                if (sets.Count == 0)
                {
                    pnlSetScores.Controls.Clear();
                    pnlSetScores.ColumnCount = 0;
                    pnlSetScores.RowCount = 0;
                    return;
                }

                // Cấu trúc bảng: 2 hàng
                // Cột 0: Tên đội
                // Các cột 1+: Điểm của từng set
                int columnCount = sets.Count + 1; // 1 cột cho tên đội + các cột cho từng set

                pnlSetScores.SuspendLayout();
                pnlSetScores.Controls.Clear();

                // Thiết lập số cột và hàng
                pnlSetScores.ColumnCount = columnCount;
                pnlSetScores.RowCount = 2;

                // Xóa style cột cũ và thêm mới
                pnlSetScores.ColumnStyles.Clear();
                pnlSetScores.RowStyles.Clear();

                // Đặt width auto cho panel
                pnlSetScores.AutoSize = true;
                pnlSetScores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                pnlSetScores.Dock = DockStyle.None;
                pnlSetScores.Anchor = AnchorStyles.None;

                // Tính width tối thiểu cho cột tên đội dựa trên tên dài nhất
                int maxNameWidth = 0;
                using (Graphics g = pnlSetScores.CreateGraphics())
                {
                    Font nameFont = new Font("Arial", 11, FontStyle.Bold);
                    int team1Width = (int)g.MeasureString(match.Team1 ?? "Đội 1", nameFont).Width + 15; // +15 cho padding
                    int team2Width = (int)g.MeasureString(match.Team2 ?? "Đội 2", nameFont).Width + 15;
                    maxNameWidth = Math.Max(team1Width, team2Width);
                }

                // Cột 0: tên đội - Absolute với width đủ cho tên dài nhất
                pnlSetScores.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, maxNameWidth));

                // Các cột điểm set - cố định 20px
                for (int i = 0; i < sets.Count; i++)
                {
                    pnlSetScores.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
                }

                // Tính chiều cao hàng theo font
                int rowHeight = TextRenderer.MeasureText("0", new Font("Arial", 14, FontStyle.Bold)).Height + 8;
                pnlSetScores.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
                pnlSetScores.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

                // Hàng 0, Cột 0: Tên Đội 1 - nền trong suốt, viền trắng
                var lblTeam1 = new Label();
                lblTeam1.Dock = DockStyle.Fill;
                lblTeam1.Margin = new Padding(1);
                lblTeam1.ForeColor = Color.White;
                lblTeam1.BackColor = Color.Transparent;
                lblTeam1.TextAlign = ContentAlignment.MiddleLeft;
                lblTeam1.Font = new Font("Arial", 11, FontStyle.Bold);
                lblTeam1.AutoSize = false;
                lblTeam1.Padding = new Padding(5, 0, 5, 0);
                lblTeam1.Text = match.Team1 ?? "Đội 1";
                lblTeam1.Paint += (s, e) => {
                    using (Pen pen = new Pen(Color.White, 1))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, lblTeam1.Width - 1, lblTeam1.Height - 1);
                    }
                };
                pnlSetScores.Controls.Add(lblTeam1, 0, 0);

                // Hàng 1, Cột 0: Tên Đội 2 - nền trong suốt, viền trắng
                var lblTeam2 = new Label();
                lblTeam2.Dock = DockStyle.Fill;
                lblTeam2.Margin = new Padding(1);
                lblTeam2.ForeColor = Color.White;
                lblTeam2.BackColor = Color.Transparent;
                lblTeam2.TextAlign = ContentAlignment.MiddleLeft;
                lblTeam2.Font = new Font("Arial", 11, FontStyle.Bold);
                lblTeam2.AutoSize = false;
                lblTeam2.Padding = new Padding(5, 0, 5, 0);
                lblTeam2.Text = match.Team2 ?? "Đội 2";
                lblTeam2.Paint += (s, e) => {
                    using (Pen pen = new Pen(Color.White, 1))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, lblTeam2.Width - 1, lblTeam2.Height - 1);
                    }
                };
                pnlSetScores.Controls.Add(lblTeam2, 0, 1);

                // Thêm điểm các set: Hàng 0 (điểm Đội 1), Hàng 1 (điểm Đội 2) - nền trong suốt, viền trắng
                for (int i = 0; i < sets.Count; i++)
                {
                    var set = sets[i];
                    int colIndex = i + 1; // Bắt đầu từ cột 1

                    // Hàng 0: Điểm Đội 1 của set này
                    var lblScore1 = new Label();
                    lblScore1.Dock = DockStyle.Fill;
                    lblScore1.Margin = new Padding(1);
                    lblScore1.ForeColor = Color.White;
                    lblScore1.BackColor = Color.Transparent;
                    lblScore1.TextAlign = ContentAlignment.MiddleCenter;
                    lblScore1.Font = new Font("Arial", 14, FontStyle.Bold);
                    lblScore1.AutoSize = false;
                    lblScore1.Text = set.Score1.ToString();
                    lblScore1.Paint += (s, e) => {
                        using (Pen pen = new Pen(Color.White, 1))
                        {
                            e.Graphics.DrawRectangle(pen, 0, 0, lblScore1.Width - 1, lblScore1.Height - 1);
                        }
                    };
                    pnlSetScores.Controls.Add(lblScore1, colIndex, 0);

                    // Hàng 1: Điểm Đội 2 của set này
                    var lblScore2 = new Label();
                    lblScore2.Dock = DockStyle.Fill;
                    lblScore2.Margin = new Padding(1);
                    lblScore2.ForeColor = Color.White;
                    lblScore2.BackColor = Color.Transparent;
                    lblScore2.TextAlign = ContentAlignment.MiddleCenter;
                    lblScore2.Font = new Font("Arial", 14, FontStyle.Bold);
                    lblScore2.AutoSize = false;
                    lblScore2.Text = set.Score2.ToString();
                    lblScore2.Paint += (s, e) => {
                        using (Pen pen = new Pen(Color.White, 1))
                        {
                            e.Graphics.DrawRectangle(pen, 0, 0, lblScore2.Width - 1, lblScore2.Height - 1);
                        }
                    };
                    pnlSetScores.Controls.Add(lblScore2, colIndex, 1);
                }

                // Đăng ký sự kiện CellPaint để vẽ border cho bảng
                pnlSetScores.CellPaint -= PnlSetScores_CellPaint; // Xóa sự kiện cũ nếu có
                pnlSetScores.CellPaint += PnlSetScores_CellPaint;

                pnlSetScores.ResumeLayout();
            }
            catch
            {
                // ignore UI errors for panel rendering
            }
        }
        // Vẽ border cho từng cell trong bảng
        private void PnlSetScores_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                Rectangle rect = e.CellBounds;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
