using System.ComponentModel;

namespace Raktarkezelo
{
        partial class TermekMod
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
                this.EditButton = new System.Windows.Forms.Button();
                this.ItemNumTextbox = new System.Windows.Forms.TextBox();
                this.LocLevTextbox = new System.Windows.Forms.TextBox();
                this.LocColTextbox = new System.Windows.Forms.TextBox();
                this.LocRowTextbox = new System.Windows.Forms.TextBox();
                this.QuantityTextbox = new System.Windows.Forms.TextBox();
                this.PriceTextbox = new System.Windows.Forms.TextBox();
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
                this.QrBox = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(this.QrBox)).BeginInit();
                this.SuspendLayout();
                // 
                // EditButton
                // 
                this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.EditButton.Location = new System.Drawing.Point(179, 274);
                this.EditButton.Name = "EditButton";
                this.EditButton.Size = new System.Drawing.Size(120, 39);
                this.EditButton.TabIndex = 86;
                this.EditButton.Text = "Módosít";
                this.EditButton.UseVisualStyleBackColor = true;
                this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
                // 
                // ItemNumTextbox
                // 
                this.ItemNumTextbox.Location = new System.Drawing.Point(582, 235);
                this.ItemNumTextbox.Name = "ItemNumTextbox";
                this.ItemNumTextbox.Size = new System.Drawing.Size(248, 20);
                this.ItemNumTextbox.TabIndex = 85;
                this.ItemNumTextbox.TextChanged += new System.EventHandler(this.ItemNumTextbox_TextChanged);
                // 
                // LocLevTextbox
                // 
                this.LocLevTextbox.Location = new System.Drawing.Point(179, 235);
                this.LocLevTextbox.Name = "LocLevTextbox";
                this.LocLevTextbox.Size = new System.Drawing.Size(290, 20);
                this.LocLevTextbox.TabIndex = 84;
                // 
                // LocColTextbox
                // 
                this.LocColTextbox.Location = new System.Drawing.Point(179, 209);
                this.LocColTextbox.Name = "LocColTextbox";
                this.LocColTextbox.Size = new System.Drawing.Size(290, 20);
                this.LocColTextbox.TabIndex = 83;
                // 
                // LocRowTextbox
                // 
                this.LocRowTextbox.Location = new System.Drawing.Point(179, 180);
                this.LocRowTextbox.Name = "LocRowTextbox";
                this.LocRowTextbox.Size = new System.Drawing.Size(290, 20);
                this.LocRowTextbox.TabIndex = 82;
                // 
                // QuantityTextbox
                // 
                this.QuantityTextbox.Location = new System.Drawing.Point(179, 155);
                this.QuantityTextbox.Name = "QuantityTextbox";
                this.QuantityTextbox.Size = new System.Drawing.Size(290, 20);
                this.QuantityTextbox.TabIndex = 81;
                // 
                // PriceTextbox
                // 
                this.PriceTextbox.Location = new System.Drawing.Point(179, 129);
                this.PriceTextbox.Name = "PriceTextbox";
                this.PriceTextbox.Size = new System.Drawing.Size(290, 20);
                this.PriceTextbox.TabIndex = 80;
                // 
                // CategoryTextbox
                // 
                this.CategoryTextbox.Location = new System.Drawing.Point(179, 105);
                this.CategoryTextbox.Name = "CategoryTextbox";
                this.CategoryTextbox.Size = new System.Drawing.Size(290, 20);
                this.CategoryTextbox.TabIndex = 79;
                // 
                // TypeTextbox
                // 
                this.TypeTextbox.Location = new System.Drawing.Point(179, 79);
                this.TypeTextbox.Name = "TypeTextbox";
                this.TypeTextbox.Size = new System.Drawing.Size(290, 20);
                this.TypeTextbox.TabIndex = 78;
                // 
                // BrandTextbox
                // 
                this.BrandTextbox.Location = new System.Drawing.Point(179, 53);
                this.BrandTextbox.Name = "BrandTextbox";
                this.BrandTextbox.Size = new System.Drawing.Size(290, 20);
                this.BrandTextbox.TabIndex = 77;
                // 
                // StorageIdTextbox
                // 
                this.StorageIdTextbox.Location = new System.Drawing.Point(179, 27);
                this.StorageIdTextbox.Name = "StorageIdTextbox";
                this.StorageIdTextbox.Size = new System.Drawing.Size(290, 20);
                this.StorageIdTextbox.TabIndex = 76;
                // 
                // LocLevLabel
                // 
                this.LocLevLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.LocLevLabel.Location = new System.Drawing.Point(35, 233);
                this.LocLevLabel.Name = "LocLevLabel";
                this.LocLevLabel.Size = new System.Drawing.Size(138, 24);
                this.LocLevLabel.TabIndex = 75;
                this.LocLevLabel.Text = "Lokáció(Szint):";
                // 
                // LocColLabel
                // 
                this.LocColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.LocColLabel.Location = new System.Drawing.Point(35, 207);
                this.LocColLabel.Name = "LocColLabel";
                this.LocColLabel.Size = new System.Drawing.Size(155, 29);
                this.LocColLabel.TabIndex = 74;
                this.LocColLabel.Text = "Lokáció(Oszlop):";
                // 
                // LocRowLabel
                // 
                this.LocRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.LocRowLabel.Location = new System.Drawing.Point(35, 180);
                this.LocRowLabel.Name = "LocRowLabel";
                this.LocRowLabel.Size = new System.Drawing.Size(138, 25);
                this.LocRowLabel.TabIndex = 73;
                this.LocRowLabel.Text = "Lokáció(Sor):";
                // 
                // QuantityLabel
                // 
                this.QuantityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.QuantityLabel.Location = new System.Drawing.Point(35, 156);
                this.QuantityLabel.Name = "QuantityLabel";
                this.QuantityLabel.Size = new System.Drawing.Size(103, 24);
                this.QuantityLabel.TabIndex = 72;
                this.QuantityLabel.Text = "Mennyiség:";
                // 
                // PriceLabel
                // 
                this.PriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.PriceLabel.Location = new System.Drawing.Point(35, 129);
                this.PriceLabel.Name = "PriceLabel";
                this.PriceLabel.Size = new System.Drawing.Size(60, 21);
                this.PriceLabel.TabIndex = 71;
                this.PriceLabel.Text = "Ár:";
                // 
                // CategoryLabel
                // 
                this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.CategoryLabel.Location = new System.Drawing.Point(35, 103);
                this.CategoryLabel.Name = "CategoryLabel";
                this.CategoryLabel.Size = new System.Drawing.Size(103, 22);
                this.CategoryLabel.TabIndex = 70;
                this.CategoryLabel.Text = "Kategória:";
                // 
                // TypeLabel
                // 
                this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.TypeLabel.Location = new System.Drawing.Point(35, 76);
                this.TypeLabel.Name = "TypeLabel";
                this.TypeLabel.Size = new System.Drawing.Size(76, 23);
                this.TypeLabel.TabIndex = 69;
                this.TypeLabel.Text = "Típus:";
                // 
                // BrandLabel
                // 
                this.BrandLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.BrandLabel.Location = new System.Drawing.Point(35, 50);
                this.BrandLabel.Name = "BrandLabel";
                this.BrandLabel.Size = new System.Drawing.Size(76, 23);
                this.BrandLabel.TabIndex = 68;
                this.BrandLabel.Text = "Márka:";
                // 
                // StorageIdLabel
                // 
                this.StorageIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.StorageIdLabel.Location = new System.Drawing.Point(35, 25);
                this.StorageIdLabel.Name = "StorageIdLabel";
                this.StorageIdLabel.Size = new System.Drawing.Size(103, 20);
                this.StorageIdLabel.TabIndex = 67;
                this.StorageIdLabel.Text = "Raktár azonosító";
                // 
                // Itemnumberlabel
                // 
                this.Itemnumberlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.Itemnumberlabel.Location = new System.Drawing.Point(488, 235);
                this.Itemnumberlabel.Name = "Itemnumberlabel";
                this.Itemnumberlabel.Size = new System.Drawing.Size(167, 25);
                this.Itemnumberlabel.TabIndex = 66;
                this.Itemnumberlabel.Text = "Azonosító:";
                // 
                // QrBox
                // 
                this.QrBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                this.QrBox.BackColor = System.Drawing.Color.White;
                this.QrBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.QrBox.Location = new System.Drawing.Point(543, 27);
                this.QrBox.Name = "QrBox";
                this.QrBox.Size = new System.Drawing.Size(200, 200);
                this.QrBox.TabIndex = 87;
                this.QrBox.TabStop = false;
                this.QrBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.QrBox_MouseClick);
                // 
                // TermekModosit
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(842, 327);
                this.Controls.Add(this.QrBox);
                this.Controls.Add(this.EditButton);
                this.Controls.Add(this.ItemNumTextbox);
                this.Controls.Add(this.LocLevTextbox);
                this.Controls.Add(this.LocColTextbox);
                this.Controls.Add(this.LocRowTextbox);
                this.Controls.Add(this.QuantityTextbox);
                this.Controls.Add(this.PriceTextbox);
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
                this.Name = "TermekModosit";
                this.Text = "TermekModosit";
                ((System.ComponentModel.ISupportInitialize)(this.QrBox)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            private System.Windows.Forms.PictureBox QrBox;

            private System.Windows.Forms.Button EditButton;
            private System.Windows.Forms.TextBox ItemNumTextbox;
            private System.Windows.Forms.TextBox LocLevTextbox;
            private System.Windows.Forms.TextBox LocColTextbox;
            private System.Windows.Forms.TextBox LocRowTextbox;
            private System.Windows.Forms.TextBox QuantityTextbox;
            private System.Windows.Forms.TextBox PriceTextbox;
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

            #endregion
        }
}