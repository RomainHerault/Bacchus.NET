namespace Bacchus.Forms
{
    partial class ProductForm
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
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.RefTextBox = new System.Windows.Forms.TextBox();
            this.RefLabel = new System.Windows.Forms.Label();
            this.BrandComboBox = new System.Windows.Forms.ComboBox();
            this.SubCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.SubCategoryLabel = new System.Windows.Forms.Label();
            this.PricePreVATTextBox = new System.Windows.Forms.TextBox();
            this.PricePreVATLabel = new System.Windows.Forms.Label();
            this.QuantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(211, 36);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Description";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(214, 52);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(196, 33);
            this.DescriptionTextBox.TabIndex = 2;
            // 
            // RefTextBox
            // 
            this.RefTextBox.Location = new System.Drawing.Point(22, 52);
            this.RefTextBox.Name = "RefTextBox";
            this.RefTextBox.Size = new System.Drawing.Size(165, 20);
            this.RefTextBox.TabIndex = 3;
            this.RefTextBox.TextChanged += new System.EventHandler(this.RefTextBox_TextChanged);
            // 
            // RefLabel
            // 
            this.RefLabel.AutoSize = true;
            this.RefLabel.Location = new System.Drawing.Point(19, 36);
            this.RefLabel.Name = "RefLabel";
            this.RefLabel.Size = new System.Drawing.Size(57, 13);
            this.RefLabel.TabIndex = 4;
            this.RefLabel.Text = "Référence";
            // 
            // BrandComboBox
            // 
            this.BrandComboBox.FormattingEnabled = true;
            this.BrandComboBox.Location = new System.Drawing.Point(22, 121);
            this.BrandComboBox.Name = "BrandComboBox";
            this.BrandComboBox.Size = new System.Drawing.Size(165, 21);
            this.BrandComboBox.TabIndex = 5;
            // 
            // SubCategoryComboBox
            // 
            this.SubCategoryComboBox.FormattingEnabled = true;
            this.SubCategoryComboBox.Location = new System.Drawing.Point(214, 121);
            this.SubCategoryComboBox.Name = "SubCategoryComboBox";
            this.SubCategoryComboBox.Size = new System.Drawing.Size(196, 21);
            this.SubCategoryComboBox.TabIndex = 6;
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.Location = new System.Drawing.Point(19, 105);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(43, 13);
            this.BrandLabel.TabIndex = 7;
            this.BrandLabel.Text = "Marque";
            this.BrandLabel.Click += new System.EventHandler(this.BrandLabel_Click);
            // 
            // SubCategoryLabel
            // 
            this.SubCategoryLabel.AutoSize = true;
            this.SubCategoryLabel.Location = new System.Drawing.Point(214, 102);
            this.SubCategoryLabel.Name = "SubCategoryLabel";
            this.SubCategoryLabel.Size = new System.Drawing.Size(78, 13);
            this.SubCategoryLabel.TabIndex = 8;
            this.SubCategoryLabel.Text = "Sous-catégorie";
            // 
            // PricePreVATTextBox
            // 
            this.PricePreVATTextBox.Location = new System.Drawing.Point(22, 189);
            this.PricePreVATTextBox.Name = "PricePreVATTextBox";
            this.PricePreVATTextBox.Size = new System.Drawing.Size(165, 20);
            this.PricePreVATTextBox.TabIndex = 9;
            // 
            // PricePreVATLabel
            // 
            this.PricePreVATLabel.AutoSize = true;
            this.PricePreVATLabel.Location = new System.Drawing.Point(19, 173);
            this.PricePreVATLabel.Name = "PricePreVATLabel";
            this.PricePreVATLabel.Size = new System.Drawing.Size(48, 13);
            this.PricePreVATLabel.TabIndex = 10;
            this.PricePreVATLabel.Text = "Prix TTC";
            // 
            // QuantityNumericUpDown
            // 
            this.QuantityNumericUpDown.Location = new System.Drawing.Point(217, 189);
            this.QuantityNumericUpDown.Name = "QuantityNumericUpDown";
            this.QuantityNumericUpDown.Size = new System.Drawing.Size(193, 20);
            this.QuantityNumericUpDown.TabIndex = 11;
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(217, 170);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(47, 13);
            this.QuantityLabel.TabIndex = 12;
            this.QuantityLabel.Text = "Quantité";
            // 
            // ValidateButton
            // 
            this.ValidateButton.Location = new System.Drawing.Point(112, 277);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(75, 23);
            this.ValidateButton.TabIndex = 13;
            this.ValidateButton.Text = "Valider";
            this.ValidateButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(217, 277);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Annuler";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 350);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.QuantityNumericUpDown);
            this.Controls.Add(this.PricePreVATLabel);
            this.Controls.Add(this.PricePreVATTextBox);
            this.Controls.Add(this.SubCategoryLabel);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.SubCategoryComboBox);
            this.Controls.Add(this.BrandComboBox);
            this.Controls.Add(this.RefLabel);
            this.Controls.Add(this.RefTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Name = "ProductForm";
            this.Text = "Article";
            this.Load += new System.EventHandler(this.NewProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuantityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox RefTextBox;
        private System.Windows.Forms.Label RefLabel;
        private System.Windows.Forms.ComboBox BrandComboBox;
        private System.Windows.Forms.ComboBox SubCategoryComboBox;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.Label SubCategoryLabel;
        private System.Windows.Forms.TextBox PricePreVATTextBox;
        private System.Windows.Forms.Label PricePreVATLabel;
        private System.Windows.Forms.NumericUpDown QuantityNumericUpDown;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.Button CancelButton;
    }
}