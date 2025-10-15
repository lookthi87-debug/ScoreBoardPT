using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Scoreboard
{
    public class ChangePassForm : MaterialForm
    {
        private TextBox txtUserName;
        private Label lblUser;
        private TextBox txtPassWord;
        private Label lblPassWord;
        private MaterialButton btnCancel;
        private TextBox txtPassWordNew;
        private Label label1;
        private TextBox txtPassWordNewCf;
        private Label label2;
        private MaterialButton btnSave;
        private UserModel User;
        public ChangePassForm(UserModel us)
        {
            InitializeComponent();
            if (us != null) {
                txtUserName.Text = us.Name;
                User = us;
            }
            else
            {
                txtUserName.Text = "";
            }
            txtPassWord.Text = "";
            txtPassWordNew.Text = "";
            txtPassWordNewCf.Text = "";
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassForm));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.txtPassWordNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassWordNewCf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(220, 79);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 29);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "admin";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(17, 79);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(196, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(220, 120);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(354, 29);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.Text = "admin123";
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // lblPassWord
            // 
            this.lblPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassWord.Location = new System.Drawing.Point(17, 120);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(196, 23);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "Mật khẩu";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(220, 253);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(416, 253);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Thay đổi";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPassWordNew
            // 
            this.txtPassWordNew.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWordNew.Location = new System.Drawing.Point(220, 161);
            this.txtPassWordNew.Name = "txtPassWordNew";
            this.txtPassWordNew.PasswordChar = '*';
            this.txtPassWordNew.Size = new System.Drawing.Size(354, 29);
            this.txtPassWordNew.TabIndex = 2;
            this.txtPassWordNew.Text = "admin123";
            this.txtPassWordNew.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mật khẩu mới";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWordNewCf
            // 
            this.txtPassWordNewCf.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWordNewCf.Location = new System.Drawing.Point(220, 204);
            this.txtPassWordNewCf.Name = "txtPassWordNewCf";
            this.txtPassWordNewCf.PasswordChar = '*';
            this.txtPassWordNewCf.Size = new System.Drawing.Size(354, 29);
            this.txtPassWordNewCf.TabIndex = 3;
            this.txtPassWordNewCf.Text = "admin123";
            this.txtPassWordNewCf.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu mới (xác nhận)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChangePassForm
            // 
            this.ClientSize = new System.Drawing.Size(614, 314);
            this.Controls.Add(this.txtPassWordNewCf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassWordNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            if (string.IsNullOrEmpty(username) )
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                txtPassWord.Focus();
                return;
            }
            User = Repository.GetUserByName(username);
            if (User == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                txtUserName.Focus();
                return;
            }
            if (Security.VerifyPassword(txtPassWord.Text, User.Password))
            {
                MessageBox.Show("Sai mật khẩu!");
                txtPassWord.Clear();
                txtPassWord.Focus();
                return;
            }
            if (txtPassWordNew.Text.Trim().Length==0)
            {
                MessageBox.Show("Chưa nhập mật khẩu mới.");
                txtPassWordNew.Clear();
                txtPassWordNew.Focus();
                return;
            }
            if (txtPassWordNew.Text.Trim().Length < 8)
            {
                MessageBox.Show("Mật khẩu phải từ 8 ký tự trở lên.");
                txtPassWordNew.Clear();
                txtPassWordNew.Focus();
                return;
            }
            if (txtPassWord.Text == txtPassWordNew.Text)
            {
                MessageBox.Show("Không được trùng mật khẩu cũ.");
                txtPassWordNew.Clear();
                txtPassWordNew.Focus();
                return;
            }
            if (txtPassWordNewCf.Text.Length==0)
            {
                MessageBox.Show("Chưa nhập xác nhận mật khẩu mới.");
                txtPassWordNewCf.Clear();
                txtPassWordNewCf.Focus();
                return;
            }
            if (txtPassWordNew.Text != txtPassWordNewCf.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu mới chưa khớp nhau.");
                txtPassWordNew.Focus();
                return;
            }
            //------------------------
            try
            {
                User.Password = Security.HashPassword(txtPassWordNew.Text);
                Repository.UpdateUser(User);
                MessageBox.Show("Thay đổi mật khẩu thành công.");
            }
            catch 
            {
                MessageBox.Show("Lỗi hệ thống.");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
