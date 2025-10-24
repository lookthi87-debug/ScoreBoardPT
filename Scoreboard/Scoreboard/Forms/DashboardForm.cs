using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Models;

namespace Scoreboard
{
    public class DashboardForm : MaterialForm
    {
        private TabControl tabControl;
        private TabPage tabMatches;
        private TabPage tabUsers;
        private Panel avatarPanel;
        private Label avatarLabel;
        private Button btnLogout;
        private Label lblWelcome;
        private Panel headerPanel;
        private UserModel currentUser;

        public DashboardForm(UserModel user)
        {
            currentUser = user;
            InitializeComponent();
            SetupDashboard();
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMatches = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.avatarPanel = new System.Windows.Forms.Panel();
            this.avatarLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.avatarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMatches);
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabControl.Location = new System.Drawing.Point(3, 120);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1194, 577);
            this.tabControl.TabIndex = 1;
            // 
            // tabMatches
            // 
            this.tabMatches.BackColor = System.Drawing.Color.White;
            this.tabMatches.Location = new System.Drawing.Point(4, 29);
            this.tabMatches.Name = "tabMatches";
            this.tabMatches.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatches.Size = new System.Drawing.Size(1186, 544);
            this.tabMatches.TabIndex = 0;
            this.tabMatches.Text = "Quản lý giải đấu";
            // 
            // tabUsers
            // 
            this.tabUsers.BackColor = System.Drawing.Color.White;
            this.tabUsers.Location = new System.Drawing.Point(4, 29);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(1186, 544);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Quản lý người dùng";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(20, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(190, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng, Admin";
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.headerPanel.Controls.Add(this.btnLogout);
            this.headerPanel.Controls.Add(this.avatarPanel);
            this.headerPanel.Controls.Add(this.lblWelcome);
            this.headerPanel.Location = new System.Drawing.Point(3, 64);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1194, 53);
            this.headerPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1078, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(42, 25);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // avatarPanel
            // 
            this.avatarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avatarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.avatarPanel.Controls.Add(this.avatarLabel);
            this.avatarPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarPanel.Location = new System.Drawing.Point(1130, 8);
            this.avatarPanel.Name = "avatarPanel";
            this.avatarPanel.Size = new System.Drawing.Size(40, 40);
            this.avatarPanel.TabIndex = 1;
            this.avatarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.avatarPanel_Paint);
            // 
            // avatarLabel
            // 
            this.avatarLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avatarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.avatarLabel.ForeColor = System.Drawing.Color.White;
            this.avatarLabel.Location = new System.Drawing.Point(0, 0);
            this.avatarLabel.Name = "avatarLabel";
            this.avatarLabel.Size = new System.Drawing.Size(40, 40);
            this.avatarLabel.TabIndex = 0;
            this.avatarLabel.Text = "A";
            this.avatarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.avatarLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.avatarLabel_Paint);
            // 
            // DashboardForm
            // 
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Hệ thống quản lý Scoreboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardForm_FormClosed);
            this.Shown += new System.EventHandler(this.DashboardForm_Shown);
            this.tabControl.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.avatarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void SetupDashboard()
        {
            // Set user avatar
            if (currentUser != null && !string.IsNullOrEmpty(currentUser.Fullname))
            {
                string firstLetter = currentUser.Fullname.Substring(0, 1).ToUpper();
                avatarLabel.Text = firstLetter;
            }
            else
            {
                avatarLabel.Text = "A";
            }
            
            // Set welcome message
            lblWelcome.Text = $"Chào mừng, {currentUser?.Fullname ?? "Admin"}";

            // Load TournamentsForm into tabMatches
            var tournamentsForm = new TournamentsForm(currentUser);
            tournamentsForm.TopLevel = false;
            tournamentsForm.FormBorderStyle = FormBorderStyle.None;
            tournamentsForm.Dock = DockStyle.Fill;
            tabMatches.Controls.Add(tournamentsForm);
            tournamentsForm.Show();

            // Load UsersForm into tabUsers
            var usersForm = new UsersForm(currentUser);
            usersForm.TopLevel = false;
            usersForm.FormBorderStyle = FormBorderStyle.None;
            usersForm.Dock = DockStyle.Fill;
            tabUsers.Controls.Add(usersForm);
            usersForm.Show();
        }

        private void OnLogout()
        {
            // Clear user activity
            try
            {
                if (currentUser?.Id > 0)
                {
                    Data.Repository.ClearUserActivity(currentUser.Id);
                }
            }
            catch { }

            // Show login form and hide current form
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void DashboardForm_Shown(object sender, EventArgs e)
        {
            // Đảm bảo avatar hiển thị đúng
            this.avatarPanel.Visible = true;
            this.avatarPanel.Enabled = true;
            this.avatarPanel.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                OnLogout();
            }
        }

        private void avatarPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            
            // Vẽ hình tròn với border trắng dày hơn
            Rectangle rect = new Rectangle(2, 2, panel.Width - 5, panel.Height - 5);
            
            // Vẽ border trắng trước (lớn hơn)
            using (Pen borderPen = new Pen(Color.White, 4))
            {
                g.DrawEllipse(borderPen, new Rectangle(0, 0, panel.Width - 1, panel.Height - 1));
            }
            
            // Vẽ hình tròn nền
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                g.FillEllipse(brush, rect);
            }
            
            // Vẽ border trong cùng (mỏng hơn)
            using (Pen innerPen = new Pen(Color.White, 1))
            {
                g.DrawEllipse(innerPen, rect);
            }
        }

        private void avatarLabel_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // Vẽ border trắng xung quanh avatarLabel
            using (Pen borderPen = new Pen(Color.White, 2))
            {
                g.DrawRectangle(borderPen, 1, 1, label.Width - 3, label.Height - 3);
            }
        }
    }
}