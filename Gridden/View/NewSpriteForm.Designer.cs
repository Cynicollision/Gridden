namespace Gridden.View
{
    partial class NewSpriteForm
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
            this.newImageLabel = new System.Windows.Forms.Label();
            this.charTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newImageLabel
            // 
            this.newImageLabel.AutoSize = true;
            this.newImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newImageLabel.Location = new System.Drawing.Point(13, 13);
            this.newImageLabel.Name = "newImageLabel";
            this.newImageLabel.Size = new System.Drawing.Size(278, 48);
            this.newImageLabel.TabIndex = 0;
            this.newImageLabel.Text = "Enter a single character to represent this  new \r\nimage in the map. This characte" +
    "r must not \r\nalready exist in the map (case insensitive).\r\n";
            // 
            // charTextBox
            // 
            this.charTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charTextBox.Location = new System.Drawing.Point(127, 64);
            this.charTextBox.MaxLength = 1;
            this.charTextBox.Name = "charTextBox";
            this.charTextBox.Size = new System.Drawing.Size(34, 26);
            this.charTextBox.TabIndex = 1;
            this.charTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(108, 96);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // NewSpriteForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 135);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.charTextBox);
            this.Controls.Add(this.newImageLabel);
            this.Name = "NewSpriteForm";
            this.Text = "Add image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newImageLabel;
        private System.Windows.Forms.TextBox charTextBox;
        private System.Windows.Forms.Button okButton;
    }
}