namespace Battleships
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.startBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.logRTBox = new System.Windows.Forms.RichTextBox();
            this.lbRadioBtn = new System.Windows.Forms.RadioButton();
            this.lnRadioBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Lime;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(20, 70);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(100, 50);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Silver;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(130, 70);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(100, 50);
            this.exitBtn.TabIndex = 1;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // logRTBox
            // 
            this.logRTBox.BackColor = System.Drawing.Color.MintCream;
            this.logRTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRTBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logRTBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logRTBox.Location = new System.Drawing.Point(0, 135);
            this.logRTBox.Name = "logRTBox";
            this.logRTBox.ReadOnly = true;
            this.logRTBox.Size = new System.Drawing.Size(250, 318);
            this.logRTBox.TabIndex = 2;
            this.logRTBox.Text = "";
            // 
            // lbRadioBtn
            // 
            this.lbRadioBtn.AutoSize = true;
            this.lbRadioBtn.Checked = true;
            this.lbRadioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbRadioBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRadioBtn.Location = new System.Drawing.Point(20, 12);
            this.lbRadioBtn.Name = "lbRadioBtn";
            this.lbRadioBtn.Size = new System.Drawing.Size(89, 21);
            this.lbRadioBtn.TabIndex = 3;
            this.lbRadioBtn.TabStop = true;
            this.lbRadioBtn.Text = "127.0.0.1";
            this.lbRadioBtn.UseVisualStyleBackColor = true;
            // 
            // lnRadioBtn
            // 
            this.lnRadioBtn.AutoSize = true;
            this.lnRadioBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnRadioBtn.Location = new System.Drawing.Point(20, 39);
            this.lnRadioBtn.Name = "lnRadioBtn";
            this.lnRadioBtn.Size = new System.Drawing.Size(121, 21);
            this.lnRadioBtn.TabIndex = 4;
            this.lnRadioBtn.Text = "Local Network";
            this.lnRadioBtn.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 453);
            this.Controls.Add(this.lnRadioBtn);
            this.Controls.Add(this.lbRadioBtn);
            this.Controls.Add(this.logRTBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.startBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.RichTextBox logRTBox;
        private System.Windows.Forms.RadioButton lbRadioBtn;
        private System.Windows.Forms.RadioButton lnRadioBtn;
    }
}

