using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ClosedXML.Excel;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Scoreboard
{
    public partial class ucFormView_User : UserControl
    {
        private Timer matchTimer;
        private int elapsedMinutes = 0;
        private bool isPaused = true;

        private MatchsetModel match;
        private int scoreTeam1;
        private int scoreTeam2;
        private int TotalscoreTeam1;
        private int TotalscoreTeam2;
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
        public ucFormView_User(MatchsetModel m)
        {
            InitializeComponent();
            this.Padding = new Padding(4);
            this.Resize += MatchUC_Resize;

            InitTimer();
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
            this.Click += (s, e) => this.Focus();

            foreach (Control ctl in this.Controls)
                AttachFocusHandler(ctl);

            match = m;
            lblTitle.Text = m.TournamentName;
            lblHiepDau.Text = m.ClassSetsName;
            lblTeam1.Text = m.Team1;
            lblTeam2.Text = m.Team2;
            lblScoreTeam1.Text = m.TotalScore1.ToString();
            lblScoreTeam2.Text = m.TotalScore2.ToString();
            lblTime.Text = m.Time ?? "00:00";

            TotalscoreTeam1 = m.TotalScore1;
            TotalscoreTeam2 = m.TotalScore2;

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

            scoreTeam1 = m.TotalScore1;
            scoreTeam2 = m.TotalScore2;
        }

        private void AttachFocusHandler(Control ctl)
        {
            ctl.Click += (s, e) => this.Focus();
            foreach (Control child in ctl.Controls)
                AttachFocusHandler(child);
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    if (this.Focused)
        //    {
        //        using (Pen pen = new Pen(Color.Green, 4))
        //        {
        //            Rectangle rect = this.ClientRectangle;
        //            rect.Width -= 1;
        //            rect.Height -= 1;
        //            e.Graphics.DrawRectangle(pen, rect);
        //        }
        //    }
        //}
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
        private void MatchUC_Resize(object sender, EventArgs e)
        {
            float baseSize = Math.Min(this.Width, this.Height) / 25f;
            lblTitle.Font = new Font("Arial", baseSize, FontStyle.Bold);
            lblTime.Font = new Font("Arial", baseSize * 2, FontStyle.Bold);
            lblHiepDau.Font = new Font("Arial", baseSize, FontStyle.Bold);
            lblTeam1.Font = new Font("Arial", baseSize, FontStyle.Bold);
            lblTeam2.Font = new Font("Arial", baseSize, FontStyle.Bold);
            lblScoreTeam1.Font = new Font("Arial", baseSize * 2 + 30, FontStyle.Bold);
            lblScoreTeam2.Font = new Font("Arial", baseSize * 2 + 30, FontStyle.Bold);
            lblBonus.Font = new Font("Arial", baseSize - 10, FontStyle.Bold);
            foreach (Control ctl in this.Controls)
                if (ctl is Label lbl) lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void AddPointTeam1()
        {
            scoreTeam1++;
            UpdateScoreLabel();
            match.TotalScore1 = scoreTeam1;
            match.Score1 = scoreTeam1 - TotalscoreTeam1;
            Repository.UpdateMatchSetScore1(match.MatchId, match.Id, match.Score1);
            Repository.UpdateMatchScore1(match.MatchId, scoreTeam1);
        }

        public void AddPointTeam2()
        {
            scoreTeam2++;
            UpdateScoreLabel();
            match.TotalScore1 = scoreTeam2;
            match.Score2 = scoreTeam2 - TotalscoreTeam2;
            Repository.UpdateMatchSetScore2(match.MatchId, match.Id, match.Score2);
            Repository.UpdateMatchScore2(match.MatchId, scoreTeam2);
        }

        public void ResetScore()
        {
            scoreTeam1 = match.TotalScore1;
            scoreTeam2 = match.TotalScore2;
            UpdateScoreLabel();
        }

        private void UpdateScoreLabel()
        {
            lblScoreTeam1.Text = $"{scoreTeam1}";
            lblScoreTeam2.Text = $"{scoreTeam2}";

        }

        public void UpdateMatchTime(string time)
        {
            lblTime.Text = time;
            Repository.UpdateMatchSetTime(match.MatchId, match.Id, lblTime.Text);
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
                    ws.Cell(row, 4).Value = "Đội 1";
                    ws.Cell(row, 5).Value = "Đội 2";
                    ws.Cell(row, 6).Value = "Score 1";
                    ws.Cell(row, 7).Value = "Score 2";

                    ws.Range(row, 1, row, 7).Style
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
                        if (m.Status == "0")
                        {
                            continue;
                        }
                        ws.Cell(row, 1).Value = m.TournamentName;
                        ws.Cell(row, 2).Value = m.Time ?? "00:00";
                        ws.Cell(row, 3).Value = m.ClassSetsName;
                        ws.Cell(row, 4).Value = $"{m.Team1} ({m.Score1})";
                        ws.Cell(row, 5).Value = $"{m.Team2} ({m.Score2})";
                        ws.Range(row, 1, row, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        row++;
                    }
                    ws.Cell(row, 4).Value = $"{match.Team1} ({match.TotalScore1})";
                    ws.Cell(row, 5).Value = $"{match.Team2} ({match.TotalScore2})";
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
                    Repository.UpdateMatchSetStatus(match.MatchId, match.Id, "2");
                    Repository.UpdateMatchStatus(match.MatchId,"2");
                    MessageBox.Show($"Đã xuất file:\n{sfd.FileName}", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Repository.UpdateMatchSetStatus(match.MatchId, match.Id, "2");

            var next = Repository.GetNextMatchDetail(match.MatchId, match.Id);
            if (next == null)
            {
                MessageBox.Show("Đã hết hiệp đấu!");
                return;
            }

            Repository.UpdateMatchSetStatus(next.MatchId, next.Id, "1");

            match = next;

            lblTitle.Text = match.TournamentName;
            lblHiepDau.Text = match.ClassSetsName;
            lblTeam1.Text = match.Team1;
            lblTeam2.Text = match.Team2;
            lblScoreTeam1.Text = match.TotalScore1.ToString();
            lblScoreTeam2.Text = match.TotalScore2.ToString();
            lblTime.Text = match.Time ?? "00:00";

            if (lblTime.Text != "00:00")
            {
                var parts = lblTime.Text.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int hours) &&
                    int.TryParse(parts[1], out int minutes))
                {
                    elapsedMinutes = hours * 3600 + minutes * 60;
                }
            }
            else
            {
                elapsedMinutes = 0;
            }

            scoreTeam1 = match.TotalScore1;
            scoreTeam2 = match.TotalScore2;
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

        public void StartClock() => isPaused = false;
        public void StopClock() => isPaused = true;

        public void ResetClock()
        {
            elapsedMinutes = 0;
            lblTime.Text = "00:00";
        }

        public MatchsetModel Matchset => match;
    }
}