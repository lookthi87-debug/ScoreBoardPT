using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;
using System.IO;

namespace Scoreboard.Forms
{
    public class AddUpdateFlagVN : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private PictureBox pbFlag;
        private MaterialButton btnSave;
        private OpenFileDialog openFileDialog;
        private MaterialButton btnCancel;
        private FlagModel currentFlag; 
        public AddUpdateFlagVN()
        {
            InitializeComponent();
            LoadFlagImages();
        }
        private void InitializeComponent()
        {
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbFlag = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(290, 284);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 557);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pbFlag);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(144, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 338);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pbFlag
            // 
            this.pbFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFlag.Location = new System.Drawing.Point(26, 12);
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Size = new System.Drawing.Size(468, 263);
            this.pbFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFlag.TabIndex = 42;
            this.pbFlag.TabStop = false;
            this.pbFlag.DoubleClick += new System.EventHandler(this.pbFlag_DoubleClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|A" +
    "ll files (*.*)|*.*";
            this.openFileDialog.Title = "Chọn hình ảnh lá cờ";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(99, 284);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddUpdateFlagVN
            // 
            this.ClientSize = new System.Drawing.Size(812, 557);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateFlagVN";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdateFlagVN";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).EndInit();
            this.ResumeLayout(false);

        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pbFlag.Image == null)
            {
                MessageBox.Show("Vui lòng chọn cờ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
     
            try
            {
                Repository.DeleteFlag();
                Repository.AddFlag(currentFlag);
                MessageBox.Show("Lưu thành công.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbFlag_DoubleClick(object sender, EventArgs e)
        {
            SelectFlagImage();
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
                    currentFlag.Flag = imageBytes; // LƯU DB
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFlagImages()
        {
            try
            {
                currentFlag = new FlagModel();
                currentFlag = Repository.GetFlag();
                if (currentFlag.Flag != null)
                {
                    using (var ms = new MemoryStream(currentFlag.Flag))
                    {
                        pbFlag.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
