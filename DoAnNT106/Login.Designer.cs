namespace Battleships
{
    partial class loginForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.userTBox = new System.Windows.Forms.TextBox();
            this.userPanel = new System.Windows.Forms.Panel();
            this.passPanel = new System.Windows.Forms.Panel();
            this.passTBox = new System.Windows.Forms.TextBox();
            this.mailPanel = new System.Windows.Forms.Panel();
            this.mailTBox = new System.Windows.Forms.TextBox();
            this.orLabel = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.signinBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.signinPanel = new System.Windows.Forms.Panel();
            this.settingBtn = new System.Windows.Forms.Button();
            this.loginPBox = new System.Windows.Forms.PictureBox();
            this.mailPBox = new System.Windows.Forms.PictureBox();
            this.passPBox = new System.Windows.Forms.PictureBox();
            this.userPBox = new System.Windows.Forms.PictureBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.registerPanel.SuspendLayout();
            this.signinPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userTBox
            // 
            this.userTBox.BackColor = System.Drawing.Color.Teal;
            this.userTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userTBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTBox.ForeColor = System.Drawing.Color.Black;
            this.userTBox.Location = new System.Drawing.Point(78, 209);
            this.userTBox.Name = "userTBox";
            this.userTBox.Size = new System.Drawing.Size(282, 23);
            this.userTBox.TabIndex = 1;
            this.userTBox.Text = "Username";
            this.userTBox.Enter += new System.EventHandler(this.userTBox_Enter);
            this.userTBox.Leave += new System.EventHandler(this.userTBox_Leave);
            // 
            // userPanel
            // 
            this.userPanel.BackColor = System.Drawing.Color.White;
            this.userPanel.Location = new System.Drawing.Point(40, 238);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(320, 1);
            this.userPanel.TabIndex = 6;
            // 
            // passPanel
            // 
            this.passPanel.BackColor = System.Drawing.Color.White;
            this.passPanel.Location = new System.Drawing.Point(40, 292);
            this.passPanel.Name = "passPanel";
            this.passPanel.Size = new System.Drawing.Size(320, 1);
            this.passPanel.TabIndex = 7;
            // 
            // passTBox
            // 
            this.passTBox.BackColor = System.Drawing.Color.Teal;
            this.passTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passTBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passTBox.ForeColor = System.Drawing.Color.Black;
            this.passTBox.Location = new System.Drawing.Point(78, 263);
            this.passTBox.Name = "passTBox";
            this.passTBox.Size = new System.Drawing.Size(282, 23);
            this.passTBox.TabIndex = 2;
            this.passTBox.Text = "Password";
            this.passTBox.Enter += new System.EventHandler(this.passTBox_Enter);
            this.passTBox.Leave += new System.EventHandler(this.passTBox_Leave);
            // 
            // mailPanel
            // 
            this.mailPanel.BackColor = System.Drawing.Color.White;
            this.mailPanel.Location = new System.Drawing.Point(40, 346);
            this.mailPanel.Name = "mailPanel";
            this.mailPanel.Size = new System.Drawing.Size(320, 1);
            this.mailPanel.TabIndex = 8;
            // 
            // mailTBox
            // 
            this.mailTBox.BackColor = System.Drawing.Color.Teal;
            this.mailTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mailTBox.Enabled = false;
            this.mailTBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailTBox.ForeColor = System.Drawing.Color.Black;
            this.mailTBox.Location = new System.Drawing.Point(78, 317);
            this.mailTBox.Name = "mailTBox";
            this.mailTBox.Size = new System.Drawing.Size(282, 23);
            this.mailTBox.TabIndex = 3;
            this.mailTBox.Text = "Email";
            this.mailTBox.Enter += new System.EventHandler(this.mailTBox_Enter);
            this.mailTBox.Leave += new System.EventHandler(this.mailTBox_Leave);
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orLabel.ForeColor = System.Drawing.Color.White;
            this.orLabel.Location = new System.Drawing.Point(141, 78);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(40, 23);
            this.orLabel.TabIndex = 1;
            this.orLabel.Text = "OR";
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.Cyan;
            this.registerBtn.FlatAppearance.BorderSize = 0;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.Font = new System.Drawing.Font("Arial", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.Location = new System.Drawing.Point(0, 18);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(152, 50);
            this.registerBtn.TabIndex = 0;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // signinBtn
            // 
            this.signinBtn.BackColor = System.Drawing.Color.Cyan;
            this.signinBtn.FlatAppearance.BorderSize = 0;
            this.signinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signinBtn.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signinBtn.Location = new System.Drawing.Point(0, 13);
            this.signinBtn.Name = "signinBtn";
            this.signinBtn.Size = new System.Drawing.Size(320, 50);
            this.signinBtn.TabIndex = 0;
            this.signinBtn.Text = "Sign In";
            this.signinBtn.UseVisualStyleBackColor = false;
            this.signinBtn.Click += new System.EventHandler(this.signinBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Silver;
            this.backBtn.Enabled = false;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Arial", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(167, 18);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(153, 50);
            this.backBtn.TabIndex = 2;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.Silver;
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.Location = new System.Drawing.Point(168, 18);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(152, 50);
            this.quitBtn.TabIndex = 1;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.quitBtn);
            this.registerPanel.Controls.Add(this.backBtn);
            this.registerPanel.Controls.Add(this.registerBtn);
            this.registerPanel.Location = new System.Drawing.Point(40, 413);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(320, 90);
            this.registerPanel.TabIndex = 5;
            // 
            // signinPanel
            // 
            this.signinPanel.Controls.Add(this.signinBtn);
            this.signinPanel.Controls.Add(this.orLabel);
            this.signinPanel.Location = new System.Drawing.Point(40, 312);
            this.signinPanel.Name = "signinPanel";
            this.signinPanel.Size = new System.Drawing.Size(320, 109);
            this.signinPanel.TabIndex = 4;
            // 
            // settingBtn
            // 
            this.settingBtn.FlatAppearance.BorderSize = 0;
            this.settingBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Image = global::Battleships.Properties.Resources.setting;
            this.settingBtn.Location = new System.Drawing.Point(0, 0);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(34, 34);
            this.settingBtn.TabIndex = 0;
            this.settingBtn.UseVisualStyleBackColor = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // loginPBox
            // 
            this.loginPBox.BackColor = System.Drawing.Color.Transparent;
            this.loginPBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loginPBox.Image = global::Battleships.Properties.Resources.login;
            this.loginPBox.Location = new System.Drawing.Point(130, 33);
            this.loginPBox.Name = "loginPBox";
            this.loginPBox.Size = new System.Drawing.Size(140, 140);
            this.loginPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginPBox.TabIndex = 0;
            this.loginPBox.TabStop = false;
            // 
            // mailPBox
            // 
            this.mailPBox.Enabled = false;
            this.mailPBox.Image = global::Battleships.Properties.Resources.email;
            this.mailPBox.Location = new System.Drawing.Point(40, 312);
            this.mailPBox.Name = "mailPBox";
            this.mailPBox.Size = new System.Drawing.Size(32, 32);
            this.mailPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mailPBox.TabIndex = 9;
            this.mailPBox.TabStop = false;
            // 
            // passPBox
            // 
            this.passPBox.Enabled = false;
            this.passPBox.Image = ((System.Drawing.Image)(resources.GetObject("passPBox.Image")));
            this.passPBox.Location = new System.Drawing.Point(40, 258);
            this.passPBox.Name = "passPBox";
            this.passPBox.Size = new System.Drawing.Size(32, 32);
            this.passPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.passPBox.TabIndex = 6;
            this.passPBox.TabStop = false;
            // 
            // userPBox
            // 
            this.userPBox.Enabled = false;
            this.userPBox.Image = ((System.Drawing.Image)(resources.GetObject("userPBox.Image")));
            this.userPBox.Location = new System.Drawing.Point(40, 204);
            this.userPBox.Name = "userPBox";
            this.userPBox.Size = new System.Drawing.Size(32, 32);
            this.userPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userPBox.TabIndex = 3;
            this.userPBox.TabStop = false;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.Color.Maroon;
            this.loginLabel.Location = new System.Drawing.Point(37, 174);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(0, 20);
            this.loginLabel.TabIndex = 10;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(400, 520);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.loginPBox);
            this.Controls.Add(this.registerPanel);
            this.Controls.Add(this.signinPanel);
            this.Controls.Add(this.mailPBox);
            this.Controls.Add(this.mailPanel);
            this.Controls.Add(this.mailTBox);
            this.Controls.Add(this.passPBox);
            this.Controls.Add(this.passPanel);
            this.Controls.Add(this.passTBox);
            this.Controls.Add(this.userPBox);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.userTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.loginForm_Shown);
            this.registerPanel.ResumeLayout(false);
            this.signinPanel.ResumeLayout(false);
            this.signinPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginPBox;
        private System.Windows.Forms.TextBox userTBox;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.PictureBox userPBox;
        private System.Windows.Forms.PictureBox passPBox;
        private System.Windows.Forms.Panel passPanel;
        private System.Windows.Forms.TextBox passTBox;
        private System.Windows.Forms.PictureBox mailPBox;
        private System.Windows.Forms.Panel mailPanel;
        private System.Windows.Forms.TextBox mailTBox;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button signinBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Panel registerPanel;
        private System.Windows.Forms.Panel signinPanel;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Label loginLabel;
    }
}