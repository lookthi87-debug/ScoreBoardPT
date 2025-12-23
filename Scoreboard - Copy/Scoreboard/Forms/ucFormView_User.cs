using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Scoreboard.Data;
using Scoreboard.Models;
using Scoreboard.Config;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Scoreboard
{
    public partial class ucFormView_User : UserControl
    {
        private Timer matchTimer;
        private int elapsedMinutes = 0;
        private bool isPaused = true;
        private FlagModel currentFlag;
        private MatchsetModel match;
        private int scoreTeam1;
        private int scoreTeam2;
        private void tableLayoutPanel_BongDa_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (Pen pen = new Pen(System.Drawing.Color.Red, 2))
            {
                Rectangle rect = e.CellBounds;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
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
                42, // Time
                32, // Hiệp đấu
                80,  // Team
                100,  //Score
                80,   //Score detail
                60
            };

            tableView.RowCount = _baseRowHeights.Length;

            // Header + footer: Absolute
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[0]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[1]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[2]));
            tableView.RowStyles.Add(new RowStyle(SizeType.Absolute, _baseRowHeights[3]));

            // Content chính
            tableView.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

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
        public ucFormView_User(MatchsetModel m)
        {
            InitializeComponent();
            InitTableViewLayout();
            _baseHeight = this.Height;

            this.Padding = new Padding(4);
            this.Resize += MatchUC_Resize;

            InitTimer();
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
            this.Click += (s, e) => this.Focus();

            foreach (Control ctl in this.Controls)
                AttachFocusHandler(ctl);

            // Đảm bảo control có thể nhận được focus
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
            this.Focus();
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

            // Khởi tạo điểm số của hiệp/set hiện tại
            scoreTeam1 = m.Score1;
            scoreTeam2 = m.Score2;

            if (lblTime.Text != "00:00")
            {
                var parts = lblTime.Text.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int hours) &&
                    int.TryParse(parts[1], out int minutes))
                {
                    elapsedMinutes = hours * 60 + minutes;
                }
            }
            else
            {
                elapsedMinutes = 0;
            }

            LoadFlagImagesTeams(m);
            // Khởi tạo bảng điểm các set cho các bộ môn không phải bóng đá
            //UpdateSetScoresPanel();
        }

        private void AttachFocusHandler(Control ctl)
        {
            ctl.Click += (s, e) => this.Focus();
            foreach (Control child in ctl.Controls)
                AttachFocusHandler(child);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Nếu đang được focus thì viền xanh, ngược lại viền đỏ
            Color borderColor = this.Focused ? Color.LimeGreen : Color.DarkRed;
            int borderWidth = this.Focused ? 4 : 2;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate(); // vẽ lại khi được chọn
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate(); // vẽ lại khi mất chọn
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
            lblTime.Font = new Font("Arial", normalSize + 20, FontStyle.Bold);
            lblHiepDau.Font = new Font("Arial", normalSize, FontStyle.Bold);
            lblTeam1.Font = new Font("Arial", normalSize + 20, FontStyle.Bold);
            lblTeam2.Font = new Font("Arial", normalSize + 20, FontStyle.Bold);
            lblScoreTeam1.Font = new Font("Arial", titleSize + 60, FontStyle.Bold);
            lblScoreTeam2.Font = new Font("Arial", titleSize + 60, FontStyle.Bold);

            int flagVN = Math.Max(24, Math.Min(120, (int)(40 * scale)));
            int flagTeam = Math.Max(20, Math.Min(100, (int)(30 * scale)));

            pgFlagVN.Size = new Size(flagVN * 8, flagVN * 8);
            pgFlagTeam1.Size = new Size(flagTeam * 8, flagTeam * 8);
            pgFlagTeam2.Size = new Size(flagTeam * 8, flagTeam * 8);

            CenterAllLabels(this);
        }
        public void AddPointTeam1()
        {
            try
            {
                // Chỉ cho phép cộng điểm khi đồng hồ đang chạy
                if (isPaused)
                {
                    MessageBox.Show("Vui lòng bắt đầu đồng hồ trước khi cộng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn cộng 1 điểm cho {match.Team1}?",
                    "Xác nhận cộng điểm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return; // Người dùng chọn Không, không cộng điểm
                }

                // Tăng điểm của hiệp/set hiện tại
                scoreTeam1++;

                // Cập nhật điểm của hiệp/set hiện tại vào đối tượng trận đấu
                match.Score1 = scoreTeam1;

                // Lưu vào cơ sở dữ liệu trước
                Repository.UpdateMatchSetScore1(match.MatchId, match.Id, match.Score1);

                // Tính tổng điểm từ cơ sở dữ liệu (tổng tất cả các hiệp/set cùng match_id)
                if (IsSoccerMatch())
                {
                    var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);
                    if (allPeriods.Count <= 4)
                    {
                        Repository.UpdateMatchScore1(match.MatchId, CalculateTotalScore1());
                    }
                }
                // Cập nhật giao diện
                UpdateScoreLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong AddPointTeam1: {ex.Message}\n\nStack: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddPointTeam2()
        {
            try
            {
                // Chỉ cho phép cộng điểm khi đồng hồ đang chạy
                if (isPaused)
                {
                    MessageBox.Show("Vui lòng bắt đầu đồng hồ trước khi cộng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn cộng 1 điểm cho {match.Team2}?",
                    "Xác nhận cộng điểm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return; // Người dùng chọn Không, không cộng điểm
                }

                // Tăng điểm của hiệp/set hiện tại
                scoreTeam2++;

                // Cập nhật điểm của hiệp/set hiện tại vào đối tượng trận đấu
                match.Score2 = scoreTeam2;

                // Lưu vào cơ sở dữ liệu trước
                Repository.UpdateMatchSetScore2(match.MatchId, match.Id, match.Score2);

                // Tính tổng điểm từ cơ sở dữ liệu (tổng tất cả các hiệp/set cùng match_id)
                if (IsSoccerMatch())
                {
                    var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);
                    if (allPeriods.Count <= 2)
                    {
                        Repository.UpdateMatchScore2(match.MatchId, CalculateTotalScore2());
                    }
                }
                // Cập nhật giao diện
                UpdateScoreLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong AddPointTeam2: {ex.Message}\n\nStack: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResetScore()
        {
            // Đặt lại điểm của hiệp/set hiện tại về 0
            scoreTeam1 = 0;
            scoreTeam2 = 0;

            // Cập nhật đối tượng trận đấu
            match.Score1 = 0;
            match.Score2 = 0;

            // Tính lại tổng điểm
            match.TotalScore1 = CalculateTotalScore1();
            match.TotalScore2 = CalculateTotalScore2();

            // Cập nhật cơ sở dữ liệu
            Repository.UpdateMatchSetScore1(match.MatchId, match.Id, 0);
            Repository.UpdateMatchSetScore2(match.MatchId, match.Id, 0);

            UpdateScoreLabel();
        }


        private int CalculateTotalScore1()
        {
            if (IsSoccerMatch())
            {
                // Lấy tất cả các hiệp/set của trận đấu từ cơ sở dữ liệu
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);
                allPeriods = allPeriods.Where(m => !m.ClassSetsName.Contains("Penalty")).ToList();
                // Cộng dồn toàn bộ Score1 của tất cả hiệp/set cùng match_id
                int totalScore = 0;
                foreach (var period in allPeriods)
                {
                    totalScore += period.Score1;
                }

                return totalScore;
            } else
            {
                var matchQuery = Repository.GetMatchById(match.MatchId);
                return matchQuery.Score1;
            }
        }

        private int CalculateTotalScore2()
        {
            if (IsSoccerMatch())
            {
                // Lấy tất cả các hiệp/set của trận đấu từ cơ sở dữ liệu
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);
                allPeriods = allPeriods.Where(m => !m.ClassSetsName.Contains("Penalty")).ToList();
                // Cộng dồn toàn bộ Score2 của tất cả hiệp/set cùng match_id
                int totalScore = 0;
                foreach (var period in allPeriods)
                {
                    totalScore += period.Score2;
                }

                return totalScore;
            }
            else
            {
                var matchQuery = Repository.GetMatchById(match.MatchId);
                return matchQuery.Score2;
            }
        }

        private void UpdateScoreLabel()
        {

            if (IsSoccerMatch())
            {
                var list = Repository.GetMatchSetsByMatchId(match.MatchId);
                if (list.Count == 5) // check nếu là penalty thì reset về 0 UI
                {
                    var matchPen = list.SingleOrDefault(m => m.ClassSetsName.Contains("Penalty"));
                    lblScoreTeam1.Text = matchPen.Score1.ToString();
                    lblScoreTeam2.Text = matchPen.Score2.ToString();
                } else
                {
                    // Hiển thị tổng điểm (tổng của tất cả hiệp/set)
                    lblScoreTeam1.Text = list.Sum(x => x.Score1).ToString();
                    lblScoreTeam2.Text = list.Sum(x => x.Score2).ToString();
                }
            }
            else
            {
                var data = Repository.GetMatchSetByMatchAndId(match.MatchId, match.Id);
                lblScoreTeam1.Text = data.Score1.ToString();
                lblScoreTeam2.Text = data.Score2.ToString();
            }

           // // Làm mới bảng điểm các set cho môn không phải bóng đá
            UpdateSetScoresPanel();
        }

        public void UpdateMatchTime(string time)
        {
            lblTime.Text = time;
            Repository.UpdateMatchSetTime(match.MatchId, match.Id, lblTime.Text);
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
        
        public void ExportMatchToExcel(MatchsetModel match)
        {
            try
            {
                // Kiểm tra null
                if (match == null)
                {
                    MessageBox.Show("Không có dữ liệu trận đấu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DialogResult rs = MessageBox.Show("Đã kết thúc trận đấu! Bạn muốn xuất excel phải không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.No)
                    {
                        return;
                    }
                }

                // Tạo workbook
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Kết quả trận đấu");

                    // Format cơ bản
                    ws.Style.Font.FontName = "Arial";
                    ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                    int row = 1;

                    // Dòng 1: Tiêu đề giải đấu
                    ws.Cell(row, 1).Value = $"Giải đấu {match.TournamentName}";
                    ws.Range(row, 1, row, 5).Merge().Style
                        .Font.SetBold()
                        .Font.SetFontSize(18)
                        .Font.SetFontColor(XLColor.Black);
                    ws.Row(row).Height = 25;
                    row += 2;

                    // Dòng 3: Thông tin tổng quan
                    ws.Cell(row, 1).Value = $"Trận đấu: {match.Team1} - {match.Team2}";
                    ws.Range(row, 1, row, 5).Merge().Style.Font.SetFontSize(14);
                    row++;

                    ws.Cell(row, 1).Value = $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    ws.Range(row, 1, row, 5).Merge();
                    row += 2;

                    // Dòng 5: Header (các cột)
                    ws.Cell(row, 1).Value = "Giải đấu";
                    ws.Cell(row, 2).Value = "Thời gian";
                    ws.Cell(row, 3).Value = "Set";
                    ws.Cell(row, 4).Value = match.Team1;
                    ws.Cell(row, 5).Value = match.Team2;

                    ws.Range(row, 1, row, 5).Style
                        .Font.SetBold()
                        .Font.SetFontSize(12)
                        .Fill.SetBackgroundColor(XLColor.LightGray)
                        .Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;

                    // Dòng dữ liệu (ví dụ: 1 trận duy nhất)
                    List<MatchsetModel> mdl = Repository.GetMatchSetsByMatchId(match.MatchId);
                    for (int i = 0; i < mdl.Count; i++)
                    {
                        MatchsetModel m = mdl[i];
                        if (m.Status == MatchStatusConfig.Status.NotStarted)
                        {
                            continue;
                        }
                        ws.Cell(row, 1).Value = m.TournamentName;
                        ws.Cell(row, 2).Value = m.Time ?? "00:00";
                        ws.Cell(row, 3).Value = m.ClassSetsName;
                        ws.Cell(row, 4).Value = m.Score1;
                        ws.Cell(row, 5).Value = m.Score2;
                        ws.Range(row, 1, row, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        row++;
                    }
                    ws.Cell(row, 4).Value = match.TotalScore1;
                    ws.Cell(row, 4).Style.Font.SetBold();
                    ws.Cell(row, 4).Style.Font.FontColor = XLColor.Red;
                    ws.Cell(row, 5).Value = match.TotalScore2;
                    ws.Cell(row, 5).Style.Font.SetBold();
                    ws.Cell(row, 5).Style.Font.FontColor = XLColor.Red;
                    ws.Range(row, 1, row, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row++;

                    // Tự căn chỉnh
                    ws.Columns().AdjustToContents();

                    // Tên file: yyyyMMdd_Tournament_Team1_Team2.xlsx
                    string safeTournament = RemoveInvalidFileChars(match.TournamentName);
                    string safeTeam1 = RemoveInvalidFileChars(match.Team1);
                    string safeTeam2 = RemoveInvalidFileChars(match.Team2);
                    string fileName = $"{DateTime.Now:yyyyMMdd}_{safeTournament}_{safeTeam1}_{safeTeam2}.xlsx";

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.Title = "Chọn nơi lưu file Excel";
                    sfd.FileName = fileName;

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    wb.SaveAs(sfd.FileName);
                    Repository.UpdateMatchSetStatus(match.MatchId, match.Id, MatchStatusConfig.Status.Finished);
                    Repository.UpdateMatchStatus(match.MatchId, MatchStatusConfig.Status.Finished);
                    MessageBox.Show($"Đã xuất file:\n{sfd.FileName}", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    wb.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RemoveInvalidFileChars(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name;
        }
        public void NextSet()
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult resultConfirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn tăng set đấu?",
                "Xác nhận tăng set đấu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultConfirm != DialogResult.Yes)
            {
                return;
            }
            try
            {
                // Đánh dấu hiệp/set hiện tại đã kết thúc
                Repository.UpdateMatchSetStatus(match.MatchId, match.Id, MatchStatusConfig.Status.Finished);

                // Cập nhật điểm tổng cho trận
                UpdateScoreMatch(match.MatchId, match.Id);

                // Kiểm tra có cần hỏi tạo hiệp phụ hay không
                if (ShouldAskForOvertime())
                {
                    var result = MessageBox.Show("Kết quả hiện tại đang hòa.\nBạn có muốn tạo hiệp phụ không?",
                                               "Xác nhận tạo hiệp phụ",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        // Kết thúc trận mà không tạo hiệp phụ
                        Repository.UpdateMatchStatus(match.MatchId, MatchStatusConfig.Status.Finished);
                        MessageBox.Show("Trận đấu kết thúc với kết quả hòa!");
                        return;
                    }
                    else
                    {
                        Repository.UpdateMatchStatus(match.MatchId, MatchStatusConfig.Status.InProgress);
                    }
                }

                // Thử lấy hiệp/set kế tiếp đã tồn tại trước
                var next = Repository.GetNextMatchDetail(match.MatchId, match.Id);
                if (next == null)
                {
                    // Kiểm tra kết quả trước khi tạo hiệp/set mới
                    if (!IsCreateNewMatchSet())
                    {
                        // Hiển thị kết quả cho các bộ môn khác ngoài bóng đá
                        ShowMatchResult();
                        return;
                    }
                    // Không có hiệp/set kế tiếp, tạo mới
                    next = CreateNextPeriod();
                    if (next == null)
                    {
                        // Đánh dấu trận đấu đã kết thúc
                        ShowMatchResult();
                        return;
                    }
                }

                // Kích hoạt hiệp/set kế tiếp
                Repository.UpdateMatchSetStatus(next.MatchId, next.Id, MatchStatusConfig.Status.InProgress);

                // Sử dụng trực tiếp hiệp/set kế tiếp
                match = next;

                // Đặt lại điểm hiệp/set hiện tại về 0 (bắt đầu hiệp/set mới)
                scoreTeam1 = 0;
                scoreTeam2 = 0;

                // Cập nhật đối tượng trận đấu với điểm hiệp/set hiện tại
                match.Score1 = 0;
                match.Score2 = 0;

                // Lưu điểm hiệp/set mới vào cơ sở dữ liệu (0-0)
                Repository.UpdateMatchSetScore1(match.MatchId, match.Id, 0);
                Repository.UpdateMatchSetScore2(match.MatchId, match.Id, 0);

                // Tính toán và cập nhật tổng điểm từ cơ sở dữ liệu
                match.TotalScore1 = CalculateTotalScore1();
                match.TotalScore2 = CalculateTotalScore2();

                // Buộc cập nhật giao diện
                UpdateUI();

                if (lblTime.Text != "00:00")
                {
                    var parts = lblTime.Text.Split(':');
                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int hours) &&
                        int.TryParse(parts[1], out int minutes))
                    {
                        elapsedMinutes = hours * 60 + minutes;
                    }
                }
                else
                {
                    elapsedMinutes = 0;
                }

            }
            catch
            {
                // Bỏ qua lỗi im lặng
            }
        }

        private MatchsetModel CreateNextPeriod()
        {
            try
            {
                // Lấy thông tin lớp môn thi đấu để xác định quy tắc hiệp/set
                var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);
                if (matchClass == null)
                {
                    return null;
                }

                // Lấy tất cả các hiệp/set của trận
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

                // Xác định hiệp/set tiếp theo dựa trên quy tắc của môn
                string nextPeriodName = DetermineNextPeriodName(allPeriods, matchClass);

                if (string.IsNullOrEmpty(nextPeriodName))
                {
                    return null; // Không còn hiệp/set nào được phép
                }


                // Tạo hiệp/set mới
                var newSet = new MatchsetModel
                {
                    MatchId = match.MatchId,
                    Team1 = match.Team1,
                    Team2 = match.Team2,
                    Score1 = 0,
                    Score2 = 0,
                    Time = "00:00",
                    Note = "",
                    Status = MatchStatusConfig.Status.NotStarted, // Ban đầu chưa hoạt động
                    RefereeId = match.RefereeId,
                    RefereeName = match.RefereeName,
                    ClassSetsName = nextPeriodName, // Sử dụng tên hiệp/set đã xác định
                    TournamentId = match.TournamentId,
                    TournamentName = match.TournamentName,
                    MatchClassId = match.MatchClassId,
                    MatchClassName = match.MatchClassName
                };

                // Thêm vào cơ sở dữ liệu
                Repository.AddMatchSet(newSet);

                // Chờ một chút để cơ sở dữ liệu cập nhật
                System.Threading.Thread.Sleep(100);

                // Lấy lại tất cả hiệp/set để tìm hiệp/set vừa tạo
                var updatedPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

                // Thử tìm hiệp/set vừa tạo theo tên
                var createdSet = updatedPeriods.FirstOrDefault(s => s.ClassSetsName == nextPeriodName);

                if (createdSet == null)
                {
                    // Nếu không tìm thấy theo tên, lấy hiệp/set có Id mới nhất
                    createdSet = updatedPeriods.OrderByDescending(s => s.Id).FirstOrDefault();
                }

                return createdSet;
            }
            catch
            {
                return null;
            }
        }

        private string DetermineNextPeriodName(List<MatchsetModel> allPeriods, MatchClassModel matchClass)
        {
            // Determine next period based on match class rules
            switch (matchClass.PeriodType?.ToLower())
            {
                case "half": // Football/Soccer - Use complex logic with period classification
                    return DetermineFootballNextPeriod(allPeriods, matchClass);

                default: // All other sports - Simple increment
                    return DetermineSimpleNextPeriod(allPeriods, matchClass);
            }
        }

        private string DetermineFootballNextPeriod(List<MatchsetModel> allPeriods, MatchClassModel matchClass)
        {
            // Count different types of periods ONLY for football
            var regularPeriods = allPeriods.Where(p => p.ClassSetsName?.StartsWith("Hiệp ") == true && !p.ClassSetsName.Contains("phụ") && !p.ClassSetsName.Contains("Penalty")).ToList();
            var overtimePeriods = allPeriods.Where(p => p.ClassSetsName?.Contains("phụ") == true).ToList();
            var penaltyPeriods = allPeriods.Where(p => p.ClassSetsName?.Contains("Penalty") == true || p.ClassSetsName?.Contains("Pen") == true).ToList();

            // Check điểm của 2 hiệp chính
            int team1Score = regularPeriods.Sum(m => m.Score1);
            int team2Score = regularPeriods.Sum(m => m.Score2);
            bool isTied = team1Score == team2Score;

            // Standard football: 2 regular periods
            if (regularPeriods.Count < matchClass.StandardPeriods)
            {
                return $"Hiệp {regularPeriods.Count + 1}";
            }

            // After 2 regular periods, check if someone won
            if (!isTied)
            {
                // Someone won, show result and end match
                ShowMatchResult();
                return null; // No more periods
            }

            // If tied after regular periods, check if overtime is allowed
            if (isTied && matchClass.AllowOvertime && overtimePeriods.Count < matchClass.MaxOvertimePeriods)
            {
                return $"Hiệp phụ {overtimePeriods.Count + 1}";
            }

            // After overtime, if still tied, go to penalty
            if (isTied && matchClass.AllowOvertime && overtimePeriods.Count >= matchClass.MaxOvertimePeriods && penaltyPeriods.Count == 0 && CalculateTotalScore1() == CalculateTotalScore2())
            {
                return "Penalty";
            }

            // No more periods allowed
            return null;
        }

        private string DetermineSimpleNextPeriod(List<MatchsetModel> allPeriods, MatchClassModel matchClass)
        {
            // For all non-football sports: Simple increment (Set 1 -> Set 2 -> Set 3...)
            // Just count all existing periods without complex classification
            int currentPeriodCount = allPeriods.Count;

            // Check if we've reached the maximum allowed periods
            if (currentPeriodCount >= matchClass.StandardPeriods)
            {
                return null; // No more periods allowed
            }

            // Return next period name based on PeriodType
            switch (matchClass.PeriodType?.ToLower())
            {
                case "set":
                    return $"Set {currentPeriodCount + 1}";
                case "quarter":
                    return $"Hiệp nhỏ {currentPeriodCount + 1}";
                default:
                    return $"Hiệp {currentPeriodCount + 1}";
            }
        }

        private void ShowMatchResult()
        {
            try
            {
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);
                var matchPen = allPeriods.FirstOrDefault(m => m.ClassSetsName.Contains("Penalty"));
                int team1Score = CalculateTotalScore1();
                int team2Score = CalculateTotalScore2();
                int team1ScorePen = 0;
                int team2ScorePen = 0;
                string winner = "";
                string resultMessage = "";
                string resultPen = "";
                if (matchPen != null)
                {
                    team1ScorePen = matchPen.Score1;
                    team2ScorePen = matchPen.Score2;
                    resultPen = $"({team1ScorePen} - {team2ScorePen})\n";
                }

                if (team1Score + team1ScorePen > team2Score + team2ScorePen)
                {
                    winner = match.Team1;
                    resultMessage = $"🏆 {match.Team1} THẮNG!\n\n" +
                                  $"Tỉ số: {match.Team1} {team1Score} - {team2Score} {match.Team2} {resultPen}\n" +
                                  $"Trận đấu kết thúc!";
                }
                else if (team2Score + team2ScorePen > team1Score + team1ScorePen)
                {
                    winner = match.Team2;
                    resultMessage = $"🏆 {match.Team2} THẮNG!\n\n" +
                                  $"Tỉ số: {match.Team1} {team1Score} - {team2Score} {match.Team2} {resultPen}\n" +
                                  $"Trận đấu kết thúc!";
                }
                else
                {
                    resultMessage = $"🤝 HÒA!\n\n" +
                                  $"Tỉ số: {match.Team1} {team1Score} - {team2Score} {match.Team2}\n" +
                                  $"Trận đấu kết thúc!";
                }

                MessageBox.Show(resultMessage, "Kết quả trận đấu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lấy tất cả các set thi đấu set status = 2 "Đã kết thúc"
                Repository.UpdateMatchStatus(match.MatchId, MatchStatusConfig.Status.Finished);
                foreach (var period in allPeriods)
                {
                    Repository.UpdateMatchSetStatus(period.MatchId, period.Id, MatchStatusConfig.Status.Finished); // Finished
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị kết quả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUI()
        {
            try
            {
                if (match == null)
                {
                    return;
                }
                var matchSet = Repository.GetMatchClassById((int)match.MatchClassId);
                // Cập nhật các thành phần giao diện
                lblTitle.Text = match.TournamentName ?? "";
                lblHiepDau.Text = match.ClassSetsName ?? "";
                lblTeam1.Text = match.Team1 ?? "";
                lblTeam2.Text = match.Team2 ?? "";
                UpdateScoreLabel();
                lblTime.Text = match.Time ?? "00:00";

                // Buộc làm mới giao diện
                this.Invalidate();
                this.Update();

            }
            catch
            {
                // Bỏ qua lỗi im lặng
            }
        }


        private void InitTimer()
        {
            if (matchTimer == null)
            {
                matchTimer = new Timer();
                matchTimer.Interval = 1000;
                matchTimer.Tick += (s, e) =>
                {
                    if (!isPaused)
                    {
                        elapsedMinutes++;
                        int hours = elapsedMinutes / 60;
                        int minutes = elapsedMinutes % 60;
                        lblTime.Text = $"{hours:D2}:{minutes:D2}";
                        Repository.UpdateMatchSetTime(match.MatchId, match.Id, lblTime.Text);
                    }
                };
            }
            matchTimer.Start();
        }

        public void StartClock()
        {
            var currentMatch = Repository.GetMatchById(match.MatchId);
            if (currentMatch.Start == null)
            {
                Repository.StartMatch(match.MatchId);
            }
            if (isPaused == true)
            {
                isPaused = false;
                Repository.StartMatchSet(match.MatchId, match.Id);
            }
        }
        public void StopClock()
        {
            var matchSet = Repository.GetMatchSetByMatchAndId(match.MatchId, match.Id);
            if (isPaused == false)
            {
                isPaused = true;
                Repository.EndMatchSet(match.MatchId, match.Id);
            }
        }

        public void ResetClock()
        {
            elapsedMinutes = 0;
            lblTime.Text = "00:00";
        }

        public MatchsetModel Matchset => match;

        private bool ShouldAskForOvertime()
        {
            try
            {
                // Check if this is football (half periods)
                var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);
                if (matchClass == null || !IsSoccerMatch())
                {
                    return false; // Not football, no overtime logic
                }

                // Get all periods for this match
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

                // Count regular periods (Hiệp 1, Hiệp 2)
                var regularPeriods = allPeriods.Where(p =>
                    p.ClassSetsName?.StartsWith("Hiệp ") == true &&
                    !p.ClassSetsName.Contains("phụ") &&
                    !p.ClassSetsName.Contains("Penalty")).ToList();

                // Check if we're finishing the second regular period
                if (regularPeriods.Count == 2)
                {
                    // Check if current period is "Hiệp 2"
                    bool isSecondHalf = match.ClassSetsName?.Contains("Hiệp 2") == true;

                    if (isSecondHalf)
                    {
                        // Check if scores are tied
                        int team1TotalScore = CalculateTotalScore1();
                        int team2TotalScore = CalculateTotalScore2();

                        return team1TotalScore == team2TotalScore;
                    }
                }

                return false;
            }
            catch
            {
                // If any error occurs, don't show overtime dialog
                return false;
            }
        }

        public void UpdateScoreMatch(string matchId, int idMatchset)
        {
            var match = Repository.GetMatchById(matchId);
            var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);
            var matchSet = Repository.GetMatchSetByMatchAndId(matchId, idMatchset);
            if (!IsSoccerMatch())
            {
                // check xem đội nào có điểm số WIN trước
                if ((match.Score1 == matchClass.PeriodsToWin) || (match.Score2 == matchClass.PeriodsToWin)) return;
                if (matchSet.Score1 > matchSet.Score2)
                {
                    // Update match totals in database
                    Repository.UpdateMatchScore1(matchId, match.Score1 + 1);
                }
                if (matchSet.Score1 < matchSet.Score2)
                {
                    // Update match totals in database
                    Repository.UpdateMatchScore2(matchId, match.Score2 + 1);
                }
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
        public bool IsCreateNewMatchSet()
        {
            var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);
            var matchQuery = Repository.GetMatchById(match.MatchId);
            if ((matchQuery.Score1 >= matchClass.PeriodsToWin || matchQuery.Score2 >= matchClass.PeriodsToWin) && !IsSoccerMatch())
            {
                return false;
            } else
                return true;
        }
        private void LoadFlagImagesVN()
        {
            try
            {
                currentFlag = new FlagModel();
                currentFlag = Repository.GetFlag();
                if (currentFlag.Flag != null)
                {
                    tblFlagVN.Visible = true;
                    using (var ms = new MemoryStream(currentFlag.Flag))
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
    }
}