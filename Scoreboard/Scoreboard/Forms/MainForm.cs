using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Database;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Scoreboard
{
    public class MainForm : Form
    {
        private List<MatchModel> currentMatches = new List<MatchModel>();
        private TableLayoutPanel grid;
        private Label lblFooter;
        private TabControl tabMain;
        private TabPage tabBongDa;
        private TabPage tabBongChuyen;
        private TabPage tabCauLong;
        private TabPage tabQuanVot;
        private Timer refreshTimer;
        private TableLayoutPanel tableLayoutPanel_BongDa;
        private Label label1;
        private List<ucFormView_User> ucs = new List<ucFormView_User>();
        private int nCountView { get; set; }
        private User user { get; set; }
        public MainForm(User us)
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
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
                else if (cursor.X >= Width -  RESIZE_HANDLE_SIZE && cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTBOTTOMRIGHT);
                else if (cursor.X <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTLEFT);
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTRIGHT);
                else if (cursor.Y <=  RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTTOP);
                else if (cursor.Y >=Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)(HTBOTTOM);
                return;
            }
            base.WndProc(ref m);

        }
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBongDa = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_BongDa = new System.Windows.Forms.TableLayoutPanel();
            this.tabBongChuyen = new System.Windows.Forms.TabPage();
            this.tabCauLong = new System.Windows.Forms.TabPage();
            this.tabQuanVot = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabBongDa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabBongDa);
            this.tabMain.Controls.Add(this.tabBongChuyen);
            this.tabMain.Controls.Add(this.tabCauLong);
            this.tabMain.Controls.Add(this.tabQuanVot);
            this.tabMain.Location = new System.Drawing.Point(-2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(0, 0);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1188, 652);
            this.tabMain.TabIndex = 0;
            this.tabMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabMain_DrawItem);
            // 
            // tabBongDa
            // 
            this.tabBongDa.BackColor = System.Drawing.Color.Black;
            this.tabBongDa.Controls.Add(this.tableLayoutPanel_BongDa);
            this.tabBongDa.Location = new System.Drawing.Point(4, 22);
            this.tabBongDa.Name = "tabBongDa";
            this.tabBongDa.Padding = new System.Windows.Forms.Padding(3);
            this.tabBongDa.Size = new System.Drawing.Size(1180, 626);
            this.tabBongDa.TabIndex = 0;
            this.tabBongDa.Text = "Bóng đá";
            // 
            // tableLayoutPanel_BongDa
            // 
            this.tableLayoutPanel_BongDa.ColumnCount = 2;
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_BongDa.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_BongDa.Name = "tableLayoutPanel_BongDa";
            this.tableLayoutPanel_BongDa.RowCount = 2;
            this.tableLayoutPanel_BongDa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Size = new System.Drawing.Size(1174, 620);
            this.tableLayoutPanel_BongDa.TabIndex = 0;
            this.tableLayoutPanel_BongDa.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_BongDa_CellPaint);
            // 
            // tabBongChuyen
            // 
            this.tabBongChuyen.BackColor = System.Drawing.Color.Black;
            this.tabBongChuyen.Location = new System.Drawing.Point(4, 22);
            this.tabBongChuyen.Name = "tabBongChuyen";
            this.tabBongChuyen.Padding = new System.Windows.Forms.Padding(3);
            this.tabBongChuyen.Size = new System.Drawing.Size(1180, 626);
            this.tabBongChuyen.TabIndex = 1;
            this.tabBongChuyen.Text = "Bóng chuyền";
            // 
            // tabCauLong
            // 
            this.tabCauLong.BackColor = System.Drawing.Color.Black;
            this.tabCauLong.Location = new System.Drawing.Point(4, 22);
            this.tabCauLong.Name = "tabCauLong";
            this.tabCauLong.Padding = new System.Windows.Forms.Padding(3);
            this.tabCauLong.Size = new System.Drawing.Size(1180, 626);
            this.tabCauLong.TabIndex = 2;
            this.tabCauLong.Text = "Cầu lông";
            // 
            // tabQuanVot
            // 
            this.tabQuanVot.BackColor = System.Drawing.Color.Black;
            this.tabQuanVot.Location = new System.Drawing.Point(4, 22);
            this.tabQuanVot.Name = "tabQuanVot";
            this.tabQuanVot.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuanVot.Size = new System.Drawing.Size(1180, 626);
            this.tabQuanVot.TabIndex = 3;
            this.tabQuanVot.Text = "Quần vợt";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 621);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1116, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phím số : 1-Đ1+ | 2-Đ2+ | 3-Reset điểm | 4-Đổi tên | 5-Bắt đầu | 6-Dừng | 7-Reset" +
    " TG | 8-Lưu | 9-Đổi giải đấu | +/-:Hiệp/Set | 0-Ẩn/Hiện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1188, 652);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabMain.ResumeLayout(false);
            this.tabBongDa.ResumeLayout(false);
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
            tabMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabMain.DrawItem += tabMain_DrawItem;
            foreach (TabPage page in tabMain.TabPages)
            {
                page.BackColor = Color.Black;   // nền đen
                page.ForeColor = Color.White;   // chữ trắng (nếu có control bên trong thì mặc định chữ vẫn trắng)
                page.BorderStyle = BorderStyle.None;
            }

            var list = Repository.GetShowMatchesUser(user);
            LoadCacTranDau(list);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            var activeUc = ucs.FirstOrDefault(uc => uc.ContainsFocus);
            if (e.KeyCode == Keys.Escape) 
            {
                for (int i = 0; i <= ucs.Count() - 1; i++)
                {
                    ucs[i].Dispose();
                }
                ucs.Clear();
                this.Close();
            }
            if (e.KeyCode == Keys.D0)
            {
            }
            else if (activeUc == null) return; // không có uc nào được chọn

            else if (e.KeyCode == Keys.D1) // phím số 1 -> đội 1 cộng điểm
            {
                activeUc.AddPointTeam1();
            }
            else if (e.KeyCode == Keys.D2) // phím số 2 -> đội 2 cộng điểm
            {
                activeUc.AddPointTeam2();
            }
            else if (e.KeyCode == Keys.D3) activeUc.ResetScore();  // Reset điểm
            else if (e.KeyCode == Keys.D5) activeUc.StartClock();  // Bắt đầu chạy
            else if (e.KeyCode == Keys.D6) activeUc.StopClock();   // Dừng lại
            else if (e.KeyCode == Keys.D7) activeUc.ResetClock();  // Reset thời gian
            else if (e.KeyCode == Keys.D8) activeUc.SaveState();   // Lưu trạng thái
        }
        //Vẽ lại để giấu viền của tabcontrol
        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabMain.TabPages[e.Index];
            Rectangle rect = e.Bounds;
            // Header nền trắng
            e.Graphics.FillRectangle(Brushes.White, rect);
            // Nếu tab đang chọn thì in đậm
            Font font = (e.Index == tabMain.SelectedIndex)
                ? new Font(e.Font, FontStyle.Bold)
                : e.Font;
            // Vẽ text
            TextRenderer.DrawText(e.Graphics, page.Text, font, rect, Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            // Viền mảnh quanh header
            e.Graphics.DrawRectangle(Pens.Black, rect);
        }
        //xử lý add từng ucControl (form hiển thị giao diện load thông tin trận đấu)
        private void LoadCacTranDau(List<MatchModel> m)
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
