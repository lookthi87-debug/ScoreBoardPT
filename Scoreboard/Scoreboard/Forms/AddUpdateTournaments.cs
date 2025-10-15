using System;
using System.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Scoreboard
{
    public class AddUpdateTournaments : MaterialForm
    {
        private Label lblTenGiaiDau;
        private System.Windows.Forms.TextBox txtName;
        private Label label4;
        private MaterialButton btnCancel;
        private MaterialButton btnSave;
        private Label lblId;
        private Label lblClassMatch;
        private System.Windows.Forms.ComboBox cbMatchClass;
        private DateTimePicker dStart;
        private DateTimePicker dEnd;
        private Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private Label lblNote;
        private TournamentModel currentTournament;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateTournaments));
            this.lblTenGiaiDau = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblId = new System.Windows.Forms.Label();
            this.lblClassMatch = new System.Windows.Forms.Label();
            this.cbMatchClass = new System.Windows.Forms.ComboBox();
            this.dStart = new System.Windows.Forms.DateTimePicker();
            this.dEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTenGiaiDau
            // 
            this.lblTenGiaiDau.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGiaiDau.Location = new System.Drawing.Point(29, 114);
            this.lblTenGiaiDau.Name = "lblTenGiaiDau";
            this.lblTenGiaiDau.Size = new System.Drawing.Size(110, 23);
            this.lblTenGiaiDau.TabIndex = 0;
            this.lblTenGiaiDau.Text = "Tên giải đấu";
            this.lblTenGiaiDau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtName.Location = new System.Drawing.Point(145, 114);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(485, 29);
            this.txtName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bắt đầu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(146, 302);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 36);
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
            this.btnSave.Location = new System.Drawing.Point(321, 302);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblId.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(6, 65);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(27, 23);
            this.lblId.TabIndex = 18;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblId.Visible = false;
            // 
            // lblClassMatch
            // 
            this.lblClassMatch.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassMatch.Location = new System.Drawing.Point(29, 78);
            this.lblClassMatch.Name = "lblClassMatch";
            this.lblClassMatch.Size = new System.Drawing.Size(110, 23);
            this.lblClassMatch.TabIndex = 25;
            this.lblClassMatch.Text = "Bộ môn";
            this.lblClassMatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMatchClass
            // 
            this.cbMatchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatchClass.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbMatchClass.FormattingEnabled = true;
            this.cbMatchClass.Location = new System.Drawing.Point(145, 78);
            this.cbMatchClass.Name = "cbMatchClass";
            this.cbMatchClass.Size = new System.Drawing.Size(325, 29);
            this.cbMatchClass.TabIndex = 0;
            // 
            // dStart
            // 
            this.dStart.CustomFormat = "dd/MM/yyyy";
            this.dStart.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.dStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dStart.Location = new System.Drawing.Point(146, 151);
            this.dStart.Name = "dStart";
            this.dStart.Size = new System.Drawing.Size(107, 29);
            this.dStart.TabIndex = 2;
            // 
            // dEnd
            // 
            this.dEnd.CustomFormat = "dd/MM/yyyy";
            this.dEnd.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.dEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dEnd.Location = new System.Drawing.Point(363, 151);
            this.dEnd.Name = "dEnd";
            this.dEnd.Size = new System.Drawing.Size(107, 29);
            this.dEnd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "Kết thúc";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtDescription.Location = new System.Drawing.Point(145, 195);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(485, 94);
            this.txtDescription.TabIndex = 34;
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(29, 223);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(110, 29);
            this.lblNote.TabIndex = 35;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddUpdateTournaments
            // 
            this.ClientSize = new System.Drawing.Size(655, 363);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dEnd);
            this.Controls.Add(this.dStart);
            this.Controls.Add(this.cbMatchClass);
            this.Controls.Add(this.lblClassMatch);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTenGiaiDau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateTournaments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin giải đấu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadClass()
        {
            try
            {
                var sets = Repository.GetAllMatchClasses();
                cbMatchClass.DataSource = sets;
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
        private void PopulateFromModel(TournamentModel t)
        {
            lblId.Text = t.Id.ToString();
            txtName.Text = t.Name;
            dStart.Text = t.Start.ToString();
            dEnd.Text = t.End.ToString();
            try { cbMatchClass.SelectedValue = t.match_class_id; } catch { }
            cbMatchClass.Text = t.match_class_name?? "";
        }
        public AddUpdateTournaments(int TournamentsId = -1)
        {
            InitializeComponent();
            LoadClass();
            dEnd.Value = dStart.Value.AddDays(10);

            if (TournamentsId != -1)
            {
                // edit mode
                currentTournament = Repository.GetAllTournamentsById(TournamentsId);
                if (currentTournament != null)
                    PopulateFromModel(currentTournament);
                else
                {
                    MessageBox.Show("Không tìm thấy giải đấu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblId.Text = "";
                    currentTournament = new TournamentModel();
                }
            }
            else
            {
                lblId.Text = "";
                // create mode
                currentTournament = new TournamentModel();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbMatchClass.Text.Trim()== "")
            {
                MessageBox.Show("Vui lòng chọn bộ môn thi đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMatchClass.Focus();
                return;
            }
            // validation
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên giải đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (dStart.Value.Date > dEnd.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dEnd.Focus();
                return;
            }
            // map
            currentTournament.Name = txtName.Text;
            currentTournament.match_class_id= (cbMatchClass.SelectedValue is int) ? (int)cbMatchClass.SelectedValue : 0;
            currentTournament.Start = dStart.Value;
            currentTournament.End = dEnd.Value;
            currentTournament.Description = txtDescription.Text;
            try
            {
                if (string.IsNullOrWhiteSpace(lblId.Text))
                {
                    Repository.AddTournament(currentTournament);
                    MessageBox.Show("Tạo mới thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Repository.UpdateTournament(currentTournament);
                    MessageBox.Show("Cập nhật thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
