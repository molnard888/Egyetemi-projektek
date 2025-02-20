namespace Raktarkezelo
{
    partial class Kezdolap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kezdolap));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.PwLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PWTxtB = new System.Windows.Forms.TextBox();
            this.UsernameTxtB = new System.Windows.Forms.TextBox();
            this.WorkerBasePanel = new System.Windows.Forms.Panel();
            this.KezdolapButton = new System.Windows.Forms.Button();
            this.BeolvasButton = new System.Windows.Forms.Button();
            this.EladasokButton = new System.Windows.Forms.Button();
            this.WbPanelAddNewUserButton = new System.Windows.Forms.Button();
            this.WbPanelDisplayUsersButton = new System.Windows.Forms.Button();
            this.WbPanelAddNewProductsButton = new System.Windows.Forms.Button();
            this.WbPanelDispProductsButton = new System.Windows.Forms.Button();
            this.WbPanelSignedInAsUserLabel = new System.Windows.Forms.Label();
            this.WbPanelSignedInAsLabel = new System.Windows.Forms.Label();
            this.WbPanelSignOutButton = new System.Windows.Forms.Button();
            this.PanelControl_Main = new System.Windows.Forms.Panel();
            this.MuvNaploBttn = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.WorkerBasePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginPanel.BackColor = System.Drawing.SystemColors.Info;
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.PwLabel);
            this.LoginPanel.Controls.Add(this.UsernameLabel);
            this.LoginPanel.Controls.Add(this.PWTxtB);
            this.LoginPanel.Controls.Add(this.UsernameTxtB);
            this.LoginPanel.Location = new System.Drawing.Point(8, 510);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(542, 85);
            this.LoginPanel.TabIndex = 0;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoginButton.Location = new System.Drawing.Point(375, 35);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(142, 38);
            this.LoginButton.TabIndex = 14;
            this.LoginButton.Text = "Bejelentkezés";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PwLabel
            // 
            this.PwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PwLabel.Location = new System.Drawing.Point(21, 50);
            this.PwLabel.Name = "PwLabel";
            this.PwLabel.Size = new System.Drawing.Size(80, 26);
            this.PwLabel.TabIndex = 13;
            this.PwLabel.Text = "Jelszó:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UsernameLabel.Location = new System.Drawing.Point(21, 13);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(113, 26);
            this.UsernameLabel.TabIndex = 12;
            this.UsernameLabel.Text = "Felhasználó:";
            // 
            // PWTxtB
            // 
            this.PWTxtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PWTxtB.Location = new System.Drawing.Point(140, 47);
            this.PWTxtB.Name = "PWTxtB";
            this.PWTxtB.Size = new System.Drawing.Size(222, 26);
            this.PWTxtB.TabIndex = 11;
            // 
            // UsernameTxtB
            // 
            this.UsernameTxtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UsernameTxtB.Location = new System.Drawing.Point(140, 13);
            this.UsernameTxtB.Name = "UsernameTxtB";
            this.UsernameTxtB.Size = new System.Drawing.Size(222, 26);
            this.UsernameTxtB.TabIndex = 10;
            // 
            // WorkerBasePanel
            // 
            this.WorkerBasePanel.BackColor = System.Drawing.Color.Transparent;
            this.WorkerBasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkerBasePanel.Controls.Add(this.KezdolapButton);
            this.WorkerBasePanel.Controls.Add(this.BeolvasButton);
            this.WorkerBasePanel.Controls.Add(this.EladasokButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelAddNewUserButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelDisplayUsersButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelAddNewProductsButton);
            this.WorkerBasePanel.Controls.Add(this.WbPanelDispProductsButton);
            this.WorkerBasePanel.Location = new System.Drawing.Point(1, 0);
            this.WorkerBasePanel.Name = "WorkerBasePanel";
            this.WorkerBasePanel.Size = new System.Drawing.Size(1043, 49);
            this.WorkerBasePanel.TabIndex = 1;
            // 
            // KezdolapButton
            // 
            this.KezdolapButton.BackColor = System.Drawing.SystemColors.Info;
            this.KezdolapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KezdolapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KezdolapButton.Image = ((System.Drawing.Image)(resources.GetObject("KezdolapButton.Image")));
            this.KezdolapButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.KezdolapButton.Location = new System.Drawing.Point(8, 3);
            this.KezdolapButton.Name = "KezdolapButton";
            this.KezdolapButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.KezdolapButton.Size = new System.Drawing.Size(112, 40);
            this.KezdolapButton.TabIndex = 10;
            this.KezdolapButton.Text = "Kezdőlap";
            this.KezdolapButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KezdolapButton.UseVisualStyleBackColor = false;
            // 
            // BeolvasButton
            // 
            this.BeolvasButton.BackColor = System.Drawing.SystemColors.Info;
            this.BeolvasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BeolvasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BeolvasButton.Image = ((System.Drawing.Image)(resources.GetObject("BeolvasButton.Image")));
            this.BeolvasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BeolvasButton.Location = new System.Drawing.Point(386, 3);
            this.BeolvasButton.Name = "BeolvasButton";
            this.BeolvasButton.Size = new System.Drawing.Size(120, 40);
            this.BeolvasButton.TabIndex = 9;
            this.BeolvasButton.Text = "Beolvasás";
            this.BeolvasButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BeolvasButton.UseVisualStyleBackColor = false;
            this.BeolvasButton.Click += new System.EventHandler(this.BeolvasButton_Click);
            // 
            // EladasokButton
            // 
            this.EladasokButton.BackColor = System.Drawing.SystemColors.Info;
            this.EladasokButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EladasokButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.EladasokButton.Image = ((System.Drawing.Image)(resources.GetObject("EladasokButton.Image")));
            this.EladasokButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EladasokButton.Location = new System.Drawing.Point(512, 3);
            this.EladasokButton.Name = "EladasokButton";
            this.EladasokButton.Size = new System.Drawing.Size(112, 40);
            this.EladasokButton.TabIndex = 8;
            this.EladasokButton.Text = "Eladások";
            this.EladasokButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EladasokButton.UseVisualStyleBackColor = false;
            this.EladasokButton.Click += new System.EventHandler(this.EladasokButton_Click);
            // 
            // WbPanelAddNewUserButton
            // 
            this.WbPanelAddNewUserButton.BackColor = System.Drawing.SystemColors.Info;
            this.WbPanelAddNewUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WbPanelAddNewUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.WbPanelAddNewUserButton.Image = ((System.Drawing.Image)(resources.GetObject("WbPanelAddNewUserButton.Image")));
            this.WbPanelAddNewUserButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WbPanelAddNewUserButton.Location = new System.Drawing.Point(787, 3);
            this.WbPanelAddNewUserButton.Name = "WbPanelAddNewUserButton";
            this.WbPanelAddNewUserButton.Size = new System.Drawing.Size(158, 40);
            this.WbPanelAddNewUserButton.TabIndex = 4;
            this.WbPanelAddNewUserButton.Text = "Új felhasználó";
            this.WbPanelAddNewUserButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WbPanelAddNewUserButton.UseVisualStyleBackColor = false;
            this.WbPanelAddNewUserButton.Click += new System.EventHandler(this.UjFelhasznaloButton_Click);
            // 
            // WbPanelDisplayUsersButton
            // 
            this.WbPanelDisplayUsersButton.BackColor = System.Drawing.SystemColors.Info;
            this.WbPanelDisplayUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WbPanelDisplayUsersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.WbPanelDisplayUsersButton.Image = ((System.Drawing.Image)(resources.GetObject("WbPanelDisplayUsersButton.Image")));
            this.WbPanelDisplayUsersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WbPanelDisplayUsersButton.Location = new System.Drawing.Point(631, 3);
            this.WbPanelDisplayUsersButton.Name = "WbPanelDisplayUsersButton";
            this.WbPanelDisplayUsersButton.Size = new System.Drawing.Size(150, 40);
            this.WbPanelDisplayUsersButton.TabIndex = 3;
            this.WbPanelDisplayUsersButton.Text = "Felhasználók";
            this.WbPanelDisplayUsersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WbPanelDisplayUsersButton.UseVisualStyleBackColor = false;
            this.WbPanelDisplayUsersButton.Click += new System.EventHandler(this.FelhasznalokButton_Click);
            // 
            // WbPanelAddNewProductsButton
            // 
            this.WbPanelAddNewProductsButton.BackColor = System.Drawing.SystemColors.Info;
            this.WbPanelAddNewProductsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WbPanelAddNewProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WbPanelAddNewProductsButton.Image = ((System.Drawing.Image)(resources.GetObject("WbPanelAddNewProductsButton.Image")));
            this.WbPanelAddNewProductsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WbPanelAddNewProductsButton.Location = new System.Drawing.Point(260, 3);
            this.WbPanelAddNewProductsButton.Name = "WbPanelAddNewProductsButton";
            this.WbPanelAddNewProductsButton.Size = new System.Drawing.Size(120, 40);
            this.WbPanelAddNewProductsButton.TabIndex = 1;
            this.WbPanelAddNewProductsButton.Text = "Új termék";
            this.WbPanelAddNewProductsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WbPanelAddNewProductsButton.UseVisualStyleBackColor = false;
            this.WbPanelAddNewProductsButton.Click += new System.EventHandler(this.UjTermekButton_Click);
            // 
            // WbPanelDispProductsButton
            // 
            this.WbPanelDispProductsButton.BackColor = System.Drawing.SystemColors.Info;
            this.WbPanelDispProductsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WbPanelDispProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WbPanelDispProductsButton.Image = ((System.Drawing.Image)(resources.GetObject("WbPanelDispProductsButton.Image")));
            this.WbPanelDispProductsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WbPanelDispProductsButton.Location = new System.Drawing.Point(134, 3);
            this.WbPanelDispProductsButton.Name = "WbPanelDispProductsButton";
            this.WbPanelDispProductsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WbPanelDispProductsButton.Size = new System.Drawing.Size(120, 40);
            this.WbPanelDispProductsButton.TabIndex = 0;
            this.WbPanelDispProductsButton.Text = "Termékek";
            this.WbPanelDispProductsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.WbPanelDispProductsButton.UseVisualStyleBackColor = false;
            this.WbPanelDispProductsButton.Click += new System.EventHandler(this.TermekekButton_Click);
            // 
            // WbPanelSignedInAsUserLabel
            // 
            this.WbPanelSignedInAsUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.WbPanelSignedInAsUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WbPanelSignedInAsUserLabel.Location = new System.Drawing.Point(796, 536);
            this.WbPanelSignedInAsUserLabel.Name = "WbPanelSignedInAsUserLabel";
            this.WbPanelSignedInAsUserLabel.Size = new System.Drawing.Size(211, 29);
            this.WbPanelSignedInAsUserLabel.TabIndex = 7;
            this.WbPanelSignedInAsUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WbPanelSignedInAsLabel
            // 
            this.WbPanelSignedInAsLabel.BackColor = System.Drawing.Color.Transparent;
            this.WbPanelSignedInAsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WbPanelSignedInAsLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.WbPanelSignedInAsLabel.Location = new System.Drawing.Point(796, 510);
            this.WbPanelSignedInAsLabel.Name = "WbPanelSignedInAsLabel";
            this.WbPanelSignedInAsLabel.Size = new System.Drawing.Size(211, 18);
            this.WbPanelSignedInAsLabel.TabIndex = 6;
            this.WbPanelSignedInAsLabel.Text = "Felhasználó:";
            this.WbPanelSignedInAsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WbPanelSignOutButton
            // 
            this.WbPanelSignOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WbPanelSignOutButton.Location = new System.Drawing.Point(989, 507);
            this.WbPanelSignOutButton.Name = "WbPanelSignOutButton";
            this.WbPanelSignOutButton.Size = new System.Drawing.Size(33, 26);
            this.WbPanelSignOutButton.TabIndex = 5;
            this.WbPanelSignOutButton.Text = "->";
            this.WbPanelSignOutButton.UseVisualStyleBackColor = true;
            this.WbPanelSignOutButton.Click += new System.EventHandler(this.KijelentkezesButton_Click);
            // 
            // PanelControl_Main
            // 
            this.PanelControl_Main.BackColor = System.Drawing.Color.Transparent;
            this.PanelControl_Main.Location = new System.Drawing.Point(1, 50);
            this.PanelControl_Main.Name = "PanelControl_Main";
            this.PanelControl_Main.Size = new System.Drawing.Size(1043, 451);
            this.PanelControl_Main.TabIndex = 8;
            // 
            // MuvNaploBttn
            // 
            this.MuvNaploBttn.BackColor = System.Drawing.SystemColors.Info;
            this.MuvNaploBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuvNaploBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.MuvNaploBttn.Image = ((System.Drawing.Image)(resources.GetObject("MuvNaploBttn.Image")));
            this.MuvNaploBttn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MuvNaploBttn.Location = new System.Drawing.Point(652, 551);
            this.MuvNaploBttn.Name = "MuvNaploBttn";
            this.MuvNaploBttn.Size = new System.Drawing.Size(154, 40);
            this.MuvNaploBttn.TabIndex = 9;
            this.MuvNaploBttn.Text = "MűveletNapló";
            this.MuvNaploBttn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MuvNaploBttn.UseVisualStyleBackColor = false;
            this.MuvNaploBttn.Click += new System.EventHandler(this.MuvNaploButton_Click);
            // 
            // Kezdolap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1045, 596);
            this.Controls.Add(this.MuvNaploBttn);
            this.Controls.Add(this.PanelControl_Main);
            this.Controls.Add(this.WorkerBasePanel);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.WbPanelSignedInAsUserLabel);
            this.Controls.Add(this.WbPanelSignOutButton);
            this.Controls.Add(this.WbPanelSignedInAsLabel);
            this.MaximumSize = new System.Drawing.Size(1061, 635);
            this.MinimumSize = new System.Drawing.Size(1061, 635);
            this.Name = "Kezdolap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raktarkezelo_OXOOBF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bejelentkezes_FormClosing);
            this.Load += new System.EventHandler(this.Bejelentkezes_Load);
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

        private System.Windows.Forms.Panel PanelControl_Main;
        private System.Windows.Forms.Button KezdolapButton;
        private System.Windows.Forms.Button MuvNaploBttn;
    }
}