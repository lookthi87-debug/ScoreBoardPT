using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public class AddUpdateMatchsets : MaterialForm
    {
        private System.Windows.Forms.TextBox txtTeam1;
        private System.Windows.Forms.TextBox txtTeam2;
        private Label lblTeam2;
        private Label lblName;
        private Label lblScore;
        private Label label4;
        private NumericUpDown nScore1;
        private NumericUpDown nScore2;
        private MaterialButton btnCancel;
        private MaterialButton btnSave;
        private Label lblTrongTai;
        private System.Windows.Forms.CheckedListBox clbReferees;
        private System.Windows.Forms.TextBox txtMatchTime;
        private System.Windows.Forms.Button btnUpdateTime;
        private Label lblTeam1;
        private Label lblNote;
        private System.Windows.Forms.TextBox txtnote;
        private MaterialLabel txtClasssetsname;
        private MatchsetModel currentMatch;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateMatchsets));
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nScore1 = new System.Windows.Forms.NumericUpDown();
            this.nScore2 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblTrongTai = new System.Windows.Forms.Label();
            this.clbReferees = new System.Windows.Forms.CheckedListBox();
            this.txtMatchTime = new System.Windows.Forms.TextBox();
            this.btnUpdateTime = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.txtClasssetsname = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTeam1
            // 
            this.txtTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam1.Location = new System.Drawing.Point(139, 213);
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.ReadOnly = true;
            this.txtTeam1.Size = new System.Drawing.Size(303, 26);
            this.txtTeam1.TabIndex = 3;
            this.txtTeam1.TabStop = false;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.Blue;
            this.lblTeam1.Location = new System.Drawing.Point(220, 160);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(124, 50);
            this.lblTeam1.TabIndex = 2;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTeam2
            // 
            this.txtTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam2.Location = new System.Drawing.Point(457, 213);
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.ReadOnly = true;
            this.txtTeam2.Size = new System.Drawing.Size(303, 26);
            this.txtTeam2.TabIndex = 4;
            this.txtTeam2.TabStop = false;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.Blue;
            this.lblTeam2.Location = new System.Drawing.Point(544, 160);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(124, 50);
            this.lblTeam2.TabIndex = 4;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(23, 213);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 29);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(23, 255);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(110, 29);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "Điểm số";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thời gian";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nScore1
            // 
            this.nScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore1.Location = new System.Drawing.Point(139, 253);
            this.nScore1.Name = "nScore1";
            this.nScore1.Size = new System.Drawing.Size(108, 26);
            this.nScore1.TabIndex = 5;
            this.nScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nScore2
            // 
            this.nScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore2.Location = new System.Drawing.Point(457, 253);
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
            this.btnCancel.Location = new System.Drawing.Point(249, 449);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 36);
            this.btnCancel.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(424, 449);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTrongTai
            // 
            this.lblTrongTai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrongTai.Location = new System.Drawing.Point(23, 292);
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
            this.clbReferees.Location = new System.Drawing.Point(139, 292);
            this.clbReferees.Name = "clbReferees";
            this.clbReferees.Size = new System.Drawing.Size(426, 67);
            this.clbReferees.TabIndex = 7;
            this.clbReferees.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbReferees_ItemCheck);
            this.clbReferees.Click += new System.EventHandler(this.clbReferees_Click);
            // 
            // txtMatchTime
            // 
            this.txtMatchTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMatchTime.ForeColor = System.Drawing.Color.Red;
            this.txtMatchTime.Location = new System.Drawing.Point(139, 78);
            this.txtMatchTime.Name = "txtMatchTime";
            this.txtMatchTime.ReadOnly = true;
            this.txtMatchTime.Size = new System.Drawing.Size(66, 26);
            this.txtMatchTime.TabIndex = 0;
            this.txtMatchTime.TabStop = false;
            this.txtMatchTime.Text = "00:00";
            this.txtMatchTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnUpdateTime
            // 
            this.btnUpdateTime.BackColor = System.Drawing.Color.Aqua;
            this.btnUpdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTime.Location = new System.Drawing.Point(207, 77);
            this.btnUpdateTime.Name = "btnUpdateTime";
            this.btnUpdateTime.Size = new System.Drawing.Size(44, 32);
            this.btnUpdateTime.TabIndex = 1;
            this.btnUpdateTime.Text = "Sửa";
            this.btnUpdateTime.UseVisualStyleBackColor = false;
            this.btnUpdateTime.Click += new System.EventHandler(this.btnUpdateTime_Click);
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(23, 374);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(110, 29);
            this.lblNote.TabIndex = 39;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnote
            // 
            this.txtnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtnote.Location = new System.Drawing.Point(139, 374);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(621, 66);
            this.txtnote.TabIndex = 38;
            // 
            // txtClasssetsname
            // 
            this.txtClasssetsname.Depth = 0;
            this.txtClasssetsname.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtClasssetsname.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.txtClasssetsname.Location = new System.Drawing.Point(27, 117);
            this.txtClasssetsname.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtClasssetsname.Name = "txtClasssetsname";
            this.txtClasssetsname.Size = new System.Drawing.Size(733, 41);
            this.txtClasssetsname.TabIndex = 40;
            this.txtClasssetsname.Text = "Hiệp";
            this.txtClasssetsname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddUpdateMatchsets
            // 
            this.ClientSize = new System.Drawing.Size(787, 511);
            this.Controls.Add(this.txtClasssetsname);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.btnUpdateTime);
            this.Controls.Add(this.txtMatchTime);
            this.Controls.Add(this.clbReferees);
            this.Controls.Add(this.lblTrongTai);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nScore2);
            this.Controls.Add(this.nScore1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTeam2);
            this.Controls.Add(this.lblTeam2);
            this.Controls.Add(this.txtTeam1);
            this.Controls.Add(this.lblTeam1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateMatchsets";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin hiệp đấu";
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadUsers()
        {
            try
            {
                var users = Repository.GetAllUsers().Where(u => u.RoleName != "Admin").ToList();
                clbReferees.Items.Clear();
                
                // Set the DisplayMember to show the Name property
                clbReferees.DisplayMember = "Name";

                foreach (var user in users)
                {
                    clbReferees.Items.Add(user, false); // Add user object with unchecked state
                }
                
                if (clbReferees.Items.Count > 0)
                {
                    clbReferees.SelectedIndex = 0;
                }
            }
            catch
            {
                clbReferees.Items.Clear();
                clbReferees.Items.Add("No data");
                MessageBox.Show("Không có dữ liệu trọng tài. Vui lòng tạo");
            }
        }
        private void PopulateFromModel(MatchsetModel m)
        {
            txtMatchTime.Text = m.Time ?? "00:00";
            txtClasssetsname.Text = m.ClassSetsName ?? "";
            txtTeam1.Text = m.Team1;
            txtTeam2.Text = m.Team2;
            
            // Load all users and check the current referee
            LoadUsers();
            
            // Handle single referee selection - check the current referee
            if (m.RefereeId.HasValue)
            {
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
            
            // Disable the CheckedListBox
            clbReferees.Enabled = false;
        }
        public AddUpdateMatchsets(string matchId = null, int id = -1)
        {
            InitializeComponent();
            currentMatch = new MatchsetModel();
            LoadUsers();
            if (matchId != null)
            {
                var m = Repository.GetMatchById(matchId);
                if (m != null)
                {
                    txtTeam1.Text = m.Team1;
                    txtTeam2.Text = m.Team2;
                    currentMatch.MatchId = matchId;
                    currentMatch.MatchClassId = m.MatchClassId;
                }
            }

            if (id != -1)
            {
                // edit mode
                currentMatch = Repository.GetMatchSetByMatchAndId(matchId, id);
                if (currentMatch != null)
                    PopulateFromModel(currentMatch);
                else
                {
                    MessageBox.Show("Không tìm thấy hiệp đấu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            currentMatch.MatchId = matchId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if exactly one referee is selected
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
                MessageBox.Show("Vui lòng chọn một trọng tài cho hiệp đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clbReferees.Focus();
                return;
            }
            // map
            currentMatch.Team1 = txtTeam1.Text.Trim();
            currentMatch.Team2 = txtTeam2.Text.Trim();
            currentMatch.Score1 = int.Parse(nScore1.Value.ToString());
            currentMatch.Score2 = int.Parse(nScore2.Value.ToString());
            currentMatch.Time = txtMatchTime.Text.Trim();
            // Set the selected referee
            if (selectedReferees.Count > 0)
            {
                currentMatch.RefereeId = selectedReferees[0].Id;
                currentMatch.RefereeName = selectedReferees[0].Name;
            }
            currentMatch.Note = txtnote.Text;
            try
            {
                if (currentMatch.Id == 0)
                {
                    Repository.AddMatchSet(currentMatch);
                    MessageBox.Show("Tạo mới thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Repository.UpdateMatchSet(currentMatch);
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
            up.MatchsetModel.Time = txtMatchTime.Text;
            up.ShowDialog();
            txtMatchTime.Text = up.MatchsetModel.Time;
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
    }
}
