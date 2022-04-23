using System.ComponentModel;

namespace Raktarkezelo
{
    partial class EladTermek
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
            this.EladButton = new System.Windows.Forms.Button();
            this.TelefonTextbox = new System.Windows.Forms.TextBox();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.VevoAdatLabel = new System.Windows.Forms.Label();
            this.VegosszegLabel = new System.Windows.Forms.Label();
            this.VegOsszegEmptyLabel = new System.Windows.Forms.Label();
            this.BeolvasButton = new System.Windows.Forms.Button();
            this.TorolButton = new System.Windows.Forms.Button();
            this.IdoLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.IdoTextbox = new System.Windows.Forms.Label();
            this.OsszTorolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EladButton
            // 
            this.EladButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.EladButton.Location = new System.Drawing.Point(632, 353);
            this.EladButton.Name = "EladButton";
            this.EladButton.Size = new System.Drawing.Size(133, 35);
            this.EladButton.TabIndex = 77;
            this.EladButton.Text = "Eladás";
            this.EladButton.UseVisualStyleBackColor = true;
            this.EladButton.Click += new System.EventHandler(this.EladButton_Click);
            // 
            // TelefonTextbox
            // 
            this.TelefonTextbox.Location = new System.Drawing.Point(487, 40);
            this.TelefonTextbox.Name = "TelefonTextbox";
            this.TelefonTextbox.Size = new System.Drawing.Size(278, 20);
            this.TelefonTextbox.TabIndex = 75;
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.Location = new System.Drawing.Point(61, 75);
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.Size = new System.Drawing.Size(515, 20);
            this.AddressTextbox.TabIndex = 74;
            // 
            // NameTextbox
            // 
            this.NameTextbox.Location = new System.Drawing.Point(61, 40);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(323, 20);
            this.NameTextbox.TabIndex = 73;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PhoneLabel.Location = new System.Drawing.Point(402, 41);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(79, 19);
            this.PhoneLabel.TabIndex = 71;
            this.PhoneLabel.Text = "Telefon:";
            // 
            // AddressLabel
            // 
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.AddressLabel.Location = new System.Drawing.Point(14, 74);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(52, 21);
            this.AddressLabel.TabIndex = 70;
            this.AddressLabel.Text = "Cím:";
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.NameLabel.Location = new System.Drawing.Point(14, 38);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(113, 22);
            this.NameLabel.TabIndex = 69;
            this.NameLabel.Text = "Név:";
            // 
            // VevoAdatLabel
            // 
            this.VevoAdatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.VevoAdatLabel.Location = new System.Drawing.Point(304, 9);
            this.VevoAdatLabel.Name = "VevoAdatLabel";
            this.VevoAdatLabel.Size = new System.Drawing.Size(177, 28);
            this.VevoAdatLabel.TabIndex = 78;
            this.VevoAdatLabel.Text = "A vevő adatai:";
            // 
            // VegosszegLabel
            // 
            this.VegosszegLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.VegosszegLabel.Location = new System.Drawing.Point(554, 292);
            this.VegosszegLabel.Name = "VegosszegLabel";
            this.VegosszegLabel.Size = new System.Drawing.Size(122, 28);
            this.VegosszegLabel.TabIndex = 79;
            this.VegosszegLabel.Text = "Végösszeg:";
            // 
            // VegOsszegEmptyLabel
            // 
            this.VegOsszegEmptyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.VegOsszegEmptyLabel.Location = new System.Drawing.Point(554, 320);
            this.VegOsszegEmptyLabel.Name = "VegOsszegEmptyLabel";
            this.VegOsszegEmptyLabel.Size = new System.Drawing.Size(209, 28);
            this.VegOsszegEmptyLabel.TabIndex = 80;
            this.VegOsszegEmptyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BeolvasButton
            // 
            this.BeolvasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.BeolvasButton.Location = new System.Drawing.Point(593, 125);
            this.BeolvasButton.Name = "BeolvasButton";
            this.BeolvasButton.Size = new System.Drawing.Size(133, 35);
            this.BeolvasButton.TabIndex = 81;
            this.BeolvasButton.Text = "Beolvas";
            this.BeolvasButton.UseVisualStyleBackColor = true;
            this.BeolvasButton.Click += new System.EventHandler(this.BeolvasButton_Click);
            // 
            // TorolButton
            // 
            this.TorolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.TorolButton.Location = new System.Drawing.Point(553, 180);
            this.TorolButton.Name = "TorolButton";
            this.TorolButton.Size = new System.Drawing.Size(101, 35);
            this.TorolButton.TabIndex = 82;
            this.TorolButton.Text = "Töröl";
            this.TorolButton.UseVisualStyleBackColor = true;
            this.TorolButton.Click += new System.EventHandler(this.TorolButton_Click);
            // 
            // IdoLabel
            // 
            this.IdoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.IdoLabel.Location = new System.Drawing.Point(553, 231);
            this.IdoLabel.Name = "IdoLabel";
            this.IdoLabel.Size = new System.Drawing.Size(212, 28);
            this.IdoLabel.TabIndex = 83;
            this.IdoLabel.Text = "A vásárlás időpontja:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(14, 125);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(534, 263);
            this.richTextBox1.TabIndex = 85;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Richtextbox1_MouseClick);
            // 
            // IdoTextbox
            // 
            this.IdoTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.IdoTextbox.Location = new System.Drawing.Point(576, 259);
            this.IdoTextbox.Name = "IdoTextbox";
            this.IdoTextbox.Size = new System.Drawing.Size(187, 28);
            this.IdoTextbox.TabIndex = 86;
            // 
            // OsszTorolButton
            // 
            this.OsszTorolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.OsszTorolButton.Location = new System.Drawing.Point(660, 180);
            this.OsszTorolButton.Name = "OsszTorolButton";
            this.OsszTorolButton.Size = new System.Drawing.Size(101, 48);
            this.OsszTorolButton.TabIndex = 87;
            this.OsszTorolButton.Text = "Összes töröl";
            this.OsszTorolButton.UseVisualStyleBackColor = true;
            this.OsszTorolButton.Click += new System.EventHandler(this.OsszTorolButton_Click);
            // 
            // EladTermek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 407);
            this.Controls.Add(this.OsszTorolButton);
            this.Controls.Add(this.IdoTextbox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.IdoLabel);
            this.Controls.Add(this.TorolButton);
            this.Controls.Add(this.BeolvasButton);
            this.Controls.Add(this.VegOsszegEmptyLabel);
            this.Controls.Add(this.VegosszegLabel);
            this.Controls.Add(this.VevoAdatLabel);
            this.Controls.Add(this.EladButton);
            this.Controls.Add(this.TelefonTextbox);
            this.Controls.Add(this.AddressTextbox);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "EladTermek";
            this.Text = "EladTermek";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button OsszTorolButton;

        private System.Windows.Forms.Label IdoTextbox;

        private System.Windows.Forms.RichTextBox richTextBox1;

        private System.Windows.Forms.Button BeolvasButton;
        private System.Windows.Forms.Button TorolButton;
        private System.Windows.Forms.Label IdoLabel;

        private System.Windows.Forms.Label VevoAdatLabel;
        private System.Windows.Forms.Label VegosszegLabel;
        private System.Windows.Forms.Label VegOsszegEmptyLabel;

        private System.Windows.Forms.Button EladButton;
        private System.Windows.Forms.TextBox TelefonTextbox;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label NameLabel;

        #endregion
    }
}