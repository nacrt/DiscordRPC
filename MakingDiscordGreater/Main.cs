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
using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.Exceptions;
using DiscordRPC.Helper;
using DiscordRPC.IO;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using DiscordRPC.RPC;
using DiscordRPC.RPC.Payload;
using DiscordRPC.Web;
using MDG.AssetCollection;


namespace MDG
{

	public partial class Main : Form
    {
        public static DiscordRpcClient client;

		public bool id_avaliable = false;
		public static long rpc_client_id;

        public static string details;
        public static string state;
        public static string largeImageKey;
        public static string largeImageText;
        public static string smallImageKey;
        public static string smallImageText;


		private static string[] connectionsTXT;
		private static string connectionsFileName = "connections.txt";
		public static long[] ids;
		public static string[] ids_name;
		
		

        //Called when your application first starts.
        //For example, just before your main loop, on OnEnable for unity.
        void InitializeConnection()
        {
            client = new DiscordRpcClient(rpc_client_id.ToString());
			
			client.OnPresenceUpdate += (sender, e) =>
			{
				debugThrowNew("Received Update! {0}" + e.Presence.ToString());
			};
			client.OnReady += (sender, e) =>
			{
				debugThrowNew("Received Ready from user {0}" + e.User.Username.ToString());
			};

			//Subscribe to events
			//client.OnReady += (sender, e) =>
			//{
			//    textDebug.Text = "did something \n" + textDebug.Text;
			//    textDebug.Text = "Received Ready from user {0}" + e.User.Username.ToString() + "\n" + textDebug.Text;
			//    //Console.WriteLine("Received Ready from user {0}", e.User.Username);
			//};
			//
			//client.OnPresenceUpdate += (sender, e) =>
			//{
			//    textDebug.Text = "did something2 \n" + textDebug.Text;
			//    textDebug.Text = "Received Update! {0}" + e.Presence.ToString() + "\n" + textDebug.Text;
			//    //Console.WriteLine("Received Update! {0}", e.Presence);
			//};

			//Connect to the RPC
			client.Initialize();

		}

