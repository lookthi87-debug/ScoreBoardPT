using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Database;

namespace Scoreboard
{
    public class AddUpdateUserDialog : MaterialForm
    {
        private User _editingUser = null;
        
        public string Role => comboRole.SelectedItem?.ToString() ?? "User";

        private MaterialButton btnSave;
        private MaterialButton btnCancel;
        private TextBox txtPassWord;
        private Label lblPassWord;
        private TextBox txtUserName;
        private Label lblUser;
        private TextBox txtName;
        private Label lblName;
        private ComboBox comboRole;
        private Label lblRole;

        // Constructor for adding a new user
        public AddUpdateUserDialog()
        {
            InitializeComponent();
            this.Text = "Thêm user";
        }

        // Constructor for editing an existing user
        public AddUpdateUserDialog(User user) : this()
        {
            _editingUser = user;
            LoadUserData(user);
            this.Text = "Sửa user";
        }

        private void LoadUserData(User user)
        {
            if (user != null)
            {
                txtUserName.Text = user.Username;
                txtUserName.Enabled = false; // Don't allow changing username when editing
                txtName.Text = user.Name;
                comboRole.SelectedItem = user.Role;
                
                // Clear password field for security - user must enter new password to change it
                txtPassWord.Text = "";
            }
        }

        private void InitializeComponent()
        {
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
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
            this.txtPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(218, 157);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(354, 26);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // lblPassWord
            // 
            this.lblPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassWord.Location = new System.Drawing.Point(60, 157);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(152, 23);
            this.lblPassWord.TabIndex = 10;
            this.lblPassWord.Text = "Mật khẩu";
            this.lblPassWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtUserName.Location = new System.Drawing.Point(218, 116);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 26);
            this.txtUserName.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(60, 116);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(152, 23);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(218, 203);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(354, 26);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(60, 203);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(152, 23);
            this.lblName.TabIndex = 18;
            this.lblName.Text = "Họ và tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboRole
            // 
            this.comboRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Items.AddRange(Enum.GetNames(typeof(UserRole)));
            this.comboRole.Location = new System.Drawing.Point(218, 250);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(354, 28);
            this.comboRole.TabIndex = 3;
            this.comboRole.SelectedIndex = 0;
            this.comboRole.SelectedIndexChanged += new System.EventHandler(this.comboRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(102, 250);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(110, 23);
            this.lblRole.TabIndex = 20;
            this.lblRole.Text = "Quyền";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddUserDialog
            // 
            this.ClientSize = new System.Drawing.Size(707, 374);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
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
                if (_editingUser == null)
                {
                    // Adding a new user
                    if (string.IsNullOrEmpty(txtUserName.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên đăng nhập");
                        return;
                    }
                    
                    if (string.IsNullOrEmpty(txtPassWord.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu");
                        return;
                    }
                    
                    var us = Repository.GetAllUsersByUserName(txtUserName.Text);
                    if (us.Count > 0) 
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại");
                        return;
                    }
                    
                    Repository.AddUser(txtUserName.Text, txtPassWord.Text, comboRole.Text, txtName.Text);
                    MessageBox.Show("Thêm thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Editing an existing user
                    // Update user information
                    _editingUser.Name = txtName.Text;
                    _editingUser.Role = comboRole.Text;
                    
                    // Only update password if something was entered
                    if (!string.IsNullOrEmpty(txtPassWord.Text))
                    {
                        _editingUser.Password = txtPassWord.Text;
                    }
                    
                    Repository.UpdateUser(_editingUser);
                    MessageBox.Show("Cập nhật thành công");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle role selection change here if needed
            // For example, you can leave it empty if you don't need to do anything
        }
    }
}