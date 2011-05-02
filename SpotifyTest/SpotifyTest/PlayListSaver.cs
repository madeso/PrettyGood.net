using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrettyGood.SpotifyTest
{
	public partial class PlayListSaver : Form
	{
		public List<Data> data = null;

		public PlayListSaver()
		{
			InitializeComponent();
		}

		private void dSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (sfd.ShowDialog() != DialogResult.OK) return;
				List<string> lines = new List<string>();

				var p = Util.Pattern.Compile(dFormat.Text);
				var f = Util.Pattern.DefaultFunctions();
				foreach (var d in data)
				{
					Dictionary<string, string> dic = new Dictionary<string, string>();
					dic.Add("artist", d.Artist);
					dic.Add("album", d.Album);
					dic.Add("title", d.Title);
					dic.Add("track", d.Tracknumber);
					var l = p.eval(f, dic);
					lines.Add(l);
				}

				File.WriteAllLines(sfd.FileName, lines.ToArray());
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Error while saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dSetRoot_Click(object sender, EventArgs e)
		{
			if (dFolder.ShowDialog() != DialogResult.OK) return;
			dRoot.Text = dFolder.SelectedPath;
		}
	}
}
