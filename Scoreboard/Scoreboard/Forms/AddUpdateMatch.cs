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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Globalization;

namespace Scoreboard
{
    public class AddUpdateMatch : MaterialForm
    {
        private System.Windows.Forms.TextBox txtTeam1;
        private System.Windows.Forms.TextBox txtTeam2;
        private Label lblTeam2;
        private Label lblName;
        private MaterialButton btnCancel;
        private MaterialButton btnSave;
        private Label lblTrongTai;
        private CheckedListBox clbReferees; // Changed from ComboBox to CheckedListBox for multiple selection
        private Label lblTeam1;
        private Label lblMatch_Id;
        private Label lblNote;
        private System.Windows.Forms.TextBox txtnote;
        private MatchModel currentMatch;
        private List<UserModel> allUsers; // Store all users for reference
		private Label lblStartTime;
		private DateTimePicker dtpStartTime;
        private Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateMatch));
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblTrongTai = new System.Windows.Forms.Label();
            this.clbReferees = new System.Windows.Forms.CheckedListBox();
            this.lblMatch_Id = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtTeam1
            // 
            this.txtTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam1.Location = new System.Drawing.Point(148, 122);
            this.txtTeam1.MaxLength = 100;
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.Size = new System.Drawing.Size(303, 26);
            this.txtTeam1.TabIndex = 3;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.Blue;
            this.lblTeam1.Location = new System.Drawing.Point(229, 69);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(124, 50);
            this.lblTeam1.TabIndex = 2;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTeam2
            // 
            this.txtTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam2.Location = new System.Drawing.Point(466, 122);
            this.txtTeam2.MaxLength = 100;
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.Size = new System.Drawing.Size(303, 26);
            this.txtTeam2.TabIndex = 4;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.Blue;
            this.lblTeam2.Location = new System.Drawing.Point(553, 69);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(124, 50);
            this.lblTeam2.TabIndex = 4;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(32, 122);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 29);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(252, 465);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 36);
            this.btnCancel.TabIndex = 10;
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
            this.btnSave.Location = new System.Drawing.Point(426, 465);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTrongTai
            // 
            this.lblTrongTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrongTai.Location = new System.Drawing.Point(32, 158);
            this.lblTrongTai.Name = "lblTrongTai";
            this.lblTrongTai.Size = new System.Drawing.Size(110, 29);
            this.lblTrongTai.TabIndex = 20;
            this.lblTrongTai.Text = "Trọng tài";
            this.lblTrongTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clbReferees
            // 
            this.clbReferees.DisplayMember = "Name";
            this.clbReferees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clbReferees.FormattingEnabled = true;
            this.clbReferees.Location = new System.Drawing.Point(148, 158);
            this.clbReferees.Name = "clbReferees";
            this.clbReferees.Size = new System.Drawing.Size(426, 109);
            this.clbReferees.TabIndex = 7;
            this.clbReferees.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbReferees_ItemCheck);
            this.clbReferees.Click += new System.EventHandler(this.clbReferees_Click);
            // 
            // lblMatch_Id
            // 
            this.lblMatch_Id.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblMatch_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatch_Id.Location = new System.Drawing.Point(710, 78);
            this.lblMatch_Id.Name = "lblMatch_Id";
            this.lblMatch_Id.Size = new System.Drawing.Size(27, 23);
            this.lblMatch_Id.TabIndex = 30;
            this.lblMatch_Id.Text = "Id";
            this.lblMatch_Id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMatch_Id.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(32, 325);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(110, 29);
            this.lblNote.TabIndex = 37;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnote
            // 
            this.txtnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtnote.Location = new System.Drawing.Point(148, 325);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(621, 94);
            this.txtnote.TabIndex = 9;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(32, 290);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(110, 29);
            this.lblStartTime.TabIndex = 36;
            this.lblStartTime.Text = "Thời gian";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(148, 290);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(108, 26);
            this.dtpStartTime.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(32, 425);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 29);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "Trạng thái";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(148, 425);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(200, 28);
            this.cbStatus.TabIndex = 10;
            // 
            // AddUpdateMatch
            // 
            this.ClientSize = new System.Drawing.Size(787, 520);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.lblMatch_Id);
            this.Controls.Add(this.clbReferees);
            this.Controls.Add(this.lblTrongTai);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTeam2);
            this.Controls.Add(this.lblTeam2);
            this.Controls.Add(this.txtTeam1);
            this.Controls.Add(this.lblTeam1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateMatch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin trận đấu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadUsers()
        {
            try
            {
                allUsers = Repository.GetAllUsers().Where(u => u.RoleName != "Admin").ToList(); // Store all users for reference
                clbReferees.Items.Clear();
                
                // Set the DisplayMember to show the Name property
                clbReferees.DisplayMember = "Name";
                
                foreach (var user in allUsers)
                {
                    clbReferees.Items.Add(user, false); // Add user object with unchecked state
                }
                
                if (clbReferees.Items.Count > 0)
                {
                    clbReferees.SelectedIndex = 0;
                }
            }
            catch {
                clbReferees.Items.Clear();
                clbReferees.Items.Add("No data");
                MessageBox.Show("Không có dữ liệu trọng tài. Vui lòng tạo");
            }
        }

        private void LoadStatus()
        {
            cbStatus.Items.Clear();
            cbStatus.Items.Add(new { Text = "Chưa bắt đầu", Value = "0" });
            cbStatus.Items.Add(new { Text = "Đang diễn ra", Value = "1" });
            cbStatus.Items.Add(new { Text = "Đã kết thúc", Value = "2" });
            cbStatus.DisplayMember = "Text";
            cbStatus.ValueMember = "Value";
            cbStatus.SelectedIndex = 0; // Default to "Chưa bắt đầu"
        }
        
        private void PopulateFromModel(MatchModel m)
        {
            lblMatch_Id.Text = m.Id.ToString();
            txtTeam1.Text = m.Team1;
            txtTeam2.Text = m.Team2;
            //nScore1.Value = m.Score1;
            //nScore2.Value = m.Score2;
            
            // Time: store HH:mm only
            currentMatch.Time = dtpStartTime.Value.ToString("HH:mm");

            // Set status
            if (!string.IsNullOrEmpty(m.Status))
            {
                for (int i = 0; i < cbStatus.Items.Count; i++)
                {
                    var item = cbStatus.Items[i];
                    var valueProperty = item.GetType().GetProperty("Value");
                    if (valueProperty != null && valueProperty.GetValue(item).ToString() == m.Status)
                    {
                        cbStatus.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Handle single referee selection
            if (m.RefereeIds != null && m.RefereeIds.Count > 0)
            {
                // Select only the first referee in the CheckedListBox
                for (int i = 0; i < clbReferees.Items.Count; i++)
                {
                    if (clbReferees.Items[i] is UserModel user)
                    {
                        if (m.RefereeIds.Contains(user.Id))
                        {
                            clbReferees.SetItemChecked(i, true);
                            break; // Only select the first match
                        }
                    }
                }
            }
            else if (m.RefereeId.HasValue)
            {
                // Fallback to single referee for backward compatibility
                for (int i = 0; i < clbReferees.Items.Count; i++)
                {
                    if (clbReferees.Items[i] is UserModel user)
                    {
                        if (user.Id == m.RefereeId.Value)
                        {
                            clbReferees.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
            
            txtnote.Text = m.Note;
            // Always set time to 00:00
            dtpStartTime.Value = DateTime.Today;
            this.Text = "Thông tin trận đấu: " + txtTeam1.Text + " - " + txtTeam2.Text;
        }

        public AddUpdateMatch(int tournament_id, string id = "")
        {
            InitializeComponent();
            // Set default time to 00:00
            dtpStartTime.Value = DateTime.Today;
            LoadUsers();
            LoadStatus();
            if (id != "")
            {
                // edit mode
                currentMatch = Repository.GetMatchById(id);
                if (currentMatch != null)
                    PopulateFromModel(currentMatch);
                else
                {
                    MessageBox.Show("Không tìm thấy trận đấu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentMatch = new MatchModel();
                    currentMatch.TournamentId = tournament_id;
                    lblMatch_Id.Text = "";
                }
            }
            else
            {
                // create mode
                currentMatch = new MatchModel();
                currentMatch.TournamentId = tournament_id;
                lblMatch_Id.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (txtTeam1.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhận tên đội 1", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeam1.Focus();
                return;
            }
            if (txtTeam2.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhận tên đội 2", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeam2.Focus();
                return;
            }
            if (txtTeam1.Text.Trim().ToUpper() == txtTeam2.Text.Trim().ToUpper())
            {
                MessageBox.Show("Trùng tên đội", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeam1.Focus();
                return;
            }

            // Check if at least one referee is selected
            var selectedReferees = new List<UserModel>();
            foreach (var item in clbReferees.CheckedItems)
            {
                if (item is UserModel user)
                {
                    selectedReferees.Add(user);
                }
            }
            
            if (selectedReferees.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một trọng tài cho trận đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clbReferees.Focus();
                return;
            }
            
            // map
            currentMatch.Team1 = txtTeam1.Text.Trim();
            currentMatch.Team2 = txtTeam2.Text.Trim();
            //currentMatch.Score1 = int.Parse(nScore1.Value.ToString());
            //currentMatch.Score2 = int.Parse(nScore2.Value.ToString());
            // Always save time as 00:00
            currentMatch.Time = "00:00";
            
            // Handle multiple referees
            currentMatch.RefereeIds = new List<int>();
            currentMatch.RefereeNames = new List<string>();
            currentMatch.Status = cbStatus.SelectedValue?.ToString();

            foreach (var referee in selectedReferees)
            {
                currentMatch.RefereeIds.Add(referee.Id);
                currentMatch.RefereeNames.Add(referee.Name);
            }
            
            // For backward compatibility, set the first referee as the main referee
            if (selectedReferees.Count > 0)
            {
                currentMatch.RefereeId = selectedReferees[0].Id;
                currentMatch.RefereeName = selectedReferees[0].Name;
            }
            
            currentMatch.Note = txtnote.Text.Trim();
            
            // Set status from combobox
            if (cbStatus.SelectedItem != null)
            {
                var selectedItem = cbStatus.SelectedItem;
                var valueProperty = selectedItem.GetType().GetProperty("Value");
                if (valueProperty != null)
                {
                    currentMatch.Status = valueProperty.GetValue(selectedItem).ToString();
                }
            }
            
            try
            {
                if (string.IsNullOrWhiteSpace(currentMatch.Id))
                {
                    currentMatch.Id = Repository.GenerateMatchCode();
                    Repository.AddMatch(currentMatch);
                    
                    // Auto-create the first match set (Hiệp 1) for the newly added match
                    if (currentMatch.TournamentId.HasValue)
                    {
                        var tournament = Repository.GetAllTournamentsById(currentMatch.TournamentId.Value);
                        if (tournament != null)
                        {
                            var classSets = Repository.GetAllClassSetsByClassId(tournament.match_class_id);
                            var firstClassSet = classSets != null && classSets.Count > 0 ? classSets[0] : null;

                            if (firstClassSet != null)
                            {
                                // Determine period name based on match class
                                string firstPeriodName = GetFirstPeriodName(tournament.match_class_id);

                                var firstSet = new MatchsetModel
                                {
                                    MatchId = currentMatch.Id,
                                    Team1 = currentMatch.Team1,
                                    Team2 = currentMatch.Team2,
                                    Score1 = 0,
                                    Score2 = 0,
                                    Time = "00:00",
                                    Note = "",
                                    Status = "1", // Active
                                    RefereeId = (currentMatch.RefereeIds != null && currentMatch.RefereeIds.Count > 0) ? (int?)currentMatch.RefereeIds[0] : null,
                                    RefereeName = currentMatch.RefereeName,
                                    ClassSets_Id = firstClassSet.Id,
                                    ClassSetsName = firstPeriodName, // Use "Hiệp 1" instead of firstClassSet.Name
                                    TournamentId = currentMatch.TournamentId,
                                    TournamentName = currentMatch.TournamentName,
                                    MatchClassId = currentMatch.MatchClassId,
                                    MatchClassName = currentMatch.MatchClassName
                                };
                                Repository.AddMatchSet(firstSet);
                            }
                        }
                    }
                    
                    MessageBox.Show("Tạo mới thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Repository.UpdateMatch(currentMatch);
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

        private void clbReferees_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // If the user is checking an item, uncheck all other items
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < clbReferees.Items.Count; i++)
                {
                    if (i != e.Index && clbReferees.GetItemChecked(i))
                    {
                        clbReferees.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void clbReferees_Click(object sender, EventArgs e)
        {
            // Get the index of the clicked item
            int index = clbReferees.IndexFromPoint(clbReferees.PointToClient(Cursor.Position));
            
            if (index >= 0)
            {
                // Toggle the checked state of the clicked item
                bool isCurrentlyChecked = clbReferees.GetItemChecked(index);
                clbReferees.SetItemChecked(index, !isCurrentlyChecked);
            }
        }

        private void btnUpdateTime_Click(object sender, EventArgs e)
        {
            UpdateTime up = new UpdateTime();
            up.ShowDialog();
        }

        private string GetFirstPeriodName(int matchClassId)
        {
            // Get match class info to determine period type
            var matchClass = Repository.GetMatchClassById(matchClassId);
            if (matchClass != null)
            {
                switch (matchClass.PeriodType?.ToLower())
                {
                    case "half":
                        return "Hiệp 1";
                    case "quarter":
                        return "Hiệp nhỏ 1";
                    case "set":
                        return "Set 1";
                    default:
                        return "Hiệp 1";
                }
            }
            else
            {
                return "Hiệp 1";
            }
        }

        // Helper method to convert status text to number
        public static string GetStatusText(string status)
        {
            return status == "0" ? "Chưa bắt đầu" :
                   status == "1" ? "Đang diễn ra" :
                   status == "2" ? "Đã kết thúc" : "Không xác định";
        }
    }
}
