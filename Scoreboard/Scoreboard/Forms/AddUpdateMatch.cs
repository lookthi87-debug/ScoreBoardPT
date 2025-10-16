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

namespace Scoreboard
{
    public class AddUpdateMatch : MaterialForm
    {
        private System.Windows.Forms.TextBox txtTeam1;
        private System.Windows.Forms.TextBox txtTeam2;
        private Label lblTeam2;
        private Label lblName;
        private Label lblScore;
        private NumericUpDown nScore1;
        private NumericUpDown nScore2;
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateMatch));
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.nScore1 = new System.Windows.Forms.NumericUpDown();
            this.nScore2 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblTrongTai = new System.Windows.Forms.Label();
            this.clbReferees = new System.Windows.Forms.CheckedListBox();
            this.lblMatch_Id = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).BeginInit();
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
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(32, 157);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(110, 29);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "Điểm";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nScore1
            // 
            this.nScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore1.Location = new System.Drawing.Point(148, 155);
            this.nScore1.Name = "nScore1";
            this.nScore1.Size = new System.Drawing.Size(108, 26);
            this.nScore1.TabIndex = 5;
            this.nScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nScore2
            // 
            this.nScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore2.Location = new System.Drawing.Point(466, 155);
            this.nScore2.Name = "nScore2";
            this.nScore2.Size = new System.Drawing.Size(108, 26);
            this.nScore2.TabIndex = 6;
            this.nScore2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(260, 423);
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
            this.btnSave.Location = new System.Drawing.Point(434, 423);
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
            this.lblTrongTai.Location = new System.Drawing.Point(32, 188);
            this.lblTrongTai.Name = "lblTrongTai";
            this.lblTrongTai.Size = new System.Drawing.Size(110, 29);
            this.lblTrongTai.TabIndex = 20;
            this.lblTrongTai.Text = "Trọng tài";
            this.lblTrongTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clbReferees
            // 
            this.clbReferees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.clbReferees.FormattingEnabled = true;
            this.clbReferees.Location = new System.Drawing.Point(148, 188);
            this.clbReferees.Name = "clbReferees";
            this.clbReferees.Size = new System.Drawing.Size(426, 120); // Increased height to accommodate multiple items
            this.clbReferees.TabIndex = 7;
            this.clbReferees.DisplayMember = "Name"; // Set DisplayMember to show the Name property
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
            this.lblNote.Location = new System.Drawing.Point(32, 320);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(110, 29);
            this.lblNote.TabIndex = 37;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnote
            // 
            this.txtnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtnote.Location = new System.Drawing.Point(148, 320);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(621, 94);
            this.txtnote.TabIndex = 8;
            // 
            // AddUpdateMatch
            // 
            this.ClientSize = new System.Drawing.Size(787, 500);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.lblMatch_Id);
            this.Controls.Add(this.clbReferees);
            this.Controls.Add(this.lblTrongTai);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nScore2);
            this.Controls.Add(this.nScore1);
            this.Controls.Add(this.lblScore);
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
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadUsers()
        {
            try
            {
                allUsers = Repository.GetAllUsers(); // Store all users for reference
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
        
        private void PopulateFromModel(MatchModel m)
        {
            lblMatch_Id.Text = m.Id.ToString();
            txtTeam1.Text = m.Team1;
            txtTeam2.Text = m.Team2;
            nScore1.Value = m.Score1;
            nScore2.Value = m.Score2;
            
            // Handle multiple referees
            if (m.RefereeIds != null && m.RefereeIds.Count > 0)
            {
                // Select referees in the CheckedListBox based on RefereeIds
                for (int i = 0; i < clbReferees.Items.Count; i++)
                {
                    if (clbReferees.Items[i] is UserModel user)
                    {
                        if (m.RefereeIds.Contains(user.Id))
                        {
                            clbReferees.SetItemChecked(i, true);
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
        }
        
        public AddUpdateMatch(int tournament_id, string id = "")
        {
            InitializeComponent();
            LoadUsers();
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
                MessageBox.Show("Vui lòng chọn ít nhất một trọng tài cho trận đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clbReferees.Focus();
                return;
            }
            
            // map
            currentMatch.Team1 = txtTeam1.Text.Trim();
            currentMatch.Team2 = txtTeam2.Text.Trim();
            currentMatch.Score1 = int.Parse(nScore1.Value.ToString());
            currentMatch.Score2 = int.Parse(nScore2.Value.ToString());
            
            // Handle multiple referees
            currentMatch.RefereeIds = new List<int>();
            currentMatch.RefereeNames = new List<string>();
            
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
            
            try
            {
                if (string.IsNullOrWhiteSpace(currentMatch.Id))
                {
                    currentMatch.Id = Repository.GenerateMatchCode();
                    Repository.AddMatch(currentMatch);
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

        private void btnUpdateTime_Click(object sender, EventArgs e)
        {
            UpdateTime up = new UpdateTime();
            up.ShowDialog();
        }
    }
}
