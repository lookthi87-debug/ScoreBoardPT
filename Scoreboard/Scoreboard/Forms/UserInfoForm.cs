using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Config;
using Scoreboard.Data;
using Scoreboard.Models;
using System.Linq;

namespace Scoreboard
{
    public class UserInfoForm : Form
    {
        private TextBox txtTime;
        private NumericUpDown nScore2;
        private NumericUpDown nScore1;
        private Label label4;
        private Label lblScore;
        private Label lblName;
        private TextBox txtTeam2;
        private Label lblTeam2;
        private TextBox txtTeam1;
        private Label lblTeam1;
        private TextBox txtTitle;
        private Label lblTenTranDau;
        private MaterialButton btnCancel;
        private MaterialButton btnStart;
        private MaterialButton btnEndMatch;
        private Label lblMessage;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private DataGridView dgvMatches;
        private UserModel currentUser;
        private string currentMatchid;
        private int currentMatchSetid;
        private bool _isLoadingGrid = false;
        public UserInfoForm(UserModel u)
        {
            InitializeComponent();
            currentUser = u;
            LoadMatchesList();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoForm));
            this.btnStart = new MaterialSkin.Controls.MaterialButton();
            this.btnEndMatch = new MaterialSkin.Controls.MaterialButton();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.nScore2 = new System.Windows.Forms.NumericUpDown();
            this.nScore1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTenTranDau = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = false;
            this.btnStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStart.Depth = 0;
            this.btnStart.HighEmphasis = true;
            this.btnStart.Icon = null;
            this.btnStart.Location = new System.Drawing.Point(656, 244);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(117, 36);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStart.UseAccentColor = false;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEndMatch
            // 
            this.btnEndMatch.AutoSize = false;
            this.btnEndMatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEndMatch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEndMatch.Depth = 0;
            this.btnEndMatch.HighEmphasis = true;
            this.btnEndMatch.Icon = null;
            this.btnEndMatch.Location = new System.Drawing.Point(545, 244);
            this.btnEndMatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEndMatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEndMatch.Name = "btnEndMatch";
            this.btnEndMatch.Size = new System.Drawing.Size(102, 36);
            this.btnEndMatch.TabIndex = 3;
            this.btnEndMatch.Text = "Kết thúc trận đấu";
            this.btnEndMatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEndMatch.UseAccentColor = false;
            this.btnEndMatch.UseVisualStyleBackColor = true;
            this.btnEndMatch.Click += new System.EventHandler(this.btnEndMatch_Click);
            // 
            // dgvMatches
            // 
            this.dgvMatches.AllowUserToAddRows = false;
            this.dgvMatches.AllowUserToDeleteRows = false;
            this.dgvMatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatches.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatches.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMatches.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMatches.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatches.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatches.Location = new System.Drawing.Point(109, 3);
            this.dgvMatches.MultiSelect = false;
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.ReadOnly = true;
            this.dgvMatches.RowHeadersVisible = false;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.dgvMatches.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatches.Size = new System.Drawing.Size(817, 194);
            this.dgvMatches.TabIndex = 42;
            this.dgvMatches.SelectionChanged += new System.EventHandler(this.dgvMatches_SelectionChanged);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTime.Location = new System.Drawing.Point(154, 89);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(81, 26);
            this.txtTime.TabIndex = 36;
            this.txtTime.TabStop = false;
            this.txtTime.Text = "00:00";
            // 
            // nScore2
            // 
            this.nScore2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.nScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore2.Location = new System.Drawing.Point(470, 195);
            this.nScore2.Name = "nScore2";
            this.nScore2.ReadOnly = true;
            this.nScore2.Size = new System.Drawing.Size(108, 26);
            this.nScore2.TabIndex = 35;
            this.nScore2.TabStop = false;
            this.nScore2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nScore1
            // 
            this.nScore1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.nScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nScore1.Location = new System.Drawing.Point(152, 195);
            this.nScore1.Name = "nScore1";
            this.nScore1.ReadOnly = true;
            this.nScore1.Size = new System.Drawing.Size(108, 26);
            this.nScore1.TabIndex = 34;
            this.nScore1.TabStop = false;
            this.nScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.label4.Location = new System.Drawing.Point(36, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thời gian";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblScore.Location = new System.Drawing.Point(36, 201);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(110, 23);
            this.lblScore.TabIndex = 33;
            this.lblScore.Text = "Điểm số";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblName.Location = new System.Drawing.Point(36, 155);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 23);
            this.lblName.TabIndex = 30;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeam2
            // 
            this.txtTeam2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam2.Location = new System.Drawing.Point(470, 155);
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.ReadOnly = true;
            this.txtTeam2.Size = new System.Drawing.Size(303, 26);
            this.txtTeam2.TabIndex = 32;
            this.txtTeam2.TabStop = false;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblTeam2.Location = new System.Drawing.Point(557, 114);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(124, 38);
            this.lblTeam2.TabIndex = 29;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTeam1
            // 
            this.txtTeam1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam1.Location = new System.Drawing.Point(152, 155);
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.ReadOnly = true;
            this.txtTeam1.Size = new System.Drawing.Size(303, 26);
            this.txtTeam1.TabIndex = 31;
            this.txtTeam1.TabStop = false;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblTeam1.Location = new System.Drawing.Point(241, 114);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(124, 38);
            this.lblTeam1.TabIndex = 28;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTitle.Location = new System.Drawing.Point(152, 55);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(621, 26);
            this.txtTitle.TabIndex = 26;
            this.txtTitle.TabStop = false;
            // 
            // lblTenTranDau
            // 
            this.lblTenTranDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTranDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(64)))), ((int)(((byte)(84)))));
            this.lblTenTranDau.Location = new System.Drawing.Point(36, 55);
            this.lblTenTranDau.Name = "lblTenTranDau";
            this.lblTenTranDau.Size = new System.Drawing.Size(110, 23);
            this.lblTenTranDau.TabIndex = 25;
            this.lblTenTranDau.Text = "Tên giải đấu";
            this.lblTenTranDau.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(438, 244);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 36);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1036, 48);
            this.lblMessage.TabIndex = 40;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvMatches, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1036, 682);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTenTranDau);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.btnEndMatch);
            this.panel1.Controls.Add(this.lblTeam1);
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Controls.Add(this.txtTeam1);
            this.panel1.Controls.Add(this.nScore2);
            this.panel1.Controls.Add(this.lblTeam2);
            this.panel1.Controls.Add(this.nScore1);
            this.panel1.Controls.Add(this.txtTeam2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblScore);
            this.panel1.Location = new System.Drawing.Point(109, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(817, 348);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // UserInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(1036, 730);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thông tin";
            this.Activated += new System.EventHandler(this.UserInfoForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInfoForm_FormClosed);
            this.Load += new System.EventHandler(this.UserInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nScore1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        private void LoadMatchesList()
        {
            // Set title with user name
            this.Text = currentUser?.Fullname ?? "";
            currentMatchid = "";
            currentMatchSetid = 0;

            // Check if user has referee role (by role name, with legacy ID fallback)
            bool isReferee = false;
            if (currentUser?.RoleName != null)
            {
                isReferee = currentUser.RoleName.IndexOf("trọng tài", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            currentUser.RoleName.Equals("Referee", StringComparison.OrdinalIgnoreCase);
            }
            // Fallback: legacy check by role ID
            if (!isReferee && currentUser?.RoleId == 2)
            {
                isReferee = true;
            }
            if (!isReferee)
            {
                lblMessage.Text = "Không có quyền trọng tài";
                btnStart.Enabled = false;
                btnEndMatch.Enabled = false;
                return;
            }

            try
            {
                _isLoadingGrid = true;
                var matches = Repository.GetMatchesByRefereeToday(currentUser.Id);

                dgvMatches.Columns.Clear();
                dgvMatches.Columns.Add("TournamentName", "Giải đấu");
                dgvMatches.Columns["TournamentName"].Width = 250;
                dgvMatches.Columns.Add("Team1", "Đội 1");
                dgvMatches.Columns["Team1"].Width = 150;
                dgvMatches.Columns.Add("Team2", "Đội 2");
                dgvMatches.Columns["Team2"].Width = 150;
                dgvMatches.Columns.Add("Set", "Hiệp/Set");
                dgvMatches.Columns["Set"].Width = 100;
                dgvMatches.Columns.Add("Score", "Tỉ số");
                dgvMatches.Columns["Score"].Width = 80;
                dgvMatches.Columns.Add("Status", "Trạng thái");
                dgvMatches.Columns["Status"].Width = 100;
                dgvMatches.Columns.Add("StartTime", "Bắt đầu");
                dgvMatches.Columns["StartTime"].Visible = false;
                dgvMatches.Columns.Add("MatchId", "MatchId");
                dgvMatches.Columns["MatchId"].Visible = false;
                dgvMatches.Columns.Add("SetId", "SetId");
                dgvMatches.Columns["SetId"].Visible = false;

                foreach (var m in matches)
                {
                    string statusText = MatchStatusConfig.GetStatusText(m.Status);
                    string startTime = m.Start.HasValue ? m.Start.Value.ToString("HH:mm") : "";
                    dgvMatches.Rows.Add(
                        m.TournamentName,
                        m.Team1,
                        m.Team2,
                        m.ClassSetsName,
                        $"{m.Score1} - {m.Score2}",
                        statusText,
                        startTime,
                        m.MatchId,
                        m.Id
                    );
                }

                if (matches.Count == 0)
                {
                    lblMessage.Text = "Chưa có trận đấu nào trong ngày";
                    btnStart.Enabled = false;
                    btnEndMatch.Enabled = false;
                }
                else
                {
                    lblMessage.Text = "";
                    btnStart.Enabled = true;
                    btnEndMatch.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi tải dữ liệu";
                MessageBox.Show($"Lỗi tải danh sách trận đấu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoadingGrid = false;
            }
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoadingGrid) return;
            if (dgvMatches.SelectedRows.Count == 0) return;

            var row = dgvMatches.SelectedRows[0];
            currentMatchid = row.Cells["MatchId"].Value?.ToString() ?? "";
            currentMatchSetid = int.TryParse(row.Cells["SetId"].Value?.ToString(), out int setId) ? setId : 0;

            txtTitle.Text = row.Cells["TournamentName"].Value?.ToString() ?? "";
            txtTeam1.Text = row.Cells["Team1"].Value?.ToString() ?? "";
            txtTeam2.Text = row.Cells["Team2"].Value?.ToString() ?? "";

            string scoreStr = row.Cells["Score"].Value?.ToString() ?? "0 - 0";
            var scoreParts = scoreStr.Split('-');
            if (scoreParts.Length == 2 &&
                int.TryParse(scoreParts[0].Trim(), out int s1) &&
                int.TryParse(scoreParts[1].Trim(), out int s2))
            {
                nScore1.Value = s1;
                nScore2.Value = s2;
            }

            // Load time from matchset
            if (currentMatchid != "" && currentMatchSetid > 0)
            {
                try
                {
                    var matchSet = Repository.GetMatchSetByMatchAndId(currentMatchid, currentMatchSetid);
                    if (matchSet != null)
                    {
                        txtTime.Text = matchSet.Time ?? "00:00";
                    }
                }
                catch
                {
                    txtTime.Text = "00:00";
                }
            }

            lblMessage.Text = "";
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvMatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một trận đấu trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentMatchid != "")
            {
                Repository.UpdateMatchStatus(currentMatchid, "1");
                Repository.UpdateMatchSetStatus(currentMatchid, currentMatchSetid, "1");
            }
            var frmMain = new MainForm(currentUser);
            this.Hide();
            frmMain.FormClosed += (s, ev) => { this.Show(); LoadMatchesList(); };
            frmMain.Show();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEndMatch_Click(object sender, EventArgs e)
        {
            if (dgvMatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một trận đấu trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentMatchid)) return;

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc chắn muốn kết thúc trận đấu này?",
                "Xác nhận kết thúc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs != DialogResult.Yes) return;

            try
            {
                // Kết thúc tất cả các hiệp/set của trận đấu
                var allSets = Repository.GetMatchSetsByMatchId(currentMatchid);
                foreach (var set in allSets)
                {
                    Repository.UpdateMatchSetStatus(currentMatchid, set.Id, MatchStatusConfig.Status.Finished);
                }
                Repository.UpdateMatchStatus(currentMatchid, MatchStatusConfig.Status.Finished);

                MessageBox.Show("Đã kết thúc trận đấu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMatchesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kết thúc trận đấu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UserInfoForm_Activated(object sender, EventArgs e)
        {
            LoadMatchesList();
        }

        // Create border panels for textboxes after the form loads
        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            // Set button colors through MaterialSkin theme
            // btnStart - Xanh dương chủ đạo #3B82F6
            // This will be handled by the MaterialSkin theme set in MainMDIForm
            
            // btnCancel - Xám nhạt #E5E7EB
            // We'll need to customize this button specifically
            btnCancel.BackColor = Color.FromArgb(229, 231, 235); // #E5E7EB - Xám nhạt
            btnCancel.ForeColor = Color.FromArgb(52, 64, 84); // #344054 - Xám đậm for text
            
            // btnEndMatch - Xám nhạt #E5E7EB
            btnEndMatch.BackColor = Color.FromArgb(229, 231, 235); // #E5E7EB - Xám nhạt
            btnEndMatch.ForeColor = Color.FromArgb(52, 64, 84); // #344054 - Xám đậm for text
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 10;   // độ bo góc - 8-10px như yêu cầu
            int shadow = 8;    // độ dày bóng
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Tạo path bo góc cho panel
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            // Gán Region để panel thật sự bo góc
            panel.Region = new Region(path);

            // Vẽ viền xám nhẹ cho panel (#D0D5DD)
            using (Pen borderPen = new Pen(Color.FromArgb(208, 213, 221), 1)) // #D0D5DD - Border color
            {
                e.Graphics.DrawPath(borderPen, path);
            }

            // Vẽ bóng mờ nhẹ (ngoài path)
            using (GraphicsPath shadowPath = new GraphicsPath())
            {
                Rectangle shadowRect = new Rectangle(shadow, shadow, panel.Width - shadow, panel.Height - shadow);
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, radius, radius, 180, 90);
                shadowPath.AddArc(shadowRect.Right - radius, shadowRect.Y, radius, radius, 270, 90);
                shadowPath.AddArc(shadowRect.Right - radius, shadowRect.Bottom - radius, radius, radius, 0, 90);
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - radius, radius, radius, 90, 90);
                shadowPath.CloseFigure();

                using (PathGradientBrush brush = new PathGradientBrush(shadowPath))
                {
                    brush.CenterColor = Color.FromArgb(50, Color.Black); // độ mờ
                    brush.SurroundColors = new Color[] { Color.Transparent };
                    e.Graphics.FillPath(brush, shadowPath);
                }
            }

            // Vẽ lại thân panel để che phần bóng bên trong
            using (SolidBrush brush = new SolidBrush(panel.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }
        }
    }
}
