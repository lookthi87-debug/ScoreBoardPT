using System;
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
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.TextBox txtMatchTime;
        private Label lblSet;
        private System.Windows.Forms.ComboBox cbSetMatch;
        private System.Windows.Forms.Button btnUpdateTime;
        private Label lblTeam1;
        private Label lblNote;
        private System.Windows.Forms.TextBox txtnote;
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
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.txtMatchTime = new System.Windows.Forms.TextBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.cbSetMatch = new System.Windows.Forms.ComboBox();
            this.btnUpdateTime = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTeam1
            // 
            this.txtTeam1.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtTeam1.Location = new System.Drawing.Point(139, 213);
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.ReadOnly = true;
            this.txtTeam1.Size = new System.Drawing.Size(303, 29);
            this.txtTeam1.TabIndex = 3;
            this.txtTeam1.TabStop = false;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Arial Unicode MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txtTeam2.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtTeam2.Location = new System.Drawing.Point(457, 213);
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.ReadOnly = true;
            this.txtTeam2.Size = new System.Drawing.Size(303, 29);
            this.txtTeam2.TabIndex = 4;
            this.txtTeam2.TabStop = false;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Arial Unicode MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.lblName.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(23, 213);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 29);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(23, 255);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(110, 29);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "Điểm số";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thời gian";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nScore1
            // 
            this.nScore1.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.nScore1.Location = new System.Drawing.Point(139, 253);
            this.nScore1.Name = "nScore1";
            this.nScore1.Size = new System.Drawing.Size(108, 29);
            this.nScore1.TabIndex = 5;
            this.nScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nScore2
            // 
            this.nScore2.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.nScore2.Location = new System.Drawing.Point(457, 253);
            this.nScore2.Name = "nScore2";
            this.nScore2.Size = new System.Drawing.Size(108, 29);
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
            this.btnCancel.Location = new System.Drawing.Point(249, 427);
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
            this.btnSave.Location = new System.Drawing.Point(424, 427);
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
            this.lblTrongTai.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrongTai.Location = new System.Drawing.Point(23, 292);
            this.lblTrongTai.Name = "lblTrongTai";
            this.lblTrongTai.Size = new System.Drawing.Size(110, 29);
            this.lblTrongTai.TabIndex = 20;
            this.lblTrongTai.Text = "Trọng tài";
            this.lblTrongTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUser
            // 
            this.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(139, 292);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(426, 29);
            this.cbUser.TabIndex = 7;
            // 
            // txtMatchTime
            // 
            this.txtMatchTime.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtMatchTime.ForeColor = System.Drawing.Color.Red;
            this.txtMatchTime.Location = new System.Drawing.Point(139, 78);
            this.txtMatchTime.Name = "txtMatchTime";
            this.txtMatchTime.ReadOnly = true;
            this.txtMatchTime.Size = new System.Drawing.Size(66, 29);
            this.txtMatchTime.TabIndex = 0;
            this.txtMatchTime.TabStop = false;
            this.txtMatchTime.Text = "00:00";
            this.txtMatchTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSet
            // 
            this.lblSet.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSet.Location = new System.Drawing.Point(23, 118);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(110, 29);
            this.lblSet.TabIndex = 27;
            this.lblSet.Text = "Hiệp / Set";
            this.lblSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSetMatch
            // 
            this.cbSetMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSetMatch.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbSetMatch.FormattingEnabled = true;
            this.cbSetMatch.Location = new System.Drawing.Point(139, 118);
            this.cbSetMatch.Name = "cbSetMatch";
            this.cbSetMatch.Size = new System.Drawing.Size(325, 29);
            this.cbSetMatch.TabIndex = 2;
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
            this.lblNote.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(23, 352);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(110, 29);
            this.lblNote.TabIndex = 39;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnote
            // 
            this.txtnote.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtnote.Location = new System.Drawing.Point(139, 324);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(621, 94);
            this.txtnote.TabIndex = 38;
            // 
            // AddUpdateMatchsets
            // 
            this.ClientSize = new System.Drawing.Size(787, 488);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.btnUpdateTime);
            this.Controls.Add(this.cbSetMatch);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.txtMatchTime);
            this.Controls.Add(this.cbUser);
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
                var users = Repository.GetAllUsers();
                cbUser.DataSource = users;
                cbUser.DisplayMember = "Name";
                cbUser.ValueMember = "Id";
                cbUser.SelectedIndex = 0;
            }
            catch
            {
                cbUser.Items.Clear();
                cbUser.Items.Add("No data");
                MessageBox.Show("Không có dữ liệu trọng tài. Vui lòng tạo");
            }
        }
        private void LoadClassSets()
        {
            try
            {
                var classsets = Repository.GetAllClassSetsByClassId(int.Parse(currentMatch.MatchClassId.ToString()));
                cbSetMatch.DataSource = classsets;
                cbSetMatch.DisplayMember = "Name";
                cbSetMatch.ValueMember = "Id";
                cbSetMatch.SelectedIndex = 0;
            }
            catch
            {
                cbSetMatch.Items.Clear();
                cbSetMatch.Items.Add("No data");
                MessageBox.Show("Không có dữ liệu hiệp đấu. Vui lòng tạo");
            }
        }
        private void PopulateFromModel(MatchsetModel m)
        {
            txtMatchTime.Text = m.Time ?? "00:00";
            try { cbSetMatch.SelectedValue = m.ClassSets_Id; } catch { }
            cbSetMatch.Text = m.ClassSetsName ?? "";
            txtTeam1.Text = m.Team1;
            txtTeam2.Text = m.Team2;
            try { cbUser.SelectedValue = m.RefereeId; } catch { }
            cbUser.Text = m.RefereeName ?? "";
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
                    try { cbUser.SelectedValue = m.RefereeId; } catch { }
                    cbUser.Text = m.RefereeName ?? "";
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

            LoadClassSets();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (cbSetMatch.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hiệp thi đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSetMatch.Focus();
                return;
            }

            if (currentMatch.MatchId != "")
            {
                var ms = Repository.GetMatchSetsByMatchId(currentMatch.MatchId);
                for (int i = 0; i < ms.Count; i++)
                {
                    if (int.Parse(cbSetMatch.SelectedValue.ToString()) == ms[i].ClassSets_Id)
                    {
                        MessageBox.Show("Hiệp đấu đã tồn tại trong trận này rồi. Vui lòng chọn hiếp tiếp theo.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbSetMatch.Focus();
                        return;
                    }
                }
            }

            if (cbUser.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn trọng tài hiệp đấu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbUser.Focus();
                return;
            }
            // map
            currentMatch.Team1 = txtTeam1.Text.Trim();
            currentMatch.Team2 = txtTeam2.Text.Trim();
            currentMatch.Score1 = int.Parse(nScore1.Value.ToString());
            currentMatch.Score2 = int.Parse(nScore2.Value.ToString());
            currentMatch.Time = txtMatchTime.Text.Trim();
            currentMatch.RefereeId = (cbUser.SelectedValue is int) ? (int)cbUser.SelectedValue : 0;
            currentMatch.Note = txtnote.Text;
            currentMatch.ClassSets_Id = (cbSetMatch.SelectedValue is int) ? (int)cbSetMatch.SelectedValue : 0;
            currentMatch.ClassSetsName = cbSetMatch.Text;
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
    }
}
