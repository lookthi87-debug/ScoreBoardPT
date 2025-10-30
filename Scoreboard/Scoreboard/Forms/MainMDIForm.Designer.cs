namespace Scoreboard
{
    partial class MainMDIForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuTournaments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMatches = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.mDB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTournaments,
            this.menuMatches,
            this.menuUsers,
            this.menuLogout,
            this.mLicense,
            this.mDB});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 26);
            this.menuStrip1.TabIndex = 1;
            // 
            // menuTournaments
            // 
            this.menuTournaments.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTournaments.ForeColor = System.Drawing.Color.Blue;
            this.menuTournaments.Name = "menuTournaments";
            this.menuTournaments.Size = new System.Drawing.Size(90, 22);
            this.menuTournaments.Text = "⚽ Giải đấu";
            this.menuTournaments.Click += new System.EventHandler(this.menuTournaments_Click);
            // 
            // menuMatches
            // 
            this.menuMatches.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.menuMatches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menuMatches.Name = "menuMatches";
            this.menuMatches.Size = new System.Drawing.Size(93, 22);
            this.menuMatches.Text = "🏆 Trận đấu";
            this.menuMatches.Click += new System.EventHandler(this.menuMatches_Click);
            // 
            // menuUsers
            // 
            this.menuUsers.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Size = new System.Drawing.Size(108, 22);
            this.menuUsers.Text = "👤 Người dùng";
            this.menuUsers.Click += new System.EventHandler(this.menuUsers_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuLogout.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.menuLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(101, 22);
            this.menuLogout.Text = "🚪 Đăng xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // mLicense
            // 
            this.mLicense.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F);
            this.mLicense.ForeColor = System.Drawing.Color.Orange;
            this.mLicense.Name = "mLicense";
            this.mLicense.Size = new System.Drawing.Size(161, 22);
            this.mLicense.Text = "🔑 Bản quyền / License";
            this.mLicense.Click += new System.EventHandler(this.mLicense_Click);
            // 
            // mDB
            // 
            this.mDB.Name = "mDB";
            this.mDB.Size = new System.Drawing.Size(94, 22);
            this.mDB.Text = "⚙️ Cấu hình DB";
            this.mDB.Click += new System.EventHandler(this.mDB_Click);
            // 
            // MainMDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.IsMdiContainer = true;
            this.Name = "MainMDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scoreboard - Trang chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMDIForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuTournaments;
        private System.Windows.Forms.ToolStripMenuItem menuMatches;
        private System.Windows.Forms.ToolStripMenuItem menuUsers;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem mLicense;
        private System.Windows.Forms.ToolStripMenuItem mDB;
    }
}
