using System.ComponentModel;

namespace Raktarkezelo
{
    partial class Eladasok
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
            this.RendezesCombobox = new System.Windows.Forms.ComboBox();
            this.RendezesLabel = new System.Windows.Forms.Label();
            this.KeresesButton = new System.Windows.Forms.Button();
            this.ModositButton = new System.Windows.Forms.Button();
            this.TorlesButton = new System.Windows.Forms.Button();
            this.VisszaButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RendezesCombobox
            // 
            this.RendezesCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.RendezesCombobox.FormattingEnabled = true;
            this.RendezesCombobox.Items.AddRange(new object[] {"ItemNumber A-Z", "ItemNumber Z-A", "Brand A-Z", "Brand Z-A", "Quantity Ascending", "Quantity Descending"});
            this.RendezesCombobox.Location = new System.Drawing.Point(107, 359);
            this.RendezesCombobox.Name = "RendezesCombobox";
            this.RendezesCombobox.Size = new System.Drawing.Size(236, 26);
            this.RendezesCombobox.TabIndex = 14;
            this.RendezesCombobox.SelectedIndexChanged += new System.EventHandler(this.RendezesCombobox_SelectedIndexChanged);
            // 
            // RendezesLabel
            // 
            this.RendezesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.RendezesLabel.Location = new System.Drawing.Point(12, 361);
            this.RendezesLabel.Name = "RendezesLabel";
            this.RendezesLabel.Size = new System.Drawing.Size(100, 27);
            this.RendezesLabel.TabIndex = 13;
            this.RendezesLabel.Text = "Rendezés:";
            // 
            // KeresesButton
            // 
            this.KeresesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.KeresesButton.Location = new System.Drawing.Point(14, 397);
            this.KeresesButton.Name = "KeresesButton";
            this.KeresesButton.Size = new System.Drawing.Size(121, 40);
            this.KeresesButton.TabIndex = 12;
            this.KeresesButton.Text = "Keresés";
            this.KeresesButton.UseVisualStyleBackColor = true;
            this.KeresesButton.Click += new System.EventHandler(this.KeresesButton_Click);
            // 
            // ModositButton
            // 
            this.ModositButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.ModositButton.Location = new System.Drawing.Point(141, 397);
            this.ModositButton.Name = "ModositButton";
            this.ModositButton.Size = new System.Drawing.Size(121, 40);
            this.ModositButton.TabIndex = 11;
            this.ModositButton.Text = "Módosít / Részletek";
            this.ModositButton.UseVisualStyleBackColor = true;
            this.ModositButton.Click += new System.EventHandler(this.ModositButton_Click);
            // 
            // TorlesButton
            // 
            this.TorlesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.TorlesButton.Location = new System.Drawing.Point(268, 397);
            this.TorlesButton.Name = "TorlesButton";
            this.TorlesButton.Size = new System.Drawing.Size(121, 40);
            this.TorlesButton.TabIndex = 10;
            this.TorlesButton.Text = "Törlés";
            this.TorlesButton.UseVisualStyleBackColor = true;
            this.TorlesButton.Click += new System.EventHandler(this.TorlesButton_Click);
            // 
            // VisszaButton
            // 
            this.VisszaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.VisszaButton.Location = new System.Drawing.Point(667, 397);
            this.VisszaButton.Name = "VisszaButton";
            this.VisszaButton.Size = new System.Drawing.Size(121, 40);
            this.VisszaButton.TabIndex = 9;
            this.VisszaButton.Text = "Vissza";
            this.VisszaButton.UseVisualStyleBackColor = true;
            this.VisszaButton.Click += new System.EventHandler(this.VisszaButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 338);
            this.panel1.TabIndex = 8;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(768, 339);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            // 
            // Eladasok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RendezesCombobox);
            this.Controls.Add(this.RendezesLabel);
            this.Controls.Add(this.KeresesButton);
            this.Controls.Add(this.ModositButton);
            this.Controls.Add(this.TorlesButton);
            this.Controls.Add(this.VisszaButton);
            this.Controls.Add(this.panel1);
            this.Name = "Eladasok";
            this.Text = "Eladasok";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox RendezesCombobox;
        private System.Windows.Forms.Label RendezesLabel;
        private System.Windows.Forms.Button KeresesButton;
        private System.Windows.Forms.Button ModositButton;
        private System.Windows.Forms.Button TorlesButton;
        private System.Windows.Forms.Button VisszaButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;

        #endregion
    }
}