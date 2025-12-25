using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Data;
using Scoreboard.Models;
using static MaterialSkin.MaterialSkinManager;
using MaterialSkin;
using Scoreboard.Forms;

namespace Scoreboard
{
    public partial class MainMDIForm : Form
    {
        private UserModel currentUser;
        // Store the currently selected menu item
        private ToolStripMenuItem selectedMenuItem;
        
        // Public properties to expose menu items
        public ToolStripMenuItem MenuTournaments => menuTournaments;
        public ToolStripMenuItem MenuMatches => menuMatches;
        public ToolStripMenuItem MenuUsers => menuUsers;
        public ToolStripMenuItem MenuLogout => menuLogout;
        public ToolStripMenuItem MenuLicense => mLicense;
        public ToolStripMenuItem MenuDB => mDB;

        public MainMDIForm()
        {
            InitializeComponent(); // designer only
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchsForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            
            // Initialize MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = Themes.LIGHT;
            
            // Set primary color to our main blue color (#3B82F6)
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600,  // Primary color - Xanh dương chủ đạo
                Primary.Blue700, 
                Primary.Blue400, 
                Accent.LightBlue200, 
                TextShade.WHITE
            );
            
            // Initialize menu highlighting after the form is loaded
            this.Load += MainMDIForm_LoadComplete;
        }
        
        // Initialize menu highlighting functionality after form is loaded
        private void MainMDIForm_LoadComplete(object sender, EventArgs e)
        {
            // Attach click event handlers to all menu items for highlighting
            menuTournaments.Click += (s, ev) => { SetSelectedMenuItem(menuTournaments); menuTournaments_Click(s, ev); };
            menuTeam.Click += (s, ev) => { SetSelectedMenuItem(menuTeam); menuTeam_Click(s, ev); };
            menuMatches.Click += (s, ev) => { SetSelectedMenuItem(menuMatches); menuMatches_Click(s, ev); };
            menuUsers.Click += (s, ev) => { SetSelectedMenuItem(menuUsers); menuUsers_Click(s, ev); };
            menuFlagVN.Click += (s, ev) => { SetSelectedMenuItem(menuFlagVN); menuFlagVN_Click(s, ev); };
            mLicense.Click += (s, ev) => { SetSelectedMenuItem(mLicense); mLicense_Click(s, ev); };
            mDB.Click += (s, ev) => { SetSelectedMenuItem(mDB); mDB_Click(s, ev); };
        }
        
        // Public method to allow other forms to set the selected menu item
        public void SetSelectedMenuItem(ToolStripMenuItem menuItem)
        {
            // Reset previous selection
            if (selectedMenuItem != null)
            {
                ResetMenuItemStyle(selectedMenuItem);
            }
            
            // Highlight the new selection
            HighlightMenuItem(menuItem);
            selectedMenuItem = menuItem;
        }
        
        // Highlight a menu item
        private void HighlightMenuItem(ToolStripMenuItem item)
        {
            // Store original colors
            item.Tag = new MenuItemColors 
            { 
                BackColor = item.BackColor, 
                ForeColor = item.ForeColor 
            };
            
            // Apply highlight colors (blue background with white text)
            item.BackColor = Color.FromArgb(59, 130, 246); // Our main blue color (#3B82F6)
            item.ForeColor = Color.White;
        }
        
        // Reset a menu item to its original colors
        private void ResetMenuItemStyle(ToolStripMenuItem item)
        {
            // Restore original colors if they were stored
            if (item.Tag is MenuItemColors colors)
            {
                item.BackColor = colors.BackColor;
                item.ForeColor = colors.ForeColor;
            }
            else
            {
                // Fallback to default colors if tag is not set
                item.BackColor = Color.Transparent;
                item.ForeColor = SystemColors.MenuText;
            }
        }
        
        // Helper class to store original menu item colors
        private class MenuItemColors
        {
            public Color BackColor { get; set; }
            public Color ForeColor { get; set; }
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
                    menuTeam.Visible = true;
                    menuFlagVN.Visible = true;
                }
                else 
                { 
                    menuTournaments.Visible = false;
                    menuMatches.Visible = false;
                    menuUsers.Visible = false;
                    mLicense.Visible = false;
                    menuLogout.Enabled = true;
                    menuTeam.Visible= false;
                    menuFlagVN.Visible= false;
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
                menuTeam.Visible = false;
                menuFlagVN.Visible = false;
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
        public void OpenChildForm(Type formType, params object[] args)
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
                // Highlight the Tournaments menu item by default for admin
                SetSelectedMenuItem(menuTournaments);
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
                // Reset menu highlighting on logout
                if (selectedMenuItem != null)
                {
                    ResetMenuItemStyle(selectedMenuItem);
                    selectedMenuItem = null;
                }
                
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


            SetMenuVisibel(false);
            
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

        private void menuUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(UsersForm),currentUser);
        }

        private void menuTeam_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(TeamsForm),-1,-1);
        }

        private void menuFlagVN_Click(object sender, EventArgs e)
        {
            OpenChildForm(typeof(AddUpdateFlagVN));
        }
    }
}