using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Scoreboard.Database;
using Scoreboard;
using System.Text.RegularExpressions;

namespace Scoreboard.Forms
{
    public partial class AdminForm : MaterialForm
    {
        public AdminForm()
        {
            InitializeComponent();
            InitializeMaterialSkin();
        }

        private void InitializeMaterialSkin()
        {
            // Create and configure the MaterialSkinManager
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, 
                Primary.BlueGrey900, 
                Primary.BlueGrey500, 
                Accent.LightBlue200, 
                TextShade.WHITE
            );
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadUsersGrid();
            LoadMatchesGrid(dgTranDau);
        }

        private void LoadUsersGrid()
        {
            var users = Repository.GetAllUsers();
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = users;
        }

        private void LoadMatchesGrid(DataGridView dgv)
        {
            var matches = Repository.GetAllMatches();
            matches.Sort((a, b) => { int ra = a.Status; int rb = b.Status; if (ra != rb) return ra - rb; return b.Id - a.Id; });
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = matches;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUpdateUserDialog frmUser = new AddUpdateUserDialog();
            if (frmUser.ShowDialog() == DialogResult.OK)
            {
                LoadUsersGrid();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                if (user.UserRole == UserRole.Admin)
                {
                    MessageBox.Show("Không được xóa Admin");
                }
                else if (MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{user.Username}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Repository.DeleteUser(user.Id);
                    LoadUsersGrid();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var m = new MatchModel();
            m.Id = -1;
            AddUpdateMatchs mgAdd = new AddUpdateMatchs(m);
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                LoadMatchesGrid(dgTranDau);
            }
        }

        private void dgTranDau_DoubleClick(object sender, EventArgs e)
        {
            if (dgTranDau.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgTranDau.CurrentRow.Cells[dgTranDau.Columns.Count - 1].Value);
                var m = Repository.GetMatchById(id);
                AddUpdateMatchs mgAdd = new AddUpdateMatchs(m);
                if (mgAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadMatchesGrid(dgTranDau);
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int nRowSelect = 0;
            foreach (DataGridViewRow row in dgTranDau.Rows)
            {
                // Skip new row if AllowUserToAddRows = true
                if (row.IsNewRow) continue;
                // Get checkbox value
                bool isChecked = false;
                if (row.Cells["ShowToggle"].Value != null)
                {
                    // Check data type and convert to bool
                    isChecked = Convert.ToBoolean(row.Cells["ShowToggle"].Value);
                }
                // Custom operation
                if (isChecked)
                {
                    nRowSelect++;
                }
                if (nRowSelect > 8)
                {
                    MessageBox.Show("Không thể load toggle trên 8 trận!");
                    return;
                }
            }
            if (nRowSelect == 0)
            {
                MessageBox.Show("Chưa chọn trận nào để hiển thị toggle!");
                return;
            }
            foreach (DataGridViewRow row in dgTranDau.Rows)
            {
                if (row.IsNewRow) continue;
                bool isChecked = false;
                if (row.Cells["ShowToggle"].Value != null)
                {
                    isChecked = Convert.ToBoolean(row.Cells["ShowToggle"].Value);
                }
                if (isChecked)
                {
                    int id = Convert.ToInt32(dgTranDau.CurrentRow.Cells[dgTranDau.Columns.Count - 1].Value);
                    var m = Repository.GetMatchById(id);
                    if (m != null)
                    {
                        m.ShowToggle = true;
                        Repository.UpdateMatch(m);
                    }
                }
            }
            Toggle frmToggle = new Toggle();
            frmToggle.ShowDialog();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            AddUpdateUserDialog frmUser = new AddUpdateUserDialog();
            frmUser.ShowDialog();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                AddUpdateUserDialog frmUser = new AddUpdateUserDialog(user);
                if (frmUser.ShowDialog() == DialogResult.OK)
                {
                    LoadUsersGrid();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng để sửa.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgTranDau.SelectedRows.Count > 0)
            {
                var match = (MatchModel)dgTranDau.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa trận đấu '{match.Title}'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Repository.DeleteMatch(match.Id);
                    LoadMatchesGrid(dgTranDau);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một trận đấu để xóa.");
            }
        }

        private void dgvUsers_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                Console.Write(dgvUsers);
                int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserId"].Value);
                var user = Repository.GetUsersById(id);
                AddUpdateUserDialog frmUser = new AddUpdateUserDialog(user);
                if (frmUser.ShowDialog() == DialogResult.OK)
                {
                    LoadUsersGrid();
                }
            }
        }
    }
}