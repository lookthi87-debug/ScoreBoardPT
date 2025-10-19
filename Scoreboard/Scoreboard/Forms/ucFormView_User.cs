using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using Scoreboard.Data;
using Scoreboard.Models;

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

            // Ensure this control can receive focus
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
            this.Focus();

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

            // Initialize current period scores
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
            foreach (Control ctl in this.Controls)
                if (ctl is Label lbl) lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void AddPointTeam1()
        {
            try
            {
                // Only allow adding points when clock is running
                if (isPaused)
                {
                    MessageBox.Show("Vui lòng bắt đầu đồng hồ trước khi cộng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Increment current period score
                scoreTeam1++;

                // Update current period score in match object
                match.Score1 = scoreTeam1;

                // Save to database first
                Repository.UpdateMatchSetScore1(match.MatchId, match.Id, match.Score1);

                // Calculate total score from database (sum of all periods with same match_id)
                match.TotalScore1 = CalculateTotalScore1();
                TotalscoreTeam1 = match.TotalScore1;

                // Update UI
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
                // Only allow adding points when clock is running
                if (isPaused)
                {
                    MessageBox.Show("Vui lòng bắt đầu đồng hồ trước khi cộng điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Increment current period score
                scoreTeam2++;

                // Update current period score in match object
                match.Score2 = scoreTeam2;

                // Save to database first
                Repository.UpdateMatchSetScore2(match.MatchId, match.Id, match.Score2);

                // Calculate total score from database (sum of all periods with same match_id)
                match.TotalScore2 = CalculateTotalScore2();
                TotalscoreTeam2 = match.TotalScore2;

                // Update UI
                UpdateScoreLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong AddPointTeam2: {ex.Message}\n\nStack: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResetScore()
        {
            // Reset current period scores to 0
            scoreTeam1 = 0;
            scoreTeam2 = 0;

            // Update match object
            match.Score1 = 0;
            match.Score2 = 0;

            // Recalculate total scores
            match.TotalScore1 = CalculateTotalScore1();
            match.TotalScore2 = CalculateTotalScore2();
            TotalscoreTeam1 = match.TotalScore1;
            TotalscoreTeam2 = match.TotalScore2;

            // Update database
            Repository.UpdateMatchSetScore1(match.MatchId, match.Id, 0);
            Repository.UpdateMatchSetScore2(match.MatchId, match.Id, 0);
            Repository.UpdateMatchScore1(match.MatchId, match.TotalScore1);
            Repository.UpdateMatchScore2(match.MatchId, match.TotalScore2);

            UpdateScoreLabel();
        }


        private int CalculateTotalScore1()
        {
            // Get all periods for this match from database
            var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

            // Sum up all score1 from all periods with same match_id
            int totalScore = 0;
            foreach (var period in allPeriods)
            {
                totalScore += period.Score1;
            }

            return totalScore;
        }

        private int CalculateTotalScore2()
        {
            // Get all periods for this match from database
            var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

            // Sum up all score2 from all periods with same match_id
            int totalScore = 0;
            foreach (var period in allPeriods)
            {
                totalScore += period.Score2;
            }

            return totalScore;
        }

        private void UpdateScoreLabel()
        {
            var list = Repository.GetMatchSetsByMatchId(match.MatchId);
            // Display total scores (sum of all periods)
            lblScoreTeam1.Text = list.Sum(x => x.Score1).ToString();
            lblScoreTeam2.Text = list.Sum(x => x.Score2).ToString();
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
                    Repository.UpdateMatchStatus(match.MatchId, "2");
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
            try
            {
                // Mark current set as finished
                Repository.UpdateMatchSetStatus(match.MatchId, match.Id, "2");
                // Try to get next existing period first
                var next = Repository.GetNextMatchDetail(match.MatchId, match.Id);

                if (next == null)
                {
                    // No next period exists, create a new one
                    next = CreateNextPeriod();
                    if (next == null)
                    {
                        MessageBox.Show("Không thể tạo hiệp mới!");
                        return;
                    }
                }

                // Activate next period
                Repository.UpdateMatchSetStatus(next.MatchId, next.Id, "1");

                // Use the next period directly
                match = next;

                // Reset current period scores to 0 (new period starts)
                scoreTeam1 = 0;
                scoreTeam2 = 0;

                // Update match object with current period scores
                match.Score1 = 0;
                match.Score2 = 0;

                // Save new period scores to database (0-0)
                Repository.UpdateMatchSetScore1(match.MatchId, match.Id, 0);
                Repository.UpdateMatchSetScore2(match.MatchId, match.Id, 0);

                // Calculate and update total scores from database
                match.TotalScore1 = CalculateTotalScore1();
                match.TotalScore2 = CalculateTotalScore2();
                TotalscoreTeam1 = match.TotalScore1;
                TotalscoreTeam2 = match.TotalScore2;

                // Update match totals in database
                Repository.UpdateMatchScore1(match.MatchId, match.TotalScore1);
                Repository.UpdateMatchScore2(match.MatchId, match.TotalScore2);

                UpdateScoreLabel();

                // Force UI update
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
            catch (Exception ex)
            {
                // Silent error handling
            }
        }

        private MatchsetModel CreateNextPeriod()
        {
            try
            {
                // Get match class info to determine period rules
                var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);
                if (matchClass == null)
                {
                    return null;
                }

                // Get all periods for this match
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

                // Determine next period based on match class rules
                string nextPeriodName = DetermineNextPeriodName(allPeriods, matchClass);

                if (string.IsNullOrEmpty(nextPeriodName))
                {
                    return null; // No more periods allowed
                }


                // Create new matchset
                var newSet = new MatchsetModel
                {
                    MatchId = match.MatchId,
                    Team1 = match.Team1,
                    Team2 = match.Team2,
                    Score1 = 0,
                    Score2 = 0,
                    Time = "00:00",
                    Note = "",
                    Status = "0", // Inactive initially
                    RefereeId = match.RefereeId,
                    RefereeName = match.RefereeName,
                    ClassSets_Id = match.ClassSets_Id, // Keep same ClassSets_Id as current period
                    ClassSetsName = nextPeriodName, // Use the determined period name
                    TournamentId = match.TournamentId,
                    TournamentName = match.TournamentName,
                    MatchClassId = match.MatchClassId,
                    MatchClassName = match.MatchClassName
                };

                // Add to database
                Repository.AddMatchSet(newSet);

                // Wait a moment for database to update
                System.Threading.Thread.Sleep(100);

                // Get all periods again to find the newly created one
                var updatedPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);

                // Try to find the newly created set by name
                var createdSet = updatedPeriods.FirstOrDefault(s => s.ClassSetsName == nextPeriodName);

                if (createdSet == null)
                {
                    // If not found by name, try to get the last created period
                    createdSet = updatedPeriods.OrderByDescending(s => s.Id).FirstOrDefault();
                }

                return createdSet;
            }
            catch (Exception ex)
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
            var regularPeriods = allPeriods.Where(p => p.ClassSetsName?.StartsWith("Hiệp ") == true && !p.ClassSetsName.Contains("phụ") && !p.ClassSetsName.Contains("penalty")).ToList();
            var overtimePeriods = allPeriods.Where(p => p.ClassSetsName?.Contains("phụ") == true).ToList();
            var penaltyPeriods = allPeriods.Where(p => p.ClassSetsName?.Contains("penalty") == true || p.ClassSetsName?.Contains("pen") == true).ToList();

            // Get current scores
            int team1Score = match.TotalScore1;
            int team2Score = match.TotalScore2;
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
            if (isTied && matchClass.AllowOvertime && overtimePeriods.Count >= matchClass.MaxOvertimePeriods && penaltyPeriods.Count == 0)
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
                int team1Score = match.TotalScore1;
                int team2Score = match.TotalScore2;

                string winner = "";
                string resultMessage = "";

                if (team1Score > team2Score)
                {
                    winner = match.Team1;
                    resultMessage = $"🏆 {match.Team1} THẮNG!\n\n" +
                                  $"Tỉ số: {match.Team1} {team1Score} - {team2Score} {match.Team2}\n" +
                                  $"Trận đấu kết thúc!";
                }
                else if (team2Score > team1Score)
                {
                    winner = match.Team2;
                    resultMessage = $"🏆 {match.Team2} THẮNG!\n\n" +
                                  $"Tỉ số: {match.Team1} {team1Score} - {team2Score} {match.Team2}\n" +
                                  $"Trận đấu kết thúc!";
                }
                else
                {
                    resultMessage = $"🤝 HÒA!\n\n" +
                                  $"Tỉ số: {match.Team1} {team1Score} - {team2Score} {match.Team2}\n" +
                                  $"Trận đấu kết thúc!";
                }

                MessageBox.Show(resultMessage, "Kết quả trận đấu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mark all periods as finished
                var allPeriods = Repository.GetMatchSetsByMatchId(match.MatchId);
                foreach (var period in allPeriods)
                {
                    Repository.UpdateMatchSetStatus(period.MatchId, period.Id, "2"); // Finished
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị kết quả: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetPeriodName(int periodNumber)
        {
            // Get match class info to determine period type
            var matchClass = Repository.GetMatchClassById(match.MatchClassId ?? 0);

            if (matchClass != null)
            {
                switch (matchClass.PeriodType?.ToLower())
                {
                    case "half":
                        return $"Hiệp {periodNumber}";
                    case "quarter":
                        return $"Hiệp phụ {periodNumber}";
                    case "set":
                        return $"Set {periodNumber}";
                    default:
                        return $"Hiệp {periodNumber}";
                }
            }
            else
            {
                return $"Hiệp {periodNumber}";
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
                var list = Repository.GetMatchSetsByMatchId(match.MatchId);

                // Update UI elements
                lblTitle.Text = match.TournamentName ?? "";
                lblHiepDau.Text = match.ClassSetsName ?? "";
                lblTeam1.Text = match.Team1 ?? "";
                lblTeam2.Text = match.Team2 ?? "";
                lblScoreTeam1.Text = list.Sum(x => x.Score1).ToString();
                lblScoreTeam2.Text = list.Sum(x => x.Score2).ToString();
                lblTime.Text = match.Time ?? "00:00";

                // Force UI refresh
                this.Invalidate();
                this.Update();
            }
            catch (Exception ex)
            {
                // Silent error handling
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