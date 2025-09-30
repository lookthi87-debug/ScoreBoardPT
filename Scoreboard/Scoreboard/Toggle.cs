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
    public class Toggle : Form
    {
        private TableLayoutPanel tableLayoutPanel_BongDa;
        private List<ucFormView_Toggle> ucs = new List<ucFormView_Toggle>();
        public List<MatchModel> m { get; set; }
        public Toggle()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
        }
        private void InitializeComponent()
        {
            this.tableLayoutPanel_BongDa = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_BongDa
            // 
            this.tableLayoutPanel_BongDa.ColumnCount = 2;
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_BongDa.Name = "tableLayoutPanel_BongDa";
            this.tableLayoutPanel_BongDa.RowCount = 2;
            this.tableLayoutPanel_BongDa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Size = new System.Drawing.Size(1188, 652);
            this.tableLayoutPanel_BongDa.TabIndex = 1;
            this.tableLayoutPanel_BongDa.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel_BongDa_CellPaint);
            // 
            // Toggle
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1188, 652);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_BongDa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Toggle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            var list = Repository.GetShowMatchesToggle();
            LoadCacTranDau(list);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                for (int i = 0; i <= ucs.Count() - 1; i++)
                {
                    ucs[i].Dispose();  
                }
                ucs.Clear();
                this.Close();
            }
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

                var uc = new ucFormView_Toggle(m[0]);
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
                        var uc = new ucFormView_Toggle(m[index]);
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
