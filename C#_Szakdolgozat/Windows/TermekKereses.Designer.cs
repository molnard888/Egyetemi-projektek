using System.ComponentModel;

namespace Raktarkezelo
{
    partial class TermekKereses
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.ItemNumTextbox = new System.Windows.Forms.TextBox();
            this.LocLevTextbox = new System.Windows.Forms.TextBox();
            this.LocColTextbox = new System.Windows.Forms.TextBox();
            this.LocRowTextbox = new System.Windows.Forms.TextBox();
            this.QuantityTextbox = new System.Windows.Forms.TextBox();
            this.PriceFromTextbox = new System.Windows.Forms.TextBox();
            this.CategoryTextbox = new System.Windows.Forms.TextBox();
            this.TypeTextbox = new System.Windows.Forms.TextBox();
            this.BrandTextbox = new System.Windows.Forms.TextBox();
            this.StorageIdTextbox = new System.Windows.Forms.TextBox();
            this.LocLevLabel = new System.Windows.Forms.Label();
            this.LocColLabel = new System.Windows.Forms.Label();
            this.LocRowLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.StorageIdLabel = new System.Windows.Forms.Label();
            this.Itemnumberlabel = new System.Windows.Forms.Label();
            this.PriceToTextbox = new System.Windows.Forms.TextBox();
            this.PriceFromToLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SearchButton.Location = new System.Drawing.Point(408, 178);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(87, 28);
            this.SearchButton.TabIndex = 49;
            this.SearchButton.Text = "Keres";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ItemNumTextbox
            // 
            this.ItemNumTextbox.Location = new System.Drawing.Point(116, 26);
            this.ItemNumTextbox.Name = "ItemNumTextbox";
            this.ItemNumTextbox.Size = new System.Drawing.Size(290, 20);
            this.ItemNumTextbox.TabIndex = 84;
            // 
            // LocLevTextbox
            // 
            this.LocLevTextbox.Location = new System.Drawing.Point(600, 131);
            this.LocLevTextbox.Name = "LocLevTextbox";
            this.LocLevTextbox.Size = new System.Drawing.Size(290, 20);
            this.LocLevTextbox.TabIndex = 83;
            // 
            // LocColTextbox
            // 
            this.LocColTextbox.Location = new System.Drawing.Point(600, 105);
            this.LocColTextbox.Name = "LocColTextbox";
            this.LocColTextbox.Size = new System.Drawing.Size(290, 20);
            this.LocColTextbox.TabIndex = 82;
            // 
            // LocRowTextbox
            // 
            this.LocRowTextbox.Location = new System.Drawing.Point(600, 80);
            this.LocRowTextbox.Name = "LocRowTextbox";
            this.LocRowTextbox.Size = new System.Drawing.Size(290, 20);
            this.LocRowTextbox.TabIndex = 81;
            // 
            // QuantityTextbox
            // 
            this.QuantityTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.QuantityTextbox.Location = new System.Drawing.Point(600, 51);
            this.QuantityTextbox.Name = "QuantityTextbox";
            this.QuantityTextbox.Size = new System.Drawing.Size(290, 22);
            this.QuantityTextbox.TabIndex = 80;
            // 
            // PriceFromTextbox
            // 
            this.PriceFromTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PriceFromTextbox.Location = new System.Drawing.Point(499, 26);
            this.PriceFromTextbox.Name = "PriceFromTextbox";
            this.PriceFromTextbox.Size = new System.Drawing.Size(162, 22);
            this.PriceFromTextbox.TabIndex = 79;
            // 
            // CategoryTextbox
            // 
            this.CategoryTextbox.Location = new System.Drawing.Point(116, 131);
            this.CategoryTextbox.Name = "CategoryTextbox";
            this.CategoryTextbox.Size = new System.Drawing.Size(290, 20);
            this.CategoryTextbox.TabIndex = 78;
            // 
            // TypeTextbox
            // 
            this.TypeTextbox.Location = new System.Drawing.Point(116, 105);
            this.TypeTextbox.Name = "TypeTextbox";
            this.TypeTextbox.Size = new System.Drawing.Size(290, 20);
            this.TypeTextbox.TabIndex = 77;
            // 
            // BrandTextbox
            // 
            this.BrandTextbox.Location = new System.Drawing.Point(116, 79);
            this.BrandTextbox.Name = "BrandTextbox";
            this.BrandTextbox.Size = new System.Drawing.Size(290, 20);
            this.BrandTextbox.TabIndex = 76;
            // 
            // StorageIdTextbox
            // 
            this.StorageIdTextbox.Location = new System.Drawing.Point(116, 53);
            this.StorageIdTextbox.Name = "StorageIdTextbox";
            this.StorageIdTextbox.Size = new System.Drawing.Size(290, 20);
            this.StorageIdTextbox.TabIndex = 75;
            // 
            // LocLevLabel
            // 
            this.LocLevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LocLevLabel.Location = new System.Drawing.Point(456, 131);
            this.LocLevLabel.Name = "LocLevLabel";
            this.LocLevLabel.Size = new System.Drawing.Size(138, 24);
            this.LocLevLabel.TabIndex = 74;
            this.LocLevLabel.Text = "Lokáció(Szint):";
            // 
            // LocColLabel
            // 
            this.LocColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LocColLabel.Location = new System.Drawing.Point(456, 105);
            this.LocColLabel.Name = "LocColLabel";
            this.LocColLabel.Size = new System.Drawing.Size(155, 29);
            this.LocColLabel.TabIndex = 73;
            this.LocColLabel.Text = "Lokáció(Oszlop):";
            // 
            // LocRowLabel
            // 
            this.LocRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LocRowLabel.Location = new System.Drawing.Point(456, 79);
            this.LocRowLabel.Name = "LocRowLabel";
            this.LocRowLabel.Size = new System.Drawing.Size(138, 25);
            this.LocRowLabel.TabIndex = 72;
            this.LocRowLabel.Text = "Lokáció(Sor):";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.QuantityLabel.Location = new System.Drawing.Point(456, 54);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(103, 25);
            this.QuantityLabel.TabIndex = 71;
            this.QuantityLabel.Text = "Mennyiség:";
            // 
            // PriceLabel
            // 
            this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PriceLabel.Location = new System.Drawing.Point(456, 25);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(60, 21);
            this.PriceLabel.TabIndex = 70;
            this.PriceLabel.Text = "Ár:";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CategoryLabel.Location = new System.Drawing.Point(16, 130);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(103, 22);
            this.CategoryLabel.TabIndex = 69;
            this.CategoryLabel.Text = "Kategória:";
            // 
            // TypeLabel
            // 
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TypeLabel.Location = new System.Drawing.Point(16, 103);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(76, 23);
            this.TypeLabel.TabIndex = 68;
            this.TypeLabel.Text = "Típus:";
            // 
            // BrandLabel
            // 
            this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrandLabel.Location = new System.Drawing.Point(16, 77);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(76, 23);
            this.BrandLabel.TabIndex = 67;
            this.BrandLabel.Text = "Márka:";
            // 
            // StorageIdLabel
            // 
            this.StorageIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StorageIdLabel.Location = new System.Drawing.Point(16, 52);
            this.StorageIdLabel.Name = "StorageIdLabel";
            this.StorageIdLabel.Size = new System.Drawing.Size(103, 20);
            this.StorageIdLabel.TabIndex = 66;
            this.StorageIdLabel.Text = "Raktár azonosító";
            // 
            // Itemnumberlabel
            // 
            this.Itemnumberlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Itemnumberlabel.Location = new System.Drawing.Point(16, 27);
            this.Itemnumberlabel.Name = "Itemnumberlabel";
            this.Itemnumberlabel.Size = new System.Drawing.Size(167, 25);
            this.Itemnumberlabel.TabIndex = 65;
            this.Itemnumberlabel.Text = "Azonosító:";
            // 
            // PriceToTextbox
            // 
            this.PriceToTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PriceToTextbox.Location = new System.Drawing.Point(683, 26);
            this.PriceToTextbox.Name = "PriceToTextbox";
            this.PriceToTextbox.Size = new System.Drawing.Size(162, 22);
            this.PriceToTextbox.TabIndex = 85;
            // 
            // PriceFromToLabel
            // 
            this.PriceFromToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PriceFromToLabel.Location = new System.Drawing.Point(667, 26);
            this.PriceFromToLabel.Name = "PriceFromToLabel";
            this.PriceFromToLabel.Size = new System.Drawing.Size(10, 18);
            this.PriceFromToLabel.TabIndex = 86;
            this.PriceFromToLabel.Text = "-";
            // 
            // TermekKereses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 215);
            this.Controls.Add(this.PriceFromToLabel);
            this.Controls.Add(this.PriceToTextbox);
            this.Controls.Add(this.ItemNumTextbox);
            this.Controls.Add(this.LocLevTextbox);
            this.Controls.Add(this.LocColTextbox);
            this.Controls.Add(this.LocRowTextbox);
            this.Controls.Add(this.QuantityTextbox);
            this.Controls.Add(this.PriceFromTextbox);
            this.Controls.Add(this.CategoryTextbox);
            this.Controls.Add(this.TypeTextbox);
            this.Controls.Add(this.BrandTextbox);
            this.Controls.Add(this.StorageIdTextbox);
            this.Controls.Add(this.LocLevLabel);
            this.Controls.Add(this.LocColLabel);
            this.Controls.Add(this.LocRowLabel);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.StorageIdLabel);
            this.Controls.Add(this.Itemnumberlabel);
            this.Controls.Add(this.SearchButton);
            this.Name = "TermekKereses";
            this.Text = "Termék keresés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox PriceToTextbox;
        private System.Windows.Forms.Label PriceFromToLabel;

        private System.Windows.Forms.TextBox ItemNumTextbox;
        private System.Windows.Forms.TextBox LocLevTextbox;
        private System.Windows.Forms.TextBox LocColTextbox;
        private System.Windows.Forms.TextBox LocRowTextbox;
        private System.Windows.Forms.TextBox QuantityTextbox;
        private System.Windows.Forms.TextBox PriceFromTextbox;
        private System.Windows.Forms.TextBox CategoryTextbox;
        private System.Windows.Forms.TextBox TypeTextbox;
        private System.Windows.Forms.TextBox BrandTextbox;
        private System.Windows.Forms.TextBox StorageIdTextbox;
        private System.Windows.Forms.Label LocLevLabel;
        private System.Windows.Forms.Label LocColLabel;
        private System.Windows.Forms.Label LocRowLabel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label StorageIdLabel;
        private System.Windows.Forms.Label Itemnumberlabel;
        private System.Windows.Forms.Button SearchButton;

        private System.Windows.Forms.Button DisplayProductsPanelSearchButton;

        #endregion
    }
}