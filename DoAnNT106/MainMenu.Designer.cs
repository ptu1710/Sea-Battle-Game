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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.playBtn = new System.Windows.Forms.Button();
            this.howtoBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.roomidTBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playBtn.FlatAppearance.BorderSize = 0;
            this.playBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Image = global::Battleships.Properties.Resources.BackBtn;
            this.playBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playBtn.Location = new System.Drawing.Point(50, 113);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(200, 60);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "PLAY";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // howtoBtn
            // 
            this.howtoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.howtoBtn.FlatAppearance.BorderSize = 0;
            this.howtoBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howtoBtn.Image = global::Battleships.Properties.Resources.BackBtn;
            this.howtoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.howtoBtn.Location = new System.Drawing.Point(50, 198);
            this.howtoBtn.Name = "howtoBtn";
            this.howtoBtn.Size = new System.Drawing.Size(200, 60);
            this.howtoBtn.TabIndex = 2;
            this.howtoBtn.Text = "HOW TO";
            this.howtoBtn.UseVisualStyleBackColor = true;
            this.howtoBtn.Click += new System.EventHandler(this.howtoBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.Image = global::Battleships.Properties.Resources.BackBtn;
            this.quitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.quitBtn.Location = new System.Drawing.Point(50, 283);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(200, 60);
            this.quitBtn.TabIndex = 3;
            this.quitBtn.Text = "QUIT";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.usernameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.usernameLabel.Location = new System.Drawing.Point(0, 430);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(0, 20);
            this.usernameLabel.TabIndex = 4;
            // 
            // roomidTBox
            // 
            this.roomidTBox.BackColor = System.Drawing.Color.MidnightBlue;
            this.roomidTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomidTBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomidTBox.ForeColor = System.Drawing.Color.Chocolate;
            this.roomidTBox.Location = new System.Drawing.Point(50, 57);
            this.roomidTBox.Name = "roomidTBox";
            this.roomidTBox.Size = new System.Drawing.Size(200, 34);
            this.roomidTBox.TabIndex = 1;
            this.roomidTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Battleships.Properties.Resources.SpeakerPlay;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(735, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 41);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Battleships.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.roomidTBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.howtoBtn);
            this.Controls.Add(this.playBtn);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Shown += new System.EventHandler(this.MainMenu_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button howtoBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox roomidTBox;
        private System.Windows.Forms.Button button1;
    }
}

