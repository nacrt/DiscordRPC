using System;
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
		private static bool selectedLVItemAvaliable = false;
		
		
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
			listView.Items.Clear();
			int index = 0;
			foreach (Img.Asset item in Img.Small)
			{
				ListViewItem newRow = listView.Items.Add(item.Key);
				newRow.SubItems.Add(item.Path);
				newRow.SubItems.Add(item.Text);
				newRow.Checked = item.Check;
				newRow.ImageKey = item.Key;
				index++;
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

				selectedLVItemAvaliable = true;
				txtKey.Text = Img.Small[lv_sel_index].Key;
				txtPath.Text = Img.Small[lv_sel_index].Path;
				txtText.Text = Img.Small[lv_sel_index].Text;
			}
			else
			{
				selectedLVItemAvaliable = false;
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
			if (listView.Columns[e.ColumnIndex].Width > 200)
				listView.Columns[e.ColumnIndex].Width = 200;
			resizeLV();
		}

		/// <summary>
		/// changes the location of the control after the resizing of the list view
		/// </summary>
		private void resizeLV()
		{
			listView.Width = listView.Columns[0].Width + listView.Columns[1].Width + listView.Columns[2].Width + 20;
			int distLvEnd = listView.Size.Width + 12;
			int txtKeyY = txtKey.Location.Y;
			int txtPathY = txtPath.Location.Y;
			int txtTextY = txtText.Location.Y;
			int btnTCKY = btnTxtChangeKeys.Location.Y;
			int btnCloseY = btnClose.Location.Y;
			int btnARKY = btnTxtAddKeys.Location.Y;
			int btnTDKY = btnTxtDeleteKeys.Location.Y;
			int btnSUY = btnSortUp.Location.Y;
			int btnSDY = btnSortDown.Location.Y;
			int btnSaveY = btnSave.Location.Y;


			int distTxtToLv = 6;
			int distafterlv = distLvEnd + distTxtToLv;
			txtKey.Location =			new Point(distafterlv, txtKeyY);
			txtPath.Location =			new Point(distafterlv, txtPathY);
			txtText.Location =			new Point(distafterlv, txtTextY);
			btnTxtChangeKeys.Location = new Point(distafterlv, btnTCKY);
			btnClose.Location =			new Point(distafterlv, btnCloseY);
			btnTxtAddKeys.Location =	new Point(distafterlv, btnARKY);
			btnTxtDeleteKeys.Location = new Point(distafterlv, btnTDKY);
			btnSortUp.Location =		new Point(distafterlv, btnSUY);
			btnSortDown.Location =		new Point(distafterlv + 80, btnSDY);
			btnSave.Location =			new Point(distafterlv, btnSaveY);
		}


		/// <summary>
		/// Updates the Used state of the key
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lv_small_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			Img.Small[e.Item.Index].Check = e.Item.Checked;
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
			if (selectedLVItemAvaliable)
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
						listView.Items[lv_sel_index].ImageKey = "EmptyImage";
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

				ListViewItem item = listView.Items[lv_sel_index];
				item.SubItems[0].Text = key;
				item.SubItems[1].Text = path;
				item.SubItems[2].Text = text;
				item.ImageKey = key;
				listView.Items[lv_sel_index] = item;
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
			if (selectedLVItemAvaliable)
			{
				listView.Items[lv_sel_index].Remove();

				Img.Small = IP.removeAssetByIndex(Img.Small, lv_sel_index);

				try
				{
					listView.Items[lv_sel_index].Selected = true;
				} catch (Exception) {
					try
					{
						listView.Items[lv_sel_index - 1].Selected = true;
					} catch (Exception) { }
				}

				listView.Select();
			}
		}

		private void btnSort_Click(object _sender, EventArgs e)
		{
			if (selectedLVItemAvaliable && listView.Items.Count > 1)
			{
				Button sender = (Button)_sender;
				string uORd = sender.AccessibleDescription;

				if (uORd == "u")
				{
					if (lv_sel_index > 0)
					{
						Img.Asset old_asset = Img.Small[lv_sel_index];
						Img.Asset new_asset = Img.Small[lv_sel_index - 1];

						Img.Small[lv_sel_index] = new_asset;
						Img.Small[lv_sel_index - 1] = old_asset;

						_updateListViewItem(new_asset, lv_sel_index);
						_updateListViewItem(old_asset, lv_sel_index - 1);
						listView.Items[lv_sel_index - 1].Selected = true;
					}
					else
					{
						int last_index = listView.Items.Count - 1;
						Img.Asset old_asset = Img.Small[lv_sel_index];

						listView.Items[lv_sel_index].Remove();
						Img.Small = IP.removeAssetByIndex(Img.Small, lv_sel_index);
						Img.Small = IP.insertAssetByIndex(Img.Small, old_asset);

						_addListViewItem(old_asset);
						listView.Items[last_index].Selected = true;
					}
				}
				else if (uORd == "d")
				{
					if (lv_sel_index < listView.Items.Count - 1)
					{
						Img.Asset old_asset = Img.Small[lv_sel_index];
						Img.Asset new_asset = Img.Small[lv_sel_index + 1];


						Img.Small[lv_sel_index] = new_asset;
						Img.Small[lv_sel_index + 1] = old_asset;

						_updateListViewItem(new_asset, lv_sel_index);
						_updateListViewItem(old_asset, lv_sel_index + 1);
						listView.Items[lv_sel_index + 1].Selected = true;

					}
					else
					{
						int first_index = 0;
						Img.Asset old_asset = Img.Small[lv_sel_index];

						Img.Small = IP.removeAssetByIndex(Img.Small, lv_sel_index);
						Img.Small = IP.insertAssetByIndex(Img.Small, old_asset, first_index);

						load_listView_from_all();
						listView.Items[first_index].Selected = true;
					}
				}
			}
		}

		private void _updateListViewItem(Img.Asset asset, int index)
		{
			ListViewItem item = listView.Items[index];

			item.SubItems[0].Text = asset.Key;
			item.SubItems[1].Text = asset.Path;
			item.SubItems[2].Text = asset.Text;
			item.ImageKey = asset.Key;
			item.Checked = asset.Check;

			listView.Items[index] = item;

		}

		private void _addListViewItem(Img.Asset asset, int index = -1)
		{
			ListViewItem newRow = listView.Items.Add(asset.Key);
			newRow.SubItems.Add(asset.Path);
			newRow.SubItems.Add(asset.Text);
			newRow.Checked = asset.Check;
			newRow.ImageKey = asset.Key;
			newRow.Checked = asset.Check;
			newRow.Selected = true;

			if (index != -1)
			{

			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			IP.saveToFile(Img.Small, folder_path + file_name);
		}
	}
}