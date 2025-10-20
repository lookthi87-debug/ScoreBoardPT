using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Config;
using Scoreboard.Data;
using Scoreboard.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace Scoreboard
{
    public class MatchsForm : MaterialForm
    {
        private DataGridView dgGiaiDau;
        private MaterialButton btnAddMatchset;
        private MaterialButton btnDeleteMatchset;
        private ComboBox cbMatchClass;
        private Label lblClassMatch;
        private TextBox txtTeam;
        private Label lblTeam;
        private MaterialButton btnSearch;
        private ListView lvToggle;
        private Label lblViewToggle;
        private DataGridView dgvDetail;
        private Label label1;
        private MaterialButton btnDeleteMatch;
        private MaterialButton btnAddMatch;
        private Label label5;
        private ComboBox cbTournaments;
        private Label label6;
        private ListView lvActiveMatch;
        private MaterialButton BtnUp;
        private MaterialButton BtnDown;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private DataGridViewTextBoxColumn ClassSetsName;
        private DataGridViewTextBoxColumn time;
        private DataGridViewTextBoxColumn Score1detail;
        private DataGridViewTextBoxColumn Score2detail;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn id2;
        private DataGridViewTextBoxColumn MatchId;
        private DataGridViewTextBoxColumn Status2;
        private DataGridViewTextBoxColumn tournamentname;
        private DataGridViewTextBoxColumn Team1;
        private DataGridViewTextBoxColumn Team2;
        private DataGridViewTextBoxColumn Score1;
        private DataGridViewTextBoxColumn Score2;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn timeStart;
        private DataGridViewTextBoxColumn timeEnd;

        private UserModel user { get; set; }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchsForm));
            this.dgGiaiDau = new System.Windows.Forms.DataGridView();
            this.tournamentname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddMatchset = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteMatchset = new MaterialSkin.Controls.MaterialButton();
            this.cbMatchClass = new System.Windows.Forms.ComboBox();
            this.lblClassMatch = new System.Windows.Forms.Label();
            this.txtTeam = new System.Windows.Forms.TextBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.btnSearch = new MaterialSkin.Controls.MaterialButton();
            this.lvToggle = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblViewToggle = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.ClassSetsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score1detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score2detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteMatch = new MaterialSkin.Controls.MaterialButton();
            this.btnAddMatch = new MaterialSkin.Controls.MaterialButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTournaments = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvActiveMatch = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnUp = new MaterialSkin.Controls.MaterialButton();
            this.BtnDown = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgGiaiDau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgGiaiDau
            // 
            this.dgGiaiDau.AllowUserToAddRows = false;
            this.dgGiaiDau.AllowUserToDeleteRows = false;
            this.dgGiaiDau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgGiaiDau.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGiaiDau.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgGiaiDau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGiaiDau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tournamentname,
            this.Team1,
            this.Team2,
            this.Score1,
            this.Score2,
            this.Id,
            this.status,
            this.timeStart,
            this.timeEnd});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgGiaiDau.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgGiaiDau.Location = new System.Drawing.Point(17, 190);
            this.dgGiaiDau.Name = "dgGiaiDau";
            this.dgGiaiDau.RowHeadersVisible = false;
            this.dgGiaiDau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGiaiDau.Size = new System.Drawing.Size(945, 347);
            this.dgGiaiDau.TabIndex = 1;
            this.dgGiaiDau.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGiaiDau_CellDoubleClick);
            this.dgGiaiDau.SelectionChanged += new System.EventHandler(this.DgTranDau_SelectionChanged);
            // 
            // tournamentname
            // 
            this.tournamentname.DataPropertyName = "tournamentname";
            this.tournamentname.HeaderText = "Giải đấu";
            this.tournamentname.Name = "tournamentname";
            this.tournamentname.ReadOnly = true;
            this.tournamentname.Width = 150;
            // 
            // Team1
            // 
            this.Team1.DataPropertyName = "Team1";
            this.Team1.HeaderText = "Đội 1";
            this.Team1.Name = "Team1";
            this.Team1.ReadOnly = true;
            this.Team1.Width = 140;
            // 
            // Team2
            // 
            this.Team2.DataPropertyName = "Team2";
            this.Team2.HeaderText = "Đội 2";
            this.Team2.Name = "Team2";
            this.Team2.ReadOnly = true;
            this.Team2.Width = 140;
            // 
            // Score1
            // 
            this.Score1.DataPropertyName = "Score1";
            this.Score1.HeaderText = "Điểm đội 1";
            this.Score1.Name = "Score1";
            this.Score1.ReadOnly = true;
            this.Score1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Score2
            // 
            this.Score2.DataPropertyName = "Score2";
            this.Score2.HeaderText = "Điểm đội 2";
            this.Score2.Name = "Score2";
            this.Score2.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 5;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Trạng thái";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // timeStart
            // 
            this.timeStart.DataPropertyName = "Start";
            this.timeStart.HeaderText = "Thời gian bắt đầu";
            this.timeStart.Name = "timeStart";
            this.timeStart.ReadOnly = true;
            // 
            // timeEnd
            // 
            this.timeEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeEnd.DataPropertyName = "End";
            this.timeEnd.HeaderText = "Thời gian kết  thúc";
            this.timeEnd.Name = "timeEnd";
            // 
            // btnAddMatchset
            // 
            this.btnAddMatchset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddMatchset.AutoSize = false;
            this.btnAddMatchset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddMatchset.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddMatchset.Depth = 0;
            this.btnAddMatchset.HighEmphasis = true;
            this.btnAddMatchset.Icon = null;
            this.btnAddMatchset.Location = new System.Drawing.Point(17, 790);
            this.btnAddMatchset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddMatchset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddMatchset.Name = "btnAddMatchset";
            this.btnAddMatchset.Size = new System.Drawing.Size(158, 36);
            this.btnAddMatchset.TabIndex = 2;
            this.btnAddMatchset.Text = "Thêm hiệp đấu";
            this.btnAddMatchset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddMatchset.UseAccentColor = false;
            this.btnAddMatchset.UseVisualStyleBackColor = true;
            this.btnAddMatchset.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteMatchset
            // 
            this.btnDeleteMatchset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteMatchset.AutoSize = false;
            this.btnDeleteMatchset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteMatchset.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteMatchset.Depth = 0;
            this.btnDeleteMatchset.HighEmphasis = true;
            this.btnDeleteMatchset.Icon = null;
            this.btnDeleteMatchset.Location = new System.Drawing.Point(183, 790);
            this.btnDeleteMatchset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteMatchset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteMatchset.Name = "btnDeleteMatchset";
            this.btnDeleteMatchset.Size = new System.Drawing.Size(158, 36);
            this.btnDeleteMatchset.TabIndex = 4;
            this.btnDeleteMatchset.Text = "Xóa";
            this.btnDeleteMatchset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteMatchset.UseAccentColor = false;
            this.btnDeleteMatchset.UseVisualStyleBackColor = true;
            this.btnDeleteMatchset.Click += new System.EventHandler(this.btnDeleteMatchset_Click);
            // 
            // cbMatchClass
            // 
            this.cbMatchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatchClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbMatchClass.FormattingEnabled = true;
            this.cbMatchClass.Location = new System.Drawing.Point(172, 74);
            this.cbMatchClass.Name = "cbMatchClass";
            this.cbMatchClass.Size = new System.Drawing.Size(324, 28);
            this.cbMatchClass.TabIndex = 7;
            this.cbMatchClass.SelectedIndexChanged += new System.EventHandler(this.cbMatchClass_SelectedIndexChanged);
            // 
            // lblClassMatch
            // 
            this.lblClassMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassMatch.Location = new System.Drawing.Point(12, 74);
            this.lblClassMatch.Name = "lblClassMatch";
            this.lblClassMatch.Size = new System.Drawing.Size(152, 29);
            this.lblClassMatch.TabIndex = 9;
            this.lblClassMatch.Text = "Môn thể thao";
            this.lblClassMatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTeam
            // 
            this.txtTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTeam.Location = new System.Drawing.Point(172, 142);
            this.txtTeam.MaxLength = 100;
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.Size = new System.Drawing.Size(324, 26);
            this.txtTeam.TabIndex = 12;
            // 
            // lblTeam
            // 
            this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam.Location = new System.Drawing.Point(73, 142);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(91, 29);
            this.lblTeam.TabIndex = 13;
            this.lblTeam.Text = "Team";
            this.lblTeam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = false;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSearch.Depth = 0;
            this.btnSearch.HighEmphasis = true;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(503, 139);
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
            // lvToggle
            // 
            this.lvToggle.AllowDrop = true;
            this.lvToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lvToggle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lvToggle.FullRowSelect = true;
            this.lvToggle.GridLines = true;
            this.lvToggle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvToggle.HideSelection = false;
            this.lvToggle.HoverSelection = true;
            this.lvToggle.Location = new System.Drawing.Point(994, 576);
            this.lvToggle.Name = "lvToggle";
            this.lvToggle.Size = new System.Drawing.Size(340, 204);
            this.lvToggle.TabIndex = 18;
            this.lvToggle.UseCompatibleStateImageBehavior = false;
            this.lvToggle.View = System.Windows.Forms.View.Details;
            this.lvToggle.DragDrop += new System.Windows.Forms.DragEventHandler(this.LvToggle_DragDrop);
            this.lvToggle.DragEnter += new System.Windows.Forms.DragEventHandler(this.LvToggle_DragEnter);
            this.lvToggle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvToggle_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 333;
            // 
            // lblViewToggle
            // 
            this.lblViewToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblViewToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViewToggle.ForeColor = System.Drawing.Color.Blue;
            this.lblViewToggle.Location = new System.Drawing.Point(992, 550);
            this.lblViewToggle.Name = "lblViewToggle";
            this.lblViewToggle.Size = new System.Drawing.Size(152, 23);
            this.lblViewToggle.TabIndex = 19;
            this.lblViewToggle.Text = "Hiển thị led";
            this.lblViewToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassSetsName,
            this.time,
            this.Score1detail,
            this.Score2detail,
            this.dataGridViewTextBoxColumn6,
            this.id2,
            this.MatchId,
            this.Status2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.Location = new System.Drawing.Point(17, 639);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(945, 141);
            this.dgvDetail.TabIndex = 24;
            this.dgvDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellDoubleClick);
            // 
            // ClassSetsName
            // 
            this.ClassSetsName.DataPropertyName = "ClassSetsName";
            this.ClassSetsName.HeaderText = "Hiệp/Set";
            this.ClassSetsName.Name = "ClassSetsName";
            this.ClassSetsName.ReadOnly = true;
            this.ClassSetsName.Width = 284;
            // 
            // time
            // 
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "Thời gian";
            this.time.Name = "time";
            this.time.Width = 120;
            // 
            // Score1detail
            // 
            this.Score1detail.DataPropertyName = "Score1";
            this.Score1detail.HeaderText = "Điểm đội 1";
            this.Score1detail.Name = "Score1detail";
            this.Score1detail.ReadOnly = true;
            this.Score1detail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Score2detail
            // 
            this.Score2detail.DataPropertyName = "Score2";
            this.Score2detail.HeaderText = "Điểm đội 2";
            this.Score2detail.Name = "Score2detail";
            this.Score2detail.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "refereename";
            this.dataGridViewTextBoxColumn6.HeaderText = "Trọng tài";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // id2
            // 
            this.id2.DataPropertyName = "Id";
            this.id2.HeaderText = "Id";
            this.id2.Name = "id2";
            this.id2.ReadOnly = true;
            this.id2.Visible = false;
            this.id2.Width = 5;
            // 
            // MatchId
            // 
            this.MatchId.DataPropertyName = "MatchId";
            this.MatchId.HeaderText = "Match_Id";
            this.MatchId.Name = "MatchId";
            this.MatchId.Visible = false;
            this.MatchId.Width = 5;
            // 
            // Status2
            // 
            this.Status2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status2.DataPropertyName = "Status";
            this.Status2.HeaderText = "Trạng thái";
            this.Status2.Name = "Status2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(13, 613);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Các hiệp đấu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeleteMatch
            // 
            this.btnDeleteMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteMatch.AutoSize = false;
            this.btnDeleteMatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteMatch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteMatch.Depth = 0;
            this.btnDeleteMatch.HighEmphasis = true;
            this.btnDeleteMatch.Icon = null;
            this.btnDeleteMatch.Location = new System.Drawing.Point(183, 544);
            this.btnDeleteMatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteMatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteMatch.Name = "btnDeleteMatch";
            this.btnDeleteMatch.Size = new System.Drawing.Size(158, 36);
            this.btnDeleteMatch.TabIndex = 27;
            this.btnDeleteMatch.Text = "Xóa";
            this.btnDeleteMatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteMatch.UseAccentColor = false;
            this.btnDeleteMatch.UseVisualStyleBackColor = true;
            this.btnDeleteMatch.Click += new System.EventHandler(this.btnDeleteMatch_Click);
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddMatch.AutoSize = false;
            this.btnAddMatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddMatch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddMatch.Depth = 0;
            this.btnAddMatch.HighEmphasis = true;
            this.btnAddMatch.Icon = null;
            this.btnAddMatch.Location = new System.Drawing.Point(17, 544);
            this.btnAddMatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddMatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(158, 36);
            this.btnAddMatch.TabIndex = 26;
            this.btnAddMatch.Text = "Thêm trận đấu";
            this.btnAddMatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddMatch.UseAccentColor = false;
            this.btnAddMatch.UseVisualStyleBackColor = true;
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 23);
            this.label5.TabIndex = 38;
            this.label5.Text = "Giải đấu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTournaments
            // 
            this.cbTournaments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbTournaments.FormattingEnabled = true;
            this.cbTournaments.Location = new System.Drawing.Point(172, 108);
            this.cbTournaments.Name = "cbTournaments";
            this.cbTournaments.Size = new System.Drawing.Size(324, 28);
            this.cbTournaments.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(992, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "Danh sách trận đấu";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvActiveMatch
            // 
            this.lvActiveMatch.AllowDrop = true;
            this.lvActiveMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvActiveMatch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvActiveMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvActiveMatch.FullRowSelect = true;
            this.lvActiveMatch.GridLines = true;
            this.lvActiveMatch.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvActiveMatch.HideSelection = false;
            this.lvActiveMatch.Location = new System.Drawing.Point(996, 190);
            this.lvActiveMatch.Name = "lvActiveMatch";
            this.lvActiveMatch.Size = new System.Drawing.Size(339, 347);
            this.lvActiveMatch.TabIndex = 40;
            this.lvActiveMatch.UseCompatibleStateImageBehavior = false;
            this.lvActiveMatch.View = System.Windows.Forms.View.Details;
            this.lvActiveMatch.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LvActiveMatch_ItemDrag);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 333;
            // 
            // BtnUp
            // 
            this.BtnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUp.AutoSize = false;
            this.BtnUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnUp.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnUp.Depth = 0;
            this.BtnUp.HighEmphasis = true;
            this.BtnUp.Icon = null;
            this.BtnUp.Location = new System.Drawing.Point(1335, 577);
            this.BtnUp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnUp.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(26, 24);
            this.BtnUp.TabIndex = 43;
            this.BtnUp.Text = "▲";
            this.BtnUp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnUp.UseAccentColor = false;
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDown.AutoSize = false;
            this.BtnDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDown.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnDown.Depth = 0;
            this.BtnDown.HighEmphasis = true;
            this.BtnDown.Icon = null;
            this.BtnDown.Location = new System.Drawing.Point(1335, 604);
            this.BtnDown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnDown.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(26, 24);
            this.BtnDown.TabIndex = 44;
            this.BtnDown.Text = "▼";
            this.BtnDown.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnDown.UseAccentColor = false;
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // MatchsForm
            // 
            this.ClientSize = new System.Drawing.Size(1368, 843);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnUp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lvActiveMatch);
            this.Controls.Add(this.cbTournaments);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteMatch);
            this.Controls.Add(this.btnAddMatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.lblViewToggle);
            this.Controls.Add(this.lvToggle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblClassMatch);
            this.Controls.Add(this.cbMatchClass);
            this.Controls.Add(this.btnDeleteMatchset);
            this.Controls.Add(this.btnAddMatchset);
            this.Controls.Add(this.dgGiaiDau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MatchsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý trận đấu";
            ((System.ComponentModel.ISupportInitialize)(this.dgGiaiDau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void LoadMatchClass()
        {
            try
            {
                var ml = Repository.GetAllMatchClasses();
                cbMatchClass.DataSource = ml.OrderBy(element => element.Id).ToList();
                cbMatchClass.DisplayMember = "Name";
                cbMatchClass.ValueMember = "Id";
                cbMatchClass.SelectedIndex = 0;
                LoadTournaments((int)cbMatchClass.SelectedValue);
            }
            catch
            {
                cbMatchClass.Items.Clear();
                cbMatchClass.Items.Add("No data");
                cbMatchClass.Focus();
                MessageBox.Show("Không có dữ liệu trọng tài. Vui lòng tạo");
            }
        }
        private void LoadTournaments(int classId = 0)
        {
            try
            {
                var Tournaments = Repository.GetAllTournamentsByClassId(classId);
                cbTournaments.DataSource = Tournaments;
                cbTournaments.DisplayMember = "Name";
                cbTournaments.ValueMember = "Id";
            }
            catch
            {
                cbMatchClass.Items.Clear();
                cbMatchClass.Items.Add("No data");
                cbMatchClass.Focus();
                MessageBox.Show("Không có dữ liệu trọng tài. Vui lòng tạo");
            }
        }
        public MatchsForm(UserModel us)
        {
            InitializeComponent();
            dgGiaiDau.AutoGenerateColumns = false;
            dgvDetail.AutoGenerateColumns = false;
            user = us;
            LoadMatchClass();
            LoadListMatchActive();
            LoadListMatchShowToggle();
            btnSearch_Click(this, new EventArgs());
        }

        private void LoadAllMatches(string keyword = null)
        {
            try
            {
                var matches = Repository.GetMatchesByTournament((int)cbTournaments.SelectedValue);

                string keywordTeam = txtTeam.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(keywordTeam))
                {
                    matches = matches.Where(m =>
                        (m.Team1 ?? "").ToLower().Contains(keywordTeam) ||
                        (m.Team2 ?? "").ToLower().Contains(keywordTeam)
                    ).ToList();
                }
                matches = matches.Select(m =>
                {
                    switch (m.Status)
                    {
                        case MatchStatusConfig.Status.NotStarted:
                            m.Status = MatchStatusConfig.GetStatusText(MatchStatusConfig.Status.NotStarted);
                            break;
                        case MatchStatusConfig.Status.InProgress:
                            m.Status = MatchStatusConfig.GetStatusText(MatchStatusConfig.Status.InProgress);
                            break;
                        case MatchStatusConfig.Status.Finished:
                            m.Status = MatchStatusConfig.GetStatusText(MatchStatusConfig.Status.Finished);
                            break;
                        default:
                            m.Status = m.Status;
                            break;
                    }
                    return m;
                }).ToList();
                dgGiaiDau.DataSource = matches;

                if (dgGiaiDau.Rows.Count > 0)
                {
                    // Đảm bảo có ít nhất 1 dòng được chọn
                    dgGiaiDau.Rows[0].Selected = true;
                    dgGiaiDau.CurrentCell = dgGiaiDau.Rows[0].Cells[0];
                    LoadDetailsForSelectedMatch();
                }
                else
                {
                    dgvDetail.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DgTranDau_SelectionChanged(object sender, EventArgs e)
        {
            if (dgGiaiDau.CurrentRow != null)
            {
                int index = dgGiaiDau.CurrentRow.Index;
                LoadDetailsForSelectedMatch(index);
            }
        }
        private void LoadDetailsForSelectedMatch(int index = -1)
        {
            try
            {
                //  Không có dòng nào trong dgGiaiDau thì thoát
                if (dgGiaiDau.Rows.Count == 0)
                    return;

                DataGridViewRow row = null;

                // Ưu tiên dòng đang được chọn
                if (dgGiaiDau.SelectedRows.Count > 0)
                {
                    row = dgGiaiDau.SelectedRows[0];
                }
                else
                {
                    // Nếu không có dòng nào được chọn, lấy dòng đầu tiên hợp lệ
                    row = dgGiaiDau.Rows.Cast<DataGridViewRow>()
                                 .FirstOrDefault(r => !r.IsNewRow);
                    if (row == null)
                        return; // Không có dòng hợp lệ nào
                }

                // Lấy Id trận đấu
                var idObj = row.Cells["Id"]?.Value;
                if (idObj == null) return;

                string matchId = idObj.ToString();

                // Lấy danh sách chi tiết hiệp đấu
                var details = Repository.GetMatchSetsByMatchId(matchId);
                details = details.Select(m =>
                {
                    switch (m.Status)
                    {
                        case MatchStatusConfig.Status.NotStarted:
                            m.Status = MatchStatusConfig.GetStatusText(MatchStatusConfig.Status.NotStarted);
                            break;
                        case MatchStatusConfig.Status.InProgress:
                            m.Status = MatchStatusConfig.GetStatusText(MatchStatusConfig.Status.InProgress);
                            break;
                        case MatchStatusConfig.Status.Finished:
                            m.Status = MatchStatusConfig.GetStatusText(MatchStatusConfig.Status.Finished);
                            break;
                        default:
                            m.Status = m.Status;
                            break;
                    }
                    return m;
                }).ToList();
                // Gán vào dgvDetail
                dgvDetail.DataSource = details;

                // Nếu có dữ liệu thì chọn hiệp đầu tiên hoặc theo index
                if (dgvDetail.Rows.Count > 0)
                {
                    int safeIndex = (index >= 0 && index < dgvDetail.Rows.Count) ? index : 0;
                    dgvDetail.Rows[safeIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết trận đấu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (lvToggle.SelectedItems.Count == 0) return;
            var sel = lvToggle.SelectedItems[0];
            var idx = sel.Index;
            if (idx <= 0) return;
            var item = (ListViewItem)sel.Clone();
            lvToggle.Items.RemoveAt(idx);
            lvToggle.Items.Insert(idx - 1, item);
            lvToggle.Items[idx - 1].Selected = true;
            UpdateShowToggleFromListView();
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (lvToggle.SelectedItems.Count == 0) return;
            var sel = lvToggle.SelectedItems[0];
            var idx = sel.Index;
            if (idx >= lvToggle.Items.Count - 1) return;
            var item = (ListViewItem)sel.Clone();
            lvToggle.Items.RemoveAt(idx);
            lvToggle.Items.Insert(idx + 1, item);
            lvToggle.Items[idx + 1].Selected = true;
            UpdateShowToggleFromListView();
        }

        //Thêm trận đấu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgGiaiDau.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có trận nào, nên không thể thêm hiệp đấu.");
                return;
            }
            var row = dgGiaiDau.Rows[0];
            if (dgGiaiDau.SelectedRows.Count > 0)
            {
                row = dgGiaiDau.SelectedRows[0];
            }
            string matchId = row.Cells["id"].Value?.ToString();
            AddUpdateMatchsets mgAdd = new AddUpdateMatchsets(matchId);
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                int index = dgGiaiDau.RowCount - 1;
                LoadDetailsForSelectedMatch(index);
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (lvToggle.Items.Count == 0)
            {
                MessageBox.Show("Danh sách toggle rỗng.");
                return;
            }
            List<MatchsetModel> mdlShowToggle = new List<MatchsetModel>();
            foreach (ListViewItem item in lvToggle.Items)
            {
                string matchId = item.Tag?.ToString();
                if (string.IsNullOrEmpty(matchId)) continue;

                List<MatchsetModel> mdl = Repository.GetActiveMatchSetsByMatchId(matchId);
                for (int i = 0; i <= mdl.Count - 1; i++)
                {
                    mdlShowToggle.Add(mdl[i]);
                }
            }

        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int index = e.RowIndex;

            int colStatus = dgvDetail.Rows[index].DataGridView.Columns["status2"].Index;
            var statusObj = dgvDetail.Rows[index].Cells[colStatus].Value;
            var status = statusObj?.ToString() ?? "0";
            if (status == MatchStatusConfig.GetStatusText(2))
            {
                MessageBox.Show("Trận đấu đã kết thúc. Không thể sửa.", "Xác nhận chỉnh sửa");
                return;
            }
            if (status == "1")
            {
                DialogResult rs = MessageBox.Show("Trận đấu đang hoạt động! Bạn có chắc chắn muốn sửa không?", "Xác nhận chỉnh sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.No)
                {
                    return;
                }
            }
            int colid = dgvDetail.Rows[index].DataGridView.Columns["Id2"].Index;
            var id = int.Parse(dgvDetail.Rows[index].Cells[colid].Value.ToString());
            var matchid = dgvDetail.Rows[index].Cells["MatchId"].Value.ToString();
            AddUpdateMatchsets mgAdd = new AddUpdateMatchsets(matchid, id);
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                LoadDetailsForSelectedMatch(index);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cbTournaments.Text))
                {
                    MessageBox.Show("Chưa chọn giải đấu");
                    cbTournaments.Focus();
                    return;
                }

                // Load danh sách trận theo điều kiện
                LoadAllMatches();

                // 2Chuẩn bị danh sách hiển thị
                List<(string Id, int ShowToggle)> showList = new List<(string, int)>();
                //lvActiveMatch.Items.Clear();
                lvToggle.Items.Clear();

                // 3Duyệt toàn bộ dòng trong dgGiaiDau
                for (int i = 0; i < dgGiaiDau.Rows.Count; i++)
                {
                    var row = dgGiaiDau.Rows[i];
                    if (row.IsNewRow) continue; // bỏ dòng trống cuối cùng

                    int colStatus = row.DataGridView.Columns["status"].Index;
                    string status = row.Cells[colStatus].Value?.ToString() ?? "";

                    int colId = row.DataGridView.Columns["id"].Index;
                    string id = row.Cells["id"]?.Value?.ToString() ?? "";

                    // Reset lại màu nền & tag
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    row.Tag = null;

                    if (status == "1")
                    {
                        var mc = Repository.GetMatchById(id);
                        if (mc != null)
                        {
                            //var li = new ListViewItem($"{mc.Team1} vs {mc.Team2} - {mc.RefereeName}")
                            //{
                            //    Tag = mc.Id
                            //};
                            //lvActiveMatch.Items.Add(li);

                            // Đánh dấu dòng bị khóa
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                            row.Tag = "locked";

                            // Nếu có ShowToggle > 0 → lưu vào danh sách toggle
                            if (mc.ShowToggle > 0)
                                showList.Add((id, mc.ShowToggle));
                        }
                    }
                    else if (status == "2")
                    {
                        // Đã kết thúc trận đấu
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                        row.Tag = "locked";
                    }
                }

                // Sắp xếp theo ShowToggle rồi hiển thị vào lvToggle
                foreach (var (matchId, showtoggle) in showList.OrderBy(x => x.ShowToggle))
                {
                    var mc = Repository.GetMatchById(matchId);
                    if (mc == null) continue;

                    var li = new ListViewItem($"{mc.Team1} vs {mc.Team2} - {mc.RefereeName}")
                    {
                        Tag = mc.Id
                    };
                    lvToggle.Items.Add(li);
                }
                LoadListMatchActive();
                LoadListMatchShowToggle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LvActiveMatch_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var items = (ListViewItem)e.Item;
            if (items != null)
                DoDragDrop(items, DragDropEffects.Copy);
        }

        private void LvToggle_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void LvToggle_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ListViewItem))) return;

            var dragged = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            string matchId = dragged.Tag?.ToString();
            if (string.IsNullOrEmpty(matchId)) return;

            if (lvToggle.Items.Cast<ListViewItem>().Any(it => it.Tag?.ToString() == matchId))
            {
                MessageBox.Show("Trận này đã có trong Toggle.");
                return;
            }

            // Giới hạn 8 trận
            if (lvToggle.Items.Count >= 8)
            {
                MessageBox.Show("Không thể hiển thị quá 8 trận trên Toggle.");
                return;
            }

            // Kiểm tra có hiệp nào đang status = 1 không
            var details = Repository.GetMatchSetsByMatchId(matchId);
            bool hasActiveSet = details.Any(d => d.Status != "2");
            if (!hasActiveSet)
            {
                MessageBox.Show("Trận này chưa có hiệp nào đang diễn ra (status = 1).");
                return;
            }

            // Thêm vào lvToggle
            var m = Repository.GetMatchById(matchId);
            var li = new ListViewItem($"{m.Team1} vs {m.Team2} - {m.RefereeName}") { Tag = matchId };
            lvToggle.Items.Add(li);

            // Cập nhật ShowToggle trên Matches
            UpdateShowToggleFromListView();
        }
        private void BtnDelToggle_Click(object sender, EventArgs e)
        {
            if (lvToggle.SelectedItems.Count == 0) return;

            var tag = lvToggle.SelectedItems[0].Tag?.ToString();
            lvToggle.Items.Remove(lvToggle.SelectedItems[0]);

            if (!string.IsNullOrEmpty(tag))
            {
                var match = Repository.GetMatchById(tag);
                if (match != null)
                {
                    match.ShowToggle = 0;
                    Repository.UpdateMatch(match);
                }
            }

            // Cập nhật lại thứ tự
            UpdateShowToggleFromListView();
            LoadListMatchShowToggle();
        }
        private void UpdateShowToggleFromListView()
        {
            try
            {
                int index = 1;
                foreach (ListViewItem item in lvToggle.Items)
                {
                    string matchId = item.Tag?.ToString();
                    if (string.IsNullOrEmpty(matchId)) continue;

                    var match = Repository.GetMatchById(matchId);
                    if (match != null)
                    {
                        match.ShowToggle = index;
                        Repository.UpdateMatch(match);
                    }

                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật ShowToggle: " + ex.Message);
            }
        }

        private void lvToggle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lvToggle.SelectedItems.Count > 0)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa trận này khỏi toggle không?",
                                              "Xác nhận xóa",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    BtnDelToggle_Click(sender, e);
                }
                e.Handled = true;
            }
        }

        private void btnAddActive_Click(object sender, EventArgs e)
        {
            if (dgGiaiDau.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một trận đấu trong danh sách trước khi thêm vào danh sách hoạt động.");
                return;
            }

            if (dgvDetail.RowCount == 0)
            {
                MessageBox.Show("Chưa có hiệp đấu nào.");
                return;
            }

            // Lấy dòng được chọn
            var row = dgGiaiDau.SelectedRows[0];
            string matchId = row.Cells["id"].Value?.ToString();
            string status = row.Cells["status"].Value?.ToString();

            if (string.IsNullOrEmpty(matchId))
            {
                MessageBox.Show("Không tìm thấy id trận đấu.");
                return;
            }

            // Kiểm tra đã tồn tại trong lvActiveMatch chưa
            //if (lvActiveMatch.Items.Cast<ListViewItem>().Any(it => it.Tag?.ToString() == matchId))
            //{
            //    MessageBox.Show("Trận đấu này đã có trong danh sách hoạt động.");
            //    return;
            //}

            // Lấy thông tin từ database
            var match = Repository.GetMatchById(matchId);
            if (match == null)
            {
                MessageBox.Show("Không tìm thấy thông tin trận đấu trong cơ sở dữ liệu.");
                return;
            }

            // Cập nhật status = 1 (đang hoạt động)
            row.Cells["ShowToggle"].Value = 1;
            match.Status = "1";
            Repository.UpdateMatch(match);

            MatchsetModel ms = Repository.GetNoActiveMatchSetsByMatchId(matchId);
            if (ms != null)
            {
                ms.Status = "1";
                Repository.UpdateMatchSetStatus(matchId, ms.Id, ms.Status);
            }

            // "Lock" dòng tương ứng trong dgGiaiDau (chặn sửa hoặc xóa)
            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            row.Tag = "locked";
            row.Cells["status"].Value = "Đang diễn ra"; // status  = 1
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgGiaiDau.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.Title = "Chọn nơi lưu file Excel";
                    sfd.FileName = "DanhSachGiaiDau.xlsx";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook wb = excelApp.Workbooks.Add(Missing.Value);
                    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;
                    ws.Name = "Danh sách giải đấu";

                    int currentRow = 1;

                    // ====== TIÊU ĐỀ CHÍNH ======
                    ws.Cells[currentRow, 1] = "DANH SÁCH GIẢI ĐẤU VÀ HIỆP ĐẤU";
                    Excel.Range titleRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, 8]];
                    titleRange.Merge();
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 16;
                    titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    currentRow += 2;

                    // ====== TIÊU ĐỀ CÁC CỘT ======
                    string[] headers = { "ID", "Giải đấu", "Đội 1", "Đội 2", "Trọng tài", "Trạng thái", "Điểm đội 1", "Điểm đội 2" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cells[currentRow, i + 1] = headers[i];
                    }

                    Excel.Range headerRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, headers.Length]];
                    headerRange.Font.Bold = true;
                    headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSkyBlue);
                    headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    currentRow++;

                    // ====== GHI DỮ LIỆU ======
                    foreach (DataGridViewRow gRow in dgGiaiDau.Rows)
                    {
                        if (gRow.IsNewRow) continue;

                        string matchId = gRow.Cells["id"].Value?.ToString();
                        var match = Repository.GetMatchById(matchId);
                        if (match == null) continue;

                        // Ghi dòng chính (trận đấu)
                        ws.Cells[currentRow, 1] = match.Id;
                        ws.Cells[currentRow, 2] = match.TournamentName ?? "";
                        ws.Cells[currentRow, 3] = match.Team1 ?? "";
                        ws.Cells[currentRow, 4] = match.Team2 ?? "";
                        ws.Cells[currentRow, 5] = match.RefereeName ?? "";
                        ws.Cells[currentRow, 6] = match.Status == "0" ? "Chưa cấp phép" :
                                                  match.Status == "1" ? "Đang hoạt động" :
                                                  match.Status == "2" ? "Đã kết thúc" : match.Status;
                        ws.Cells[currentRow, 7] = match.Score1;
                        ws.Cells[currentRow, 8] = match.Score2;

                        // Tô viền cho dòng chính
                        Excel.Range matchRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, 8]];
                        matchRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        currentRow++;

                        // ====== HIỆP ĐẤU CỦA TRẬN NÀY ======
                        var details = Repository.GetMatchSetsByMatchId(matchId);
                        if (details != null && details.Count > 0)
                        {
                            // Tiêu đề chi tiết
                            ws.Cells[currentRow, 3] = "Hiệp";
                            ws.Cells[currentRow, 4] = "Thời gian";
                            ws.Cells[currentRow, 5] = "Điểm đội 1";
                            ws.Cells[currentRow, 6] = "Điểm đội 2";
                            ws.Cells[currentRow, 7] = "Trạng thái";
                            Excel.Range subHeaderRange = ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 7]];
                            subHeaderRange.Font.Bold = true;
                            subHeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow);
                            subHeaderRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            currentRow++;

                            // Ghi từng hiệp
                            foreach (var d in details)
                            {
                                if (d.Time != "00:00")
                                {
                                    ws.Cells[currentRow, 3] = d.ClassSetsName ?? "";
                                    ws.Cells[currentRow, 4] = d.Time ?? "";
                                    ws.Cells[currentRow, 5] = d.Score1;
                                    ws.Cells[currentRow, 6] = d.Score2;
                                    ws.Cells[currentRow, 7] = d.Status == "0" ? "Chưa bắt đầu" :
                                                              d.Status == "1" ? "Đang diễn ra" :
                                                              d.Status == "2" ? "Đã kết thúc" : d.Status;
                                    Excel.Range detailRange = ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 7]];
                                    detailRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                    currentRow++;
                                }
                            }
                        }
                        // Dòng trống giữa các trận
                        currentRow++;
                    }

                    // ====== ĐỊNH DẠNG TOÀN TRANG ======
                    ws.Columns.AutoFit();
                    ws.Rows.AutoFit();
                    ws.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    ws.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    wb.SaveAs(sfd.FileName);
                    wb.Close();
                    excelApp.Quit();

                    MessageBox.Show("Xuất Excel thành công!\n" + sfd.FileName, "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            AddUpdateMatch mgAdd = new AddUpdateMatch(int.Parse(cbTournaments.SelectedValue.ToString()));
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                LoadAllMatches();
                LoadListMatchActive();
            }
        }

        private void dgGiaiDau_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int index = e.RowIndex;

            var statusObj = dgGiaiDau.Rows[index].Cells["Status"].Value;
            var status = statusObj?.ToString() ?? "0";
            if (status == MatchStatusConfig.GetStatusText(2))
            {
                MessageBox.Show("Trận đấu đã kết thúc. Không thể sửa.", "Xác nhận chỉnh sửa");
                return;
            }
            if (status == "1")
            {
                DialogResult rs = MessageBox.Show("Trận đấu đang hoạt động! Bạn có chắc chắn muốn sửa không?", "Xác nhận chỉnh sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.No)
                {
                    return;
                }
            }
            string matchid = dgGiaiDau.Rows[index].Cells["id"].Value.ToString();
            AddUpdateMatch mgAdd = new AddUpdateMatch(int.Parse(cbTournaments.SelectedValue.ToString()), matchid);
            if (mgAdd.ShowDialog() == DialogResult.OK)
            {
                LoadDetailsForSelectedMatch(index);
                // reload data
                btnSearch_Click(this, new EventArgs());
                LoadListMatchActive();
                LoadListMatchShowToggle();
            }
        }

        private void btnDeleteMatchset_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow == null) return;

            int colMatchid = dgvDetail.CurrentRow.DataGridView.Columns["MatchId"].Index;
            string Matchid = dgvDetail.CurrentRow.Cells[colMatchid].Value.ToString();
            int colid = dgvDetail.CurrentRow.DataGridView.Columns["Id2"].Index;
            int id = int.Parse(dgvDetail.CurrentRow.Cells[colid].Value.ToString());

            int colstatus = dgvDetail.CurrentRow.DataGridView.Columns["status2"].Index;
            string status = dgvDetail.CurrentRow.Cells[colstatus].Value.ToString();
            if (status == "1")
            {
                MessageBox.Show($"Hiệp/set đấu đang hoạt động! Không thể xóa!");
                return;
            }
            try
            {
                Repository.DeleteMatchSet(Matchid, id);
                if (dgGiaiDau.Rows.Count > 0 && dgGiaiDau.CurrentRow != null)
                {
                    LoadDetailsForSelectedMatch(dgGiaiDau.CurrentRow.Index);
                }

                MessageBox.Show("Xóa hiệp/set đấu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa hiệp/set đấu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteMatch_Click(object sender, EventArgs e)
        {
            if (dgGiaiDau.CurrentRow == null) return;

            string id = dgGiaiDau.CurrentRow.Cells["Id"].Value.ToString();
            string status = dgGiaiDau.CurrentRow.Cells["status"].Value.ToString();
            if (status == "1")
            {
                MessageBox.Show($"Trận đấu đang hoạt động! Không thể xóa!");
                return;
            }
            try
            {
                int index = dgGiaiDau.CurrentRow.Index;
                if (dgGiaiDau.CurrentRow.Index > 0)
                {
                    index = index - 1;
                }
                Repository.DeleteMatch(id);
                LoadAllMatches();
                if (index >= 0)
                {
                    dgGiaiDau.Rows[index].Selected = true;
                    LoadDetailsForSelectedMatch(index);
                }

                MessageBox.Show("Xóa trận đấu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListMatchActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa trận đấu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void LoadListMatchActive()
        {
            try
            {
                lvActiveMatch.Items.Clear();
                List<MatchModel> activeMatches = Repository.GetMatchesByStatus("2", false);
                foreach (var match in activeMatches)
                {
                    var li = new ListViewItem($"{match.Team1} vs {match.Team2}   -   {match.RefereeName}")
                    {
                        Tag = match.Id
                    };
                    lvActiveMatch.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách trận đấu hoạt động: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadListMatchShowToggle()
        {
            try
            {
                lvToggle.Items.Clear();
                List<MatchModel> activeMatches = Repository.GetMatchesShowToggle();
                foreach (var match in activeMatches)
                {
                    var li = new ListViewItem($"{match.Team1} vs {match.Team2} - {match.RefereeName}")
                    {
                        Tag = match.Id
                    };
                    lvToggle.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hiển thị led: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
