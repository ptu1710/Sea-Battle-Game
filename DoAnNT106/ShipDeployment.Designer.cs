namespace Battleships
{
    partial class ShipDeployment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipDeployment));
            this.deckPictureBox = new System.Windows.Forms.PictureBox();
            this.rotateBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.playBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.roomIDLabel = new System.Windows.Forms.Label();
            this.circularBtn1 = new Battleships.CircularBtn();
            ((System.ComponentModel.ISupportInitialize)(this.deckPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // deckPictureBox
            // 
            this.deckPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deckPictureBox.BackgroundImage = global::Battleships.Properties.Resources.bg;
            this.deckPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deckPictureBox.Location = new System.Drawing.Point(399, 27);
            this.deckPictureBox.Name = "deckPictureBox";
            this.deckPictureBox.Size = new System.Drawing.Size(398, 398);
            this.deckPictureBox.TabIndex = 2;
            this.deckPictureBox.TabStop = false;
            this.deckPictureBox.Click += new System.EventHandler(this.DeckPictureBoxClick);
            this.deckPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.deckPictureBox_Paint);
            this.deckPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deckPictureBox_MouseMove);
            // 
            // rotateBtn
            // 
            this.rotateBtn.BackgroundImage = global::Battleships.Properties.Resources.screenshot_1653467821;
            this.rotateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rotateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotateBtn.Location = new System.Drawing.Point(286, 42);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.Size = new System.Drawing.Size(107, 65);
            this.rotateBtn.TabIndex = 3;
            this.rotateBtn.UseVisualStyleBackColor = true;
            this.rotateBtn.Click += new System.EventHandler(this.rotateBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Battleships.Properties.Resources.Ship_2;
            this.pictureBox1.Location = new System.Drawing.Point(40, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::Battleships.Properties.Resources.Ship_3_1_;
            this.pictureBox2.Location = new System.Drawing.Point(40, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 50);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Image = global::Battleships.Properties.Resources.Ship_3_2_;
            this.pictureBox3.Location = new System.Drawing.Point(40, 149);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 50);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Image = global::Battleships.Properties.Resources.Ship_4;
            this.pictureBox4.Location = new System.Drawing.Point(40, 210);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 50);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = global::Battleships.Properties.Resources.Ship_5;
            this.pictureBox5.Location = new System.Drawing.Point(40, 271);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(250, 50);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // playBtn
            // 
            this.playBtn.Enabled = false;
            this.playBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(236, 353);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(100, 65);
            this.playBtn.TabIndex = 9;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(363, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(463, 453);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::Battleships.Properties.Resources.button;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(146, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(196, 93);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 12;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(196, 154);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 13;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Location = new System.Drawing.Point(246, 215);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 40);
            this.button6.TabIndex = 14;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Location = new System.Drawing.Point(296, 276);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(40, 40);
            this.button7.TabIndex = 15;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // roomIDLabel
            // 
            this.roomIDLabel.AutoSize = true;
            this.roomIDLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.roomIDLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomIDLabel.Location = new System.Drawing.Point(0, 436);
            this.roomIDLabel.Name = "roomIDLabel";
            this.roomIDLabel.Size = new System.Drawing.Size(46, 17);
            this.roomIDLabel.TabIndex = 16;
            this.roomIDLabel.Text = "label1";
            // 
            // circularBtn1
            // 
            this.circularBtn1.Location = new System.Drawing.Point(102, 353);
            this.circularBtn1.Name = "circularBtn1";
            this.circularBtn1.Size = new System.Drawing.Size(83, 71);
            this.circularBtn1.TabIndex = 17;
            this.circularBtn1.UseVisualStyleBackColor = true;
            // 
            // ShipDeployment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battleships.Properties.Resources.ShipDeployBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(826, 453);
            this.Controls.Add(this.circularBtn1);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.roomIDLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.deckPictureBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShipDeployment";
            this.Text = "Place your ships!";
            ((System.ComponentModel.ISupportInitialize)(this.deckPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox deckPictureBox;
        private System.Windows.Forms.Button rotateBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label roomIDLabel;
        private CircularBtn circularBtn1;
    }
}