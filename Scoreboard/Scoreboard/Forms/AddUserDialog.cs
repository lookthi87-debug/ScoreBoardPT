using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public class AddUserDialog : Form
    {
        private int? editingUserId;

        private MaterialButton btnSave;
        private MaterialButton btnCancel;
        private TextBox txtUser;
        private Label lblUser;
        private ComboBox cbRole;
        private Label lblTrongTai;
        private TextBox txtName;
        private Label label1;
        private CheckBox cReset;
        private Label lblPassDefault;
        private TextBox txtPhone;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private Label lblId;

        public AddUserDialog(int? userId = null)
        {
            InitializeComponent();
            editingUserId = userId;
            LoadRoles();

            if (editingUserId.HasValue)
            {
                LoadUser(editingUserId.Value);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserDialog));
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblTrongTai = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cReset = new System.Windows.Forms.CheckBox();
            this.lblPassDefault = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
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
            this.btnSave.Location = new System.Drawing.Point(384, 224);
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
            this.btnCancel.Location = new System.Drawing.Point(188, 224);
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
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUser.Location = new System.Drawing.Point(187, 30);
            this.txtUser.MaxLength = 100;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(217, 29);
            this.txtUser.TabIndex = 0;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(29, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(152, 23);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRole
            // 
            this.cbRole.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Addmin",
            "User"});
            this.cbRole.Location = new System.Drawing.Point(187, 165);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(217, 29);
            this.cbRole.TabIndex = 2;
            // 
            // lblTrongTai
            // 
            this.lblTrongTai.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrongTai.Location = new System.Drawing.Point(71, 165);
            this.lblTrongTai.Name = "lblTrongTai";
            this.lblTrongTai.Size = new System.Drawing.Size(110, 23);
            this.lblTrongTai.TabIndex = 22;
            this.lblTrongTai.Text = "Quyền";
            this.lblTrongTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtName.Location = new System.Drawing.Point(187, 62);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(492, 29);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Họ và tên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cReset
            // 
            this.cReset.AutoSize = true;
            this.cReset.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cReset.Location = new System.Drawing.Point(425, 169);
            this.cReset.Name = "cReset";
            this.cReset.Size = new System.Drawing.Size(144, 25);
            this.cReset.TabIndex = 3;
            this.cReset.Text = "Reset password";
            this.cReset.UseVisualStyleBackColor = true;
            // 
            // lblPassDefault
            // 
            this.lblPassDefault.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassDefault.Location = new System.Drawing.Point(567, 20);
            this.lblPassDefault.Name = "lblPassDefault";
            this.lblPassDefault.Size = new System.Drawing.Size(10, 23);
            this.lblPassDefault.TabIndex = 25;
            this.lblPassDefault.Text = "Abc12345";
            this.lblPassDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPassDefault.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPhone.Location = new System.Drawing.Point(187, 95);
            this.txtPhone.MaxLength = 30;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(217, 29);
            this.txtPhone.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Điện thoại";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtEmail.Location = new System.Drawing.Point(187, 130);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(492, 29);
            this.txtEmail.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Email";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblId.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(611, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 23);
            this.lblId.TabIndex = 30;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblId.Visible = false;
            // 
            // AddUserDialog
            // 
            this.ClientSize = new System.Drawing.Size(688, 303);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPassDefault);
            this.Controls.Add(this.cReset);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.lblTrongTai);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin user";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddUserDialog_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadRoles()
        {
            try
            {
                var roles = Repository.GetAllRoles();
                cbRole.DataSource = roles;
                cbRole.DisplayMember = "name";
                cbRole.ValueMember = "Id";
                cbRole.SelectedValue = 2;
            }
            catch
            {
                cbRole.Items.Clear();
                cbRole.Items.Add("User");
                cbRole.Items.Add("Admin");
            }
        }
        private void LoadUser(int id)
        {
            var u = Repository.GetUserById(id);
            if (u != null)
            {
                txtUser.Text = u.Name;
                txtUser.Enabled = false;
                txtName.Text = u.Fullname;
                txtEmail.Text = u.Email;
                txtPhone.Text = u.Phone;
                // don't show password
                try { cbRole.SelectedValue = u.RoleId; } catch { }
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            return Regex.IsMatch(phone, @"^(0[0-9]{9,10})$");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string fullName = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            int roleId = (cbRole.SelectedValue is int) ? (int)cbRole.SelectedValue : 0;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập username.");
                txtUser.Focus();
                return;
            }
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Vui lòng nhập name.");
                txtName.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email chưa đúng định dạng");
                    txtEmail.Focus();
                    return;
                }
            }
            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                if (!IsValidPhone(txtPhone.Text))
                {
                    MessageBox.Show("Điện thoại đang có chứa ký tự chuỗi");
                    txtPhone.Focus();
                    return;
                }
            }
            try
            {
                if (!editingUserId.HasValue)
                {
                    var exist = Repository.GetAllUsers().FirstOrDefault(x => x.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
                    if (exist != null)
                    {
                        MessageBox.Show("Username đã tồn tại.");
                        return;
                    }

                    var u = new UserModel { Name = username, Password = Security.HashPassword(lblPassDefault.Text), Fullname = fullName, RoleId = roleId, Phone = phone, Email = email };
                    Repository.AddUser(u);
                    MessageBox.Show("Tạo user thành công.");
                }
                else
                {
                    var u = Repository.GetUserById(editingUserId.Value);
                    if (u == null)
                    {
                        MessageBox.Show("User không tồn tại.");
                        return;
                    }

                    u.Fullname = fullName;
                    u.Phone = phone;
                    u.Email = email;
                    if (cReset.Checked == true)
                    {
                        u.Password = Security.HashPassword(lblPassDefault.Text); // hash recommended
                    }

                    u.RoleId = roleId;
                    Repository.UpdateUser(u);
                    MessageBox.Show("Cập nhật user thành công.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserDialog_Paint(object sender, PaintEventArgs e)
        {
            int radius = 30; // bo góc
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Bo góc form
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            // Áp dụng bo góc
            this.Region = new Region(path);

            // Viền nhẹ (giống web)
            using (Pen borderPen = new Pen(Color.LightGray, 1))
                g.DrawPath(borderPen, path);
        }
    }
}
