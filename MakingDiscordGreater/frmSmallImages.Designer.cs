namespace MDG
{
	partial class smallImages
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
			this.components = new System.ComponentModel.Container();
			this.listView = new System.Windows.Forms.ListView();
			this.col_s_imgKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_s_imgPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.col_s_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.txtKey = new System.Windows.Forms.TextBox();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.txtText = new System.Windows.Forms.TextBox();
			this.btnTxtChangeKeys = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnTxtAddKeys = new System.Windows.Forms.Button();
			this.btnTxtDeleteKeys = new System.Windows.Forms.Button();
			this.btnSortUp = new System.Windows.Forms.Button();
			this.btnSortDown = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView.CheckBoxes = true;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_s_imgKey,
            this.col_s_imgPath,
            this.col_s_text});
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(12, 12);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(606, 426);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lv_col_width_changed);
			this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lv_col_width_change);
			this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_small_ItemChecked);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
			// 
			// col_s_imgKey
			// 
			this.col_s_imgKey.Text = "Image Key";
			this.col_s_imgKey.Width = 200;
			// 
			// col_s_imgPath
			// 
			this.col_s_imgPath.Text = "Image Path";
			this.col_s_imgPath.Width = 200;
			// 
			// col_s_text
			// 
			this.col_s_text.Text = "Text";
			this.col_s_text.Width = 200;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList.ImageSize = new System.Drawing.Size(64, 64);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// txtKey
			// 
			this.txtKey.AccessibleDescription = "key";
			this.txtKey.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtKey.Location = new System.Drawing.Point(624, 12);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(150, 20);
			this.txtKey.TabIndex = 1;
			this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydownEnter);
			// 
			// txtPath
			// 
			this.txtPath.AccessibleDescription = "path";
			this.txtPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPath.Location = new System.Drawing.Point(624, 38);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(150, 20);
			this.txtPath.TabIndex = 2;
			this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydownEnter);
			// 
			// txtText
			// 
			this.txtText.AccessibleDescription = "text";
			this.txtText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtText.Location = new System.Drawing.Point(624, 64);
			this.txtText.MaxLength = 128;
			this.txtText.Name = "txtText";
			this.txtText.Size = new System.Drawing.Size(150, 20);
			this.txtText.TabIndex = 3;
			this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydownEnter);
			// 
			// btnTxtChangeKeys
			// 
			this.btnTxtChangeKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTxtChangeKeys.Location = new System.Drawing.Point(624, 90);
			this.btnTxtChangeKeys.Name = "btnTxtChangeKeys";
			this.btnTxtChangeKeys.Size = new System.Drawing.Size(150, 20);
			this.btnTxtChangeKeys.TabIndex = 4;
			this.btnTxtChangeKeys.Text = "Change Row";
			this.btnTxtChangeKeys.UseVisualStyleBackColor = true;
			this.btnTxtChangeKeys.Click += new System.EventHandler(this.btnTxtChangeKeys_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(624, 418);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(150, 20);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnTxtAddKeys
			// 
			this.btnTxtAddKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTxtAddKeys.Location = new System.Drawing.Point(624, 116);
			this.btnTxtAddKeys.Name = "btnTxtAddKeys";
			this.btnTxtAddKeys.Size = new System.Drawing.Size(150, 20);
			this.btnTxtAddKeys.TabIndex = 7;
			this.btnTxtAddKeys.Text = "Add Row";
			this.btnTxtAddKeys.UseVisualStyleBackColor = true;
			this.btnTxtAddKeys.Click += new System.EventHandler(this.btnTxtAddKeys_Click);
			// 
			// btnTxtDeleteKeys
			// 
			this.btnTxtDeleteKeys.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTxtDeleteKeys.Location = new System.Drawing.Point(624, 142);
			this.btnTxtDeleteKeys.Name = "btnTxtDeleteKeys";
			this.btnTxtDeleteKeys.Size = new System.Drawing.Size(150, 20);
			this.btnTxtDeleteKeys.TabIndex = 8;
			this.btnTxtDeleteKeys.Text = "Delete Row";
			this.btnTxtDeleteKeys.UseVisualStyleBackColor = true;
			this.btnTxtDeleteKeys.Click += new System.EventHandler(this.btnTxtDeleteKeys_Click);
			// 
			// btnSortUp
			// 
			this.btnSortUp.AccessibleDescription = "u";
			this.btnSortUp.Location = new System.Drawing.Point(624, 168);
			this.btnSortUp.Name = "btnSortUp";
			this.btnSortUp.Size = new System.Drawing.Size(70, 70);
			this.btnSortUp.TabIndex = 9;
			this.btnSortUp.Text = "Sort Up";
			this.btnSortUp.UseVisualStyleBackColor = true;
			this.btnSortUp.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// btnSortDown
			// 
			this.btnSortDown.AccessibleDescription = "d";
			this.btnSortDown.Location = new System.Drawing.Point(704, 168);
			this.btnSortDown.Name = "btnSortDown";
			this.btnSortDown.Size = new System.Drawing.Size(70, 70);
			this.btnSortDown.TabIndex = 10;
			this.btnSortDown.Text = "Sort Down";
			this.btnSortDown.UseVisualStyleBackColor = true;
			this.btnSortDown.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(624, 392);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(150, 20);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save to File";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// smallImages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnSortDown);
			this.Controls.Add(this.btnSortUp);
			this.Controls.Add(this.btnTxtDeleteKeys);
			this.Controls.Add(this.btnTxtAddKeys);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnTxtChangeKeys);
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.listView);
			this.MaximumSize = new System.Drawing.Size(816, 9000);
			this.Name = "smallImages";
			this.Text = "frmSmallImages";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmimages_closed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader col_s_imgKey;
		private System.Windows.Forms.ColumnHeader col_s_imgPath;
		private System.Windows.Forms.ColumnHeader col_s_text;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.Button btnTxtChangeKeys;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnTxtAddKeys;
		private System.Windows.Forms.Button btnTxtDeleteKeys;
		private System.Windows.Forms.Button btnSortUp;
		private System.Windows.Forms.Button btnSortDown;
		private System.Windows.Forms.Button btnSave;
	}
}