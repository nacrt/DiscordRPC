namespace MDG
{
	partial class addID
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
			this.txtHID = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtDesc = new System.Windows.Forms.TextBox();
			this.txtHDesc = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtHID
			// 
			this.txtHID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHID.Location = new System.Drawing.Point(12, 12);
			this.txtHID.Name = "txtHID";
			this.txtHID.ReadOnly = true;
			this.txtHID.Size = new System.Drawing.Size(426, 20);
			this.txtHID.TabIndex = 0;
			this.txtHID.TabStop = false;
			this.txtHID.Text = "Client ID (Length = 18 Numbers)";
			this.txtHID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtID
			// 
			this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtID.Location = new System.Drawing.Point(13, 39);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(425, 20);
			this.txtID.TabIndex = 1;
			this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
			// 
			// txtDesc
			// 
			this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDesc.Location = new System.Drawing.Point(13, 92);
			this.txtDesc.Name = "txtDesc";
			this.txtDesc.Size = new System.Drawing.Size(425, 20);
			this.txtDesc.TabIndex = 2;
			// 
			// txtHDesc
			// 
			this.txtHDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHDesc.Location = new System.Drawing.Point(12, 65);
			this.txtHDesc.Name = "txtHDesc";
			this.txtHDesc.ReadOnly = true;
			this.txtHDesc.Size = new System.Drawing.Size(426, 20);
			this.txtHDesc.TabIndex = 2;
			this.txtHDesc.TabStop = false;
			this.txtHDesc.Text = "Description / Name (Max Length = 128 Bytes)";
			this.txtHDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(49, 135);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(351, 142);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Send";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// addID
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(450, 289);
			this.ControlBox = false;
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtDesc);
			this.Controls.Add(this.txtHDesc);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.txtHID);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "addID";
			this.ShowInTaskbar = false;
			this.Text = " ";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtHID;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.TextBox txtHDesc;
		private System.Windows.Forms.Button btnClose;
	}
}