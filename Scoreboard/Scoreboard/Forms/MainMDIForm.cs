using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data;
using Scoreboard.Models;
using static MaterialSkin.MaterialSkinManager;

namespace Scoreboard
{
    public partial class MainMDIForm : Form
    {
        private UserModel currentUser;

        public MainMDIForm()
        {
            InitializeComponent(); // designer only
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchsForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        }
        private void SetMenuVisibel(bool isLogin,bool isAdmin = true)
        {
            if (isLogin)
            {
                if (isAdmin)
                {
                    menuTournaments.Visible = true;
                    menuMatches.Visible = true;
                    menuUsers.Visible = true;
                    menuLogout.Enabled = true;
                    mLicense.Visible = true;
                }
                else 
                { 
                    menuTournaments.Visible = false;
                    menuMatches.Visible = false;
                    menuUsers.Visible = false;
                    mLicense.Visible = false;
                    menuLogout.Enabled = true;
                }
                mDB.Visible = false;
            }       
            else
            {
                menuTournaments.Visible = false;
                menuMatches.Visible = false;
                menuUsers.Visible = false;
                mLicense.Visible = false;
                menuLogout.Enabled = false;
                mDB.Visible = true;
            }
        }
        private void menuTournaments_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(TournamentsForm),this, currentUser);
        }

        private void MainMDIForm_Load(object sender, EventArgs e)
        {
            // Khóa menu
            SetMenuVisibel(false);

            var login = new LoginForm(this);
            login.MdiParent = this;
            login.Dock = DockStyle.Fill;
            login.Show();
        }

        private void menuMatches_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(MatchsForm),currentUser);
        }
        private Form activeForm = null;
        private void OpenChildForm(Type formType, params object[] args)
        {
            Form existingForm = this.MdiChildren.FirstOrDefault(f => f.GetType() == formType);
            if (existingForm != null)
            {
                existingForm.BringToFront();
                existingForm.Dock = DockStyle.Fill;
                existingForm.Show();
                return;
            }

            Form newForm = null;
            try
            {
                newForm = (Form)Activator.CreateInstance(formType, args);
            }
            catch
            {
                newForm = (Form)Activator.CreateInstance(formType);
            }

            // Tạm ẩn các form cũ (đừng đóng trước khi form mới hiển thị)
            foreach (Form frm in this.MdiChildren)
            {
                frm.Hide();
            }

            newForm.MdiParent = this;
            newForm.Dock = DockStyle.Fill;
            newForm.Show();

            // Sau khi form mới đã hiển thị, ta mới dispose mấy form cũ
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != newForm && !(frm is LoginForm))
                    frm.Dispose();
            }

            activeForm = newForm;
        }
        public void EnableMenusAfterLogin(bool isAdmin, UserModel uc)
        {
            currentUser = uc;
            if (isAdmin)
            {
                SetMenuVisibel(true);
                OpenChildForm(typeof(TournamentsForm), this, currentUser);
            }
            else 
            {
                SetMenuVisibel(true,false);
                OpenChildForm(typeof(UserInfoForm), currentUser);
            }
        }
        public void OpenMatchsForm(UserModel uc)
        {
            currentUser = uc;
            OpenChildForm(typeof(MatchsForm), currentUser);
        }
        private void menuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SetMenuVisibel(false);
                try
                {
                    Repository.ClearUserActivity(currentUser.Id);
                }
                catch
                {
                }
                currentUser = null;
                foreach (Form frm in this.MdiChildren)
                {
                    if (!(frm is LoginForm))
                        frm.Hide();  // ❗ KHÔNG dùng Close()
                }
                // Kiểm tra LoginForm có tồn tại chưa
                var login = this.MdiChildren.OfType<LoginForm>().FirstOrDefault();
                if (login == null)
                {
                    login = new LoginForm(this);
                    login.MdiParent = this;
                    login.Dock = DockStyle.Fill;
                    login.Show();
                }
                else
                {
                    login.Show();
                    login.BringToFront();
                }

                activeForm = login;
            }
        }
        private void mLicense_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
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
                        LicenseVerifier.SyncLicenseFileToDB(targetPath, currentUser.Id);

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
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật license: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mDB_Click(object sender, EventArgs e)
        {
            ConfigDatabase configDatabase = new ConfigDatabase();
            configDatabase.ShowDialog();
        }

        private void menuUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(UsersForm),currentUser);
        }
    }
}
