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
	partial class frmDescs : Form
	{
		public TextAssetCollection Collection { get; set; }
		public string Filename_of_contents;

		private bool lv_item_avaliable => lvDescs.SelectedItems.Count == 1;
		private ListViewItem lv_item_sel => lv_item_avaliable ? lvDescs.SelectedItems[0] : lv_item_last_sel;
		private ListViewItem lv_item_last_sel
		{
			get => _lv_item_last_sel;
			set
			{
				_lv_item_last_sel = value;
				txtDesc.Text = value.Text;
			}
		}
		private ListViewItem _lv_item_last_sel = null;

		public frmDescs()
		{
			InitializeComponent();
		}

		public void startAll()
		{
			addAllDescsToLv();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IP.SaveContentToFile(Collection, Filename_of_contents);
		}

		private void addAllDescsToLv()
		{
			if (lvDescs.Items.Count == Collection.Count)
			{
				foreach (Desc.Asset asset in Collection)
				{
					lvDescs.Items[asset.Index] = asset.ListViewItem;
				}
			}
			else
			{
				lvDescs.Items.Clear();
				foreach (Desc.Asset asset in Collection)
				{
					ListViewItem newitem = new ListViewItem(asset.Text);
					newitem.Checked = asset.Enabled;
					IP.setLviBackColor(newitem);
					lvDescs.Items.Add(newitem);
				}
			}

			if (lvDescs.Items.Count > 0) lv_item_last_sel = lvDescs.Items[0];
			else txtDesc.Text = "";
		}

		private void lvDescs_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			IP.setLviBackColor(e.Item);
			Collection[e.Item.Index].Enabled = e.Item.Checked;
		}

		private void lvDescs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_item_avaliable)
				lv_item_last_sel = lv_item_sel;

		}

		private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Enter))
			{
				lv_item_sel.Text = (sender as TextBox).Text;
				Collection[lv_item_sel.Index].Text = (sender as TextBox).Text;

			}
		}

		private void frmDescs_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Filename_of_contents == Desc.File_Name_Details)
				Main.frmDetailsIsOpen = false;
			else if (Filename_of_contents == Desc.File_Name_States)
				Main.frmStatesIsOpen = false;
		}

		private void btnSaveToFile_Click(object sender, EventArgs e)
		{
			IP.SaveContentToFile(Collection, Filename_of_contents);
		}

		private void btnSort_Clicked(object sender, EventArgs e)
		{
			if (Collection.HasItems)
			{
				int posoffset = Convert.ToInt32((sender as Button).Tag);
				int pos = lv_item_sel.Index;
				int newpos = Collection.MoveItemBy(pos, posoffset);
				addAllDescsToLv();
				lvDescs.Items[newpos].Selected = true;
			}


		}
	}
}
