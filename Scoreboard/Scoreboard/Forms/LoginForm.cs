using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Scoreboard
{
    public class LoginForm : MaterialForm
    {
        private TextBox txtUserName;
        private Label lblUser;
        private TextBox txtPassWord;
        private Label lblPassWord;
        private MaterialButton btnClose;
        private LinkLabel linkMiss;
        private LinkLabel linkChangePass;
        private MaterialButton btnLogin;
        private PictureBox pDB;
        private UserModel User;
        private LinkLabel lblLicense;
        private Timer pingTimer = new Timer();
        public LoginForm()
        {
            InitializeComponent();
            this.pDB.Image = global::Scoreboard.Properties.Resources.DB;
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
            this.pDB = new System.Windows.Forms.PictureBox();
            this.lblLicense = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pDB)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(175, 105);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 29);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "Admin";
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(17, 105);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(152, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(175, 146);
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
            this.lblPassWord.Location = new System.Drawing.Point(17, 146);
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
            this.btnClose.Location = new System.Drawing.Point(175, 196);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClose.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Thoát";
            this.btnClose.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClose.UseAccentColor = false;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(371, 196);
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
            this.linkMiss.Location = new System.Drawing.Point(335, 250);
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
            this.linkChangePass.Location = new System.Drawing.Point(433, 250);
            this.linkChangePass.Name = "linkChangePass";
            this.linkChangePass.Size = new System.Drawing.Size(96, 13);
            this.linkChangePass.TabIndex = 6;
            this.linkChangePass.TabStop = true;
            this.linkChangePass.Text = "Thay đổi mật khẩu";
            this.linkChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangePass_LinkClicked);
            // 
            // pDB
            // 
            this.pDB.Location = new System.Drawing.Point(535, 67);
            this.pDB.Name = "pDB";
            this.pDB.Size = new System.Drawing.Size(30, 30);
            this.pDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pDB.TabIndex = 7;
            this.pDB.TabStop = false;
            this.pDB.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.LinkColor = System.Drawing.Color.Gray;
            this.lblLicense.Location = new System.Drawing.Point(4, 277);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(86, 13);
            this.lblLicense.TabIndex = 8;
            this.lblLicense.TabStop = true;
            this.lblLicense.Text = "Cập nhật license";
            this.lblLicense.Click += new System.EventHandler(this.lblLicense_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(571, 293);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.pDB);
            this.Controls.Add(this.linkChangePass);
            this.Controls.Add(this.linkMiss);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                            new AdminForm(User).Show();
                            this.Hide();
                        }
                        else
                        {
                            new UserInfoForm(User).Show();
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
                pDB.Focus();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ConfigDatabase configDatabase = new ConfigDatabase();
            configDatabase.ShowDialog();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            pingTimer = new Timer();
            pingTimer.Interval = 10 * 60 * 500; // 5 phút
            pingTimer.Tick += PingTimer_Tick;
            pingTimer.Start();
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

        private void lblLicense_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    User = Repository.GetUserByName(txtUserName.Text.Trim());

                    // Chọn file license
                    using (var ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "License file (*.licx)|*.licx";
                        ofd.Title = "Chọn file license mới";
                        if (ofd.ShowDialog() != DialogResult.OK)
                            return;

                        string selectedPath = ofd.FileName;
                        string appPath = AppDomain.CurrentDomain.BaseDirectory;
                        string targetPath = Path.Combine(appPath, "license.licx");

                        // Đọc file và kiểm tra hợp lệ
                        string json = File.ReadAllText(selectedPath);
                        if (!LicenseVerifier.TryVerifyLicense(json, out int totalMachines, out DateTime expiry))
                        {
                            MessageBox.Show("File license không hợp lệ hoặc bị chỉnh sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Copy file vào thư mục chương trình (ghi đè nếu có)
                        File.Copy(selectedPath, targetPath, overwrite: true);

                        // Gọi SyncLicenseFileToDB để cập nhật xuống DB (chỉ update nếu license mới hơn)
                        LicenseVerifier.SyncLicenseFileToDB(targetPath, User.Id);

                        // Thông báo thành công
                        MessageBox.Show(
                            $"Đã cập nhật license mới!\n" +
                            $"Số máy: {totalMachines}\n" +
                            $"Hết hạn: {expiry:yyyy-MM-dd}",
                            "Cập nhật License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch 
                {
                    MessageBox.Show("Vui lòng cấu hình Database", "Thông báo");
                    pDB.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật license: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
