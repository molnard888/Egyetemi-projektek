namespace Raktarkezelo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PwLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PWTxtB = new System.Windows.Forms.TextBox();
            this.UsernameTxtB = new System.Windows.Forms.TextBox();
            this.WorkerBasePanel = new System.Windows.Forms.Panel();
            this.BeolvasButton = new System.Windows.Forms.Button();
            this.EladasokButton = new System.Windows.Forms.Button();
            this.WbPanelSignedInAsUserLabel = new System.Windows.Forms.Label();
            this.WbPanelSignedInAsLabel = new System.Windows.Forms.Label();
            this.WbPanelSignOutButton = new System.Windows.Forms.Button();
            this.WbPanelAddNewUserButton = new System.Windows.Forms.Button();
            this.WbPanelDisplayUsersButton = new System.Windows.Forms.Button();
            this.WbPanelAddNewProductsButton = new System.Windows.Forms.Button();
            this.WbPanelDispProductsButton = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.WorkerBasePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.PwLabel);
            this.LoginPanel.Controls.Add(this.UsernameLabel);
            this.LoginPanel.Controls.Add(this.PWTxtB);
            this.LoginPanel.Controls.Add(this.UsernameTxtB);
            this.LoginPanel.Location = new System.Drawing.Point(348, 48);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(395, 181);
            this.LoginPanel.TabIndex = 0;
            // 
            // LoginButton
            // 
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.LoginButton.Location = new System.Drawing.Point(125, 133);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(142, 38);
            this.LoginButton.TabIndex = 14;
            this.LoginButton.Text = "Bejelentkezés";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PwLabel
            // 
            this.PwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PwLabel.Location = new System.Drawing.Point(33, 75);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(80, 26);
            this.PwLabel.TabIndex = 13;
            this.PwLabel.Text = "Jelszó:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.UsernameLabel.Location = new System.Drawing.Point(33, 21);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(113, 26);
            this.UsernameLabel.TabIndex = 12;
            this.UsernameLabel.Text = "Felhasználó:";
            // 
            // PWTxtB
            // 
            this.PWTxtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PWTxtB.Location = new System.Drawing.Point(152, 72);
            this.PWTxtB.Name = "PWTxtB";
            this.PWTxtB.Size = new System.Drawing.Size(222, 26);
            this.PWTxtB.TabIndex = 11;
            // 
            // UsernameTxtB
            // 
            this.UsernameTxtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.UsernameTxtB.Location = new System.Drawing.Point(152, 21);
            this.UsernameTxtB.Name = "UsernameTxtB";
            this.UsernameTxtB.Size = new System.Drawing.Size(222, 26);
            this.UsernameTxtB.TabIndex = 10;
            // 
            // WorkerBasePanel
            // 
            this.WorkerBasePanel.BackColor = System.Drawing.Color.Transparent;
            this.WorkerBasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkerBasePanel.Controls.Add(this.BeolvasButton);
            this.WorkerBasePanel.Controls.Add(this.EladasokButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelSignedInAsUserLabel);
            this.WorkerBasePanel.Controls.Add(this.WbPanelSignedInAsLabel);
            this.WorkerBasePanel.Controls.Add(this.WbPanelSignOutButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelAddNewUserButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelDisplayUsersButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelAddNewProductsButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelDispProductsButton);
            this.WorkerBasePanel.Location = new System.Drawing.Point(12, 503);
            this.WorkerBasePanel.Name = "WorkerBasePanel";
            this.WorkerBasePanel.Size = new System.Drawing.Size(1021, 89);
            this.WorkerBasePanel.TabIndex = 1;
            // 
            // BeolvasButton
            // 
            this.BeolvasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BeolvasButton.Location = new System.Drawing.Point(265, 15);
            this.BeolvasButton.Name = "BeolvasButton";
            this.BeolvasButton.Size = new System.Drawing.Size(125, 55);
            this.BeolvasButton.TabIndex = 9;
            this.BeolvasButton.Text = "Beolvasás";
            this.BeolvasButton.UseVisualStyleBackColor = true;
            this.BeolvasButton.Click += new System.EventHandler(this.BeolvasButton_Click);
            // 
            // EladasokButton
            // 
            this.EladasokButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.EladasokButton.Location = new System.Drawing.Point(396, 15);
            this.EladasokButton.Name = "EladasokButton";
            this.EladasokButton.Size = new System.Drawing.Size(125, 55);
            this.EladasokButton.TabIndex = 8;
            this.EladasokButton.Text = "Eladások";
            this.EladasokButton.UseVisualStyleBackColor = true;
            this.EladasokButton.Click += new System.EventHandler(this.EladasokButton_Click);
            // 
            // WbPanelSignedInAsUserLabel
            // 
            this.WbPanelSignedInAsUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.WbPanelSignedInAsUserLabel.Location = new System.Drawing.Point(874, 18);
            this.WbPanelSignedInAsUserLabel.Name = "WbPanelSignedInAsUserLabel";
            this.WbPanelSignedInAsUserLabel.Size = new System.Drawing.Size(143, 29);
            this.WbPanelSignedInAsUserLabel.TabIndex = 7;
            // 
            // WbPanelSignedInAsLabel
            // 
            this.WbPanelSignedInAsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.WbPanelSignedInAsLabel.Location = new System.Drawing.Point(852, 0);
            this.WbPanelSignedInAsLabel.Name = "WbPanelSignedInAsLabel";
            this.WbPanelSignedInAsLabel.Size = new System.Drawing.Size(98, 18);
            this.WbPanelSignedInAsLabel.TabIndex = 6;
            this.WbPanelSignedInAsLabel.Text = "Belépve:";
            // 
            // WbPanelSignOutButton
            // 
            this.WbPanelSignOutButton.Location = new System.Drawing.Point(894, 50);
            this.WbPanelSignOutButton.Name = "WbPanelSignOutButton";
            this.WbPanelSignOutButton.Size = new System.Drawing.Size(88, 28);
            this.WbPanelSignOutButton.TabIndex = 5;
            this.WbPanelSignOutButton.Text = "Kijelentkezés";
            this.WbPanelSignOutButton.UseVisualStyleBackColor = true;
            this.WbPanelSignOutButton.Click += new System.EventHandler(this.WbPanelSignOutButton_Click);
            // 
            // WbPanelAddNewUserButton
            // 
            this.WbPanelAddNewUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.WbPanelAddNewUserButton.Location = new System.Drawing.Point(658, 15);
            this.WbPanelAddNewUserButton.Name = "WbPanelAddNewUserButton";
            this.WbPanelAddNewUserButton.Size = new System.Drawing.Size(125, 55);
            this.WbPanelAddNewUserButton.TabIndex = 4;
            this.WbPanelAddNewUserButton.Text = "Új felhasználó";
            this.WbPanelAddNewUserButton.UseVisualStyleBackColor = true;
            this.WbPanelAddNewUserButton.Click += new System.EventHandler(this.WbPanelAddNewUserButton_Click);
            // 
            // WbPanelDisplayUsersButton
            // 
            this.WbPanelDisplayUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.WbPanelDisplayUsersButton.Location = new System.Drawing.Point(527, 15);
            this.WbPanelDisplayUsersButton.Name = "WbPanelDisplayUsersButton";
            this.WbPanelDisplayUsersButton.Size = new System.Drawing.Size(125, 55);
            this.WbPanelDisplayUsersButton.TabIndex = 3;
            this.WbPanelDisplayUsersButton.Text = "Felhasználók";
            this.WbPanelDisplayUsersButton.UseVisualStyleBackColor = true;
            this.WbPanelDisplayUsersButton.Click += new System.EventHandler(this.WbPanelDisplayUsersButton_Click);
            // 
            // WbPanelAddNewProductsButton
            // 
            this.WbPanelAddNewProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.WbPanelAddNewProductsButton.Location = new System.Drawing.Point(134, 15);
            this.WbPanelAddNewProductsButton.Name = "WbPanelAddNewProductsButton";
            this.WbPanelAddNewProductsButton.Size = new System.Drawing.Size(125, 55);
            this.WbPanelAddNewProductsButton.TabIndex = 1;
            this.WbPanelAddNewProductsButton.Text = "Új termék";
            this.WbPanelAddNewProductsButton.UseVisualStyleBackColor = true;
            this.WbPanelAddNewProductsButton.Click += new System.EventHandler(this.WbPanelAddNewProductsButton_Click);
            // 
            // WbPanelDispProductsButton
            // 
            this.WbPanelDispProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.WbPanelDispProductsButton.Location = new System.Drawing.Point(3, 15);
            this.WbPanelDispProductsButton.Name = "WbPanelDispProductsButton";
            this.WbPanelDispProductsButton.Size = new System.Drawing.Size(125, 55);
            this.WbPanelDispProductsButton.TabIndex = 0;
            this.WbPanelDispProductsButton.Text = "Termékek";
            this.WbPanelDispProductsButton.UseVisualStyleBackColor = true;
            this.WbPanelDispProductsButton.Click += new System.EventHandler(this.WbPanelDispProductsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1045, 596);
            this.Controls.Add(this.WorkerBasePanel);
            this.Controls.Add(this.LoginPanel);
            this.MaximumSize = new System.Drawing.Size(1061, 635);
            this.MinimumSize = new System.Drawing.Size(1061, 635);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raktarkezelo_OXOOBF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.WorkerBasePanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button BeolvasButton;

        private System.Windows.Forms.TextBox PWTxtB;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label PwLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox UsernameTxtB;

        private System.Windows.Forms.Button EladasokButton;


        private System.Windows.Forms.Button WbPanelDispProductsButton;
        private System.Windows.Forms.Button WbPanelAddNewProductsButton;
        private System.Windows.Forms.Button WbPanelDisplayUsersButton;
        private System.Windows.Forms.Button WbPanelAddNewUserButton;
        private System.Windows.Forms.Button WbPanelSignOutButton;
            
        private System.Windows.Forms.Label WbPanelSignedInAsLabel;
        private System.Windows.Forms.Label WbPanelSignedInAsUserLabel;

        private System.Windows.Forms.Panel WorkerBasePanel;
        private System.Windows.Forms.Panel LoginPanel;

        #endregion
    }
}