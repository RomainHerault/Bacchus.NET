namespace Bacchus.Forms
{
    partial class ImportForm
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
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.OverwriteButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(484, 28);
            this.SelectFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(122, 27);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "Sélectionner";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // FileTextBox
            // 
            this.FileTextBox.Location = new System.Drawing.Point(51, 30);
            this.FileTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.Size = new System.Drawing.Size(407, 22);
            this.FileTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(108, 82);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(137, 44);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Ajouter";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // OverwriteButton
            // 
            this.OverwriteButton.Location = new System.Drawing.Point(373, 82);
            this.OverwriteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OverwriteButton.Name = "OverwriteButton";
            this.OverwriteButton.Size = new System.Drawing.Size(149, 44);
            this.OverwriteButton.TabIndex = 3;
            this.OverwriteButton.Text = "Ecraser";
            this.OverwriteButton.UseVisualStyleBackColor = true;
            this.OverwriteButton.Click += new System.EventHandler(this.OverwriteButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(46, 163);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(560, 30);
            this.ProgressBar.TabIndex = 4;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 209);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.OverwriteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FileTextBox);
            this.Controls.Add(this.SelectFileButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ImportForm";
            this.Text = "Importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button OverwriteButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}