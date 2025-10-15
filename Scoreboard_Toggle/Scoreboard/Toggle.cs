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
using DocumentFormat.OpenXml.Wordprocessing;

namespace Scoreboard
{
    public class Toggle : Form
    {
        private TableLayoutPanel tableLayoutPanel_BongDa;
        private List<ucFormView_Toggle> ucs = new List<ucFormView_Toggle>();
        private Timer matchTimer;
        private bool isPaused = true;
        private List<MatchsetModel> matchsetModels = new List<MatchsetModel>();
        public Toggle()
        {
            InitializeComponent();
           // this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            var list = Repository.GetActiveMatchSetsShowtoggle();
            matchsetModels = list;
            LoadCacTranDau(list);

            InitTimer();
            StartClock();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toggle));
            this.tableLayoutPanel_BongDa = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_BongDa
            // 
            this.tableLayoutPanel_BongDa.ColumnCount = 1;
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_BongDa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_BongDa.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_BongDa.Name = "tableLayoutPanel_BongDa";
            this.tableLayoutPanel_BongDa.RowCount = 1;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toggle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Toggle_Load);
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
            using (Pen pen = new Pen(System.Drawing.Color.Red, 2))
            {
                Rectangle rect = e.CellBounds;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                StopClock();
                this.Close();
            }
        }
        //xử lý add từng ucControl (form hiển thị giao diện load thông tin trận đấu)
        private void LoadCacTranDau(List<MatchsetModel> m)
        {
            var activeUc = ucs.FirstOrDefault(uc => uc.ContainsFocus);
            for (int i = 0; i <= ucs.Count() - 1; i++)
            {
                ucs[i].Dispose();
            }
            //------
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
        private void InitTimer()
        {
            matchTimer = new Timer();
            matchTimer.Interval = 1000; // 1 giây
            matchTimer.Tick += (s, e) =>
            {
                if (!isPaused)
                {
                    if (PostgresHelper.OpenSharedConnection() == true)
                    {
                        var list = Repository.GetActiveMatchSetsShowtoggle();
                        if (list.Count != matchsetModels.Count)
                        {
                            LoadCacTranDau(list);
                            matchsetModels = list;
                        }
                        else
                        {
                            for(int i = 0; i < list.Count; i++)
                            {
                                if (list[i].MatchId.ToString() != matchsetModels[i].MatchId.ToString())
                                {
                                    LoadCacTranDau(list);
                                    matchsetModels = list;
                                    break;
                                }
                            }
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

        private void Toggle_Load(object sender, EventArgs e)
        {
            //bool isConnect = false;
            //try
            //{
            //    matchsetModels = Repository.GetActiveMatchSetsShowtoggle();
            //    isConnect=true;
            //}
            //catch
            //{
            //    ConfigDatabase cf = new ConfigDatabase();
            //    cf.ShowDialog();
            //    if (cf.DialogResult == DialogResult.OK)
            //    {
            //        isConnect = true;
            //        matchsetModels = Repository.GetActiveMatchSetsShowtoggle();
            //    }
            //}
            //if (isConnect == true)
            //{
            //    LoadCacTranDau(matchsetModels);
            //    StartClock();
            //}
            //LoadCacTranDau(matchsetModels);
            //StartClock();

        }
    }
}
