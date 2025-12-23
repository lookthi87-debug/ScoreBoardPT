using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace Scoreboard
{
    public class LoginForm : Form
    {
        private TextBox txtUserName;
        private Label lblUser;
        private TextBox txtPassWord;
        private Label lblPassWord;
        private MaterialButton btnClose;
        private LinkLabel linkMiss;
        private LinkLabel linkChangePass;
        private MaterialButton btnLogin;
        public UserModel User;
        private Timer pingTimer = new Timer();
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private MainMDIForm mainForm;
        public LoginForm(MainMDIForm parent)
        {
            InitializeComponent();
            mainForm = parent;
            pingTimer = new Timer();
            pingTimer.Interval = 10 * 60 * 500; // 5 phút
            pingTimer.Tick += PingTimer_Tick;
            pingTimer.Start();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.btnClose = new MaterialSkin.Controls.MaterialButton();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.linkMiss = new System.Windows.Forms.LinkLabel();
            this.linkChangePass = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtUserName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(187, 69);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 29);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "Admin";
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblUser.Location = new System.Drawing.Point(29, 69);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(152, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWord
            // 
            this.txtPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(187, 103);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(354, 29);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.Text = "Abc12345";
            this.txtPassWord.UseSystemPasswordChar = true;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // lblPassWord
            // 
            this.lblPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblPassWord.Location = new System.Drawing.Point(29, 103);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(152, 23);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "Mật khẩu";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClose.Depth = 0;
            this.btnClose.HighEmphasis = true;
            this.btnClose.Icon = null;
            this.btnClose.Location = new System.Drawing.Point(187, 141);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Thoát";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(383, 141);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(158, 36);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.Login_Click);
            // 
            // linkMiss
            // 
            this.linkMiss.AutoSize = true;
            this.linkMiss.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.linkMiss.Location = new System.Drawing.Point(345, 192);
            this.linkMiss.Name = "linkMiss";
            this.linkMiss.Size = new System.Drawing.Size(80, 13);
            this.linkMiss.TabIndex = 5;
            this.linkMiss.TabStop = true;
            this.linkMiss.Text = "Quên mật khẩu";
            this.linkMiss.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMiss_LinkClicked);
            // 
            // linkChangePass
            // 
            this.linkChangePass.AutoSize = true;
            this.linkChangePass.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.linkChangePass.Location = new System.Drawing.Point(443, 192);
            this.linkChangePass.Name = "linkChangePass";
            this.linkChangePass.Size = new System.Drawing.Size(96, 13);
            this.linkChangePass.TabIndex = 6;
            this.linkChangePass.TabStop = true;
            this.linkChangePass.Text = "Thay đổi mật khẩu";
            this.linkChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangePass_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 523);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.linkChangePass);
            this.panel1.Controls.Add(this.linkMiss);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblPassWord);
            this.panel1.Controls.Add(this.txtPassWord);
            this.panel1.Location = new System.Drawing.Point(79, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 273);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LoginForm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(772, 523);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void EnsureDefaultAdmin()
        {
            try
            {
                var admin = Repository.GetUserByName("Admin");
                if (admin == null)
                {
                    var defaultPwd = Security.HashPassword("Abc12345");
                    var roles = Repository.GetAllRoles();
                    int roleId = 0;
                    var roleAdmin = roles.Find(r => r.Name.Equals("Admin", StringComparison.OrdinalIgnoreCase));
                    if (roleAdmin == null)
                    {
                        Repository.AddRole("Admin");
                        roleId = Repository.GetAllRoles().Find(r => r.Name == "Admin").Id;
                    }
                    else
                        roleId = roleAdmin.Id;

                    Repository.AddUser(new UserModel
                    {
                        Name = "Admin",
                        Password = defaultPwd,
                        RoleId = roleId,
                        Fullname = "Administrator"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo user mặc định: " + ex.Message);
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.");
                return;
            }
            try
            {
                User = Repository.GetUserByName(username);
                if (User == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    return;
                }
                if (Security.VerifyPassword(password, User.Password) == false)
                {
                    MessageBox.Show("Sai mật khẩu!");
                    return;
                }

                if (User.RoleId.HasValue)
                {
                    string jsonText = Repository.GetLicenseData();
                    if (string.IsNullOrEmpty(jsonText))
                    {
                        try
                        {
                            string licPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "license.licx");
                            LicenseVerifier.SyncLicenseFileToDB(licPath, User.Id);
                        }
                        catch
                        { 
                        }
                    }

                    //------------------------------------------
                    if (checklicense(User) == true)
                    {
                        var role = Repository.GetRoleById(User.RoleId.Value);
                        if (role != null && role.Name.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            mainForm.Invoke(new Action(() =>
                            {
                                mainForm.EnableMenusAfterLogin(true, User);
                            }));

                            // Đóng form login
                            this.Hide();
                        }
                        else
                        {
                            mainForm.Invoke(new Action(() =>
                            {
                                mainForm.EnableMenusAfterLogin(false, User);
                            }));

                            // Đóng form login
                            this.Hide();
                        }
                    }    
                }
                else
                {
                    MessageBox.Show("Người dùng chưa được gán quyền!");
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng cấu hình database");
            }

        }
        private bool checklicense(UserModel user)
        {

            Repository.CleanupInactiveSessions(); // dọn các session cũ

            if (!LicenseVerifier.TryVerifyLicense(out int totalMachines, out DateTime expiryDate, out string msg))
            {
                MessageBox.Show(msg, "License Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int daysLeft = (expiryDate - DateTime.Now).Days;
            if (daysLeft < 0)
            {
                MessageBox.Show("License đã hết hạn. Vui lòng liên hệ quản trị!", "License Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int active = Repository.CountActiveMachines();
            if (active >= totalMachines)
            {
                MessageBox.Show($"Đã vượt quá số máy được phép ({totalMachines}).", "License Error");
                return false;
            }
            // Ghi log và login thành công
            MessageBox.Show($"Đăng nhập thành công: {user.Fullname}");
            Repository.LogUserActivity(user.Id);
            Program.CurrentUserId = user.Id;

            var days = (expiryDate - DateTime.Now).TotalDays;
            if (days <= 10)
                MessageBox.Show($"License còn {Math.Ceiling(days)} ngày nữa hết hạn ({expiryDate:yyyy-MM-dd}).",
                    "License Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void linkMiss_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Nếu quên mật khẩu thì liên hệ Admin để reset mật khẩu mặc định.");
        }

        private void linkChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmChangePass = new ChangePassForm(User);
            if (new ChangePassForm(User).ShowDialog() == DialogResult.OK)
            {
                txtPassWord.Focus();
            }
            else
            {
                txtUserName.Focus();
            }
        }

        private void PingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (User == null)
                {
                    return;
                }
                if (User.RoleId.HasValue)
                {
                    Repository.UpdateUserActivityPing(User.Id);
                }
            }
            catch
            {
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                pingTimer?.Stop();
                if (User == null)
                {
                    return;
                }
                if (User.RoleId.HasValue)
                {
                    Repository.ClearUserActivity(User.Id);
                }
            }
            catch
            {
            }
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

        private void TxtBox_GotFocus(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.BorderStyle = BorderStyle.FixedSingle;
            txtBox.BackColor = Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            
            // Show the border panel with focus color
            string borderName = txtBox.Name + "_border";
            Panel borderPanel = panel1.Controls[borderName] as Panel;
            
            if (borderPanel != null)
            {
                borderPanel.BackColor = Color.FromArgb(59, 130, 246); // #3B82F6 - Xanh chủ đạo (focus color)
            }
        }

        private void TxtBox_LostFocus(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.BorderStyle = BorderStyle.FixedSingle;
            txtBox.BackColor = Color.FromArgb(249, 250, 251); // #F9FAFB - Textbox background
            
            // Hide the border panel by setting its color to transparent
            string borderName = txtBox.Name + "_border";
            Panel borderPanel = panel1.Controls[borderName] as Panel;
            
            if (borderPanel != null)
            {
                borderPanel.BackColor = Color.Transparent;
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
