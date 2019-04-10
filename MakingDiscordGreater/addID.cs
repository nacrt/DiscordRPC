using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDG
{
	public partial class addID : Form
	{
		public addID()
		{
			InitializeComponent();
		}

		public static long id { get; set; }
		private void btnClose_Click(object sender, EventArgs e)
		{
			bool korrektID = false;
			bool korrektDesc = true;
			long thisID;
			Main.addClientIntentional = true;
			if ( txtID.Text.Trim().Length >= 18 )
			{
				if (long.TryParse(txtID.Text.Trim(), out thisID))
				{
					id = thisID;
					korrektID = true;
					Main.addClientIntentional = false;
				}
				else
				{
					Main.addClientIntentional = true;
				}

			}

			if (korrektID && korrektDesc)
			{
				Main.addClientID = addID.id;
				Main.addClientDesc = txtDesc.Text;
				Main.addClientKorrekt = true;
				this.Close();
			}
			else
			{
				this.Close();
			}
		}

		private void txtID_TextChanged(object sender, EventArgs e)
		{
			if (txtID.Text.Length > 16 && txtID.Text.Length <= 20)
			{
				long kk;
				if (long.TryParse(txtID.Text.Trim(), out kk))
				{
					btnClose.Enabled = true;
					Main.addClientIntentional = false;
				}
				else
				{
					Main.addClientIntentional = false;
					btnClose.Enabled = false;
				}
			}
			else
			{
				Main.addClientIntentional = true;
				btnClose.Enabled = true;
			}
		}
	}
}
