using System;
using System.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scoreboard
{
    public class AddUpdateMatchs : MaterialForm
    {
        private Label lblTenTranDau;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtTeam1;
        private System.Windows.Forms.TextBox txtTeam2;
        private Label lblTeam2;
        private Label lblName;
        private Label lblScore;
        private Label label3;
        private NumericUpDown nSets;
        private Label label4;
        private System.Windows.Forms.TextBox txtStartTime;
        private NumericUpDown nScore1;
        private NumericUpDown nScore2;
        private MaterialButton btnCancel;
        private MaterialButton btnSave;
        private Label lblId;
        private System.Windows.Forms.ComboBox cbSets;
        private Label lblTrongTai;
        private System.Windows.Forms.ComboBox cbUser;
        private Label lblTeam1;
        private void InitializeComponent()
        {
            this.lblTenTranDau = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nSets = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.nScore1 = new System.Windows.Forms.NumericUpDown();
            this.nScore2 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblId = new System.Windows.Forms.Label();
            this.cbSets = new System.Windows.Forms.ComboBox();
            this.lblTrongTai = new System.Windows.Forms.Label();
            this.cbUser = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenTranDau
            // 
            this.lblTenTranDau.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTranDau.Location = new System.Drawing.Point(29, 88);
            this.lblTenTranDau.Name = "lblTenTranDau";
            this.lblTenTranDau.Size = new System.Drawing.Size(110, 23);
            this.lblTenTranDau.TabIndex = 0;
            this.lblTenTranDau.Text = "Tên trận đấu";
            this.lblTenTranDau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtTitle.Location = new System.Drawing.Point(145, 88);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(621, 29);
            this.txtTitle.TabIndex = 1;
            // 
            // txtTeam1
            // 
            this.txtTeam1.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtTeam1.Location = new System.Drawing.Point(145, 231);
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.Size = new System.Drawing.Size(303, 29);
            this.txtTeam1.TabIndex = 8;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.Location = new System.Drawing.Point(145, 201);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(303, 27);
            this.lblTeam1.TabIndex = 2;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTeam2
            // 
            this.txtTeam2.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtTeam2.Location = new System.Drawing.Point(463, 231);
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.Size = new System.Drawing.Size(303, 29);
            this.txtTeam2.TabIndex = 9;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.Location = new System.Drawing.Point(463, 201);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(303, 27);
            this.lblTeam2.TabIndex = 4;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(29, 231);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 23);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(29, 277);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(110, 23);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "Điểm";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hiệp đấu";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nSets
            // 
            this.nSets.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.nSets.Location = new System.Drawing.Point(262, 157);
            this.nSets.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nSets.Name = "nSets";
            this.nSets.Size = new System.Drawing.Size(94, 29);
            this.nSets.TabIndex = 6;
            this.nSets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nSets.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thời gian";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtStartTime.Location = new System.Drawing.Point(145, 123);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(94, 29);
            this.txtStartTime.TabIndex = 3;
            this.txtStartTime.Text = "00:00";
            this.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nScore1
            // 
            this.nScore1.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.nScore1.Location = new System.Drawing.Point(145, 271);
            this.nScore1.Name = "nScore1";
            this.nScore1.Size = new System.Drawing.Size(108, 29);
            this.nScore1.TabIndex = 11;
            this.nScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nScore2
            // 
            this.nScore2.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.nScore2.Location = new System.Drawing.Point(463, 271);
            this.nScore2.Name = "nScore2";
            this.nScore2.Size = new System.Drawing.Size(108, 29);
            this.nScore2.TabIndex = 12;
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
            this.btnCancel.Location = new System.Drawing.Point(477, 373);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 36);
            this.btnCancel.TabIndex = 16;
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
            this.btnSave.Location = new System.Drawing.Point(652, 373);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 17;
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
            this.lblId.Location = new System.Drawing.Point(508, 144);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(184, 23);
            this.lblId.TabIndex = 18;
            this.lblId.Text = "Id";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblId.Visible = false;
            // 
            // cbSets
            // 
            this.cbSets.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbSets.FormattingEnabled = true;
            this.cbSets.Items.AddRange(new object[] {
            "Hiệp",
            "Set"});
            this.cbSets.Location = new System.Drawing.Point(145, 157);
            this.cbSets.Name = "cbSets";
            this.cbSets.Size = new System.Drawing.Size(111, 29);
            this.cbSets.TabIndex = 5;
            // 
            // lblTrongTai
            // 
            this.lblTrongTai.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrongTai.Location = new System.Drawing.Point(29, 319);
            this.lblTrongTai.Name = "lblTrongTai";
            this.lblTrongTai.Size = new System.Drawing.Size(110, 23);
            this.lblTrongTai.TabIndex = 20;
            this.lblTrongTai.Text = "Trọng tài";
            this.lblTrongTai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUser
            // 
            this.cbUser.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(145, 319);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(426, 29);
            this.cbUser.TabIndex = 21;
            // 
            // AddUpdateMatchs
            // 
            this.ClientSize = new System.Drawing.Size(830, 432);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.lblTrongTai);
            this.Controls.Add(this.cbSets);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nScore2);
            this.Controls.Add(this.nScore1);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nSets);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTeam2);
            this.Controls.Add(this.lblTeam2);
            this.Controls.Add(this.txtTeam1);
            this.Controls.Add(this.lblTeam1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTenTranDau);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateMatchs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin trận đấu";
            ((System.ComponentModel.ISupportInitialize)(this.nSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public AddUpdateMatchs(MatchModel m)
        {
            InitializeComponent();
            lblId.Text = m.Id.ToString();
            if (m.Id != -1)
            { 
                txtTitle.Text = m.Title;
                txtStartTime.Text = m.StartTime.ToString();
                txtTeam1.Text = m.Team1;
                txtTeam2.Text = m.Team2;
                nScore1.Value= m.Score1;
                nScore2.Value= m.Score2;
                nSets.Value = m.Sets;
                cbSets.Text = m.SetsName;
                var us = Repository.GetAllUserNotAdmin("Admin");
                cbUser.DataSource = us;
                cbUser.DisplayMember = "Name";    // Hiển thị tên
                cbUser.ValueMember = "Id";
                if (us.Any(u => u.Id == m.UserId))
                {
                    cbUser.SelectedValue = m.UserId;
                }
                else
                {
                    cbUser.SelectedIndex = -1;  // Không chọn gì => combobox trống
                }
            }
        }

        //Lưu kết trận đấu
        private void btnSave_Click(object sender, EventArgs e)
        {
            var m = new MatchModel {
                Id = int.Parse(lblId.Text),
                Title = txtTitle.Text,
                Team1 = txtTeam1.Text,
                Team2 = txtTeam2.Text,
                Score1 = (int)nScore1.Value,
                Score2 = (int)nScore2.Value,
                SetsName= cbSets.Text,
                Sets = 1,
                StartTime = txtStartTime.Text,
                ElapsedSeconds = 0,
                IsPaused = 0,
                Status = 0,
                ShowToggle = false,
                UserId = 1,
            };
            try
            {
                if (lblId.Text != "-1")
                {
                    Repository.UpdateMatch(m);
                }
                else
                {
                    Repository.CreateMatch(m);
                }
                MessageBox.Show("Lưu thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại!");
                txtTitle.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
