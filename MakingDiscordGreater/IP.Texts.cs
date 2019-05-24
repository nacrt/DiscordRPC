using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDG.AssetCollection
{
	class Desc
	{
		/// <summary>
		/// Stores all Posibilities for the First line
		/// </summary>
		public static TextAssetCollection Details = new TextAssetCollection();
		/// <summary>
		/// Stores all Posibilities for the Second line 
		/// </summary>
		public static TextAssetCollection States = new TextAssetCollection();

		/// <summary>
		/// The Currently used Filename for the File containing all rows for Details
		/// </summary>
		public static string File_Name_Details = "Details.txt";
		/// <summary>
		/// The Currently used Filename for the File containing all rows for States
		/// </summary>
		public static string File_Name_States = "States.txt";
		/// <summary>
		/// a signle <see cref="Asset"/> in which every value Will be stored
		/// </summary>
		public class Asset
		{
			/// <summary>
			/// Stores the String that will be used
			/// </summary>
			public string Text = "";
			/// <summary>
			/// Stores if the String can be used or not
			/// </summary>
			public bool Enabled = true;
			/// <summary>
			/// The Current Index in the <see cref="TextAssetCollection"/>
			/// </summary>
			public int Index = -1;

			public override string ToString() => Index + ": " + Enabled + ", " + this;

			/// <summary>
			/// Translates the Given Asset into a <see cref="ListViewItem"/>
			/// </summary>
			public ListViewItem ListViewItem => new ListViewItem(Text)
			{ Checked = Enabled, BackColor = IP.getLvIColorValue(Enabled) };

			#region Constructors
			/// <summary>
			/// Initzialze a new <see cref="Asset"/> with the default values of Text: "" and Enabled: true
			/// </summary>
			public Asset () { }
			/// <summary>
			/// Initzialze a new <see cref="Asset"/> with a custom Text and the default value of Enabled: true
			/// </summary>
			/// <param name="text">custom Text</param>
			public Asset(string text) => this.Text = text;
			/// <summary>
			/// Initzialze a new <see cref="Asset"/> with a custom Enabled state and the default Text: ""
			/// </summary>
			/// <param name="enabled">Custom Enabled State</param>
			public Asset(bool enabled) => this.Enabled = enabled;
			/// <summary>
			/// Initzialze a new <see cref="Asset"/> with a custom Enabled state and a custom Text
			/// </summary>
			/// <param name="text">Custom Text</param>
			/// <param name="enabled">Custom Enabled State</param>
			public Asset (string text, bool enabled) { this.Text = text; this.Enabled = enabled; }
			#endregion

			#region Custom Operators
			public static bool operator ==(Asset a, Asset b) => a.Text == b.Text && a.Enabled == b.Enabled;
			public static bool operator !=(Asset a, Asset b) => !(a.Text == b.Text && a.Enabled == b.Enabled);
			public static bool operator & (Asset a, Asset b) => a.Enabled && b.Enabled;
			public static bool operator | (Asset a, Asset b) => a.Enabled || b.Enabled;
			public static Asset operator +(Asset a, Asset b) => new Asset(a.Text + b.Text, a.Enabled && b.Enabled);

			public static bool operator ==(Asset a, string b) => a.Text == b;
			public static bool operator ==(string a, Asset b) => b.Text == a;
			public static bool operator !=(Asset a, string b) => a.Text != b;
			public static bool operator !=(string a, Asset b) => b.Text != a;

			public static string operator +(Asset a, string b) => a.Text + b;
			public static string operator +(string a, Asset b) => a + b.Text;

			public static bool operator ==(Asset a, bool b) => a.Enabled == b;
			public static bool operator ==(bool a, Asset b) => b.Enabled == a;
			public static bool operator !=(Asset a, bool b) => a.Enabled != b;
			public static bool operator !=(bool a, Asset b) => b.Enabled != a;
			public static bool operator & (Asset a, bool b) => a.Enabled && b;
			public static bool operator & (bool a, Asset b) => b.Enabled && a;
			public static bool operator | (Asset a, bool b) => a.Enabled || b;
			public static bool operator | (bool a, Asset b) => b.Enabled || a;


			//public static ListViewItem operator as (ListViewItem a, Asset b) =>;
			#endregion
		}

	}

	class TextAssetCollection : IEnumerable
	{
		private List<Desc.Asset> Items = new List<Desc.Asset>();

		/// <summary>
		/// Alloes the Collection to be directly called instead of having to add .Items
		/// </summary>
		public Desc.Asset this[int index]
		{
			get { return Items[index]; }
			set { Items[index] = value; Items[index].Index = index; }
		}

		public bool HasItems => Items.Count != 0;

		/// <summary>
		/// ReMaps every Index
		/// </summary>
		/// <param name="startPos"></param>
		protected void reDrawAllIndexes(int startPos = 0)
		{
			for (int i = startPos; i < Items.Count; i++) Items[i].Index = i;
		}
		/// <summary>
		/// Calls the Number of Elements inside the TextAssetCollection
		/// </summary>
		public int Count => Items.Count;
		/// <summary>
		/// Replaces the List.Add Method for direct Access
		/// <para>Inserts the <see cref="Asset"/> at the Last Index of the List </para>
		/// </summary>
		/// <param name="asset">The New <see cref="Desc.Asset"/></param>
		public void Add(Desc.Asset asset)
		{
			asset.Index = Items.Count;
			Items.Add(asset);
		}
		/// <summary>
		/// Replaces the List.Add Method for direct Access
		/// <para>Inserts the <see cref="Asset"/> at the Last Index of the List </para>
		/// <para>Enabled state will be Default (True) </para>
		/// </summary>
		/// <param name="text">The Text for the asset</param>
		public void Add(string text)
		{
			Desc.Asset asset = new Desc.Asset(text);
			Items.Add(asset);
		}
		/// <summary>
		/// Adds every Asset from the Assetcollection to 
		/// </summary>
		/// <param name="collection">The <see cref="TextAssetCollection" which is supposed to be added/> </param>
		public void Add(TextAssetCollection collection) { foreach (Desc.Asset asset in collection) Add(asset); }
		/// <summary>
		/// Replaces the List.AddRage Method for direct Access
		/// <para>Adds the Collection at Last Index of the Element</para>
		/// </summary>
		/// <param name="collection">The Collection which is supposed to be added</param>
		public void AddRange(TextAssetCollection collection) => Items.AddRange(collection.Items);
		/// <summary>
		/// Replaces the List.RemoveAt Method for direct Access 
		/// <para>Removes the <see cref="Desc.Asset"/> at which Index Specified</para>
		/// </summary>
		/// <param name="index">The Index of which Asset Will be removed</param>
		public void RemoveAt(int index)
		{
			Items.RemoveAt(index);
			reDrawAllIndexes(index);
		}
		/// <summary>
		/// Replaces the Items List With a new, empty list
		/// </summary>
		public void Clear() => Items.Clear();
		/// <summary>
		/// Disassembles the file, removes all old assets and replaces them with the Dissasembled Contents of the File
		/// </summary>
		/// <param name="file">The File With the Content</param>
		public void SetContentFromFile(string[] file)
		{
			Clear();
			foreach (string line in file)
			{
				char[] splitter = { ';' };
				string[] split = line.Split(splitter, 2);

				Desc.Asset asset = new Desc.Asset();
				asset.Text = (split.Length == 2) ? split[1] : string.Empty;

				string enabled = split[0];
				if (enabled == "0")
					asset.Enabled = false;
				else if (enabled != "1")
					asset.Text = enabled + asset;
				
				this.Add(asset);
			}
		}
		/// <summary>
		/// Shifts the Item position by the Sepcivied Offset or 
		/// attaches it to the other end of the List when the index becomes out of range
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="posoffset"></param>
		public int MoveItemBy(int pos, int offset)
		{
			if (Items.Count >= 2)
			{
				int posoffset = pos - offset;
				bool pos_is_ok = posoffset >= 0 && posoffset < Items.Count; 

				if (pos_is_ok)
				{
					Desc.Asset item = Items[posoffset];
					Items[posoffset] = Items[pos];
					Items[pos] = item;
				}
				else
				{
					if (posoffset < 0)
					{
						posoffset = Items.Count - offset;
						Desc.Asset item = Items[0];
						RemoveAt(0);
						Add(item);
					}
					else
					{
						posoffset = -1 - offset;
						Desc.Asset item = Items[pos];
						RemoveAt(pos);
						var collection = new TextAssetCollection();
						collection.Add(item);
						collection.AddRange(this);
						Items = collection.Items;
					}
				}
				return posoffset;
			}
			return 0;

		}
		/// <summary>
		/// Sets every <see cref="Desc.Asset.Enabled"/> to False or the specified Bool
		/// </summary>
		/// <param name="enabled">The new state of every Element</param>
		public void ChangeEnabledAll(bool enabled = false)
		{
			foreach (Desc.Asset item in Items) item.Enabled = enabled;
		}

		#region Implementation for the GetEnumerator method
		IEnumerator IEnumerable.GetEnumerator() => new TextAssetCollectionEnum(Items);
		private class TextAssetCollectionEnum : IEnumerator
		{
			int position = -1;
			public List<Desc.Asset> Items;
			public TextAssetCollectionEnum(List<Desc.Asset> Items) => this.Items = Items;
			public bool MoveNext() => (++position < Items.Count);
			public void Reset() => position = -1;
			object IEnumerator.Current => Current;
			public Desc.Asset Current
			{
				get
				{
					try
					{
						return Items[position];
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException();
					}
				}
			}
		}
		#endregion
	}

	partial class IP
	{

		public static string[] _details_file;
		public static string[] _states_file;

		public static Color setLviBackColor(ListViewItem item) =>
			item.BackColor = getLvIColorValue(item.Checked);

		public static Color getLvIColorValue(bool enabled) => 
			enabled ? Color.FromArgb(154, 173, 224) : Color.FromKnownColor(KnownColor.WhiteSmoke);

		private static void desc_new_d(long _ID, bool fromall = false)
		{
			if (!fromall)
				_checkout(_ID);
			string[] file = new string[0];
			try
			{
				file = File.ReadAllLines(_m_folder_path + Desc.File_Name_Details);
			}
			catch (Exception e) { MessageBox.Show(e.Message); }

			Desc.Details.SetContentFromFile(file);

		}

		private static void desc_new_s(long _ID, bool fromall = false)
		{
			if (!fromall)
				_checkout(_ID);

			string[] file = new string[0];
			try
			{
				file = File.ReadAllLines(_m_folder_path + Desc.File_Name_States);
			}
			catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.Message); }
			Desc.States.SetContentFromFile(file);
		}
		/// <summary>
		/// Stores every Item of the TextAssetCollection to the File with the Specified name
		/// </summary>
		/// <param name="filename">The Filename in which the Items are supposed to be stored</param>
		public static void SaveContentToFile(TextAssetCollection collection, string filename)
		{
			string[] newfile = new string[collection.Count];
			for (int i = 0; i < collection.Count; i++)
			{
				Desc.Asset asset = collection[i];
				string newline = (asset.Enabled ? "1" : "0") + ";" + asset;
				newfile[i] = newline;
			}
			File.WriteAllLines(IP.Main_Folder_Path + filename, newfile);
		}
	}


}
