using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.AssetCollection
{
	/// <summary>
	/// Stores all Information needed for Valuation
	/// Note: does Include Preview Images
	/// </summary>
	public class Images
	{
		/// <summary>
		/// Stores Information about the Small images
		/// </summary>
		public static Asset[] Small;
		public static bool Small_uses_only_one_asset = false;

		/// <summary>
		/// Stores Information about the Large images
		/// </summary>
		public static Asset[] Large;
		public static bool Large_uses_only_one_asset = false;

		/// <summary>
		/// Unchecks every Asset
		/// </summary>
		/// <param name="assets"></param>
		public static void Uncheck_All(ref Images.Asset[] assets)
		{
			for (int i = 0; i < assets.Length; i++)
				assets[i].Check = false;
		}


		/// <summary>
		/// Combines All Items as a number to compare them
		/// </summary>
		/// <param name="asset"></param>
		/// <returns></returns>
		public static long getItemValue (Asset[] assets)
		{
			long value = 1;
			foreach (Images.Asset asset in assets)
			{
				int val = Convert.ToInt32(asset.Check);

				string[] strs = new string[3];
				strs[0] = asset.Key;
				strs[1] = asset.Path;
				strs[2] = asset.Text;

				foreach (string str in strs)
					foreach (char chr in str)
						val += Convert.ToInt32(Convert.ToByte(chr));
				value *= val;
			}
			return value;
		}
		/// <summary >
		/// Image Asset Layout
		/// </summary>
		public struct Asset
		{
			/// <summary>
			/// Whether or not the Image shall be used
			/// </summary>
			public bool Check;
			/// <summary>
			/// Discord Asset key
			/// </summary>
			public string Key;
			/// <summary>
			/// Local Image Path
			/// </summary>
			public string Path;
			/// <summary>
			/// Discord Display Text
			/// </summary>
			public string Text;
		}
	}

	/// <summary>
	/// Information Processing
	/// </summary>
	public partial class IP
	{
		public static long ID;

		private static string _s_file_name = "smallImagesIndex.txt";
		private static string _s_folder_name = "smallImages";
		private static string _s_folder_path = _s_folder_name + "\\\\";

		private static string _l_file_name = "largeImagesIndex.txt";
		private static string _l_folder_name = "largeImages";
		private static string _l_folder_path = _s_folder_name + "\\\\";
		private static string _m_folder_name;
		private static string _m_folder_path;

		private static string[] s_file;
		private static string[] l_file;

		/// <summary>
		/// Loads all Assets from the Files | 
		/// Creates those Files if not existent
		/// </summary>
		/// <param name="ID">Client ID</param>
		public static void img_new_all(long _ID)
		{
			_checkout(_ID);
			img_new_s(_ID, true);
			img_new_l(_ID, true);
			
		}

		private static void img_new_s(long _ID, bool fromall = false)
		{
			if (!fromall)
				_checkout(_ID);

			s_file = new string[0];
			try
			{
				s_file = File.ReadAllLines(_m_folder_path + _s_file_name);
			} catch (Exception) { }
			
			Images.Small = _deconstruct_file(s_file);
		}

		private static void img_new_l(long _ID, bool fromall = false)
		{
			if (!fromall)
				_checkout(_ID);

			l_file = new string[0];
			try
			{
				l_file = File.ReadAllLines(_m_folder_path + _l_file_name);
			} catch (Exception) { }
			
			 Images.Large = _deconstruct_file(l_file);
		}

		public static Images.Asset[] removeAssetByIndex(Images.Asset[] old_assets, int index)
		{
			Images.Asset[] new_assets = new Images.Asset[old_assets.Length - 1];
			old_assets[index].Key = null;

			int _index = 0;
			foreach (Images.Asset item in old_assets.Where(i=>i.Key != null))
			{
				new_assets[_index++] = item;
			}

			return new_assets;
		}

		public static Images.Asset[] insertAssetByIndex(Images.Asset[] old_assets, Images.Asset asset, int index = -1)
		{
			Images.Asset[] new_assets = new Images.Asset[old_assets.Length + 1];
			if (index == -1) index = new_assets.Length - 1;

			int _index = 0;
			int _index_old = 0;
			foreach (Images.Asset _item in new_assets)
			{
				Images.Asset item;
				if (_index != index)
					item = old_assets[_index_old++];
				else
					item = asset;
				new_assets[_index++] = item;
			}

			return new_assets;
		}

		/// <summary>
		/// Saves the Image Assets to the Specified file. must include the file name
		/// </summary>
		/// <param name="assets"></param>
		/// <param name="path"></param>
		/// <returns>Successfully saved</returns>
		public static bool saveAssetToFile(Images.Asset[] assets, string path)
		{
			string[] lines = new string[assets.Length];

			int _index = 0;
			foreach (Images.Asset asset in assets)
			{
				lines[_index] = asset.Key + ";";
				lines[_index] += asset.Path + ";";
				lines[_index] += asset.Text;
				_index++;
			}
			try
			{
				File.WriteAllLines(path, lines);
				FileStream strem = File.OpenWrite(path);
			} catch (Exception) {
				return false;
			}

			return true;
		}

		public static void throwAssetsAtConsole(Images.Asset[] assets)
		{
			Console.WriteLine("".PadRight(18, '-'));
			foreach (Images.Asset asset in assets)
			{
				throwSignleAssetAtConsole(asset);
			}
			Console.WriteLine("".PadRight(18, '-'));
		}

		public static void throwSignleAssetAtConsole (Images.Asset asset)
		{
			string log = string.Empty;
			log += "Used: ";
			log += asset.Check.ToString().PadRight(5) + ", ";
			log += "Key: ";
			log += "\"" + asset.Key.Trim() + "\", ";
			log += "File: ";
			log += "\"" + asset.Path.Trim() + "\", ";
			log += "Text: ";
			log += "\"" + asset.Text.Trim() + "\"";
			Console.WriteLine(log);
		}

		private static Images.Asset[] _deconstruct_file(string[] _file)
		{ 
			Images.Asset[] Asset = new Images.Asset[_file.Length];

			int index = 0;
			char[] separator = { ';' };
			foreach (string row in _file)
			{
				string[] splitrow = row.Split(separator, 3);

				Images.Asset item = new Images.Asset();

				item.Check = true;
				item.Key = splitrow[0];
				item.Path = (splitrow.Length > 1 ) ? splitrow[1] : string.Empty;
				item.Text = (splitrow.Length > 2 ) ? splitrow[2] : string.Empty;
				
				Asset[index] = item;
				index++;
			}
			return Asset;
		}
		
		private static void _checkout(long _ID)
		{
			ID = _ID;

			_m_folder_name = ID.ToString();
			_m_folder_path = _m_folder_name + "\\\\";

			if (!Directory.Exists(_m_folder_path))
				Directory.CreateDirectory(_m_folder_path);

			if (!Directory.Exists(_s_folder_path))
				Directory.CreateDirectory(_s_folder_path);

			if (!Directory.Exists(_l_folder_path))
				Directory.CreateDirectory(_l_folder_path);

			if (!File.Exists(_m_folder_path + _s_file_name))
				File.Create(_m_folder_path + _s_file_name);

			if (!File.Exists(_m_folder_path + _l_file_name))
				File.Create(_m_folder_path + _l_file_name);
		}
	}
}
