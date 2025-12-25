using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Config;
using Scoreboard.Data;
using Scoreboard.Models;
using System.Linq;

namespace Scoreboard
{
    public class UserInfoForm : Form
    {
        private TextBox txtTime;
        private NumericUpDown nScore2;
        private NumericUpDown nScore1;
        private Label label4;
        private Label lblScore;
        private Label lblName;
        private TextBox txtTeam2;
        private Label lblTeam2;
        private TextBox txtTeam1;
        private Label lblTeam1;
        private TextBox txtTitle;
        private Label lblTenTranDau;
        private MaterialButton btnCancel;
        private MaterialButton btnStart;
        private MaterialButton btnRefresh;
        private Label lblMessage;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private UserModel currentUser;
        private string currentMatchid;
        public UserInfoForm(UserModel u)
        {
            InitializeComponent();
            currentUser = u;
            LoadUserInfo();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoForm));
            this.btnStart = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh = new MaterialSkin.Controls.MaterialButton();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.nScore2 = new System.Windows.Forms.NumericUpDown();
            this.nScore1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTenTranDau = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = false;
            this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStart.Depth = 0;
            this.btnStart.HighEmphasis = true;
            this.btnStart.Icon = null;
            this.btnStart.Location = new System.Drawing.Point(656, 244);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(117, 36);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStart.UseAccentColor = false;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = false;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth = 0;
            this.btnRefresh.HighEmphasis = true;
            this.btnRefresh.Icon = null;
            this.btnRefresh.Location = new System.Drawing.Point(545, 244);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefresh.UseAccentColor = false;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTime.Location = new System.Drawing.Point(154, 89);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(81, 26);
            this.txtTime.TabIndex = 36;
            this.txtTime.TabStop = false;
            this.txtTime.Text = "00:00";
            this.txtTime.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            // 
            // nScore2
            // 
            this.nScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore2.Location = new System.Drawing.Point(470, 195);
            this.nScore2.Name = "nScore2";
            this.nScore2.ReadOnly = true;
            this.nScore2.Size = new System.Drawing.Size(108, 26);
            this.nScore2.TabIndex = 35;
            this.nScore2.TabStop = false;
            this.nScore2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nScore2.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            // 
            // nScore1
            // 
            this.nScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore1.Location = new System.Drawing.Point(152, 195);
            this.nScore1.Name = "nScore1";
            this.nScore1.ReadOnly = true;
            this.nScore1.Size = new System.Drawing.Size(108, 26);
            this.nScore1.TabIndex = 34;
            this.nScore1.TabStop = false;
            this.nScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nScore1.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(52, 64, 84); // #344054 - Xám đậm
            this.label4.Location = new System.Drawing.Point(36, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thời gian";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(52, 64, 84); // #344054 - Xám đậm
            this.lblScore.Location = new System.Drawing.Point(36, 201);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(110, 23);
            this.lblScore.TabIndex = 33;
            this.lblScore.Text = "Điểm số";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(52, 64, 84); // #344054 - Xám đậm
            this.lblName.Location = new System.Drawing.Point(36, 155);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 23);
            this.lblName.TabIndex = 30;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeam2
            // 
            this.txtTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam2.Location = new System.Drawing.Point(470, 155);
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.ReadOnly = true;
            this.txtTeam2.Size = new System.Drawing.Size(303, 26);
            this.txtTeam2.TabIndex = 32;
            this.txtTeam2.TabStop = false;
            this.txtTeam2.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.FromArgb(52, 64, 84); // #344054 - Xám đậm
            this.lblTeam2.Location = new System.Drawing.Point(557, 114);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(124, 38);
            this.lblTeam2.TabIndex = 29;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTeam1
            // 
            this.txtTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam1.Location = new System.Drawing.Point(152, 155);
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.ReadOnly = true;
            this.txtTeam1.Size = new System.Drawing.Size(303, 26);
            this.txtTeam1.TabIndex = 31;
            this.txtTeam1.TabStop = false;
            this.txtTeam1.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.FromArgb(52, 64, 84); // #344054 - Xám đậm
            this.lblTeam1.Location = new System.Drawing.Point(241, 114);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(124, 38);
            this.lblTeam1.TabIndex = 28;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTitle.Location = new System.Drawing.Point(152, 55);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(621, 26);
            this.txtTitle.TabIndex = 26;
            this.txtTitle.TabStop = false;
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            // 
            // lblTenTranDau
            // 
            this.lblTenTranDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTranDau.ForeColor = System.Drawing.Color.FromArgb(52, 64, 84); // #344054 - Xám đậm
            this.lblTenTranDau.Location = new System.Drawing.Point(36, 55);
            this.lblTenTranDau.Name = "lblTenTranDau";
            this.lblTenTranDau.Size = new System.Drawing.Size(110, 23);
            this.lblTenTranDau.TabIndex = 25;
            this.lblTenTranDau.Text = "Tên giải đấu";
            this.lblTenTranDau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(438, 244);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 36);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(244, 246, 248); // #F4F6F8 - Nền chính (Form background)
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1036, 48);
            this.lblMessage.TabIndex = 40;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(244, 246, 248); // #F4F6F8 - Nền chính (Form background)
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1036, 682);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White; // #FFFFFF - Khung đăng nhập (Panel)
            this.panel1.Controls.Add(this.lblTenTranDau);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblTeam1);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.txtTeam1);
            this.panel1.Controls.Add(this.nScore2);
            this.panel1.Controls.Add(this.lblTeam2);
            this.panel1.Controls.Add(this.nScore1);
            this.panel1.Controls.Add(this.txtTeam2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Location = new System.Drawing.Point(109, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 348);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UserInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(1036, 730);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thông tin";
            this.Load += new System.EventHandler(this.UserInfoForm_Load);
            this.Activated += new System.EventHandler(this.UserInfoForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInfoForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private void LoadUserInfo()
        {
            // Set title with user name
            this.Text = currentUser?.Fullname ?? "";
            currentMatchid = "";
            if (currentUser?.RoleId == 2) // role trọng tài
            {
                DateTime now = DateTime.Now;
                var match = Repository.GetAllMatchSetsByUser(currentUser.Id)
                            .Where(m => m.Start <= now && m.End >= now)
                            .ToList(); ;
                if (match != null & match.Count > 0)
                {
                    if (match[0].Status == MatchStatusConfig.Status.NotStarted)
                    {
                        currentMatchid = match[0].MatchId;
                    }
                    txtTitle.Text = match[0].TournamentName;
                    txtTeam1.Text = match[0].Team1;
                    txtTeam2.Text = match[0].Team2;
                    var matchClass = Repository.GetMatchClassById((int)match[0].MatchClassId);
                    if (matchClass.PeriodType.ToLower() == "half")
                    {
                        nScore1.Value = match[0].TotalScore1;
                        nScore2.Value = match[0].TotalScore2;
                    } 
                    else
                    {
                        nScore1.Value = match[0].Score1;
                        nScore2.Value = match[0].Score2;
                    }

                        txtTime.Text = match[0].Time;
                    lblMessage.Text = "";
                    btnStart.Enabled = true;
                }
                else
                {
                    lblMessage.Text = "Chưa có dữ liệu";
                    btnStart.Enabled = false;
                    btnCancel.Focus();
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (currentMatchid != "")
            {
                Repository.UpdateMatchStatus(currentMatchid, "1");
            }
            var frmMain = new MainForm(currentUser);
            this.Hide();
            frmMain.FormClosed += (s, ev) => this.Show();
            LoadUserInfo();
            frmMain.Show();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void UserInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UserInfoForm_Activated(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        // Create border panels for textboxes after the form loads
        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            // Set button colors through MaterialSkin theme
            // btnStart - Xanh dương chủ đạo #3B82F6
            // This will be handled by the MaterialSkin theme set in MainMDIForm
            
            // btnCancel - Xám nhạt #E5E7EB
            // We'll need to customize this button specifically
            btnCancel.BackColor = Color.FromArgb(229, 231, 235); // #E5E7EB - Xám nhạt
            btnCancel.ForeColor = Color.FromArgb(52, 64, 84); // #344054 - Xám đậm for text
            
            // btnRefresh - Xám nhạt #E5E7EB
            btnRefresh.BackColor = Color.FromArgb(229, 231, 235); // #E5E7EB - Xám nhạt
            btnRefresh.ForeColor = Color.FromArgb(52, 64, 84); // #344054 - Xám đậm for text
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 10;   // độ bo góc - 8-10px như yêu cầu
            int shadow = 8;    // độ dày bóng
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Tạo path bo góc cho panel
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            // Gán Region để panel thật sự bo góc
            panel.Region = new Region(path);

            // Vẽ viền xám nhẹ cho panel (#D0D5DD)
            using (Pen borderPen = new Pen(Color.FromArgb(208, 213, 221), 1)) // #D0D5DD - Border color
            {
                e.Graphics.DrawPath(borderPen, path);
            }

            // Vẽ bóng mờ nhẹ (ngoài path)
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                Rectangle shadowRect = new Rectangle(shadow, shadow, panel.Width - shadow, panel.Height - shadow);
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, radius, radius, 180, 90);
                shadowPath.AddArc(shadowRect.Right - radius, shadowRect.Y, radius, radius, 270, 90);
                shadowPath.AddArc(shadowRect.Right - radius, shadowRect.Bottom - radius, radius, radius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - radius, radius, radius, 90, 90);
                shadowPath.CloseFigure();

                using (PathGradientBrush brush = new PathGradientBrush(shadowPath))
                {
                    brush.CenterColor = Color.FromArgb(50, Color.Black); // độ mờ
                    brush.SurroundColors = new Color[] { Color.Transparent };
                    e.Graphics.FillPath(brush, shadowPath);
                }
            }

            // Vẽ lại thân panel để che phần bóng bên trong
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}
