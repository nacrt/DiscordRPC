namespace MDG
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.textDebug = new System.Windows.Forms.RichTextBox();
			this.timerWait = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menStripEditSmallImages = new System.Windows.Forms.ToolStripMenuItem();
			this.menStripEditLargeImages = new System.Windows.Forms.ToolStripMenuItem();
			this.DescsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.lvConnections = new System.Windows.Forms.ListView();
			this.Client_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.collhead_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnUseID = new System.Windows.Forms.Button();
			this.chkAutoConnect = new System.Windows.Forms.CheckBox();
			this.btnOpenInExplorer = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textDebug
			// 
			this.textDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textDebug.DetectUrls = false;
			this.textDebug.Font = new System.Drawing.Font("Consolas", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textDebug.Location = new System.Drawing.Point(326, 238);
			this.textDebug.Name = "textDebug";
			this.textDebug.ReadOnly = true;
			this.textDebug.Size = new System.Drawing.Size(560, 340);
			this.textDebug.TabIndex = 0;
			this.textDebug.Text = "";
			// 
			// timerWait
			// 
			this.timerWait.Interval = 5000;
			this.timerWait.Tick += new System.EventHandler(this.timerWaitTick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDToolStripMenuItem,
            this.configToolStripMenuItem,
            this.DescsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(898, 36);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// iDToolStripMenuItem
			// 
			this.iDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aDDToolStripMenuItem});
			this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
			this.iDToolStripMenuItem.Size = new System.Drawing.Size(98, 32);
			this.iDToolStripMenuItem.Text = "Client ID";
			// 
			// aDDToolStripMenuItem
			// 
			this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
			this.aDDToolStripMenuItem.Size = new System.Drawing.Size(118, 32);
			this.aDDToolStripMenuItem.Text = "add";
			this.aDDToolStripMenuItem.Click += new System.EventHandler(this.aDDToolStripMenuItem_Click);
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menStripEditSmallImages,
            this.menStripEditLargeImages});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(125, 32);
			this.configToolStripMenuItem.Text = "Edit Images";
			this.configToolStripMenuItem.Visible = false;
			// 
			// menStripEditSmallImages
			// 
			this.menStripEditSmallImages.AccessibleDescription = "small";
			this.menStripEditSmallImages.Name = "menStripEditSmallImages";
			this.menStripEditSmallImages.Size = new System.Drawing.Size(199, 32);
			this.menStripEditSmallImages.Text = "Small Images";
			this.menStripEditSmallImages.Click += new System.EventHandler(this.menstripitemimages);
			// 
			// menStripEditLargeImages
			// 
			this.menStripEditLargeImages.AccessibleDescription = "large";
			this.menStripEditLargeImages.Name = "menStripEditLargeImages";
			this.menStripEditLargeImages.Size = new System.Drawing.Size(199, 32);
			this.menStripEditLargeImages.Text = "Large Images";
			this.menStripEditLargeImages.Click += new System.EventHandler(this.menstripitemimages);
			// 
			// DescsToolStripMenuItem
			// 
			this.DescsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.statesToolStripMenuItem});
			this.DescsToolStripMenuItem.Name = "DescsToolStripMenuItem";
			this.DescsToolStripMenuItem.Size = new System.Drawing.Size(124, 32);
			this.DescsToolStripMenuItem.Text = "Description";
			this.DescsToolStripMenuItem.Visible = false;
			// 
			// detailsToolStripMenuItem
			// 
			this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
			this.detailsToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
			this.detailsToolStripMenuItem.Text = "Details";
			this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
			// 
			// statesToolStripMenuItem
			// 
			this.statesToolStripMenuItem.Name = "statesToolStripMenuItem";
			this.statesToolStripMenuItem.Size = new System.Drawing.Size(180, 32);
			this.statesToolStripMenuItem.Text = "States";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "c1.jpg");
			this.imageList1.Images.SetKeyName(1, "c2.jpg");
			this.imageList1.Images.SetKeyName(2, "c3.jpg");
			this.imageList1.Images.SetKeyName(3, "c4.jpg");
			this.imageList1.Images.SetKeyName(4, "c5.jpg");
			this.imageList1.Images.SetKeyName(5, "c6.jpg");
			this.imageList1.Images.SetKeyName(6, "c7.jpg");
			this.imageList1.Images.SetKeyName(7, "c8.jpg");
			this.imageList1.Images.SetKeyName(8, "c9.jpg");
			// 
			// lvConnections
			// 
			this.lvConnections.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
			this.lvConnections.AllowDrop = true;
			this.lvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lvConnections.CheckBoxes = true;
			this.lvConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Client_ID,
            this.collhead_name});
			this.lvConnections.FullRowSelect = true;
			this.lvConnections.GridLines = true;
			this.lvConnections.HideSelection = false;
			this.lvConnections.Location = new System.Drawing.Point(13, 39);
			this.lvConnections.MultiSelect = false;
			this.lvConnections.Name = "lvConnections";
			this.lvConnections.Size = new System.Drawing.Size(308, 539);
			this.lvConnections.SmallImageList = this.imageList1;
			this.lvConnections.TabIndex = 5;
			this.lvConnections.UseCompatibleStateImageBehavior = false;
			this.lvConnections.View = System.Windows.Forms.View.Details;
			this.lvConnections.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvConnections_ItemChecked);
			this.lvConnections.DoubleClick += new System.EventHandler(this.lvConnections_DoubleClick);
			// 
			// Client_ID
			// 
			this.Client_ID.Text = "Client ID";
			this.Client_ID.Width = 20;
			// 
			// collhead_name
			// 
			this.collhead_name.Text = "Name";
			this.collhead_name.Width = 153;
			// 
			// btnUseID
			// 
			this.btnUseID.Location = new System.Drawing.Point(326, 120);
			this.btnUseID.Name = "btnUseID";
			this.btnUseID.Size = new System.Drawing.Size(78, 43);
			this.btnUseID.TabIndex = 6;
			this.btnUseID.Text = "Use ID";
			this.btnUseID.UseVisualStyleBackColor = true;
			this.btnUseID.Click += new System.EventHandler(this.btnUseID_Click);
			// 
			// chkAutoConnect
			// 
			this.chkAutoConnect.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkAutoConnect.Location = new System.Drawing.Point(326, 39);
			this.chkAutoConnect.Name = "chkAutoConnect";
			this.chkAutoConnect.Size = new System.Drawing.Size(77, 75);
			this.chkAutoConnect.TabIndex = 7;
			this.chkAutoConnect.Text = "Automatically connect after ID changes";
			this.chkAutoConnect.UseVisualStyleBackColor = true;
			// 
			// btnOpenInExplorer
			// 
			this.btnOpenInExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOpenInExplorer.Enabled = false;
			this.btnOpenInExplorer.Location = new System.Drawing.Point(326, 191);
			this.btnOpenInExplorer.Name = "btnOpenInExplorer";
			this.btnOpenInExplorer.Size = new System.Drawing.Size(140, 41);
			this.btnOpenInExplorer.TabIndex = 8;
			this.btnOpenInExplorer.Text = "Open in Explorer";
			this.btnOpenInExplorer.UseVisualStyleBackColor = true;
			this.btnOpenInExplorer.Click += new System.EventHandler(this.btnOpenInExplorer_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(898, 590);
			this.Controls.Add(this.btnOpenInExplorer);
			this.Controls.Add(this.chkAutoConnect);
			this.Controls.Add(this.btnUseID);
			this.Controls.Add(this.lvConnections);
			this.Controls.Add(this.textDebug);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Discord Rich Presence Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerWait;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aDDToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView lvConnections;
		private System.Windows.Forms.ColumnHeader Client_ID;
		private System.Windows.Forms.ColumnHeader collhead_name;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menStripEditSmallImages;
		private System.Windows.Forms.ToolStripMenuItem menStripEditLargeImages;
		private System.Windows.Forms.Button btnUseID;
		private System.Windows.Forms.CheckBox chkAutoConnect;
		private System.Windows.Forms.Button btnOpenInExplorer;
		public System.Windows.Forms.RichTextBox textDebug;
		private System.Windows.Forms.ToolStripMenuItem DescsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem statesToolStripMenuItem;
	}
}

