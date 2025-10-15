using System;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data;
using Scoreboard.Models;
using System.Collections.Generic;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Scoreboard
{
    public class UsersForm : MaterialForm
    {
        private DataGridView dgUser;
        private MaterialButton btnAdd;
        private MaterialButton btnDelete;
        private TextBox txtFullName;
        private Label lblMatch;
        private MaterialButton btnSearch;
        private TextBox txtName;
        private Label label1;
        private MaterialButton btnCancel;
        private TextBox txtPhone;
        private Label lblPhone;
        private Label lblRole;
        private ComboBox cbRole;
        private TextBox txtEmail;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn fullname;
        private DataGridViewTextBoxColumn phone;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn RoleName;
        private DataGridViewTextBoxColumn id;
        private Label lblEmail;
        private UserModel user { get; set; }
        public UsersForm(UserModel us)
        {
            InitializeComponent();
            user = us;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblMatch = new System.Windows.Forms.Label();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.SuspendLayout();
            // 
            // dgUser
            // 
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AllowUserToDeleteRows = false;
            this.dgUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgUser.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.fullname,
            this.phone,
            this.email,
            this.RoleName,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUser.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgUser.Location = new System.Drawing.Point(17, 190);
            this.dgUser.Name = "dgUser";
            this.dgUser.RowHeadersVisible = false;
            this.dgUser.Size = new System.Drawing.Size(1086, 416);
            this.dgUser.TabIndex = 6;
            this.dgUser.DoubleClick += new System.EventHandler(this.dgUser_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.AutoSize = false;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(17, 619);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.UseAccentColor = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.AutoSize = false;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDelete.Depth = 0;
            this.btnDelete.HighEmphasis = true;
            this.btnDelete.Icon = null;
            this.btnDelete.Location = new System.Drawing.Point(183, 619);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(158, 36);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtFullName.Location = new System.Drawing.Point(171, 146);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(425, 29);
            this.txtFullName.TabIndex = 2;
            // 
            // lblMatch
            // 
            this.lblMatch.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatch.Location = new System.Drawing.Point(13, 146);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(152, 23);
            this.lblMatch.TabIndex = 11;
            this.lblMatch.Text = "Tên";
            this.lblMatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = false;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(661, 146);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(175, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSearch.UseAccentColor = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtName.Location = new System.Drawing.Point(171, 112);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(243, 29);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tài khoản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(945, 619);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 36);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPhone.Location = new System.Drawing.Point(594, 79);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(242, 29);
            this.txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(436, 79);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(152, 23);
            this.lblPhone.TabIndex = 21;
            this.lblPhone.Text = "Điện thoại";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(14, 79);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(152, 23);
            this.lblRole.TabIndex = 23;
            this.lblRole.Text = "Quyền hạn";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRole
            // 
            this.cbRole.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(171, 79);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(243, 29);
            this.cbRole.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtEmail.Location = new System.Drawing.Point(594, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 29);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(436, 112);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(152, 23);
            this.lblEmail.TabIndex = 26;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Tài khoản";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 200;
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            this.fullname.HeaderText = "Tên";
            this.fullname.Name = "fullname";
            this.fullname.ReadOnly = true;
            this.fullname.Width = 350;
            // 
            // phone
            // 
            this.phone.HeaderText = "Điện thoại";
            this.phone.Name = "phone";
            this.phone.Width = 180;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.Width = 200;
            // 
            // RoleName
            // 
            this.RoleName.DataPropertyName = "RoleName";
            this.RoleName.HeaderText = "Quyền hạn";
            this.RoleName.Name = "RoleName";
            this.RoleName.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 5;
            // 
            // UsersForm
            // 
            this.ClientSize = new System.Drawing.Size(1118, 671);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblMatch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgUser);
            this.Name = "UsersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý user";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadRoles()
        {
            try
            {
                List<RoleModel> lrole = new List<RoleModel>();
                RoleModel rl = new RoleModel();
                rl.Id = 0;
                rl.Name = "";
                lrole.Add(rl);
                var role = Repository.GetAllRoles();
                foreach (RoleModel r in role)
                {
                    lrole.Add(r);
                }
                cbRole.DataSource = lrole;
                cbRole.DisplayMember = "Name";
                cbRole.ValueMember = "Id";
                cbRole.SelectedIndex = 0;
            }
            catch
            {
                cbRole.Items.Clear();
                cbRole.Items.Add("No data");
                MessageBox.Show("Không có dữ liệu quyền hạn. Vui lòng tạo");
            }
        }
        //Load toàn bộ data
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUsers();
        }
        private void LoadUsers(string role_id ="",string nameFilter = "", string fullnameFilter = "", string fullphoneFiler = "", string fullemailFiler = "")
        {
            var users = Repository.GetAllUsers() ?? new List<UserModel>();

            if (!string.IsNullOrWhiteSpace(role_id) & role_id != "0")
            {
                int id = int.Parse(role_id);
                users = users
                    .Where(u => u.RoleId == id)
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                users = users
                    .Where(u => !string.IsNullOrEmpty(u.Name) &&
                                u.Name.IndexOf(nameFilter, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(fullnameFilter))
            {
                users = users
                    .Where(u => !string.IsNullOrEmpty(u.Fullname) &&
                                u.Fullname.IndexOf(fullnameFilter, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            if (!string.IsNullOrWhiteSpace(fullphoneFiler))
            {
                users = users
                    .Where(u => !string.IsNullOrEmpty(u.Phone) &&
                                u.Phone.IndexOf(fullphoneFiler, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            if (!string.IsNullOrWhiteSpace(fullemailFiler))
            {
                users = users
                    .Where(u => !string.IsNullOrEmpty(u.Email) &&
                                u.Email.IndexOf(fullemailFiler, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            dgUser.AutoGenerateColumns = false;
            dgUser.DataSource = users;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(cbRole.SelectedValue.ToString(), txtName.Text.Trim(), txtFullName.Text.Trim(),txtPhone.Text.Trim(),txtEmail.Text.ToString());
        }
        //Thêm trận đấu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new AddUserDialog();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(cbRole.SelectedValue.ToString(), txtName.Text.Trim(), txtFullName.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgUser.CurrentRow == null) return;

            int id = Convert.ToInt32(dgUser.CurrentRow.Cells["Id"].Value);
            string uname = dgUser.CurrentRow.Cells["name"].Value?.ToString() ?? "";

            var res = MessageBox.Show($"Bạn có chắc muốn xóa user '{uname}' ?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res != DialogResult.Yes) return;

            try
            {
                Repository.DeleteUser(id);
                MessageBox.Show("Xóa user thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers(cbRole.SelectedValue.ToString(), txtName.Text.Trim(), txtFullName.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa user: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgUser_DoubleClick(object sender, EventArgs e)
        {
            if (dgUser.CurrentRow == null) return;

            var id = Convert.ToInt32(dgUser.CurrentRow.Cells["Id"].Value);
            var frm = new AddUserDialog(id);
            if (frm.ShowDialog() == DialogResult.OK) 
            {
                LoadUsers(cbRole.SelectedValue.ToString(), txtName.Text.Trim(), txtFullName.Text.Trim(), txtPhone.Text.Trim(), txtEmail.Text.ToString());
            }
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
