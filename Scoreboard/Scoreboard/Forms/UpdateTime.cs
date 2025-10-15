using System;
using System.Linq;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;
using Scoreboard.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;

namespace Scoreboard
{
    public class UpdateTime : MaterialForm
    {
        private MaterialButton btnSave;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.TextBox txtMinute;
        private Label label1;
        public MatchsetModel MatchsetModel;
        private void InitializeComponent()
        {
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnSave.Location = new System.Drawing.Point(75, 161);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 36);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Lưu lại";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHour
            // 
            this.txtHour.Font = new System.Drawing.Font("Arial Unicode MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHour.Location = new System.Drawing.Point(75, 93);
            this.txtHour.MaxLength = 2;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(48, 50);
            this.txtHour.TabIndex = 22;
            this.txtHour.Text = "00";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.Leave += new System.EventHandler(this.txtHour_Leave);
            // 
            // txtMinute
            // 
            this.txtMinute.Font = new System.Drawing.Font("Arial Unicode MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinute.Location = new System.Drawing.Point(148, 93);
            this.txtMinute.MaxLength = 2;
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(48, 50);
            this.txtMinute.TabIndex = 23;
            this.txtMinute.Text = "00";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinute.Leave += new System.EventHandler(this.txtMinute_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 50);
            this.label1.TabIndex = 24;
            this.label1.Text = ":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateTime
            // 
            this.ClientSize = new System.Drawing.Size(267, 246);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMinute);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateTime";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật thời gian thi đấu";
            this.Load += new System.EventHandler(this.UpdateTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public UpdateTime()
        {
            InitializeComponent();
            MatchsetModel = new MatchsetModel();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MatchsetModel.Time= txtHour.Text + ":" + txtMinute.Text;
            this.Close();
        }

        private void txtHour_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtHour.Text.Trim(), out int value))
            {
                if (value >= 0 && value <= 12)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Không được lớn hơn 12 giờ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHour.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không phải số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHour.Clear();
                txtHour.Focus();
                return;
            }
        }

        private void txtMinute_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtMinute.Text.Trim(), out int value))
            {
                if (value >= 0 && value <= 60)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Không được lớn hơn 60 phút", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMinute.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không phải số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMinute.Clear();
                txtMinute.Focus();
                return;
            }
        }

        private void UpdateTime_Load(object sender, EventArgs e)
        {
            if (MatchsetModel.Time != "00:00")
            {
                var parts = MatchsetModel.Time.Split(':');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int hours) &&
                    int.TryParse(parts[1], out int minutes))
                {
                    txtHour.Text = $"{hours:D2}";
                    txtMinute.Text = $"{minutes:D2}";
                }
            }
        }
    }
}
