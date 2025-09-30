using System;
using System.Linq;
using System.Windows.Forms;
using Scoreboard.Database;
using System.Collections.Generic;
using MaterialSkin.Controls;

namespace Scoreboard
{
    public class AdminForm : MaterialForm
    {
        private DataGridView dgTranDau;
        private MaterialButton btnAdd;
        private MaterialButton btnDelete;
        private MaterialButton btnShow;
        private DataGridViewCheckBoxColumn ShowToggle;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Sets;
        private DataGridViewTextBoxColumn Team1;
        private DataGridViewTextBoxColumn Team2;
        private DataGridViewTextBoxColumn Score1;
        private DataGridViewTextBoxColumn Score2;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Id;
        private MaterialButton btnTaiKhoan;
        private ListBox lstMatches;
        private User user { get; set; }
        public AdminForm(User us)
        {
            InitializeComponent();
            user = us;
        }
        private void InitializeComponent()
        {
            this.dgTranDau = new System.Windows.Forms.DataGridView();
            this.ShowToggle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnShow = new MaterialSkin.Controls.MaterialButton();
            this.btnTaiKhoan = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgTranDau)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTranDau
            // 
            this.dgTranDau.AllowUserToAddRows = false;
            this.dgTranDau.AllowUserToDeleteRows = false;
            this.dgTranDau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTranDau.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgTranDau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTranDau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShowToggle,
            this.Title,
            this.Sets,
            this.Team1,
            this.Team2,
            this.Score1,
            this.Score2,
            this.StartTime,
            this.Status,
            this.Id});
            this.dgTranDau.Location = new System.Drawing.Point(6, 67);
            this.dgTranDau.Name = "dgTranDau";
            this.dgTranDau.Size = new System.Drawing.Size(1285, 641);
            this.dgTranDau.TabIndex = 1;
            this.dgTranDau.DoubleClick += new System.EventHandler(this.dgTranDau_DoubleClick);
            // 
            // ShowToggle
            // 
            this.ShowToggle.DataPropertyName = "ShowToggle";
            this.ShowToggle.HeaderText = "Toggle";
            this.ShowToggle.Name = "ShowToggle";
            this.ShowToggle.Width = 50;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Tên Trận Đấu";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 300;
            // 
            // Sets
            // 
            this.Sets.DataPropertyName = "Sets";
            this.Sets.HeaderText = "Hiệp /Set";
            this.Sets.Name = "Sets";
            this.Sets.ReadOnly = true;
            this.Sets.Width = 90;
            // 
            // Team1
            // 
            this.Team1.DataPropertyName = "Team1";
            this.Team1.HeaderText = "Đội 1";
            this.Team1.Name = "Team1";
            this.Team1.ReadOnly = true;
            this.Team1.Width = 200;
            // 
            // Team2
            // 
            this.Team2.DataPropertyName = "Team2";
            this.Team2.HeaderText = "Đội 2";
            this.Team2.Name = "Team2";
            this.Team2.ReadOnly = true;
            this.Team2.Width = 200;
            // 
            // Score1
            // 
            this.Score1.DataPropertyName = "Score1";
            this.Score1.HeaderText = "Điểm đội 1";
            this.Score1.Name = "Score1";
            this.Score1.ReadOnly = true;
            this.Score1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Score1.Width = 90;
            // 
            // Score2
            // 
            this.Score2.DataPropertyName = "Score2";
            this.Score2.HeaderText = "Điểm đội 2";
            this.Score2.Name = "Score2";
            this.Score2.ReadOnly = true;
            this.Score2.Width = 90;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "Thời gian";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 120;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 5;
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
            this.btnAdd.Location = new System.Drawing.Point(6, 717);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 36);
            this.btnAdd.TabIndex = 2;
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
            this.btnDelete.Location = new System.Drawing.Point(172, 717);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(158, 36);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.AutoSize = false;
            this.btnShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShow.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnShow.Depth = 0;
            this.btnShow.HighEmphasis = true;
            this.btnShow.Icon = null;
            this.btnShow.Location = new System.Drawing.Point(1132, 717);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnShow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(158, 36);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Chọn lựa hiển thị";
            this.btnShow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnShow.UseAccentColor = false;
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaiKhoan.AutoSize = false;
            this.btnTaiKhoan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTaiKhoan.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTaiKhoan.Depth = 0;
            this.btnTaiKhoan.HighEmphasis = true;
            this.btnTaiKhoan.Icon = null;
            this.btnTaiKhoan.Location = new System.Drawing.Point(391, 717);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTaiKhoan.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(158, 36);
            this.btnTaiKhoan.TabIndex = 6;
            this.btnTaiKhoan.Text = "Thêm Tài Khoản";
            this.btnTaiKhoan.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTaiKhoan.UseAccentColor = false;
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(1297, 762);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgTranDau);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addmin quản lý trận đấu";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTranDau)).EndInit();
            this.ResumeLayout(false);

        }

        private void LoadMatchesGrid(DataGridView dgv)
        {
            var matches = Repository.GetAllMatches();
            matches.Sort((a, b) => { int ra = a.Status; int rb = b.Status; if (ra != rb) return ra - rb; return b.Id - a.Id; });
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = matches;
        }
        //Load toàn bộ data
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadMatchesGrid(dgTranDau);
        }
        //Thêm trận đấu
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            int nRowSelect = 0;
            foreach (DataGridViewRow row in dgTranDau.Rows)
            {
                // Bỏ qua dòng mới nếu AllowUserToAddRows = true
                if (row.IsNewRow) continue;
                // Lấy giá trị checkbox
                bool isChecked = false;
                if (row.Cells["ShowToggle"].Value != null)
                {
                    // Kiểm tra kiểu dữ liệu và convert sang bool
                    isChecked = Convert.ToBoolean(row.Cells["ShowToggle"].Value);
                }
                // Thao tác tuỳ ý
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

        private void dgTranDau_DoubleClick(object sender, EventArgs e)
        {
            if (dgTranDau.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgTranDau.CurrentRow.Cells[dgTranDau.Columns.Count-1].Value);
                var m = Repository.GetMatchById(id);
                AddUpdateMatchs mgAdd = new AddUpdateMatchs(m);
                if (mgAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadMatchesGrid(dgTranDau);
                }
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            AddUserDialog frmUser = new AddUserDialog();
            frmUser.ShowDialog();
        }
    }
}
