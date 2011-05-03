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
			addRoot(System.Environment.GetFolderPath( Environment.SpecialFolder.MyMusic ));
			addRoot(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
		}

		private void dSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (sfd.ShowDialog() != DialogResult.OK) return;
				List<string> lines = new List<string>();

				foreach (var d in data)
				{
					var l = mdata.getPath(d.Artist, d.Album, d.Title, d.Tracknumber);
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
			addRoot(dFolder.SelectedPath);
		}

		private void addRoot(string p)
		{
			dRoots.AppendText(p);
			dRoots.AppendText("\r\n");
		}

		private void PlayListSaver_Load(object sender, EventArgs e)
		{
			dSave.Enabled = data != null;
		}

		MusicData mdata = new MusicData();
		private void dCompile_Click(object sender, EventArgs e)
		{
			mdata = new MusicData();
			// move to a comile step?
			foreach (string l in Util.Strings.RemoveEmpty(dRoots.Lines))
			{
				mdata.add(l);
			}

			dCompileResults.Text = string.Format("Found {0} songs", mdata.Count);
		}
	}
}
