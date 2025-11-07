using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public class TournamentsForm : Form
    {
        private DataGridView dgData;
        private MaterialButton btnAdd;
        private MaterialButton btnDelete;
        private MaterialButton btnSearch;
        private MaterialButton btnManageMatch;
        private ComboBox cbMatchClass;
        private Label lblClassMatch;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn match_class_name;
        private DataGridViewTextBoxColumn start;
        private DataGridViewTextBoxColumn end;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn id;
        private UserModel user;
        private MainMDIForm mainForm;
        public TournamentsForm(MainMDIForm parent,UserModel us)
        {
            InitializeComponent();
            user = us;
            mainForm = parent;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentsForm));
            this.dgData = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_class_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            this.btnManageMatch = new MaterialSkin.Controls.MaterialButton();
            this.cbMatchClass = new System.Windows.Forms.ComboBox();
            this.lblClassMatch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgData.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.match_class_name,
            this.start,
            this.end,
            this.description,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgData.Location = new System.Drawing.Point(17, 63);
            this.dgData.Name = "dgData";
            this.dgData.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(1046, 543);
            this.dgData.TabIndex = 5;
            this.dgData.DoubleClick += new System.EventHandler(this.dgUser_DoubleClick);
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Tên giải đấu";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // match_class_name
            // 
            this.match_class_name.DataPropertyName = "match_class_name";
            this.match_class_name.HeaderText = "Bộ môn";
            this.match_class_name.Name = "match_class_name";
            // 
            // start
            // 
            this.start.DataPropertyName = "start";
            this.start.HeaderText = "Ngày bắt đầu";
            this.start.Name = "start";
            this.start.ReadOnly = true;
			this.start.DefaultCellStyle.Format = "dd/MM/yyyy";
            // 
            // end
            // 
            this.end.DataPropertyName = "end";
            this.end.HeaderText = "Ngày kết thúc";
            this.end.Name = "end";
            this.end.DefaultCellStyle.Format = "dd/MM/yyyy";
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Ghi chú";
            this.description.Name = "description";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            this.btnAdd.TabIndex = 6;
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
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = false;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(503, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(151, 28);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSearch.UseAccentColor = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnManageMatch
            // 
            this.btnManageMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageMatch.AutoSize = false;
            this.btnManageMatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnManageMatch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnManageMatch.Depth = 0;
            this.btnManageMatch.HighEmphasis = true;
            this.btnManageMatch.Icon = null;
            this.btnManageMatch.Location = new System.Drawing.Point(905, 619);
            this.btnManageMatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnManageMatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnManageMatch.Name = "btnManageMatch";
            this.btnManageMatch.Size = new System.Drawing.Size(158, 36);
            this.btnManageMatch.TabIndex = 8;
            this.btnManageMatch.Text = "Quản  lý trận đấu";
            this.btnManageMatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnManageMatch.UseAccentColor = false;
            this.btnManageMatch.UseVisualStyleBackColor = true;
            this.btnManageMatch.Click += new System.EventHandler(this.btnManageMatch_Click);
            // 
            // cbMatchClass
            // 
            this.cbMatchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatchClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbMatchClass.FormattingEnabled = true;
            this.cbMatchClass.Location = new System.Drawing.Point(172, 16);
            this.cbMatchClass.Name = "cbMatchClass";
            this.cbMatchClass.Size = new System.Drawing.Size(324, 28);
            this.cbMatchClass.TabIndex = 0;
            // 
            // lblClassMatch
            // 
            this.lblClassMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassMatch.ForeColor = System.Drawing.Color.Black;
            this.lblClassMatch.Location = new System.Drawing.Point(12, 16);
            this.lblClassMatch.Name = "lblClassMatch";
            this.lblClassMatch.Size = new System.Drawing.Size(152, 29);
            this.lblClassMatch.TabIndex = 35;
            this.lblClassMatch.Text = "Bộ môn";
            this.lblClassMatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TournamentsForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1078, 671);
            this.ControlBox = false;
            this.Controls.Add(this.cbMatchClass);
            this.Controls.Add(this.lblClassMatch);
            this.Controls.Add(this.btnManageMatch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TournamentsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Quản lý giải đấu";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);

        }
        private void LoadClass()
        {
            try
            {
                var sets = Repository.GetAllMatchClasses();
                sets.Add(new MatchClassModel { Id = 0, Name = "Tất cả" });
                cbMatchClass.DataSource = sets.OrderBy(element => element.Id).ToList();
                cbMatchClass.DisplayMember = "Name";
                cbMatchClass.ValueMember = "Id";
                cbMatchClass.SelectedIndex = 0;
            }
            catch
            {
                cbMatchClass.Items.Clear();
                cbMatchClass.Items.Add("No data");
                MessageBox.Show("Không có dữ liệu bộ môn thi đấu. Vui lòng tạo");
            }
        }
        //Load toàn bộ data
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadClass();
            LoadTournaments(cbMatchClass.SelectedValue.ToString());
        }
        private void LoadTournaments(string Class_id = "")
        {
            var tournaments = Repository.GetAllTournaments() ?? new List<TournamentModel>();

            if (!string.IsNullOrWhiteSpace(Class_id))
            {
                int id = int.Parse(Class_id);
                if (id == 0)
                {
                    tournaments = tournaments.ToList();
                }
                else
                {
                    tournaments = tournaments
                                    .Where(u => u.match_class_id == id)
                                    .ToList();
                }
            }

            dgData.AutoGenerateColumns = false;
            dgData.DataSource = tournaments;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbMatchClass.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn bộ môn thi đấu");
                cbMatchClass.Focus();
                return;
            }
            LoadTournaments(cbMatchClass.SelectedValue.ToString());
        }

        //Thêm trận đấu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new AddUpdateTournaments();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadTournaments(cbMatchClass.SelectedValue.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgData.CurrentRow == null) return;

            int id = Convert.ToInt32(dgData.CurrentRow.Cells["Id"].Value);
            string uname = dgData.CurrentRow.Cells["name"].Value?.ToString() ?? "";

            var res = MessageBox.Show($"Bạn có chắc muốn xóa trận đấu '{uname}' ?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res != DialogResult.Yes) return;

            Repository.DeleteTournament(id);
            LoadTournaments(cbMatchClass.SelectedValue.ToString());
        }

        private void dgUser_DoubleClick(object sender, EventArgs e)
        {
            if (dgData.CurrentRow == null) return;

            var id = Convert.ToInt32(dgData.CurrentRow.Cells["Id"].Value);
            var frm = new AddUpdateTournaments(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadTournaments(cbMatchClass.SelectedValue.ToString());
            }
        }

        private void btnManageMatch_Click(object sender, EventArgs e)
        {
            mainForm.Invoke(new Action(() =>
            {
                mainForm.OpenMatchsForm(user);
            }));
            
            // Set the Matches menu item as selected when navigating to MatchsForm
            mainForm.SetSelectedMenuItem(mainForm.MenuMatches);
        }
    }
}
