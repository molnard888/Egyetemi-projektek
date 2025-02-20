using System.ComponentModel;

namespace Raktarkezelo
{
    partial class FelhasznaloKereses
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
            this.KeresesButton = new System.Windows.Forms.Button();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.TelefonTextbox = new System.Windows.Forms.TextBox();
            this.FirstnameTextbox = new System.Windows.Forms.TextBox();
            this.LastnameTextbox = new System.Windows.Forms.TextBox();
            this.IsAdminTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.StorageIdTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.FirstnameLabel = new System.Windows.Forms.Label();
            this.LastnameLabel = new System.Windows.Forms.Label();
            this.IsAdminLabel = new System.Windows.Forms.Label();
            this.PwLabel = new System.Windows.Forms.Label();
            this.StorageIdLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(156, 10);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(290, 20);
            this.UsernameTextbox.TabIndex = 106;
            // 
            // KeresesButton
            // 
            this.KeresesButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.KeresesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.KeresesButton.Location = new System.Drawing.Point(395, 131);
            this.KeresesButton.Name = "KeresesButton";
            this.KeresesButton.Size = new System.Drawing.Size(133, 35);
            this.KeresesButton.TabIndex = 105;
            this.KeresesButton.Text = "Keresés";
            this.KeresesButton.UseVisualStyleBackColor = true;
            this.KeresesButton.Click += new System.EventHandler(this.KeresesButton_Click);
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Location = new System.Drawing.Point(617, 86);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(290, 20);
            this.EmailTextbox.TabIndex = 104;
            // 
            // TelefonTextbox
            // 
            this.TelefonTextbox.Location = new System.Drawing.Point(617, 61);
            this.TelefonTextbox.Name = "TelefonTextbox";
            this.TelefonTextbox.Size = new System.Drawing.Size(290, 20);
            this.TelefonTextbox.TabIndex = 103;
            // 
            // FirstnameTextbox
            // 
            this.FirstnameTextbox.Location = new System.Drawing.Point(617, 35);
            this.FirstnameTextbox.Name = "FirstnameTextbox";
            this.FirstnameTextbox.Size = new System.Drawing.Size(290, 20);
            this.FirstnameTextbox.TabIndex = 102;
            // 
            // LastnameTextbox
            // 
            this.LastnameTextbox.Location = new System.Drawing.Point(617, 11);
            this.LastnameTextbox.Name = "LastnameTextbox";
            this.LastnameTextbox.Size = new System.Drawing.Size(290, 20);
            this.LastnameTextbox.TabIndex = 101;
            // 
            // IsAdminTextbox
            // 
            this.IsAdminTextbox.Location = new System.Drawing.Point(156, 88);
            this.IsAdminTextbox.Name = "IsAdminTextbox";
            this.IsAdminTextbox.Size = new System.Drawing.Size(290, 20);
            this.IsAdminTextbox.TabIndex = 100;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(156, 62);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(290, 20);
            this.PasswordTextbox.TabIndex = 99;
            // 
            // StorageIdTextbox
            // 
            this.StorageIdTextbox.Location = new System.Drawing.Point(156, 36);
            this.StorageIdTextbox.Name = "StorageIdTextbox";
            this.StorageIdTextbox.Size = new System.Drawing.Size(290, 20);
            this.StorageIdTextbox.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(156, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 97;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.EmailLabel.Location = new System.Drawing.Point(473, 86);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(138, 25);
            this.EmailLabel.TabIndex = 96;
            this.EmailLabel.Text = "Email:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PhoneLabel.Location = new System.Drawing.Point(473, 62);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(103, 19);
            this.PhoneLabel.TabIndex = 95;
            this.PhoneLabel.Text = "Telefon:";
            // 
            // FirstnameLabel
            // 
            this.FirstnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.FirstnameLabel.Location = new System.Drawing.Point(473, 35);
            this.FirstnameLabel.Name = "FirstnameLabel";
            this.FirstnameLabel.Size = new System.Drawing.Size(103, 21);
            this.FirstnameLabel.TabIndex = 94;
            this.FirstnameLabel.Text = "Keresztnév:";
            // 
            // LastnameLabel
            // 
            this.LastnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.LastnameLabel.Location = new System.Drawing.Point(473, 9);
            this.LastnameLabel.Name = "LastnameLabel";
            this.LastnameLabel.Size = new System.Drawing.Size(117, 22);
            this.LastnameLabel.TabIndex = 93;
            this.LastnameLabel.Text = "Vezetéknév:";
            // 
            // IsAdminLabel
            // 
            this.IsAdminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.IsAdminLabel.Location = new System.Drawing.Point(12, 85);
            this.IsAdminLabel.Name = "IsAdminLabel";
            this.IsAdminLabel.Size = new System.Drawing.Size(117, 23);
            this.IsAdminLabel.TabIndex = 92;
            this.IsAdminLabel.Text = "Jogosultság:";
            // 
            // PwLabel
            // 
            this.PwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PwLabel.Location = new System.Drawing.Point(12, 59);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(76, 23);
            this.PwLabel.TabIndex = 91;
            this.PwLabel.Text = "Jelszó:";
            // 
            // StorageIdLabel
            // 
            this.StorageIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.StorageIdLabel.Location = new System.Drawing.Point(12, 34);
            this.StorageIdLabel.Name = "StorageIdLabel";
            this.StorageIdLabel.Size = new System.Drawing.Size(103, 20);
            this.StorageIdLabel.TabIndex = 90;
            this.StorageIdLabel.Text = "Raktár ID:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.UsernameLabel.Location = new System.Drawing.Point(12, 9);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(167, 25);
            this.UsernameLabel.TabIndex = 89;
            this.UsernameLabel.Text = "Felhasználónév:";
            // 
            // FelhasznaloKereses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 183);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.KeresesButton);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.TelefonTextbox);
            this.Controls.Add(this.FirstnameTextbox);
            this.Controls.Add(this.LastnameTextbox);
            this.Controls.Add(this.IsAdminTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.StorageIdTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.FirstnameLabel);
            this.Controls.Add(this.LastnameLabel);
            this.Controls.Add(this.IsAdminLabel);
            this.Controls.Add(this.PwLabel);
            this.Controls.Add(this.StorageIdLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Name = "FelhasznaloKereses";
            this.Text = "FelhasznaloKereses";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.Button KeresesButton;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.TextBox TelefonTextbox;
        private System.Windows.Forms.TextBox FirstnameTextbox;
        private System.Windows.Forms.TextBox LastnameTextbox;
        private System.Windows.Forms.TextBox IsAdminTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox StorageIdTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label FirstnameLabel;
        private System.Windows.Forms.Label LastnameLabel;
        private System.Windows.Forms.Label IsAdminLabel;
        private System.Windows.Forms.Label PwLabel;
        private System.Windows.Forms.Label StorageIdLabel;
        private System.Windows.Forms.Label UsernameLabel;

        #endregion
    }
}