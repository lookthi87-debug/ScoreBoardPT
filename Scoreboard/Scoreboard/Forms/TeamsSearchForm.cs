using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
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
    public class TeamsSearchForm : Form
    {
        private DataGridView dgTeam;
        private Label label5;
        private TextBox txtTournaments;
        private int currentTournamentId;
        public int team_Id;
        private DataGridViewTextBoxColumn NameTeam;
        private DataGridViewImageColumn Flag;
        private DataGridViewTextBoxColumn Note;
        private DataGridViewTextBoxColumn teamid;
        private MaterialButton btnBack;
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamsSearchForm));
            this.dgTeam = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTournaments = new System.Windows.Forms.TextBox();
            this.btnBack = new MaterialSkin.Controls.MaterialButton();
            this.NameTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewImageColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamid = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Note,
            this.teamid});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTeam.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTeam.Location = new System.Drawing.Point(17, 68);
            this.dgTeam.MultiSelect = false;
            this.dgTeam.Name = "dgTeam";
            this.dgTeam.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgTeam.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTeam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTeam.Size = new System.Drawing.Size(836, 475);
            this.dgTeam.TabIndex = 1;
            this.dgTeam.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTeam_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 38;
            this.label5.Text = "Giải đấu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTournaments
            // 
            this.txtTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTournaments.Location = new System.Drawing.Point(111, 21);
            this.txtTournaments.MaxLength = 100;
            this.txtTournaments.Name = "txtTournaments";
            this.txtTournaments.ReadOnly = true;
            this.txtTournaments.Size = new System.Drawing.Size(769, 26);
            this.txtTournaments.TabIndex = 39;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.AutoSize = false;
            this.btnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBack.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBack.Depth = 0;
            this.btnBack.HighEmphasis = true;
            this.btnBack.Icon = null;
            this.btnBack.Location = new System.Drawing.Point(695, 552);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBack.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(158, 36);
            this.btnBack.TabIndex = 40;
            this.btnBack.Text = "Thoát";
            this.btnBack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBack.UseAccentColor = false;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // NameTeam
            // 
            this.NameTeam.DataPropertyName = "Name";
            this.NameTeam.FillWeight = 80F;
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
            this.Flag.Width = 50;
            // 
            // Note
            // 
            this.Note.HeaderText = "Ghi chú";
            this.Note.Name = "Note";
            // 
            // teamid
            // 
            this.teamid.DataPropertyName = "Id";
            this.teamid.HeaderText = "teamid";
            this.teamid.Name = "teamid";
            this.teamid.Visible = false;
            // 
            // TeamsSearchForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 603);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtTournaments);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgTeam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamsSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý trận đấu";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TeamsSearchForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgTeam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadTournaments(int tournamentId = -1)
        {
            try
            {
                TournamentModel t = Repository.GetAllTournamentsById(tournamentId);
                txtTournaments.Text = t.Name;
            }
            catch
            {
                txtTournaments.Text = "";
                MessageBox.Show("Không có dữ liệu. Vui lòng tạo");
            }
        }
        public TeamsSearchForm( int tournamentId = -1)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);

            currentTournamentId =tournamentId;
            dgTeam.AutoGenerateColumns = false;

            Flag.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgTeam.RowTemplate.Height = 50;
            LoadTournaments(tournamentId);
            LoadAllTeam();
        }

        private void LoadAllTeam()
        {
            try
            {
                var teams = Repository.GetTeamByTournamentsId(currentTournamentId);
                dgTeam.DataSource = teams;  
            }
            catch
            {
            }
        }
        
        private void dgTeam_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            team_Id = int.Parse(dgTeam.Rows[e.RowIndex].Cells["teamid"].Value.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TeamsSearchForm_Paint(object sender, PaintEventArgs e)
        {
            int radius = 30;
            int border = 1;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = this.ClientSize.Width - border;
            int h = this.ClientSize.Height - border;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(w - radius, 0, radius, radius, 270, 90);
            path.AddArc(w - radius, h - radius, radius, radius, 0, 90);
            path.AddArc(0, h - radius, radius, radius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(System.Drawing.Color.LightGray, border))
            {
                pen.Alignment = PenAlignment.Inset;
                g.DrawPath(pen, path);
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
