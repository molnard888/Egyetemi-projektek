using System.ComponentModel;

namespace Raktarkezelo
{
    partial class WebcamQrScanner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.BeolvasButton = new System.Windows.Forms.Button();
            this.VisszaButton = new System.Windows.Forms.Button();
            this.ResultTextbox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Timers.Timer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WebcamTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.timer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BeolvasButton
            // 
            this.BeolvasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.BeolvasButton.Location = new System.Drawing.Point(12, 399);
            this.BeolvasButton.Name = "BeolvasButton";
            this.BeolvasButton.Size = new System.Drawing.Size(96, 37);
            this.BeolvasButton.TabIndex = 1;
            this.BeolvasButton.Text = "Beolvas";
            this.BeolvasButton.UseVisualStyleBackColor = true;
            this.BeolvasButton.Click += new System.EventHandler(this.BeolvasButton_Click);
            // 
            // VisszaButton
            // 
            this.VisszaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.VisszaButton.Location = new System.Drawing.Point(438, 399);
            this.VisszaButton.Name = "VisszaButton";
            this.VisszaButton.Size = new System.Drawing.Size(96, 37);
            this.VisszaButton.TabIndex = 2;
            this.VisszaButton.Text = "Vissza";
            this.VisszaButton.UseVisualStyleBackColor = true;
            this.VisszaButton.Click += new System.EventHandler(this.VisszaButton_Click);
            // 
            // ResultTextbox
            // 
            this.ResultTextbox.Enabled = false;
            this.ResultTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.ResultTextbox.Location = new System.Drawing.Point(114, 408);
            this.ResultTextbox.Name = "ResultTextbox";
            this.ResultTextbox.Size = new System.Drawing.Size(255, 22);
            this.ResultTextbox.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 360);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // WebcamTextbox
            // 
            this.WebcamTextbox.Enabled = false;
            this.WebcamTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.WebcamTextbox.Location = new System.Drawing.Point(114, 378);
            this.WebcamTextbox.Name = "WebcamTextbox";
            this.WebcamTextbox.Size = new System.Drawing.Size(255, 22);
            this.WebcamTextbox.TabIndex = 5;
            // 
            // WebcamQrScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(546, 448);
            this.Controls.Add(this.WebcamTextbox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ResultTextbox);
            this.Controls.Add(this.VisszaButton);
            this.Controls.Add(this.BeolvasButton);
            this.Name = "WebcamQrScanner";
            this.Text = "WebcamQrScanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebcamQrScanner_FormClosing);
            this.Load += new System.EventHandler(this.WebcamQrScanner_Load);
            ((System.ComponentModel.ISupportInitialize) (this.timer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox WebcamTextbox;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Timers.Timer timer1;

        private System.Windows.Forms.Button BeolvasButton;
        private System.Windows.Forms.Button VisszaButton;
        private System.Windows.Forms.TextBox ResultTextbox;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}