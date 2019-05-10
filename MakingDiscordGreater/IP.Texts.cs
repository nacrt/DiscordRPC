using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.AssetCollection
{
	class Texts
	{
		/// <summary>
		/// Stores all Posibilities for the First line
		/// </summary>
		public static TextAssetCollection Details = new TextAssetCollection();
		/// <summary>
		/// Stores all Posibilities for the Second line 
		/// </summary>
		public static TextAssetCollection States = new TextAssetCollection();

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
		}

	}

	class TextAssetCollection
	{
		public List<Texts.Asset> Items = new List<Texts.Asset>();

		public void ChangeEnabledAll(bool enabled = false)
		{
			foreach (Texts.Asset item in Items) item.Enabled = enabled;
		}




	}

	public partial class IP
	{

		public static void initializeTexts()
		{

		}

		public static void aa()
		{
			//string tx = Texts.Details[0].Text;
		}
	}


}
