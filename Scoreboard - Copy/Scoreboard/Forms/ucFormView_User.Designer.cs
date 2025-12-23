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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblHiepDau = new System.Windows.Forms.Label();
            this.lblScoreTeam2 = new System.Windows.Forms.Label();
            this.lblScoreTeam1 = new System.Windows.Forms.Label();
            this.lblTeam2 = new System.Windows.Forms.Label();
            this.lblTeam1 = new System.Windows.Forms.Label();
            this.tableView = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSetScores = new System.Windows.Forms.TableLayoutPanel();
            this.tblFlagVN = new System.Windows.Forms.TableLayoutPanel();
            this.pgFlagVN = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pgFlagTeam2 = new System.Windows.Forms.PictureBox();
            this.pgFlagTeam1 = new System.Windows.Forms.PictureBox();
            this.tableView.SuspendLayout();
            this.tblFlagVN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagVN)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam1)).BeginInit();
            this.SuspendLayout();
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
            // lblScoreTeam2
            // 
            this.lblScoreTeam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScoreTeam2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreTeam2.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblScoreTeam2.Location = new System.Drawing.Point(290, 0);
            this.lblScoreTeam2.Name = "lblScoreTeam2";
            this.lblScoreTeam2.Size = new System.Drawing.Size(181, 36);
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
            this.lblScoreTeam1.Size = new System.Drawing.Size(181, 36);
            this.lblScoreTeam1.TabIndex = 17;
            this.lblScoreTeam1.Text = "0";
            this.lblScoreTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTeam2
            // 
            this.lblTeam2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam2.ForeColor = System.Drawing.Color.Red;
            this.lblTeam2.Location = new System.Drawing.Point(301, 0);
            this.lblTeam2.Name = "lblTeam2";
            this.lblTeam2.Size = new System.Drawing.Size(170, 46);
            this.lblTeam2.TabIndex = 7;
            this.lblTeam2.Text = "Đội 2";
            this.lblTeam2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTeam1
            // 
            this.lblTeam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTeam1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeam1.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTeam1.Location = new System.Drawing.Point(3, 0);
            this.lblTeam1.Name = "lblTeam1";
            this.lblTeam1.Size = new System.Drawing.Size(170, 46);
            this.lblTeam1.TabIndex = 5;
            this.lblTeam1.Text = "Đội 1";
            this.lblTeam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableView
            // 
            this.tableView.ColumnCount = 1;
            this.tableView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableView.Controls.Add(this.pnlSetScores, 0, 7);
            this.tableView.Controls.Add(this.tblFlagVN, 3, 0);
            this.tableView.Controls.Add(this.tableLayoutPanel1, 0, 6);
            this.tableView.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableView.Controls.Add(this.lblHiepDau, 0, 3);
            this.tableView.Controls.Add(this.lblTime, 0, 2);
            this.tableView.Controls.Add(this.lblTitle, 0, 1);
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
            this.tableView.Size = new System.Drawing.Size(480, 270);
            this.tableView.TabIndex = 7;
            // 
            // pnlSetScores
            // 
            this.pnlSetScores.BackColor = System.Drawing.Color.Black;
            this.pnlSetScores.ColumnCount = 1;
            this.pnlSetScores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSetScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetScores.Location = new System.Drawing.Point(3, 259);
            this.pnlSetScores.Name = "pnlSetScores";
            this.pnlSetScores.RowCount = 2;
            this.pnlSetScores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSetScores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSetScores.Size = new System.Drawing.Size(474, 8);
            this.pnlSetScores.TabIndex = 47;
            this.pnlSetScores.Visible = false;
            // 
            // tblFlagVN
            // 
            this.tblFlagVN.ColumnCount = 3;
            this.tblFlagVN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFlagVN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tblFlagVN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblFlagVN.Controls.Add(this.pgFlagVN, 1, 0);
            this.tblFlagVN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFlagVN.Location = new System.Drawing.Point(3, 3);
            this.tblFlagVN.Name = "tblFlagVN";
            this.tblFlagVN.RowCount = 1;
            this.tblFlagVN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFlagVN.Size = new System.Drawing.Size(474, 52);
            this.tblFlagVN.TabIndex = 46;
            // 
            // pgFlagVN
            // 
            this.pgFlagVN.Location = new System.Drawing.Point(180, 3);
            this.pgFlagVN.Name = "pgFlagVN";
            this.pgFlagVN.Size = new System.Drawing.Size(114, 46);
            this.pgFlagVN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pgFlagVN.TabIndex = 45;
            this.pgFlagVN.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
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
            this.pgFlagTeam2.Location = new System.Drawing.Point(251, 3);
            this.pgFlagTeam2.Name = "pgFlagTeam2";
            this.pgFlagTeam2.Size = new System.Drawing.Size(40, 30);
            this.pgFlagTeam2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pgFlagTeam2.TabIndex = 47;
            this.pgFlagTeam2.TabStop = false;
            // 
            // pgFlagTeam1
            // 
            this.pgFlagTeam1.Location = new System.Drawing.Point(179, 3);
            this.pgFlagTeam1.Name = "pgFlagTeam1";
            this.pgFlagTeam1.Size = new System.Drawing.Size(40, 30);
            this.pgFlagTeam1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pgFlagTeam1.TabIndex = 46;
            this.pgFlagTeam1.TabStop = false;
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
            this.tableView.ResumeLayout(false);
            this.tableView.PerformLayout();
            this.tblFlagVN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagVN)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgFlagTeam1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblHiepDau;
        private System.Windows.Forms.Label lblScoreTeam2;
        private System.Windows.Forms.Label lblScoreTeam1;
        private System.Windows.Forms.Label lblTeam2;
        private System.Windows.Forms.Label lblTeam1;
        private System.Windows.Forms.TableLayoutPanel tableView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblFlagVN;
        private System.Windows.Forms.PictureBox pgFlagVN;
        private System.Windows.Forms.PictureBox pgFlagTeam2;
        private System.Windows.Forms.PictureBox pgFlagTeam1;
        private System.Windows.Forms.TableLayoutPanel pnlSetScores;
    }
}
