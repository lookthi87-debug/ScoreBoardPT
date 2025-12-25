using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using MaterialSkin.Controls;
using Scoreboard.Config;
using Scoreboard.Data;
using Scoreboard.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace Scoreboard.Forms
{
    public class TeamsForm : Form
    {
        private DataGridView dgTeam;
        private Label lblClassMatch;
        private MaterialButton btnDeleteTeam;
        private MaterialButton btnAddTeam;
        private Label label5;
        private MaterialButton btnSearch;
        private ComboBox cbTournaments;
        private DataGridViewTextBoxColumn NameTeam;
        private DataGridViewImageColumn Flag;
        private DataGridViewTextBoxColumn note;
        private DataGridViewTextBoxColumn id;
        private ComboBox cbMatchClass;
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamsForm));
            this.dgTeam = new System.Windows.Forms.DataGridView();
            this.NameTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblClassMatch = new System.Windows.Forms.Label();
            this.btnDeleteTeam = new MaterialSkin.Controls.MaterialButton();
            this.btnAddTeam = new MaterialSkin.Controls.MaterialButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            this.cbTournaments = new System.Windows.Forms.ComboBox();
            this.cbMatchClass = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTeam
            // 
            this.dgTeam.AllowUserToAddRows = false;
            this.dgTeam.AllowUserToDeleteRows = false;
            this.dgTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTeam.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTeam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTeam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameTeam,
            this.Flag,
            this.note,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTeam.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTeam.Location = new System.Drawing.Point(17, 98);
            this.dgTeam.MultiSelect = false;
            this.dgTeam.Name = "dgTeam";
            this.dgTeam.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgTeam.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTeam.Size = new System.Drawing.Size(928, 552);
            this.dgTeam.TabIndex = 1;
            this.dgTeam.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTeam_CellDoubleClick);
            // 
            // NameTeam
            // 
            this.NameTeam.DataPropertyName = "Name";
            this.NameTeam.FillWeight = 40F;
            this.NameTeam.HeaderText = "Đội";
            this.NameTeam.Name = "NameTeam";
            this.NameTeam.ReadOnly = true;
            // 
            // Flag
            // 
            this.Flag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Flag.DataPropertyName = "FlagImage";
            this.Flag.FillWeight = 5F;
            this.Flag.HeaderText = "Logo";
            this.Flag.Name = "Flag";
            this.Flag.ReadOnly = true;
            this.Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag.Width = 43;
            // 
            // note
            // 
            this.note.DataPropertyName = "Note";
            this.note.FillWeight = 65F;
            this.note.HeaderText = "Ghi chú";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // lblClassMatch
            // 
            this.lblClassMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassMatch.ForeColor = System.Drawing.Color.Black;
            this.lblClassMatch.Location = new System.Drawing.Point(12, 16);
            this.lblClassMatch.Name = "lblClassMatch";
            this.lblClassMatch.Size = new System.Drawing.Size(152, 29);
            this.lblClassMatch.TabIndex = 9;
            this.lblClassMatch.Text = "Môn thể thao";
            this.lblClassMatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTeam.AutoSize = false;
            this.btnDeleteTeam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteTeam.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteTeam.Depth = 0;
            this.btnDeleteTeam.HighEmphasis = true;
            this.btnDeleteTeam.Icon = null;
            this.btnDeleteTeam.Location = new System.Drawing.Point(183, 659);
            this.btnDeleteTeam.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteTeam.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(158, 36);
            this.btnDeleteTeam.TabIndex = 27;
            this.btnDeleteTeam.Text = "Xóa";
            this.btnDeleteTeam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteTeam.UseAccentColor = false;
            this.btnDeleteTeam.UseVisualStyleBackColor = true;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTeam.AutoSize = false;
            this.btnAddTeam.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddTeam.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddTeam.Depth = 0;
            this.btnAddTeam.HighEmphasis = true;
            this.btnAddTeam.Icon = null;
            this.btnAddTeam.Location = new System.Drawing.Point(17, 659);
            this.btnAddTeam.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddTeam.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(158, 36);
            this.btnAddTeam.TabIndex = 26;
            this.btnAddTeam.Text = "Thêm đội";
            this.btnAddTeam.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddTeam.UseAccentColor = false;
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 23);
            this.label5.TabIndex = 38;
            this.label5.Text = "Giải đấu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = false;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(503, 49);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 29);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSearch.UseAccentColor = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbTournaments
            // 
            this.cbTournaments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbTournaments.FormattingEnabled = true;
            this.cbTournaments.Location = new System.Drawing.Point(172, 50);
            this.cbTournaments.Name = "cbTournaments";
            this.cbTournaments.Size = new System.Drawing.Size(324, 28);
            this.cbTournaments.TabIndex = 39;
            this.cbTournaments.SelectedIndexChanged += new System.EventHandler(this.cbTournaments_SelectedIndexChanged);
            // 
            // cbMatchClass
            // 
            this.cbMatchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatchClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbMatchClass.FormattingEnabled = true;
            this.cbMatchClass.Location = new System.Drawing.Point(172, 16);
            this.cbMatchClass.Name = "cbMatchClass";
            this.cbMatchClass.Size = new System.Drawing.Size(324, 28);
            this.cbMatchClass.TabIndex = 7;
            this.cbMatchClass.SelectedIndexChanged += new System.EventHandler(this.cbMatchClass_SelectedIndexChanged);
            // 
            // TeamsForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(960, 710);
            this.ControlBox = false;
            this.Controls.Add(this.cbTournaments);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteTeam);
            this.Controls.Add(this.btnAddTeam);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblClassMatch);
            this.Controls.Add(this.cbMatchClass);
            this.Controls.Add(this.dgTeam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý trận đấu";
            ((System.ComponentModel.ISupportInitialize)(this.dgTeam)).EndInit();
            this.ResumeLayout(false);

        }
        private void LoadMatchClass(int matchClassId = -1, int tournamentId = -1)
        {
            try
            {
                cbMatchClass.DataSource = null;
                cbMatchClass.Items.Clear();
                var ml = Repository.GetAllMatchClasses()
                           .OrderBy(x => x.Id)
                           .ToList();

                cbMatchClass.DisplayMember = "Name";
                cbMatchClass.ValueMember = "Id";

                cbMatchClass.DataSource = ml;

                if (matchClassId != -1)
                {
                    cbMatchClass.SelectedValue = matchClassId;
                    LoadTournaments(matchClassId, tournamentId);
                }
                else
                {
                    cbMatchClass.SelectedIndex = 0;
                    LoadTournaments((int)cbMatchClass.SelectedValue);
                }
            }
            catch
            {
                cbMatchClass.DataSource = null;
                cbMatchClass.Items.Clear();

                cbMatchClass.Items.Add("No data");
                cbMatchClass.SelectedIndex = 0;
                cbMatchClass.Focus();

                MessageBox.Show("Không có dữ liệu. Vui lòng tạo");
            }
        }
        private void LoadTournaments(int classId = 0, int tournamentId = -1)
        {
            try
            {
                cbTournaments.DataSource = null;
                cbTournaments.Items.Clear();

                var tournaments = Repository.GetAllTournamentsByClassId(classId)
                                            .Where(t => t.End >= DateTime.Today)
                                            .ToList();

                cbTournaments.DisplayMember = "Name";
                cbTournaments.ValueMember = "Id";
                cbTournaments.DataSource = tournaments;

                if (tournamentId != -1)
                {
                    cbTournaments.SelectedValue = tournamentId;
                }
                else if (tournaments.Count > 0)
                {
                    cbTournaments.SelectedIndex = 0;
                }
                if (tournaments.Count == 0)
                {
                    btnAddTeam.Enabled = false;
                    btnDeleteTeam.Enabled = false;
                }
                else
                {
                    btnAddTeam.Enabled = true;
                    btnDeleteTeam.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cbTournaments.DataSource = null;
                cbTournaments.Items.Clear();

                cbTournaments.Items.Add("No data");
                cbTournaments.SelectedIndex = 0;
                cbTournaments.Focus();

                MessageBox.Show("Không có dữ liệu. Vui lòng tạo\n" + ex.Message);
            }
        }
        public TeamsForm(int matchClassId = -1, int tournamentId = -1)
        {
            InitializeComponent();

            dgTeam.AutoGenerateColumns = false;

            Flag.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgTeam.RowTemplate.Height = 30;

            LoadMatchClass(matchClassId, tournamentId);
            btnSearch_Click(this, new EventArgs());
        }

        private void LoadAllTeam()
        {
            try
            {
                var teams = Repository.GetTeamByTournamentsId((int)cbTournaments.SelectedValue);
                dgTeam.DataSource = teams;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Thêm trận đấu
        private void btnAddTeam_Click(object sender, EventArgs e)
        {

            if (cbTournaments.SelectedValue == null)
            {
                MessageBox.Show("Chưa có giải đấu nào.", "Hãy tạo giải đấu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddUpdateTeam mgAdd = new AddUpdateTeam((int)cbTournaments.SelectedValue);
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                LoadAllTeam();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgTeam.DataSource = null;

                if (string.IsNullOrWhiteSpace(cbTournaments.Text))
                {
                    MessageBox.Show("Chưa chọn giải đấu");
                    cbTournaments.Focus();
                    return;
                }

                // Load danh sách trận theo điều kiện
                LoadAllTeam();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void dgTeam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = int.Parse(dgTeam.Rows[e.RowIndex].Cells["Id"].Value.ToString());

            AddUpdateTeam mgAdd = new AddUpdateTeam(int.Parse(cbTournaments.SelectedValue.ToString()), id);
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                LoadAllTeam();
            }
        }
        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (dgTeam.CurrentRow == null) return;
            if (dgTeam.Rows.Count == 0) return;

            int id = int.Parse(dgTeam.CurrentRow.Cells["Id"].Value.ToString());
            try
            {
                Repository.DeleteTeam(int.Parse(cbTournaments.SelectedValue.ToString()),id);
                LoadAllTeam();
                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbMatchClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            int classId = 0; // mặc định = 0 nếu chưa chọn gì

            if (cbMatchClass.SelectedValue != null && int.TryParse(cbMatchClass.SelectedValue.ToString(), out int value))
            {
                classId = value;
            }

            LoadTournaments(classId);

            dgTeam.DataSource = null;
        }

        private void cbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgTeam.DataSource = null;
        }
    }
}