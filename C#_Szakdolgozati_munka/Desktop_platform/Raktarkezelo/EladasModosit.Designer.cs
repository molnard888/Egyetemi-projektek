using System.ComponentModel;

namespace Raktarkezelo
{
    partial class EladasModosit
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
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.ModositButton = new System.Windows.Forms.Button();
            this.SaletimeTextbox = new System.Windows.Forms.TextBox();
            this.SummaryTextbox = new System.Windows.Forms.TextBox();
            this.ItemnumbersTextbox = new System.Windows.Forms.TextBox();
            this.StorageIdTextbox = new System.Windows.Forms.TextBox();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.PhoneTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaletimeLabel = new System.Windows.Forms.Label();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.ItemnumbersTblLabel = new System.Windows.Forms.Label();
            this.StorageIDLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TorolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTextbox
            // 
            this.NameTextbox.Location = new System.Drawing.Point(55, 19);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(391, 20);
            this.NameTextbox.TabIndex = 106;
            // 
            // ModositButton
            // 
            this.ModositButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ModositButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.ModositButton.Location = new System.Drawing.Point(156, 209);
            this.ModositButton.Name = "ModositButton";
            this.ModositButton.Size = new System.Drawing.Size(133, 35);
            this.ModositButton.TabIndex = 105;
            this.ModositButton.Text = "Módosít";
            this.ModositButton.UseVisualStyleBackColor = true;
            this.ModositButton.Click += new System.EventHandler(this.ModositButton_Click);
            // 
            // SaletimeTextbox
            // 
            this.SaletimeTextbox.Location = new System.Drawing.Point(138, 173);
            this.SaletimeTextbox.Name = "SaletimeTextbox";
            this.SaletimeTextbox.Size = new System.Drawing.Size(308, 20);
            this.SaletimeTextbox.TabIndex = 103;
            // 
            // SummaryTextbox
            // 
            this.SummaryTextbox.Enabled = false;
            this.SummaryTextbox.Location = new System.Drawing.Point(121, 147);
            this.SummaryTextbox.Name = "SummaryTextbox";
            this.SummaryTextbox.Size = new System.Drawing.Size(325, 20);
            this.SummaryTextbox.TabIndex = 102;
            // 
            // ItemnumbersTextbox
            // 
            this.ItemnumbersTextbox.Enabled = false;
            this.ItemnumbersTextbox.Location = new System.Drawing.Point(121, 123);
            this.ItemnumbersTextbox.Name = "ItemnumbersTextbox";
            this.ItemnumbersTextbox.Size = new System.Drawing.Size(325, 20);
            this.ItemnumbersTextbox.TabIndex = 101;
            // 
            // StorageIdTextbox
            // 
            this.StorageIdTextbox.Location = new System.Drawing.Point(121, 97);
            this.StorageIdTextbox.Name = "StorageIdTextbox";
            this.StorageIdTextbox.Size = new System.Drawing.Size(325, 20);
            this.StorageIdTextbox.TabIndex = 100;
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.Location = new System.Drawing.Point(55, 71);
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.Size = new System.Drawing.Size(391, 20);
            this.AddressTextbox.TabIndex = 99;
            // 
            // PhoneTextbox
            // 
            this.PhoneTextbox.Location = new System.Drawing.Point(86, 45);
            this.PhoneTextbox.Name = "PhoneTextbox";
            this.PhoneTextbox.Size = new System.Drawing.Size(360, 20);
            this.PhoneTextbox.TabIndex = 98;
            this.PhoneTextbox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(156, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 13);
            this.label1.TabIndex = 97;
            // 
            // SaletimeLabel
            // 
            this.SaletimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.SaletimeLabel.Location = new System.Drawing.Point(12, 174);
            this.SaletimeLabel.Name = "SaletimeLabel";
            this.SaletimeLabel.Size = new System.Drawing.Size(138, 19);
            this.SaletimeLabel.TabIndex = 95;
            this.SaletimeLabel.Text = "Vásárlás ideje:";
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.SummaryLabel.Location = new System.Drawing.Point(12, 147);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(103, 21);
            this.SummaryLabel.TabIndex = 94;
            this.SummaryLabel.Text = "Végösszeg:";
            // 
            // ItemnumbersTblLabel
            // 
            this.ItemnumbersTblLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.ItemnumbersTblLabel.Location = new System.Drawing.Point(12, 121);
            this.ItemnumbersTblLabel.Name = "ItemnumbersTblLabel";
            this.ItemnumbersTblLabel.Size = new System.Drawing.Size(117, 22);
            this.ItemnumbersTblLabel.TabIndex = 93;
            this.ItemnumbersTblLabel.Text = "Termékek:";
            // 
            // StorageIDLabel
            // 
            this.StorageIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.StorageIDLabel.Location = new System.Drawing.Point(12, 94);
            this.StorageIDLabel.Name = "StorageIDLabel";
            this.StorageIDLabel.Size = new System.Drawing.Size(117, 23);
            this.StorageIDLabel.TabIndex = 92;
            this.StorageIDLabel.Text = "StorageID:";
            // 
            // AddressLabel
            // 
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.AddressLabel.Location = new System.Drawing.Point(12, 68);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(76, 23);
            this.AddressLabel.TabIndex = 91;
            this.AddressLabel.Text = "Cím:";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.PhoneLabel.Location = new System.Drawing.Point(12, 43);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(103, 20);
            this.PhoneLabel.TabIndex = 90;
            this.PhoneLabel.Text = "Telefon:";
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.NameLabel.Location = new System.Drawing.Point(12, 18);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(167, 25);
            this.NameLabel.TabIndex = 89;
            this.NameLabel.Text = "Név:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(452, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(342, 211);
            this.richTextBox1.TabIndex = 107;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Richtextbox_MouseClick);
            // 
            // TorolButton
            // 
            this.TorolButton.Location = new System.Drawing.Point(709, 229);
            this.TorolButton.Name = "TorolButton";
            this.TorolButton.Size = new System.Drawing.Size(85, 21);
            this.TorolButton.TabIndex = 108;
            this.TorolButton.Text = "Töröl";
            this.TorolButton.UseVisualStyleBackColor = true;
            this.TorolButton.Click += new System.EventHandler(this.TorolButton_Click);
            // 
            // EladasModosit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 256);
            this.Controls.Add(this.TorolButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.ModositButton);
            this.Controls.Add(this.SaletimeTextbox);
            this.Controls.Add(this.SummaryTextbox);
            this.Controls.Add(this.ItemnumbersTextbox);
            this.Controls.Add(this.StorageIdTextbox);
            this.Controls.Add(this.AddressTextbox);
            this.Controls.Add(this.PhoneTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaletimeLabel);
            this.Controls.Add(this.SummaryLabel);
            this.Controls.Add(this.ItemnumbersTblLabel);
            this.Controls.Add(this.StorageIDLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "EladasModosit";
            this.Text = "EladasModosit";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button TorolButton;

        private System.Windows.Forms.TextBox ItemnumbersTextbox;

        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Button ModositButton;
        private System.Windows.Forms.TextBox SaletimeTextbox;
        private System.Windows.Forms.TextBox SummaryTextbox;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.TextBox PhoneTextbox;
        private System.Windows.Forms.TextBox StorageIdTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ItemnumbersTblLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label StorageIDLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SaletimeLabel;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;

        #endregion
    }
}