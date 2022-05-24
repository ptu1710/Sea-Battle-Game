namespace Battleships
{
    partial class MainMenu
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
            this.playBtn = new System.Windows.Forms.Button();
            this.howtoBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.BackgroundImage = global::Battleships.Properties.Resources.button;
            this.playBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playBtn.FlatAppearance.BorderSize = 0;
            this.playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(50, 50);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(200, 60);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "PLAY";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // howtoBtn
            // 
            this.howtoBtn.BackgroundImage = global::Battleships.Properties.Resources.button;
            this.howtoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.howtoBtn.FlatAppearance.BorderSize = 0;
            this.howtoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.howtoBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howtoBtn.Location = new System.Drawing.Point(50, 135);
            this.howtoBtn.Name = "howtoBtn";
            this.howtoBtn.Size = new System.Drawing.Size(200, 60);
            this.howtoBtn.TabIndex = 1;
            this.howtoBtn.Text = "HOW TO";
            this.howtoBtn.UseVisualStyleBackColor = true;
            this.howtoBtn.Click += new System.EventHandler(this.howtoBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackgroundImage = global::Battleships.Properties.Resources.button;
            this.quitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quitBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.Location = new System.Drawing.Point(50, 220);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(200, 60);
            this.quitBtn.TabIndex = 2;
            this.quitBtn.Text = "QUIT";
            this.quitBtn.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 422);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(0, 19);
            this.usernameLabel.TabIndex = 3;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.howtoBtn);
            this.Controls.Add(this.playBtn);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Shown += new System.EventHandler(this.MainMenu_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button howtoBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label usernameLabel;
    }
}

