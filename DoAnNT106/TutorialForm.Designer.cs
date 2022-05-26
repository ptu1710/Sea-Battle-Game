namespace Battleships
{
    partial class TutorialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialForm));
            this.MainMenuBack_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainMenuBack_btn
            // 
            this.MainMenuBack_btn.BackColor = System.Drawing.Color.White;
            this.MainMenuBack_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainMenuBack_btn.Font = new System.Drawing.Font("Algerian", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuBack_btn.Image = global::Battleships.Properties.Resources.BackBtn;
            this.MainMenuBack_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MainMenuBack_btn.Location = new System.Drawing.Point(272, 487);
            this.MainMenuBack_btn.Name = "MainMenuBack_btn";
            this.MainMenuBack_btn.Size = new System.Drawing.Size(270, 54);
            this.MainMenuBack_btn.TabIndex = 8;
            this.MainMenuBack_btn.Text = "I GOT IT! FIGHT !!!";
            this.MainMenuBack_btn.UseVisualStyleBackColor = false;
            this.MainMenuBack_btn.Click += new System.EventHandler(this.MainMenuBack_btn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Algerian", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SandyBrown;
            this.label1.Location = new System.Drawing.Point(0, 67);
            this.label1.MaximumSize = new System.Drawing.Size(800, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 429);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Algerian", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.MaximumSize = new System.Drawing.Size(800, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 87);
            this.label2.TabIndex = 7;
            this.label2.Text = "INTRODUCTION";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TutorialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battleships.Properties.Resources.backgroundTuto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.MainMenuBack_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TutorialForm";
            this.Text = "How to play?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MainMenuBack_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}