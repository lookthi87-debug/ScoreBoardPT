using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;

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
        public LoginForm()
        {
            InitializeComponent();
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
            try
            {
                this.pDB.Image = global::Scoreboard.Properties.Resources.DB;
            }
            catch
            {
                // If the resource cannot be loaded, leave the image as null
                this.pDB.Image = null;
            }
            this.pDB.Location = new System.Drawing.Point(535, 67);
            this.pDB.Name = "pDB";
            this.pDB.Size = new System.Drawing.Size(30, 30);
            this.pDB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pDB.TabIndex = 7;
            this.pDB.TabStop = false;
            this.pDB.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(571, 293);
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
    }
}
