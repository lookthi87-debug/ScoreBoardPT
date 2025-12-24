using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public class MainForm : Form
    {
        private List<MatchModel> currentMatches = new List<MatchModel>();
        private System.Windows.Forms.Label lblNote;
        private TableLayoutPanel tableLayoutPanel_BongDa;
        private List<ucFormView_User> ucs = new List<ucFormView_User>();
        private UserModel user { get; set; }
        public MainForm(UserModel us)
        {
            InitializeComponent();
           // this.WindowState = FormWindowState.Maximized;
            user = us;
            this.KeyPreview = true;
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITEST = 0x84;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;
            const int RESIZE_HANDLE_SIZE = 10;
            if (m.Msg == WM_NCHITEST)
            {
                base.WndProc(ref m);
                Point cursor = PointToClient(Cursor.Position);
                if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE && cursor.Y <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTBOTTOMLEFT);
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE && cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTBOTTOMRIGHT);
                else if (cursor.X <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTLEFT);
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTRIGHT);
                else if (cursor.Y <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTTOP);
                else if (cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTBOTTOM);
                return;
            }
            base.WndProc(ref m);

        }
        private void InitializeComponent()
        {
            this.lblNote = new System.Windows.Forms.Label();
            this.tableLayoutPanel_BongDa = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNote.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.White;
            this.lblNote.Location = new System.Drawing.Point(31, 621);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(1116, 21);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Phím số : 1-Đ1+ | 2-Đ2+ | 3-Reset điểm |  5-Bắt đầu | 6-Dừng | 7-Reset TG | 8-Lưu | + Hiệp/Set | 0-Ẩn/Hiện";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel_BongDa
            // 
            this.tableLayoutPanel_BongDa.ColumnCount = 2;
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_BongDa.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_BongDa.Name = "tableLayoutPanel_BongDa";
            this.tableLayoutPanel_BongDa.RowCount = 2;
            this.tableLayoutPanel_BongDa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Size = new System.Drawing.Size(1188, 652);
            this.tableLayoutPanel_BongDa.TabIndex = 2;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1188, 652);
            this.ControlBox = false;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.tableLayoutPanel_BongDa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Padding = new Padding(0, 0, 0, 0);
        }
        private void tableLayoutPanel_BongDa_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                Rectangle rect = e.CellBounds;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        //Phần trên là layout, phần dưới này là coding
        private void MainForm_Load(object sender, EventArgs e)
        {
            var list = Repository.GetActiveMatchSetsByUser(user.Id);
            LoadCacTranDau(list);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            var activeUc = ucs.FirstOrDefault(uc => uc.ContainsFocus);

            // Debug: Show which key was pressed
            // MessageBox.Show($"Key pressed: {e.KeyCode} (Value: {e.KeyValue})", "Debug");

            if (e.KeyCode == Keys.Escape)
            {
                // Show confirmation dialog
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát khỏi ứng dụng?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i <= ucs.Count() - 1; i++)
                    {
                        ucs[i].Dispose();
                    }
                    ucs.Clear();
                    this.Close();
                }
            }
            // Ẩn/hiện ghi chú
            if (e.KeyCode == Keys.D0)
            {
                lblNote.Visible = !lblNote.Visible;
                return;
            }

            if (activeUc == null)
            {
                // Debug: Show if no active UC
                // MessageBox.Show("Không có UC nào được focus!", "Debug");
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.D1:  // + điểm đội 1
                    activeUc.AddPointTeam1();
                    break;

                case Keys.D2:  // + điểm đội 2
                    activeUc.AddPointTeam2();
                    break;

                case Keys.D3:  // Reset điểm
                    activeUc.ResetScore();
                    break;

                //case Keys.D4:  // Cập nhật thời gian
                //    {
                //        activeUc.StopClock();
                //        var updateForm = new UpdateTime();
                //        updateForm.MatchsetModel.Time = activeUc.Matchset.Time;
                //        if (updateForm.ShowDialog() == DialogResult.OK)
                //        {
                //            activeUc.UpdateMatchTime(updateForm.MatchsetModel.Time);
                //        }
                //        break;
                //    }

                case Keys.D5:  // Start clock
                    activeUc.StartClock();
                    break;

                case Keys.D6:  // Stop clock
                    activeUc.StopClock();
                    break;

                case Keys.D7:  // Reset clock
                    activeUc.ResetClock();
                    break;

                case Keys.D8:  // Lưu Excel
                    activeUc.StopClock();
                    activeUc.ExportMatchToExcel(activeUc.Matchset);
                    break;

                case Keys.Oemplus: // phím "+"
                case Keys.Add:     // phím "+" trên numpad
                    activeUc.StopClock();
                    try
                    {
                        activeUc.NextSet();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi chuyển hiệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }
        //xử lý add từng ucControl (form hiển thị giao diện load thông tin trận đấu)
        private void LoadCacTranDau(List<MatchsetModel> m)
        {
            ucs.Clear();
            tableLayoutPanel_BongDa.Controls.Clear();
            tableLayoutPanel_BongDa.ColumnStyles.Clear();
            tableLayoutPanel_BongDa.RowStyles.Clear();
            if (m.Count <= 0) return;
            if (m.Count == 1)
            {
                // 1 UC full
                tableLayoutPanel_BongDa.ColumnCount = 1;
                tableLayoutPanel_BongDa.RowCount = 1;
                tableLayoutPanel_BongDa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tableLayoutPanel_BongDa.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                var uc = new ucFormView_User(m[0]);
                uc.Dock = DockStyle.Fill;
                tableLayoutPanel_BongDa.Controls.Add(uc, 0, 0);
                ucs.Add(uc);
            }
            else
            {
                // Tính số cột và số hàng hợp lý
                int cols, rows;

                if (m.Count <= 2) { cols = m.Count; rows = 1; }
                else if (m.Count <= 4) { cols = 2; rows = (int)Math.Ceiling(m.Count / 2.0); }
                else if (m.Count <= 6) { cols = 3; rows = (int)Math.Ceiling(m.Count / 3.0); }
                else { cols = 4; rows = (int)Math.Ceiling(m.Count / 4.0); }

                tableLayoutPanel_BongDa.ColumnCount = cols;
                tableLayoutPanel_BongDa.RowCount = rows;

                for (int c = 0; c < cols; c++)
                    tableLayoutPanel_BongDa.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));
                for (int r = 0; r < rows; r++)
                    tableLayoutPanel_BongDa.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

                int index = 0;
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (index >= m.Count) break;
                        var uc = new ucFormView_User(m[index]);
                        uc.Dock = DockStyle.Fill;
                        tableLayoutPanel_BongDa.Controls.Add(uc, c, r);
                        ucs.Add(uc);
                        index++;
                    }
                }
            }
        }
    }
}
