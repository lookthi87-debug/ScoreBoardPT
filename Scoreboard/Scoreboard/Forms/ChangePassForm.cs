using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public class ChangePassForm : Form
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
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private UserModel User;
        public ChangePassForm(UserModel us)
        {
            InitializeComponent();
            if (us != null)
            {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(232, 47);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 29);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "admin";
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(29, 47);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(196, 23);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tên đăng nhập";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWord.Location = new System.Drawing.Point(232, 88);
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
            this.lblPassWord.Location = new System.Drawing.Point(29, 88);
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
            this.btnCancel.Location = new System.Drawing.Point(232, 221);
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
            this.btnSave.Location = new System.Drawing.Point(428, 221);
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
            this.txtPassWordNew.Location = new System.Drawing.Point(232, 129);
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
            this.label1.Location = new System.Drawing.Point(29, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mật khẩu mới";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassWordNewCf
            // 
            this.txtPassWordNewCf.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPassWordNewCf.Location = new System.Drawing.Point(232, 172);
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
            this.label2.Location = new System.Drawing.Point(29, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu mới (xác nhận)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 534);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.txtPassWordNewCf);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblPassWord);
            this.panel1.Controls.Add(this.txtPassWordNew);
            this.panel1.Controls.Add(this.txtPassWord);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(81, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 311);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ChangePassForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            if (string.IsNullOrEmpty(username))
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
            if (!Security.VerifyPassword(txtPassWord.Text, User.Password))
            {
                MessageBox.Show("Sai mật khẩu!");
                txtPassWord.Clear();
                txtPassWord.Focus();
                return;
            }
            if (txtPassWordNew.Text.Trim().Length == 0)
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
            if (txtPassWordNewCf.Text.Length == 0)
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
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 20;   // độ bo góc
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