        void rpc_setPresence()
        {
			
            textdebugupdate();
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText
                }
            });
        }

        public Main()
        {
			InitializeAll();
            timerWait.Enabled = true;
        }

		private void load_ID()
		{

			if (File.Exists(@connectionsFileName))
			{
				connectionsTXT = File.ReadAllLines(connectionsFileName);
				ids = new long[0];
				ids_name = new string[0];
				foreach (string row in connectionsTXT)
				{
					long newID;
					string[] splitrow = row.Split(' ');
					if (splitrow[0].Length >= 18 && long.TryParse(splitrow[0], out newID))
					{
						int index = ids.Length;

						add_client_id(newID);
						add_client_desc(string.Empty);


						for (int i = 1; i < splitrow.Length; i++)
							ids_name[index] += splitrow[i] + " ";
					}
					else
					{
						debugThrowNew("Error at ID " + splitrow[0]);
					}

				}

			}
			else
			{
				//debugThrowNew("The File " + connectionsFileName + " does not exist or is in the wrong location");
				File.Create(@connectionsFileName);
				ids = new long[0];
				ids_name = new string[0];
			}
		}

		private void add_client_desc(string newString, int index = -1)
		{
			if (index == -1)
				index = ids_name.Length;

			Array.Resize(ref ids_name, index + 1);
			ids_name[index] = newString;
		}

		private void add_client_id(long newID, int index = -1)
		{
			if (index == -1)
				index = ids.Length;

			Array.Resize(ref ids, index + 1);
			ids[index] = newID;
		}

		public void debugThrowNew(string message, string message2 = "\n")
		{
			textDebug.Text = message + message2 + textDebug.Text;
			Console.WriteLine(message + ((message2 != "\n") ? message2 : ""));
		}

		private void InitializeAll()
		{
			InitializeComponent();
			InitializeConnection();
			load_ID();
			reload_lvID();
			create_Paths();
		}

		private void create_Paths()
		{
			foreach (long id in ids)
			{
				create_path(id);

			}

		}

		private void create_path(long id, string desc = "")
		{

			string path = id.ToString() + "\\\\";
			if (Directory.Exists(path))
			{
				if (Directory.Exists(path + "largeImages"))
				{

				}
				else
				{
					Directory.CreateDirectory(path + "largeImages");
				}
				if (Directory.Exists(path + "smallImages"))
				{

				}
				else
				{
					Directory.CreateDirectory(path + "smallImages");
				}
				if (File.Exists(path + "largeImagesIndex.txt"))
				{

				}
				else
				{
					File.Create(path + "largeImagesIndex.txt");
				}
				if (File.Exists(path + "smallImagesIndex.txt"))
				{

				}
				else
				{
					File.Create(path + "smallImagesIndex.txt");
				}
				if (File.Exists(path + Desc.File_Name_Details))
				{

				}
				else
				{
					File.Create(path + Desc.File_Name_Details);
				}
				if (File.Exists(path + Desc.File_Name_States))
				{

				}
				else
				{
					File.Create(path + Desc.File_Name_States);
				}



			}
			else
			{
				Directory.CreateDirectory(path);
				Directory.CreateDirectory(path + "largeImages");
				Directory.CreateDirectory(path + "smallImages");
				File.Create(path + "largeImagesIndex.txt");
				File.Create(path + "smallImagesIndex.txt");
				File.Create(path + Desc.File_Name_Details);
				File.Create(path + Desc.File_Name_States);

			}
		}

		private void reload_lvID()
		{
			lvConnections.Items.Clear();
			int IDSindexer = 0;
			foreach (long id in ids)
			{
				ListViewItem newLine = lvConnections.Items.Add(id.ToString());
				newLine.SubItems.Add(ids_name[IDSindexer++]);
			}
		}

		private void textdebugupdate()
        {
			client.OnReady += (sender, e) =>
			{
				debugThrowNew("Received Ready from user {0} "
					, e.User.Username.ToString() + "\n");
				//Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				debugThrowNew("Received Update! {0} "
					, e.Presence.ToString() + "\n");
				//Console.WriteLine("Received Update! {0}", e.Presence);
			};
		}

        int counting = 1;
        private void timerWaitTick(object sender, EventArgs e)
        {
            rpc_setPresence();
        }

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			client.Dispose();
		}

		public static long addClientID { get; set; }
		public static string addClientDesc { get; set; }
		public static bool addClientKorrekt { get; set; }
		public static bool addClientIntentional { get; set; }

		private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			addClientKorrekt = false;
			addID newform = new addID();
			newform.ShowDialog();

			if (addClientKorrekt)
			{
				string __hba = addClientID.ToString();
				__hba += " has been added under the name ";
				debugThrowNew(__hba + "\n" + addClientDesc);

				create_path(addClientID,addClientDesc);

				add_client_id(addClientID);
				add_client_desc(addClientDesc);

				ListViewItem newLine = lvConnections.Items.Add(addClientID.ToString());
				newLine.SubItems.Add(addClientDesc);
				
			}
			else
			{
				if (!addClientIntentional)
				{
					debugThrowNew("Error while parsing " + addClientID.ToString(), " under the name of \n " + addClientDesc);
				}
				else
				{
					debugThrowNew("Didn't Parse ID");
				}
			}
		}

		private void lvConnections_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (lvConnections.CheckedItems.Count > 0)
			{
				debugThrowNew("".PadRight(18, '-'));
				foreach (ListViewItem row in lvConnections.CheckedItems)
				{
					debugThrowNew(row.Text);
				}
				debugThrowNew("".PadRight(18, '-'));
			}
			else
			{
				debugThrowNew("".PadRight(18, '+'));
			}
		}

		public static bool opendLarge
		{
			get { return _opendLarge; }
			set
			{
				_opendLarge = value;
				if (!value && !(Equals(old_img_asset_large,Images.Large)))
					IP.throwAssetsAtConsole(Images.Large);
			}
		}
		public static bool opendSmall
		{
			get { return _opendSmall; }
			set
			{
				//long o_v = Img.getItemValue(old_img_asset_small);
				//long n_v = Img.getItemValue(Img.Small);
				//
				//if (o_v != n_v)
				//	IP.throwAssetsAtConsole(Img.Small);
				//
				//Console.WriteLine("\n" + o_v + "\n" + n_v);
				_opendSmall = value;
			}
		}
		private static bool _opendLarge = false;
		private static bool _opendSmall = false;

		private static Images.Asset[] old_img_asset_small = null;
		private static Images.Asset[] old_img_asset_large = null;

		private void menstripitemimages(object _sender, EventArgs e)
		{
			if (id_avaliable)
			{
				ToolStripItem sender = (ToolStripItem)_sender;
				if (sender.AccessibleDescription.Substring(0,1) ==  "s")
				{
					if (!opendSmall)
					{
						smallImages newForm = new smallImages(rpc_client_id);
						opendSmall = true;
						newForm.Show();
					}
				}
				else if (sender.AccessibleDescription.Substring(0, 1) == "l")
				{
					if (!opendLarge)
					{
						largeImages newForm = new largeImages(rpc_client_id);
						opendLarge = true;
						newForm.Show();
					}
				}
			}
		}

		private void btnUseID_Click(object sender, EventArgs e)
		{
			if (lvConnections.SelectedItems.Count == 1)
			{
				id_avaliable = true;
				long old_id = rpc_client_id;
				rpc_client_id = ids[lvConnections.SelectedItems[0].Index];
				
				if (old_id != rpc_client_id)
				{
					enable_all_if_id_avaliable(id_avaliable);
				}
			}
			else 
			{
				id_avaliable = false;
				enable_all_if_id_avaliable(id_avaliable);
			}
		}


		/// <summary>
		/// Applies all Changes if a client ID is avaliable and being used
		/// </summary>
		/// <param name="avaliable"></param>
		public void enable_all_if_id_avaliable(bool avaliable)
		{
			configToolStripMenuItem.Visible = avaliable;
			btnOpenInExplorer.Enabled = avaliable;
			DescsToolStripMenuItem.Visible = avaliable;
			if (avaliable)
			{
				IP.new_all(rpc_client_id);
				old_img_asset_small = Images.Small;
				Console.WriteLine(Images.getItemValue(old_img_asset_small) + " :: Small");
				old_img_asset_large = Images.Large;
				Console.WriteLine(Images.getItemValue(old_img_asset_large) + " :: Small");
				_subLog(Images.Small, "Small images");
				_subLog(Images.Large, "Large images");
				debugThrowNew("Now using " + rpc_client_id.ToString());
			}
		}

		public void _subLog(Images.Asset[] keys, string s_l)
		{
			string[] s_log = new string[keys.Length];
			int index = 0;
			int s_biggestLogStringSize = 2;
			foreach (Images.Asset item in keys)
			{
				string loge = string.Empty;
				loge += "Used: ";
				loge += item.Check.ToString().PadRight(5) + ", ";
				loge += "Key: ";
				loge += "\"" + item.Key.Trim() + "\", ";
				loge += "File: ";
				loge += "\"" + item.Path.Trim() + "\", ";
				loge += "Text: ";
				loge += "\"" + item.Text.Trim() + "\"";
				if (loge.Length > s_biggestLogStringSize)
					s_biggestLogStringSize = loge.Length;
				s_log[index++] = loge;
			}
			Array.Reverse(s_log);
			debugThrowNew("<".PadRight(s_biggestLogStringSize - 2, '-') + ">");
			foreach (string item in s_log)
				debugThrowNew(item);
			debugThrowNew(s_l);
			debugThrowNew("<".PadRight(s_biggestLogStringSize - 2, '-') + ">");
		}


		private void btnOpenInExplorer_Click(object sender, EventArgs e)
		{
			string mypath = AppDomain.CurrentDomain.BaseDirectory;
			string thepath = mypath + rpc_client_id.ToString();
			System.Diagnostics.Process.Start("explorer.exe", thepath);
		}

		private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmDetails frm = new frmDetails();
			frm.Visible = true;
			//frm.Show();
		}

		private void lvConnections_DoubleClick(object sender, EventArgs e)
		{
			if (lvConnections.Items.Count == 1)
			{
				id_avaliable = true;
				long old_id = rpc_client_id;
				rpc_client_id = ids[lvConnections.SelectedItems[0].Index];

				if (old_id != rpc_client_id)
				{
					enable_all_if_id_avaliable(id_avaliable);
				}
			}
		}
	}
}
