using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;

namespace Scoreboard
{
    public class AdminForm : MaterialForm
    {
        private MaterialButton btnUser;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private MaterialButton btnTournaments;
        private MaterialButton btnMatch;
        private UserModel User;

        public AdminForm(UserModel user)
        {
            InitializeComponent();
            User = user;

        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.btnTournaments = new MaterialSkin.Controls.MaterialButton();
            this.btnUser = new MaterialSkin.Controls.MaterialButton();
            this.btnMatch = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTournaments
            // 
            this.btnTournaments.AutoSize = false;
            this.btnTournaments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTournaments.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTournaments.Depth = 0;
            this.btnTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTournaments.HighEmphasis = true;
            this.btnTournaments.Icon = null;
            this.btnTournaments.Location = new System.Drawing.Point(61, 269);
            this.btnTournaments.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTournaments.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTournaments.Name = "btnTournaments";
            this.btnTournaments.Size = new System.Drawing.Size(200, 62);
            this.btnTournaments.TabIndex = 3;
            this.btnTournaments.Text = "Giải đấu";
            this.btnTournaments.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTournaments.UseAccentColor = false;
            this.btnTournaments.UseVisualStyleBackColor = true;
            this.btnTournaments.Click += new System.EventHandler(this.btnTournaments_Click);
            // 
            // btnUser
            // 
            this.btnUser.AutoSize = false;
            this.btnUser.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUser.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUser.Depth = 0;
            this.btnUser.HighEmphasis = true;
            this.btnUser.Icon = null;
            this.btnUser.Location = new System.Drawing.Point(336, 195);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(200, 62);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "user";
            this.btnUser.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUser.UseAccentColor = false;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnMatch
            // 
            this.btnMatch.AutoSize = false;
            this.btnMatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMatch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMatch.Depth = 0;
            this.btnMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatch.HighEmphasis = true;
            this.btnMatch.Icon = null;
            this.btnMatch.Location = new System.Drawing.Point(61, 195);
            this.btnMatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(200, 62);
            this.btnMatch.TabIndex = 7;
            this.btnMatch.Text = "Cấu hình hệ thống";
            this.btnMatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMatch.UseAccentColor = false;
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Scoreboard.Properties.Resources.User;
            this.pictureBox2.Location = new System.Drawing.Point(336, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Scoreboard.Properties.Resources.Board;
            this.pictureBox1.Location = new System.Drawing.Point(61, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 364);
            this.Controls.Add(this.btnMatch);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnTournaments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnTournaments_Click(object sender, EventArgs e)
        {
            var frmTournaments = new TournamentsForm(User);
            frmTournaments.ShowDialog();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            var frmUser = new UsersForm(User);
            frmUser.ShowDialog();
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            var frmUser = new MatchsForm(User);
            frmUser.ShowDialog();
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
