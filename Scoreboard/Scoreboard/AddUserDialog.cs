using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Database;

namespace Scoreboard
{
    public class AddUserDialog : MaterialForm
    {
        public string Role => comboRole.SelectedItem?.ToString() ?? "User";

        private MaterialButton btnSave;
        private MaterialButton btnCancel;
        private TextBox txtPassWord;
        private Label lblPassWord;
        private TextBox txtUserName;
        private Label lblUser;
        private ComboBox cbUser;
        private Label lblTrongTai;
        private TextBox txtName;
        private Label label1;
        private ComboBox comboRole;

        public AddUserDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.lblTrongTai = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(414, 307);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(218, 307);
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
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(218, 157);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(354, 29);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // lblPassWord
            // 
            this.lblPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassWord.Location = new System.Drawing.Point(60, 157);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(152, 23);
            this.lblPassWord.TabIndex = 10;
            this.lblPassWord.Text = "Mật khẩu";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(218, 116);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 29);
            this.txtUserName.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(60, 116);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(152, 23);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUser
            // 
            this.cbUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Items.AddRange(new object[] {
            "Addmin",
            "User"});
            this.cbUser.Location = new System.Drawing.Point(218, 250);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(354, 29);
            this.cbUser.TabIndex = 3;
            // 
            // lblTrongTai
            // 
            this.lblTrongTai.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrongTai.Location = new System.Drawing.Point(102, 250);
            this.lblTrongTai.Name = "lblTrongTai";
            this.lblTrongTai.Size = new System.Drawing.Size(110, 23);
            this.lblTrongTai.TabIndex = 22;
            this.lblTrongTai.Text = "Quyền";
            this.lblTrongTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtName.Location = new System.Drawing.Point(218, 203);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(354, 29);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Họ và tên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddUserDialog
            // 
            this.ClientSize = new System.Drawing.Size(707, 374);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.lblTrongTai);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm user";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var us = Repository.GetAllUsersById(txtUserName.Text);
                if (us.Count > 0) 
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại");
                    return;
                }
                Repository.AddUser(txtUserName.Text,txtPassWord.Text,cbUser.Text, txtName.Text);
                MessageBox.Show("Thêm thành công");
                return;
            }
            catch 
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
