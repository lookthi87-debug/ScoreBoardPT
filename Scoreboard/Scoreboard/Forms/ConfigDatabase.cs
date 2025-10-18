using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Scoreboard.Data;

namespace Scoreboard
{
    public class ConfigDatabase : MaterialForm
    {
        private TextBox txtHost;
        private Label lblHost;
        private TextBox txtPort;
        private Label label1;
        private TextBox txtDatabase;
        private Label label2;
        private TextBox txtUserName;
        private Label label3;
        private TextBox txtPass;
        private Label label4;
        private MaterialButton btnCancel;
        private MaterialButton btnConnect;
        public ConfigDatabase()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDatabase));
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.btnConnect = new MaterialSkin.Controls.MaterialButton();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtHost.Location = new System.Drawing.Point(132, 86);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(354, 29);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "localhost";
            // 
            // lblHost
            // 
            this.lblHost.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(17, 86);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(109, 23);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host (IP)";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = false;
            this.btnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConnect.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConnect.Depth = 0;
            this.btnConnect.HighEmphasis = true;
            this.btnConnect.Icon = null;
            this.btnConnect.Location = new System.Drawing.Point(328, 276);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(158, 36);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Kết nối";
            this.btnConnect.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConnect.UseAccentColor = false;
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPort.Location = new System.Drawing.Point(132, 121);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(354, 29);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5432";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Post";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtDatabase.Location = new System.Drawing.Point(132, 156);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(354, 29);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.Text = "DB_Scoreboard";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Database Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtUserName.Location = new System.Drawing.Point(132, 191);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(354, 29);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "postgres";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "User Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Arial Unicode MS", 12F);
            this.txtPass.Location = new System.Drawing.Point(132, 227);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(354, 29);
            this.txtPass.TabIndex = 4;
            this.txtPass.Text = "Abc12345";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pass word";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(132, 276);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(158, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigDatabase
            // 
            this.ClientSize = new System.Drawing.Size(520, 349);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigDatabase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigDatabase_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private bool IsConect = false;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtHost.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập host.");
                txtHost.Focus();
            }
            if (txtPort.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập port.");
                txtPort.Focus();
            }
            if (txtDatabase.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập database name.");
                txtDatabase.Focus();
            }
            if (txtUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập user name.");
                txtUserName.Focus();
            }
            if (txtPass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập password.");
                txtPass.Focus();
            }
            PostgresHelper.SaveConfig(txtHost.Text.Trim(), txtPort.Text.Trim(), txtDatabase.Text.Trim(), txtUserName.Text.Trim(), txtPass.Text.Trim());
            if (PostgresHelper.OpenSharedConnection() == true)
            {
                Repository.AddDefaultUser();
                IsConect = true;
                MessageBox.Show("Connect thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Connect thất bại.");
                txtHost.Focus();
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            var cf = PostgresHelper.LoadConfig();
            txtHost.Text = cf.Host;
            txtPort.Text = cf.Port;
            txtDatabase.Text = cf.Database;
            txtUserName.Text = cf.User;
            txtPass.Text = cf.Password;
        }

        private void ConfigDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsConect == false)
            {
                Application.Exit();
            }
        }
    }
}
