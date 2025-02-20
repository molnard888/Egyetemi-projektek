namespace Raktarkezelo
{
    partial class MuveletNaplo
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
            this.NaploDGV = new System.Windows.Forms.DataGridView();
            this.KeresesButton = new System.Windows.Forms.Button();
            this.VisszaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NaploDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // NaploDGV
            // 
            this.NaploDGV.AllowUserToDeleteRows = false;
            this.NaploDGV.AllowUserToOrderColumns = true;
            this.NaploDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NaploDGV.Location = new System.Drawing.Point(17, 17);
            this.NaploDGV.Name = "NaploDGV";
            this.NaploDGV.ReadOnly = true;
            this.NaploDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NaploDGV.Size = new System.Drawing.Size(730, 562);
            this.NaploDGV.TabIndex = 15;
            this.NaploDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NaploDGV_CellContentClick);
            this.NaploDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NaploDGV_ColumnHeaderMouseClick);
            this.NaploDGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.NaploDGV_DataBindingComplete);
            this.NaploDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // KeresesButton
            // 
            this.KeresesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KeresesButton.Location = new System.Drawing.Point(19, 640);
            this.KeresesButton.Name = "KeresesButton";
            this.KeresesButton.Size = new System.Drawing.Size(121, 40);
            this.KeresesButton.TabIndex = 14;
            this.KeresesButton.Text = "Keresés";
            this.KeresesButton.UseVisualStyleBackColor = true;
            this.KeresesButton.Click += new System.EventHandler(this.KeresesButton_Click);
            // 
            // VisszaButton
            // 
            this.VisszaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.VisszaButton.Location = new System.Drawing.Point(626, 640);
            this.VisszaButton.Name = "VisszaButton";
            this.VisszaButton.Size = new System.Drawing.Size(121, 40);
            this.VisszaButton.TabIndex = 11;
            this.VisszaButton.Text = "Vissza";
            this.VisszaButton.UseVisualStyleBackColor = true;
            this.VisszaButton.Click += new System.EventHandler(this.VisszaButton_Click);
            // 
            // MuveletNaplo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 697);
            this.Controls.Add(this.NaploDGV);
            this.Controls.Add(this.KeresesButton);
            this.Controls.Add(this.VisszaButton);
            this.Name = "MuveletNaplo";
            this.Text = "MuveletNaplo";
            this.Load += new System.EventHandler(this.MuveletNaplo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NaploDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView NaploDGV;
        public System.Windows.Forms.Button KeresesButton;
        private System.Windows.Forms.Button VisszaButton;
    }
}