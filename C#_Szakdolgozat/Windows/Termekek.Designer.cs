using System.ComponentModel;

namespace Raktarkezelo
{
    partial class Termekek
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
            this.VisszaButton = new System.Windows.Forms.Button();
            this.TorlesButton = new System.Windows.Forms.Button();
            this.ModositButton = new System.Windows.Forms.Button();
            this.KeresesButton = new System.Windows.Forms.Button();
            this.EladButton = new System.Windows.Forms.Button();
            this.KosarbaButton = new System.Windows.Forms.Button();
            this.TermekekDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TermekekDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // VisszaButton
            // 
            this.VisszaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.VisszaButton.Location = new System.Drawing.Point(1058, 635);
            this.VisszaButton.Name = "VisszaButton";
            this.VisszaButton.Size = new System.Drawing.Size(121, 40);
            this.VisszaButton.TabIndex = 1;
            this.VisszaButton.Text = "Vissza";
            this.VisszaButton.UseVisualStyleBackColor = true;
            this.VisszaButton.Click += new System.EventHandler(this.VisszaButton_Click);
            // 
            // TorlesButton
            // 
            this.TorlesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TorlesButton.Location = new System.Drawing.Point(270, 635);
            this.TorlesButton.Name = "TorlesButton";
            this.TorlesButton.Size = new System.Drawing.Size(121, 40);
            this.TorlesButton.TabIndex = 2;
            this.TorlesButton.Text = "Törlés";
            this.TorlesButton.UseVisualStyleBackColor = true;
            this.TorlesButton.Click += new System.EventHandler(this.TorlesButton_Click);
            // 
            // ModositButton
            // 
            this.ModositButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ModositButton.Location = new System.Drawing.Point(143, 635);
            this.ModositButton.Name = "ModositButton";
            this.ModositButton.Size = new System.Drawing.Size(121, 40);
            this.ModositButton.TabIndex = 3;
            this.ModositButton.Text = "Módosít / Részletek";
            this.ModositButton.UseVisualStyleBackColor = true;
            this.ModositButton.Click += new System.EventHandler(this.ModositButton_Click);
            // 
            // KeresesButton
            // 
            this.KeresesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KeresesButton.Location = new System.Drawing.Point(16, 635);
            this.KeresesButton.Name = "KeresesButton";
            this.KeresesButton.Size = new System.Drawing.Size(121, 40);
            this.KeresesButton.TabIndex = 4;
            this.KeresesButton.Text = "Keresés";
            this.KeresesButton.UseVisualStyleBackColor = true;
            this.KeresesButton.Click += new System.EventHandler(this.KeresesButton_Click);
            // 
            // EladButton
            // 
            this.EladButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EladButton.Location = new System.Drawing.Point(397, 635);
            this.EladButton.Name = "EladButton";
            this.EladButton.Size = new System.Drawing.Size(121, 40);
            this.EladButton.TabIndex = 8;
            this.EladButton.Text = "Eladás";
            this.EladButton.UseVisualStyleBackColor = true;
            this.EladButton.Click += new System.EventHandler(this.EladButton_Click);
            // 
            // KosarbaButton
            // 
            this.KosarbaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KosarbaButton.Location = new System.Drawing.Point(397, 607);
            this.KosarbaButton.Name = "KosarbaButton";
            this.KosarbaButton.Size = new System.Drawing.Size(121, 22);
            this.KosarbaButton.TabIndex = 9;
            this.KosarbaButton.Text = "Kosárba (0)";
            this.KosarbaButton.UseVisualStyleBackColor = true;
            this.KosarbaButton.Click += new System.EventHandler(this.KosárbaButton_Click);
            // 
            // TermekekDGV
            // 
            this.TermekekDGV.AllowUserToDeleteRows = false;
            this.TermekekDGV.AllowUserToOrderColumns = true;
            this.TermekekDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TermekekDGV.Location = new System.Drawing.Point(14, 12);
            this.TermekekDGV.Name = "TermekekDGV";
            this.TermekekDGV.ReadOnly = true;
            this.TermekekDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TermekekDGV.Size = new System.Drawing.Size(1165, 562);
            this.TermekekDGV.TabIndex = 10;
            this.TermekekDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TermekekDGV_CellContentClick);
            this.TermekekDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TermekekDGV_ColumnHeaderMouseClick);
            this.TermekekDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.TermekekDGV_DataBindingComplete);
            this.TermekekDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // Termekek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1199, 697);
            this.Controls.Add(this.TermekekDGV);
            this.Controls.Add(this.KosarbaButton);
            this.Controls.Add(this.EladButton);
            this.Controls.Add(this.KeresesButton);
            this.Controls.Add(this.ModositButton);
            this.Controls.Add(this.TorlesButton);
            this.Controls.Add(this.VisszaButton);
            this.Name = "Termekek";
            this.Text = "Termekek";
            this.Load += new System.EventHandler(this.Termekek_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TermekekDGV)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView TermekekDGV;

        private System.Windows.Forms.Button KosarbaButton;

        private System.Windows.Forms.Button button1;

        public System.Windows.Forms.Button EladButton;

        private System.Windows.Forms.Button TorlesButton;
        private System.Windows.Forms.Button ModositButton;
        public System.Windows.Forms.Button KeresesButton;

        private System.Windows.Forms.Button VisszaButton;

        #endregion
    }
}