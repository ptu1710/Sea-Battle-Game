namespace Battleships
{
    partial class PlayForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.playerProgress = new System.Windows.Forms.ProgressBar();
            this.meProgress = new System.Windows.Forms.ProgressBar();
            this.playerPBox = new System.Windows.Forms.PictureBox();
            this.mePBox = new System.Windows.Forms.PictureBox();
            this.playerLabel = new System.Windows.Forms.Label();
            this.meLabel = new System.Windows.Forms.Label();
            this.bsLabel = new System.Windows.Forms.Label();
            this.mePBox1 = new System.Windows.Forms.PictureBox();
            this.playerPBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.afkTimer = new System.Windows.Forms.Timer(this.components);
            this.avtTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.playerProgress);
            this.panel1.Controls.Add(this.meProgress);
            this.panel1.Controls.Add(this.playerPBox);
            this.panel1.Controls.Add(this.mePBox);
            this.panel1.Controls.Add(this.playerLabel);
            this.panel1.Controls.Add(this.meLabel);
            this.panel1.Controls.Add(this.bsLabel);
            this.panel1.Controls.Add(this.mePBox1);
            this.panel1.Controls.Add(this.playerPBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 100);
            this.panel1.TabIndex = 0;
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
            this.button1.Location = new System.Drawing.Point(377, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 29);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playerProgress
            // 
            this.playerProgress.Location = new System.Drawing.Point(398, 91);
            this.playerProgress.Maximum = 60;
            this.playerProgress.Name = "playerProgress";
            this.playerProgress.Size = new System.Drawing.Size(398, 10);
            this.playerProgress.TabIndex = 6;
            // 
            // meProgress
            // 
            this.meProgress.Location = new System.Drawing.Point(0, 91);
            this.meProgress.Maximum = 60;
            this.meProgress.Name = "meProgress";
            this.meProgress.Size = new System.Drawing.Size(398, 10);
            this.meProgress.Step = 1;
            this.meProgress.TabIndex = 5;
            // 
            // playerPBox
            // 
            this.playerPBox.BackColor = System.Drawing.Color.Transparent;
            this.playerPBox.BackgroundImage = global::Battleships.Properties.Resources.American;
            this.playerPBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playerPBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerPBox.Location = new System.Drawing.Point(707, 3);
            this.playerPBox.Name = "playerPBox";
            this.playerPBox.Size = new System.Drawing.Size(86, 86);
            this.playerPBox.TabIndex = 4;
            this.playerPBox.TabStop = false;
            // 
            // mePBox
            // 
            this.mePBox.BackColor = System.Drawing.Color.Transparent;
            this.mePBox.BackgroundImage = global::Battleships.Properties.Resources.Russia;
            this.mePBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mePBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mePBox.Location = new System.Drawing.Point(3, 3);
            this.mePBox.Name = "mePBox";
            this.mePBox.Size = new System.Drawing.Size(86, 86);
            this.mePBox.TabIndex = 3;
            this.mePBox.TabStop = false;
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.playerLabel.Location = new System.Drawing.Point(602, 28);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(99, 32);
            this.playerLabel.TabIndex = 2;
            this.playerLabel.Text = "label1";
            this.playerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // meLabel
            // 
            this.meLabel.AutoSize = true;
            this.meLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.meLabel.Location = new System.Drawing.Point(91, 28);
            this.meLabel.Name = "meLabel";
            this.meLabel.Size = new System.Drawing.Size(99, 32);
            this.meLabel.TabIndex = 1;
            this.meLabel.Text = "label1";
            this.meLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bsLabel
            // 
            this.bsLabel.AutoSize = true;
            this.bsLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bsLabel.Location = new System.Drawing.Point(355, 0);
            this.bsLabel.Name = "bsLabel";
            this.bsLabel.Size = new System.Drawing.Size(86, 54);
            this.bsLabel.TabIndex = 0;
            this.bsLabel.Text = "VS";
            // 
            // mePBox1
            // 
            this.mePBox1.BackColor = System.Drawing.Color.Black;
            this.mePBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mePBox1.Location = new System.Drawing.Point(6, 8);
            this.mePBox1.Name = "mePBox1";
            this.mePBox1.Size = new System.Drawing.Size(60, 60);
            this.mePBox1.TabIndex = 7;
            this.mePBox1.TabStop = false;
            // 
            // playerPBox1
            // 
            this.playerPBox1.BackColor = System.Drawing.Color.Black;
            this.playerPBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerPBox1.Location = new System.Drawing.Point(730, 11);
            this.playerPBox1.Name = "playerPBox1";
            this.playerPBox1.Size = new System.Drawing.Size(60, 60);
            this.playerPBox1.TabIndex = 8;
            this.playerPBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 398);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Battleships.Properties.Resources.bg;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(396, 396);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(398, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(398, 398);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Battleships.Properties.Resources.bg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 398);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // afkTimer
            // 
            this.afkTimer.Interval = 500;
            this.afkTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 498);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(814, 545);
            this.MinimumSize = new System.Drawing.Size(814, 545);
            this.Name = "PlayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayForm_FormClosing);
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mePBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label bsLabel;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label meLabel;
        private System.Windows.Forms.PictureBox playerPBox;
        private System.Windows.Forms.PictureBox mePBox;
        private System.Windows.Forms.ProgressBar playerProgress;
        private System.Windows.Forms.ProgressBar meProgress;
        private System.Windows.Forms.Timer afkTimer;
        private System.Windows.Forms.PictureBox mePBox1;
        private System.Windows.Forms.PictureBox playerPBox1;
        private System.Windows.Forms.Timer avtTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}