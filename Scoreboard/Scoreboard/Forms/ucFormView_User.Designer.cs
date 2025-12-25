using Scoreboard.Config;

namespace Scoreboard
{
    partial class ucFormView_User
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (matchTimer != null)
                {
                    matchTimer.Stop();
                    matchTimer.Dispose();
                    matchTimer = null;
                }
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgFlagTeam1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblScoreTeam2 = new System.Windows.Forms.Label();
            this.lblScoreTeam1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pgFlagTeam2 = new System.Windows.Forms.PictureBox();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.pgFlagVN = new System.Windows.Forms.PictureBox();
            this.lblBonus = new System.Windows.Forms.Label();
            this.tblFlagVN = new System.Windows.Forms.TableLayoutPanel();
            this.lblSet4 = new System.Windows.Forms.Label();
            this.lblSet3 = new System.Windows.Forms.Label();
            this.lblSet2 = new System.Windows.Forms.Label();
            this.lblSet5 = new System.Windows.Forms.Label();
            this.lblSet1 = new System.Windows.Forms.Label();
            this.lblScore25 = new System.Windows.Forms.Label();
            this.lblScore14 = new System.Windows.Forms.Label();
            this.lblScore11 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblHiepDau = new System.Windows.Forms.Label();
            this.lblScore15 = new System.Windows.Forms.Label();
            this.lblScore13 = new System.Windows.Forms.Label();
            this.lblScore12 = new System.Windows.Forms.Label();
            this.lblScore24 = new System.Windows.Forms.Label();
            this.lblScore23 = new System.Windows.Forms.Label();
            this.lblScore22 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTeam21 = new System.Windows.Forms.Label();
            this.lblTeam11 = new System.Windows.Forms.Label();
            this.lblScore21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableView = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagVN)).BeginInit();
            this.tblFlagVN.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableView.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgFlagTeam1
            // 
            this.pgFlagTeam1.Location = new System.Drawing.Point(183, 3);
            this.pgFlagTeam1.Name = "pgFlagTeam1";
            this.pgFlagTeam1.Size = new System.Drawing.Size(36, 30);
            this.pgFlagTeam1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pgFlagTeam1.TabIndex = 46;
            this.pgFlagTeam1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.lblScoreTeam2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblScoreTeam1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 217);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 36);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // lblScoreTeam2
            // 
            this.lblScoreTeam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScoreTeam2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreTeam2.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScoreTeam2.Location = new System.Drawing.Point(310, 0);
            this.lblScoreTeam2.Name = "lblScoreTeam2";
            this.lblScoreTeam2.Size = new System.Drawing.Size(161, 36);
            this.lblScoreTeam2.TabIndex = 21;
            this.lblScoreTeam2.Text = "0";
            this.lblScoreTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScoreTeam1
            // 
            this.lblScoreTeam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScoreTeam1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreTeam1.ForeColor = System.Drawing.Color.Red;
            this.lblScoreTeam1.Location = new System.Drawing.Point(3, 0);
            this.lblScoreTeam1.Name = "lblScoreTeam1";
            this.lblScoreTeam1.Size = new System.Drawing.Size(159, 36);
            this.lblScoreTeam1.TabIndex = 17;
            this.lblScoreTeam1.Text = "0";
            this.lblScoreTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel3.Controls.Add(this.pgFlagTeam2, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.pgFlagTeam1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTeam1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTeam2, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 156);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(474, 46);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // pgFlagTeam2
            // 
            this.pgFlagTeam2.Location = new System.Drawing.Point(253, 3);
            this.pgFlagTeam2.Name = "pgFlagTeam2";
            this.pgFlagTeam2.Size = new System.Drawing.Size(36, 30);
            this.pgFlagTeam2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pgFlagTeam2.TabIndex = 47;
            this.pgFlagTeam2.TabStop = false;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTeam1.Location = new System.Drawing.Point(3, 0);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(174, 46);
            this.lblTeam1.TabIndex = 5;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.Red;
            this.lblTeam2.Location = new System.Drawing.Point(295, 0);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(176, 46);
            this.lblTeam2.TabIndex = 7;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgFlagVN
            // 
            this.pgFlagVN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pgFlagVN.Location = new System.Drawing.Point(142, 3);
            this.pgFlagVN.Margin = new System.Windows.Forms.Padding(0);
            this.pgFlagVN.Name = "pgFlagVN";
            this.pgFlagVN.Size = new System.Drawing.Size(189, 46);
            this.pgFlagVN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pgFlagVN.TabIndex = 45;
            this.pgFlagVN.TabStop = false;
            // 
            // lblBonus
            // 
            this.lblBonus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBonus.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBonus.ForeColor = System.Drawing.Color.Yellow;
            this.lblBonus.Location = new System.Drawing.Point(3, 205);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(474, 9);
            this.lblBonus.TabIndex = 48;
            this.lblBonus.Text = "BONUS";
            this.lblBonus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblFlagVN
            // 
            this.tblFlagVN.ColumnCount = 3;
            this.tblFlagVN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblFlagVN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblFlagVN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblFlagVN.Controls.Add(this.pgFlagVN, 1, 0);
            this.tblFlagVN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFlagVN.Location = new System.Drawing.Point(3, 3);
            this.tblFlagVN.Name = "tblFlagVN";
            this.tblFlagVN.RowCount = 1;
            this.tblFlagVN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFlagVN.Size = new System.Drawing.Size(474, 52);
            this.tblFlagVN.TabIndex = 46;
            // 
            // lblSet4
            // 
            this.lblSet4.BackColor = System.Drawing.Color.Black;
            this.lblSet4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSet4.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblSet4.ForeColor = System.Drawing.Color.Aqua;
            this.lblSet4.Location = new System.Drawing.Point(303, 0);
            this.lblSet4.Name = "lblSet4";
            this.lblSet4.Size = new System.Drawing.Size(31, 2);
            this.lblSet4.TabIndex = 41;
            this.lblSet4.Text = "Set 1";
            this.lblSet4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSet3
            // 
            this.lblSet3.BackColor = System.Drawing.Color.Black;
            this.lblSet3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSet3.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblSet3.ForeColor = System.Drawing.Color.Aqua;
            this.lblSet3.Location = new System.Drawing.Point(266, 0);
            this.lblSet3.Name = "lblSet3";
            this.lblSet3.Size = new System.Drawing.Size(31, 2);
            this.lblSet3.TabIndex = 40;
            this.lblSet3.Text = "Set 1";
            this.lblSet3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSet2
            // 
            this.lblSet2.BackColor = System.Drawing.Color.Black;
            this.lblSet2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSet2.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblSet2.ForeColor = System.Drawing.Color.Aqua;
            this.lblSet2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSet2.Location = new System.Drawing.Point(229, 0);
            this.lblSet2.Name = "lblSet2";
            this.lblSet2.Size = new System.Drawing.Size(31, 2);
            this.lblSet2.TabIndex = 39;
            this.lblSet2.Text = "Set 1";
            this.lblSet2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSet5
            // 
            this.lblSet5.BackColor = System.Drawing.Color.Black;
            this.lblSet5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSet5.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblSet5.ForeColor = System.Drawing.Color.Aqua;
            this.lblSet5.Location = new System.Drawing.Point(340, 0);
            this.lblSet5.Name = "lblSet5";
            this.lblSet5.Size = new System.Drawing.Size(31, 2);
            this.lblSet5.TabIndex = 38;
            this.lblSet5.Text = "Set 1";
            this.lblSet5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSet1
            // 
            this.lblSet1.BackColor = System.Drawing.Color.Black;
            this.lblSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSet1.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblSet1.ForeColor = System.Drawing.Color.Aqua;
            this.lblSet1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSet1.Location = new System.Drawing.Point(192, 0);
            this.lblSet1.Name = "lblSet1";
            this.lblSet1.Size = new System.Drawing.Size(31, 2);
            this.lblSet1.TabIndex = 37;
            this.lblSet1.Text = "Set 1";
            this.lblSet1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore25
            // 
            this.lblScore25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore25.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore25.Location = new System.Drawing.Point(340, 4);
            this.lblScore25.Name = "lblScore25";
            this.lblScore25.Size = new System.Drawing.Size(31, 4);
            this.lblScore25.TabIndex = 36;
            this.lblScore25.Text = "0";
            this.lblScore25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore14
            // 
            this.lblScore14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore14.ForeColor = System.Drawing.Color.Red;
            this.lblScore14.Location = new System.Drawing.Point(303, 2);
            this.lblScore14.Name = "lblScore14";
            this.lblScore14.Size = new System.Drawing.Size(31, 2);
            this.lblScore14.TabIndex = 35;
            this.lblScore14.Text = "0";
            this.lblScore14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore11
            // 
            this.lblScore11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore11.ForeColor = System.Drawing.Color.Red;
            this.lblScore11.Location = new System.Drawing.Point(192, 2);
            this.lblScore11.Name = "lblScore11";
            this.lblScore11.Size = new System.Drawing.Size(31, 2);
            this.lblScore11.TabIndex = 34;
            this.lblScore11.Text = "0";
            this.lblScore11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Black;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTime.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblTime.Location = new System.Drawing.Point(3, 77);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(474, 43);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHiepDau
            // 
            this.lblHiepDau.BackColor = System.Drawing.Color.Black;
            this.lblHiepDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHiepDau.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiepDau.ForeColor = System.Drawing.Color.Aqua;
            this.lblHiepDau.Location = new System.Drawing.Point(3, 120);
            this.lblHiepDau.Name = "lblHiepDau";
            this.lblHiepDau.Size = new System.Drawing.Size(474, 33);
            this.lblHiepDau.TabIndex = 5;
            this.lblHiepDau.Text = "Set 1";
            this.lblHiepDau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore15
            // 
            this.lblScore15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore15.ForeColor = System.Drawing.Color.Red;
            this.lblScore15.Location = new System.Drawing.Point(340, 2);
            this.lblScore15.Name = "lblScore15";
            this.lblScore15.Size = new System.Drawing.Size(31, 2);
            this.lblScore15.TabIndex = 32;
            this.lblScore15.Text = "0";
            this.lblScore15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore13
            // 
            this.lblScore13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore13.ForeColor = System.Drawing.Color.Red;
            this.lblScore13.Location = new System.Drawing.Point(266, 2);
            this.lblScore13.Name = "lblScore13";
            this.lblScore13.Size = new System.Drawing.Size(31, 2);
            this.lblScore13.TabIndex = 31;
            this.lblScore13.Text = "0";
            this.lblScore13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore12
            // 
            this.lblScore12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore12.ForeColor = System.Drawing.Color.Red;
            this.lblScore12.Location = new System.Drawing.Point(229, 2);
            this.lblScore12.Name = "lblScore12";
            this.lblScore12.Size = new System.Drawing.Size(31, 2);
            this.lblScore12.TabIndex = 30;
            this.lblScore12.Text = "0";
            this.lblScore12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore24
            // 
            this.lblScore24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore24.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore24.Location = new System.Drawing.Point(303, 4);
            this.lblScore24.Name = "lblScore24";
            this.lblScore24.Size = new System.Drawing.Size(31, 4);
            this.lblScore24.TabIndex = 27;
            this.lblScore24.Text = "0";
            this.lblScore24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore23
            // 
            this.lblScore23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore23.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore23.Location = new System.Drawing.Point(266, 4);
            this.lblScore23.Name = "lblScore23";
            this.lblScore23.Size = new System.Drawing.Size(31, 4);
            this.lblScore23.TabIndex = 26;
            this.lblScore23.Text = "0";
            this.lblScore23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScore22
            // 
            this.lblScore22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore22.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore22.Location = new System.Drawing.Point(229, 4);
            this.lblScore22.Name = "lblScore22";
            this.lblScore22.Size = new System.Drawing.Size(31, 4);
            this.lblScore22.TabIndex = 25;
            this.lblScore22.Text = "0";
            this.lblScore22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(474, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Giải đấu";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTeam21
            // 
            this.lblTeam21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam21.ForeColor = System.Drawing.Color.Red;
            this.lblTeam21.Location = new System.Drawing.Point(3, 4);
            this.lblTeam21.Name = "lblTeam21";
            this.lblTeam21.Size = new System.Drawing.Size(183, 4);
            this.lblTeam21.TabIndex = 23;
            this.lblTeam21.Text = "Đội 2";
            this.lblTeam21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTeam11
            // 
            this.lblTeam11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam11.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTeam11.Location = new System.Drawing.Point(3, 2);
            this.lblTeam11.Name = "lblTeam11";
            this.lblTeam11.Size = new System.Drawing.Size(183, 2);
            this.lblTeam11.TabIndex = 22;
            this.lblTeam11.Text = "Đội 1";
            this.lblTeam11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScore21
            // 
            this.lblScore21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore21.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScore21.Location = new System.Drawing.Point(192, 4);
            this.lblScore21.Name = "lblScore21";
            this.lblScore21.Size = new System.Drawing.Size(31, 4);
            this.lblScore21.TabIndex = 21;
            this.lblScore21.Text = "0";
            this.lblScore21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblSet4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSet3, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSet2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSet5, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSet1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblScore25, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblScore14, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScore11, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScore15, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScore13, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScore12, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScore24, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblScore23, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblScore22, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTeam21, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTeam11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblScore21, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 259);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(474, 8);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // tableView
            // 
            this.tableView.ColumnCount = 1;
            this.tableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableView.Controls.Add(this.tableLayoutPanel2, 0, 7);
            this.tableView.Controls.Add(this.lblBonus, 0, 5);
            this.tableView.Controls.Add(this.tblFlagVN, 3, 0);
            this.tableView.Controls.Add(this.tableLayoutPanel1, 0, 6);
            this.tableView.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableView.Controls.Add(this.lblTime, 0, 2);
            this.tableView.Controls.Add(this.lblTitle, 0, 1);
            this.tableView.Controls.Add(this.lblHiepDau, 0, 3);
            this.tableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableView.Location = new System.Drawing.Point(0, 0);
            this.tableView.Name = "tableView";
            this.tableView.RowCount = 8;
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.88172F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.139785F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.8895F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.5914F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.19355F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.301075F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableView.Size = new System.Drawing.Size(480, 270);
            this.tableView.TabIndex = 9;
            // 
            // ucFormView_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tableView);
            this.MinimumSize = new System.Drawing.Size(480, 270);
            this.Name = "ucFormView_User";
            this.Size = new System.Drawing.Size(480, 270);
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagVN)).EndInit();
            this.tblFlagVN.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableView.ResumeLayout(false);
            this.tableView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pgFlagTeam1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblScoreTeam2;
        private System.Windows.Forms.Label lblScoreTeam1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pgFlagTeam2;
        private System.Windows.Forms.Label lblTeam1;
        private System.Windows.Forms.Label lblTeam2;
        private System.Windows.Forms.PictureBox pgFlagVN;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.TableLayoutPanel tblFlagVN;
        private System.Windows.Forms.Label lblSet4;
        private System.Windows.Forms.Label lblSet3;
        private System.Windows.Forms.Label lblSet2;
        private System.Windows.Forms.Label lblSet5;
        private System.Windows.Forms.Label lblSet1;
        private System.Windows.Forms.Label lblScore25;
        private System.Windows.Forms.Label lblScore14;
        private System.Windows.Forms.Label lblScore11;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblHiepDau;
        private System.Windows.Forms.Label lblScore15;
        private System.Windows.Forms.Label lblScore13;
        private System.Windows.Forms.Label lblScore12;
        private System.Windows.Forms.Label lblScore24;
        private System.Windows.Forms.Label lblScore23;
        private System.Windows.Forms.Label lblScore22;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTeam21;
        private System.Windows.Forms.Label lblTeam11;
        private System.Windows.Forms.Label lblScore21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableView;
    }
}
