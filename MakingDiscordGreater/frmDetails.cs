using MDG.AssetCollection;
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
	partial class frmDetails : Form
	{
		public TextAssetCollection Collection;
		public bool _thisformisopen;
		public string File_Name_of_contents;

		private const bool settextwhenlastselitemchanged = true;
		private bool lv_item_avaliable => lvDescs.SelectedItems.Count == 1;
		private ListViewItem lv_item_sel => lv_item_avaliable ? lvDescs.SelectedItems[0] : lv_item_last_sel;
		private ListViewItem lv_item_last_sel
		{
			get => _lv_item_last_sel;
			set
			{
				_lv_item_last_sel = value;
				if (settextwhenlastselitemchanged) txtDesc.Text = value.Text;
			}
		}

		private ListViewItem _lv_item_last_sel = null;

		public frmDetails()
		{
			InitializeComponent();
		}

		public void startAll()
		{
			addAllDescsToLv();
		}

		public frmDetails(ref TextAssetCollection Descs, ref bool thisformisopen, string contentfilename)
		{
			//this.Collection = Descs;
			//this._thisformisopen = thisformisopen;
			//this.File_Name_of_contents = contentfilename;

			InitializeComponent();
		}


		private void button1_Click(object sender, EventArgs e)
		{
			//addAllDescsToLv();
			Desc.Details.RemoveAt(0);
			foreach (Desc.Asset asset in Desc.Details)
			{
				Console.WriteLine(asset.Index);
			}
			addAllDescsToLv();
		}

		private void setLvBackColor(ListViewItem item, bool enabled) => item.BackColor = (enabled) ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);
		private void setLvBackColor(ListViewItem item, Desc.Asset asset) => item.BackColor = (asset.Enabled) ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);
		private void setLvBackColor(ListViewItem item) => item.BackColor = (item.Checked) ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);


		private void addAllDescsToLv()
		{
			lvDescs.Items.Clear();
			foreach (Desc.Asset asset in Desc.Details)
			{
				ListViewItem newitem = new ListViewItem(asset.Text);
				newitem.Checked = asset.Enabled;
				setLvBackColor(newitem);
				lvDescs.Items.Add(newitem);
			}
			if (lvDescs.Items.Count > 0)
			{
				lv_item_last_sel = lvDescs.Items[0];
				txtDesc.Text = lv_item_last_sel.Text;
			}
			else
			{
				txtDesc.Text = "";
			}
		}

		private void lvDescs_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			setLvBackColor(e.Item);
			Desc.Details[e.Item.Index].Enabled = e.Item.Checked;
		}

		private void lvDescs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_item_avaliable)
				lv_item_last_sel = lv_item_sel;

			if (!settextwhenlastselitemchanged) txtDesc.Text = lv_item_sel.Text;

		}

		private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				lv_item_sel.Text = (sender as TextBox).Text;
				Desc.Details[lv_item_sel.Index].Text = (sender as TextBox).Text;

			}
		}

		private void frmDetails_FormClosed(object sender, FormClosedEventArgs e)
		{
			_thisformisopen = false;
		}
	}
}
