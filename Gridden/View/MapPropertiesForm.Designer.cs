namespace Gridden.View
{
    partial class MapPropertiesForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.heightSelector = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthSelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.heightSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 28);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(298, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(121, 112);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // heightSelector
            // 
            this.heightSelector.Location = new System.Drawing.Point(164, 71);
            this.heightSelector.Name = "heightSelector";
            this.heightSelector.Size = new System.Drawing.Size(146, 20);
            this.heightSelector.TabIndex = 1;
            this.heightSelector.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(161, 55);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(81, 13);
            this.heightLabel.TabIndex = 5;
            this.heightLabel.Text = "Height (tiles tall)";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(13, 55);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(87, 13);
            this.widthLabel.TabIndex = 7;
            this.widthLabel.Text = "Width (tiles wide)";
            // 
            // widthSelector
            // 
            this.widthSelector.Location = new System.Drawing.Point(12, 70);
            this.widthSelector.Name = "widthSelector";
            this.widthSelector.Size = new System.Drawing.Size(146, 20);
            this.widthSelector.TabIndex = 8;
            this.widthSelector.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // MapInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 147);
            this.Controls.Add(this.widthSelector);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.heightSelector);
            this.Controls.Add(this.nameTextBox);
            this.Name = "MapInfoForm";
            this.Text = "Map Properties";
            ((System.ComponentModel.ISupportInitialize)(this.heightSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown heightSelector;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.NumericUpDown widthSelector;
    }
}