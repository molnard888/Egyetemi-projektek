using System.ComponentModel;

namespace Raktarkezelo
{
    partial class Felhasznalok
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
            this.KeresesButton = new System.Windows.Forms.Button();
            this.ModositButton = new System.Windows.Forms.Button();
            this.TorlesButton = new System.Windows.Forms.Button();
            this.VisszaButton = new System.Windows.Forms.Button();
            this.FelhasznalokDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FelhasznalokDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // KeresesButton
            // 
            this.KeresesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KeresesButton.Location = new System.Drawing.Point(921, 79);
            this.KeresesButton.Name = "KeresesButton";
            this.KeresesButton.Size = new System.Drawing.Size(121, 40);
            this.KeresesButton.TabIndex = 12;
            this.KeresesButton.Text = "Keresés";
            this.KeresesButton.UseVisualStyleBackColor = true;
            this.KeresesButton.Click += new System.EventHandler(this.KeresesButton_Click);
            // 
            // ModositButton
            // 
            this.ModositButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ModositButton.Location = new System.Drawing.Point(921, 138);
            this.ModositButton.Name = "ModositButton";
            this.ModositButton.Size = new System.Drawing.Size(121, 40);
            this.ModositButton.TabIndex = 11;
            this.ModositButton.Text = "Módosítás / Részletek";
            this.ModositButton.UseVisualStyleBackColor = true;
            this.ModositButton.Click += new System.EventHandler(this.ModositButton_Click);
            // 
            // TorlesButton
            // 
            this.TorlesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TorlesButton.Location = new System.Drawing.Point(921, 199);
            this.TorlesButton.Name = "TorlesButton";
            this.TorlesButton.Size = new System.Drawing.Size(121, 40);
            this.TorlesButton.TabIndex = 10;
            this.TorlesButton.Text = "Törlés";
            this.TorlesButton.UseVisualStyleBackColor = true;
            this.TorlesButton.Click += new System.EventHandler(this.TorlesButton_Click);
            // 
            // VisszaButton
            // 
            this.VisszaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.VisszaButton.Location = new System.Drawing.Point(921, 304);
            this.VisszaButton.Name = "VisszaButton";
            this.VisszaButton.Size = new System.Drawing.Size(121, 40);
            this.VisszaButton.TabIndex = 9;
            this.VisszaButton.Text = "Vissza";
            this.VisszaButton.UseVisualStyleBackColor = true;
            this.VisszaButton.Click += new System.EventHandler(this.VisszaButton_Click);
            // 
            // FelhasznalokDGV
            // 
            this.FelhasznalokDGV.AllowUserToOrderColumns = true;
            this.FelhasznalokDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FelhasznalokDGV.Location = new System.Drawing.Point(12, 18);
            this.FelhasznalokDGV.MultiSelect = false;
            this.FelhasznalokDGV.Name = "FelhasznalokDGV";
            this.FelhasznalokDGV.ReadOnly = true;
            this.FelhasznalokDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FelhasznalokDGV.Size = new System.Drawing.Size(877, 330);
            this.FelhasznalokDGV.TabIndex = 15;
            this.FelhasznalokDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FelhasznalokDGV_CellContentClick);
            this.FelhasznalokDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FelhasznalokDGV_ColumnHeaderMouseClick);
            this.FelhasznalokDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.FelhasznalokDGV_DataBindingComplete);
            this.FelhasznalokDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // Felhasznalok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 360);
            this.Controls.Add(this.FelhasznalokDGV);
            this.Controls.Add(this.KeresesButton);
            this.Controls.Add(this.ModositButton);
            this.Controls.Add(this.TorlesButton);
            this.Controls.Add(this.VisszaButton);
            this.Name = "Felhasznalok";
            this.Text = "Felhasznalok";
            this.Load += new System.EventHandler(this.Felhasznalok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FelhasznalokDGV)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView FelhasznalokDGV;
        private System.Windows.Forms.Button KeresesButton;
        private System.Windows.Forms.Button ModositButton;
        private System.Windows.Forms.Button TorlesButton;
        private System.Windows.Forms.Button VisszaButton;

        #endregion
    }
}