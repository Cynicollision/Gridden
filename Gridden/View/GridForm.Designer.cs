namespace Gridden
{
    partial class GridForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spritePanel = new System.Windows.Forms.Panel();
            this.paintContainerPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.paintPanel = new Gridden.DrawingPanel();
            this.menuStrip.SuspendLayout();
            this.paintContainerPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Black;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sheetToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(716, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.mapPropertiesToolStripMenuItem,
            this.viewTextToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "Map";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "Load...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // mapPropertiesToolStripMenuItem
            // 
            this.mapPropertiesToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.mapPropertiesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.mapPropertiesToolStripMenuItem.Name = "mapPropertiesToolStripMenuItem";
            this.mapPropertiesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.mapPropertiesToolStripMenuItem.Text = "Map Properties";
            // 
            // viewTextToolStripMenuItem
            // 
            this.viewTextToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.viewTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewTextToolStripMenuItem.Name = "viewTextToolStripMenuItem";
            this.viewTextToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.viewTextToolStripMenuItem.Text = "View Map Text";
            this.viewTextToolStripMenuItem.Click += new System.EventHandler(this.viewTextToolStripMenuItem_Click);
            // 
            // sheetToolStripMenuItem
            // 
            this.sheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSheetToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.addImageToolStripMenuItem,
            this.propertiesToolStripMenuItem1});
            this.sheetToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sheetToolStripMenuItem.Name = "sheetToolStripMenuItem";
            this.sheetToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.sheetToolStripMenuItem.Text = "Sheet";
            // 
            // newSheetToolStripMenuItem
            // 
            this.newSheetToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.newSheetToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newSheetToolStripMenuItem.Name = "newSheetToolStripMenuItem";
            this.newSheetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newSheetToolStripMenuItem.Text = "New sheet";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.loadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadToolStripMenuItem.Text = "Load sheet...";
            // 
            // addImageToolStripMenuItem
            // 
            this.addImageToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.addImageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
            this.addImageToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addImageToolStripMenuItem.Text = "Add image...";
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.propertiesToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.propertiesToolStripMenuItem1.Text = "Sheet Properties";
            // 
            // spritePanel
            // 
            this.spritePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spritePanel.AutoScroll = true;
            this.spritePanel.BackColor = System.Drawing.Color.Black;
            this.spritePanel.Location = new System.Drawing.Point(12, 27);
            this.spritePanel.Name = "spritePanel";
            this.spritePanel.Size = new System.Drawing.Size(692, 48);
            this.spritePanel.TabIndex = 1;
            this.spritePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.spritePanel_Paint);
            this.spritePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.spritePanel_MouseClick);
            // 
            // paintContainerPanel
            // 
            this.paintContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paintContainerPanel.AutoScroll = true;
            this.paintContainerPanel.BackColor = System.Drawing.Color.Black;
            this.paintContainerPanel.Controls.Add(this.paintPanel);
            this.paintContainerPanel.Location = new System.Drawing.Point(12, 69);
            this.paintContainerPanel.Name = "paintContainerPanel";
            this.paintContainerPanel.Size = new System.Drawing.Size(692, 529);
            this.paintContainerPanel.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 601);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(716, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "HELLO";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // paintPanel
            // 
            this.paintPanel.AutoScroll = true;
            this.paintPanel.BackColor = System.Drawing.Color.White;
            this.paintPanel.Location = new System.Drawing.Point(3, 3);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(764, 596);
            this.paintPanel.TabIndex = 0;
            this.paintPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.paintPanel_Paint);
            this.paintPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintPanel_Click);
            this.paintPanel.MouseHover += new System.EventHandler(this.paintPanel_MouseHover);
            // 
            // GridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(716, 623);
            this.Controls.Add(this.paintContainerPanel);
            this.Controls.Add(this.spritePanel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GridForm";
            this.Text = "Gridden";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.paintContainerPanel.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel spritePanel;
        private DrawingPanel paintPanel;
        private System.Windows.Forms.Panel paintContainerPanel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem viewTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newSheetToolStripMenuItem;
    }
}

