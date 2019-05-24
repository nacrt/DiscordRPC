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

		private void setLvBackColor(ListViewItem item) => 
			item.BackColor = (item.Checked) ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);


		private void addAllDescsToLv()
		{
			lvDescs.Items.Clear();
			foreach (Desc.Asset asset in Collection)
			{
				ListViewItem newitem = new ListViewItem(asset.Text);
				newitem.Checked = asset.Enabled;
				setLvBackColor(newitem);
				lvDescs.Items.Add(newitem);
			}
			if (lvDescs.Items.Count > 0) lv_item_last_sel = lvDescs.Items[0];
			else txtDesc.Text = "";
		}

		private void lvDescs_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			setLvBackColor(e.Item);
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
	}
}
