namespace MDG
{
	partial class frmDetails
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
			this.button1 = new System.Windows.Forms.Button();
			this.lvDescs = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(363, 344);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(158, 93);
			this.button1.TabIndex = 0;
			this.button1.Text = "Mighty Debug Button";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lvDescs
			// 
			this.lvDescs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvDescs.CheckBoxes = true;
			this.lvDescs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvDescs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvDescs.FullRowSelect = true;
			this.lvDescs.GridLines = true;
			this.lvDescs.HideSelection = false;
			this.lvDescs.LabelEdit = true;
			this.lvDescs.Location = new System.Drawing.Point(12, 12);
			this.lvDescs.MultiSelect = false;
			this.lvDescs.Name = "lvDescs";
			this.lvDescs.Size = new System.Drawing.Size(345, 425);
			this.lvDescs.TabIndex = 1;
			this.lvDescs.TileSize = new System.Drawing.Size(5, 5);
			this.lvDescs.UseCompatibleStateImageBehavior = false;
			this.lvDescs.View = System.Windows.Forms.View.Details;
			this.lvDescs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvDescs_ItemChecked);
			this.lvDescs.SelectedIndexChanged += new System.EventHandler(this.lvDescs_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Text";
			this.columnHeader1.Width = 338;
			// 
			// txtDesc
			// 
			this.txtDesc.AutoCompleteCustomSource.AddRange(new string[] {
            "%N1!",
            "%N2!",
            "%N3!"});
			this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDesc.Location = new System.Drawing.Point(363, 12);
			this.txtDesc.MaxLength = 128;
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(316, 26);
			this.txtDesc.TabIndex = 2;
			this.txtDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesc_KeyPress);
			// 
			// frmDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 450);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.lvDescs);
			this.Controls.Add(this.button1);
			this.Name = "frmDetails";
			this.Text = "frmDetails";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDetails_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView lvDescs;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox txtDesc;
	}
}