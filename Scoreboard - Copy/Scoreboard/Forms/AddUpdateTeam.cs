using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using MaterialSkin.Controls;
using Scoreboard.Config;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Scoreboard.Forms
{
    public class AddUpdateTeam : Form
    {
        private System.Windows.Forms.TextBox txtName;
        private Label lblName;
        private MaterialButton btnCancel;
        private MaterialButton btnSave;
        private Label lblNote;
        private System.Windows.Forms.TextBox txtnote;
        private PictureBox pbFlag;
        private Label label1;
        private OpenFileDialog openFileDialog;
        private TeamModel currentTeam;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateTeam));
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.pbFlag = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(125, 36);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(303, 26);
            this.txtName.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(9, 36);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(110, 29);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Tên";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(228, 414);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 36);
            this.btnCancel.TabIndex = 10;
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
            this.btnSave.Location = new System.Drawing.Point(402, 414);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNote
            // 
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(9, 298);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(110, 29);
            this.lblNote.TabIndex = 37;
            this.lblNote.Text = "Ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtnote
            // 
            this.txtnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtnote.Location = new System.Drawing.Point(125, 298);
            this.txtnote.Multiline = true;
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(621, 94);
            this.txtnote.TabIndex = 9;
            // 
            // pbFlag
            // 
            this.pbFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFlag.Location = new System.Drawing.Point(125, 68);
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Size = new System.Drawing.Size(303, 224);
            this.pbFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFlag.TabIndex = 41;
            this.pbFlag.TabStop = false;
            this.pbFlag.DoubleClick += new System.EventHandler(this.pbFlag_DoubleClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|A" +
    "ll files (*.*)|*.*";
            this.openFileDialog.Title = "Chọn hình ảnh lá cờ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 44;
            this.label1.Text = "Logo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddUpdateTeam
            // 
            this.ClientSize = new System.Drawing.Size(766, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtnote);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pbFlag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateTeam";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddUpdateTeam_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void PopulateFromModel(TeamModel t)
        {
            txtName.Text = t.Name;
            txtnote.Text = t.Note;
            LoadFlagImages(t);
        }
        public AddUpdateTeam(int tournament_id, int id = -1)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(1);
            this.BackColor = System.Drawing.Color.White;

            if (id != -1)
            {
                // edit mode
                currentTeam = Repository.GetTeamById(id, tournament_id);
                if (currentTeam != null)
                    PopulateFromModel(currentTeam);
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentTeam = new TeamModel();
                    currentTeam.Id = -1;
                    currentTeam.TournamentsId=tournament_id;
                }
            }
            else
            {
                // create mode
                currentTeam = new TeamModel();
                currentTeam.Id = -1;
                currentTeam.TournamentsId = tournament_id;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validation
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhận tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                currentTeam.Name= txtName.Text;
                currentTeam.Note = txtnote.Text;
                if (currentTeam.Id == -1)
                {
                    Repository.AddTeam(currentTeam);
                    MessageBox.Show("Tạo mới thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Repository.UpdateTeam(currentTeam);
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
            up.ShowDialog();
        }

        private void SelectFlagImage()
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);

                using (var ms = new MemoryStream(imageBytes))
                {
                    Image img = Image.FromStream(ms);

                    pbFlag.Image?.Dispose();
                    pbFlag.Image = new Bitmap(img);
                    currentTeam.Flag = imageBytes; // LƯU DB
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFlagImages(TeamModel team)
        {
            try
            {
                if (team.Flag != null)
                {
                    using (var ms = new MemoryStream(team.Flag))
                    {
                        pbFlag.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void AddUpdateTeam_Paint(object sender, PaintEventArgs e)
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
        private void pbFlag_DoubleClick(object sender, EventArgs e)
        {
            SelectFlagImage();
        }
    }
}

