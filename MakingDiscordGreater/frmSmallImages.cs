﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDG
{
	public partial class smallImages : Form
	{
		/// makes sure you can open it again :)
		private void frmimages_closed(object sender, FormClosedEventArgs e) => Main.opendSmall = false;

		private static long client_id;
		private static string folder_path;
		private static string file_name = "smallImagesIndex.txt";
		private static string images_folder = "smallImages";
		private static string images_path;

		private static int lv_sel_index;
		private static bool lv_sel_avaliable = false;
		private static ListViewItem lv_sel_item;
		
		
		public smallImages(long id)
		{
			InitializeComponent();
			
			if (id != 0)
				client_id = id;

			folder_path = client_id.ToString() + "\\\\";
			images_path = folder_path + images_folder + "\\\\";
			
			{ /// load_imageList_from_keys(); loads all images for List View
				int index = 0;
				foreach (Img.Asset item in Img.Small)
				{
					string key = item.Key;
					try
					{
						if (File.Exists(images_path + Img.Small[index].Path))
						{
							Image img = Image.FromFile(images_path + Img.Small[index].Path);
							imageList.Images.Add(key, img);
						}
					}
					catch (Exception) { }
					index++;
				}
			}
			load_listView_from_all();
		}
		/// <summary>
		/// Inserts array values into ListView
		/// </summary>
		private void load_listView_from_all()
		{
			lvImages.Items.Clear();
			int index = 0;
			foreach (Img.Asset item in Img.Small)
			{
				if (chkHideUnusedAssets.Checked)
				{
					if (item.Check)
					{
						_addListViewItem(item);
					}
				}
				else
				{
					_addListViewItem(item);
				}

			}
		}




		/// <summary>
		/// Sets the Text Box Texts
		/// </summary>
		/// <param name="_sender"></param>
		/// <param name="e"></param>
		private void listView_SelectedIndexChanged(object _sender, EventArgs e)
		{
			ListView sender = (ListView)_sender;
			_checkselectedindexava(sender);
		}

		private void _checkselectedindexava(ListView sender)
		{
			if (sender.SelectedItems.Count == 1)
			{
				lv_sel_index = sender.SelectedIndices[0];
				lv_sel_avaliable = true;
				lv_sel_item = sender.SelectedItems[0];
				txtKey.Text = Img.Small[lv_sel_index].Key;
				txtPath.Text = Img.Small[lv_sel_index].Path;
				txtText.Text = Img.Small[lv_sel_index].Text;
			}
			else
			{
				lv_sel_avaliable = false;
				txtKey.Text = "";
				txtPath.Text = "";
				txtText.Text = "";
			}
		}

		private void btnTxtChangeKeys_Click(object sender, EventArgs e)
		{
			_txtKeysChange();
		}

		

		/// <summary>
		/// List View Collumn resize functions
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lv_col_width_change(object sender, ColumnWidthChangingEventArgs e)
		{
			if (e.NewWidth > 200)
				e.NewWidth = 200;
			resizeLV();
		}
		private void lv_col_width_changed(object sender, ColumnWidthChangedEventArgs e)
		{
			if (lvImages.Columns[e.ColumnIndex].Width > 200)
				lvImages.Columns[e.ColumnIndex].Width = 200;
			resizeLV();
		}

		/// <summary>
		/// changes the location of the control after the resizing of the list view
		/// </summary>
		private void resizeLV()
		{
			lvImages.Width = lvImages.Columns[0].Width + lvImages.Columns[1].Width + lvImages.Columns[2].Width + 20;
			int distLvEnd = lvImages.Size.Width + 12;

			int distTxtToLv = 6;
			int afterLvX = distLvEnd + distTxtToLv;
			int x = afterLvX;

			List<TextBox> txts = new List<TextBox>(0);
			txts.Add(txtKey);
			txts.Add(txtPath);
			txts.Add(txtText);
			foreach (TextBox item in txts)
			{
				int y = item.Location.Y;
				int offset = 0;
				int.TryParse(item.AccessibleDescription, out offset);
				item.Location = new Point(x + offset, y);

			}

			List<Button> btns = new List<Button>(0);
			btns.Add(btnTxtChangeKeys);
			btns.Add(btnClose);
			btns.Add(btnTxtAddKeys);
			btns.Add(btnTxtDeleteKeys);
			btns.Add(btnSortUp);
			btns.Add(btnSortDown);
			btns.Add(btnSave);
			btns.Add(btnToggleUsage);
			foreach (Button item in btns)
			{
				int y = item.Location.Y;
				int offset = 0;
				int.TryParse(item.AccessibleDescription, out offset);
				item.Location = new Point(x + offset, y);
			}

			List<CheckBox> chks = new List<CheckBox>(0);
			chks.Add(chkHideUnusedAssets);
			foreach (CheckBox item in chks)
			{
				int y = item.Location.Y;
				int offset = 0;
				int.TryParse(item.AccessibleDescription, out offset);
				item.Location = new Point(x + offset, y);
			}
		}


		/// <summary>
		/// Updates the Used state of the key
		/// </summary>
		private void lv_small_ItemChecked(object _sender, ItemCheckedEventArgs e)
		{
			Img.Small[e.Item.Index].Check = e.Item.Checked;
			Color backcolor = (e.Item.Checked) ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);

			e.Item.BackColor = backcolor;
		}

		private void btnToggleUsage_Click(object sender, EventArgs e)
		{
			if (lv_sel_avaliable)
			{
				_toggleusage();
			}
		}

		private void _toggleusage()
		{
			bool newCheck = !Img.Small[lv_sel_index].Check;
			Img.Small[lv_sel_index].Check = newCheck;
			setLvColor(lvImages.SelectedItems[0], newCheck);
			if (chkHideUnusedAssets.Checked && !newCheck)
			{
				lvImages.Items[lv_sel_index].Remove();
				try
				{
					lvImages.Items[lv_sel_index].Selected = true;
					chkHideUnusedAssets.Select();
				}
				catch (Exception)
				{
					try
					{
						lvImages.Items[lv_sel_index - 1].Selected = true;
						chkHideUnusedAssets.Select();
					}
					catch (Exception) { }
				}
			}
		}

		public void setLvColor(ListViewItem item, bool selected)
		{
			item.BackColor = (selected) ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);
		}




		private void keydownEnter(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				_txtKeysChange();
			}
		}



		/// <summary>
		/// Updates the list View and the associated image 
		/// </summary>
		private void _txtKeysChange()
		{
			if (lv_sel_avaliable)
			{

				string key = txtKey.Text.Trim();
				string path = txtPath.Text.Trim();
				string text = txtText.Text.Trim();

				string old_key = Img.Small[lv_sel_index].Key;
				string old_path = Img.Small[lv_sel_index].Path;
				string old_text = Img.Small[lv_sel_index].Text;

				Img.Small[lv_sel_index].Key = key;
				Img.Small[lv_sel_index].Path = path;
				Img.Small[lv_sel_index].Text = text;


				if (File.Exists(images_path + path))
				{

				}
				else
				{
					//listView.Items[lv_sel_index].ImageKey = "EmptyImage";
				}




				/// kill me please
				/// Does not dispose the image if the key doesn't exist
				try
				{
					/// Make the image invsible if path doesn't exist !!!!!!
					if (File.Exists(images_path + path))
					{
						Image img = Image.FromFile(images_path + path);
						if (imageList.Images.ContainsKey(key))
						{
							bool ThumbnailCallback() { return false; }
							Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
							int imgind = imageList.Images.IndexOfKey(key);
							Image s_img = img.GetThumbnailImage(64, 64, myCallback, IntPtr.Zero);
							imageList.Images[imgind] = s_img;
						}
						else
						{
							imageList.Images.Add(key, img);
						}
					}
					else
					{
						lvImages.Items[lv_sel_index].ImageKey = "EmptyImage";
						//imageList.Images.RemoveByKey(old_key);
						//int imgind = imageList.Images.IndexOfKey(key);
						//imageList.Images[imgind] = null;
					}
				}
				catch (Exception)
				{
					try
					{
						imageList.Images[key].Dispose();
					}
					catch (Exception)
					{
						
					}
				}

				ListViewItem item = lvImages.Items[lv_sel_index];
				item.SubItems[0].Text = key;
				item.SubItems[1].Text = path;
				item.SubItems[2].Text = text;
				item.ImageKey = key;
				lvImages.Items[lv_sel_index] = item;
			}
		}

		private void btnTxtAddKeys_Click(object sender, EventArgs e)
		{
			Img.Asset[] newAssets = new Img.Asset[Img.Small.Length + 1];

			int index = 0;
			foreach (Img.Asset asset in Img.Small)
			{
				newAssets[index] = Img.Small[index];
				index++;
			}

			newAssets[Img.Small.Length].Check = true; 
			newAssets[Img.Small.Length].Key = txtKey.Text; 
			newAssets[Img.Small.Length].Path = txtPath.Text; 
			newAssets[Img.Small.Length].Text = txtText.Text;

			Img.Small = newAssets;

			Img.Asset item = Img.Small[Img.Small.Length - 1];

			_addListViewItem(item);

		}

		/// <summary>
		/// add a callback!!!!!!!
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnTxtDeleteKeys_Click(object sender, EventArgs e)
		{
			if (lv_sel_avaliable)
			{
				lvImages.Items[lv_sel_index].Remove();

				Img.Small = IP.removeAssetByIndex(Img.Small, lv_sel_index);

				try
				{
					lvImages.Items[lv_sel_index].Selected = true;
				} catch (Exception)
				{
					try
					{
						lvImages.Items[lv_sel_index - 1].Selected = true;
					} catch (Exception) { }
				}

				lvImages.Select();
			}
		}

		private void btnSort_Click(object _sender, EventArgs e)
		{
			if (lv_sel_avaliable && lvImages.Items.Count > 1)
			{
				Button sender = (Button)_sender;
				string uORd = sender.AccessibleDescription;

				if ((uORd == "u" && lv_sel_index > 0) || (uORd == "d" && lv_sel_index < lvImages.Items.Count - 1))
				{
					int offset = (uORd == "u") ? -1 : +1;
					Img.Asset old_asset = Img.Small[lv_sel_index];
					Img.Asset new_asset = Img.Small[lv_sel_index + offset];

					Img.Small[lv_sel_index] = new_asset;
					Img.Small[lv_sel_index + offset] = old_asset;

					_updateListViewItem(new_asset, lv_sel_index);
					_updateListViewItem(old_asset, lv_sel_index + offset);
					lvImages.Items[lv_sel_index + offset].Selected = true;

				}
				else
				{
					int index = (uORd == "u") ? lvImages.Items.Count - 1 : 0;
					Img.Asset old_asset = Img.Small[lv_sel_index];

					Img.Small = IP.removeAssetByIndex(Img.Small, lv_sel_index);
					Img.Small = IP.insertAssetByIndex(Img.Small, old_asset, index);

					load_listView_from_all();
					lvImages.Items[index].Selected = true;
				}
			}
		}

		private void _updateListViewItem(Img.Asset asset, int index)
		{
			ListViewItem item = lvImages.Items[index];

			item.SubItems[0].Text = asset.Key;
			item.SubItems[1].Text = asset.Path;
			item.SubItems[2].Text = asset.Text;
			item.ImageKey = asset.Key;
			item.Checked = asset.Check;

			lvImages.Items[index] = item;

		}

		private void _addListViewItem(Img.Asset asset)
		{
			ListViewItem newRow = lvImages.Items.Add(asset.Key);
			newRow.SubItems.Add(asset.Path);
			newRow.SubItems.Add(asset.Text);
			newRow.Checked = asset.Check;
			newRow.ImageKey = asset.Key;
			newRow.Checked = asset.Check;
			newRow.Selected = true;
			setLvColor(newRow, asset.Check);
		}

		private void btnSave_Click(object sender, EventArgs e) => IP.saveToFile(Img.Small, folder_path + file_name);

		private void lvImages_DoubleClick(object sender, EventArgs e)
		{
			if (lv_sel_avaliable) _toggleusage();
		}

		private void chkHideUnusedAssets_CheckedChanged(object sender, EventArgs e)
		{
			load_listView_from_all();

			btnSortUp.Enabled = !chkHideUnusedAssets.Checked;
			btnSortDown.Enabled = !chkHideUnusedAssets.Checked;
		}
	}
}