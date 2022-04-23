using System.ComponentModel;

namespace Raktarkezelo
{
    partial class Login
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
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PwTextbox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PwLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.UsernameTextbox.Location = new System.Drawing.Point(141, 82);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(222, 26);
            this.UsernameTextbox.TabIndex = 0;
            // 
            // PwTextbox
            // 
            this.PwTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PwTextbox.Location = new System.Drawing.Point(141, 133);
            this.PwTextbox.Name = "PwTextbox";
            this.PwTextbox.Size = new System.Drawing.Size(222, 26);
            this.PwTextbox.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.UsernameLabel.Location = new System.Drawing.Point(22, 82);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(113, 26);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Felhasználó:";
            // 
            // PwLabel
            // 
            this.PwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PwLabel.Location = new System.Drawing.Point(22, 133);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(80, 26);
            this.PwLabel.TabIndex = 3;
            this.PwLabel.Text = "Jelszó:";
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.LoginButton.Location = new System.Drawing.Point(114, 194);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(142, 38);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Bejelentkezés";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 253);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PwTextbox);
            this.Controls.Add(this.UsernameTextbox);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button LoginButton;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PwLabel;

        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PwTextbox;

        #endregion
    }
}