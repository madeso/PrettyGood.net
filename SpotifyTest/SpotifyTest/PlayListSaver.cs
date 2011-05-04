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
				dOutput.Text = "";
				if (sfd.ShowDialog() != DialogResult.OK) return;
				List<string> lines = new List<string>();

				foreach (var d in data)
				{
					var l = mdata.getPath(d.Artist, d.Album, d.Title, d.Tracknumber);
					if (l != "")
					{
						lines.Add(l);
					}
					else
					{
						dOutput.AppendText(string.Format("Missing from library: {0} - {1} - {2}\r\n", d.Artist, d.Title, d.Album));
					}
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

		class CompileData
		{
			public List<string> list;
			public bool Clean;

		}

		MusicData mdata = new MusicData();
		private void dCompile_Click(object sender, EventArgs e)
		{
			dCompileResults.Text = "Compiling";
			dCompile.Enabled = false;
			dSave.Enabled = false;
			dCompiler.RunWorkerAsync(new CompileData { list = new List<string>(Util.Strings.RemoveEmpty(dRoots.Lines)), Clean = dClean.Checked });
		}

		private void dCompiler_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				var da = (CompileData)e.Argument;
				MusicData mdata = new MusicData { Clean = da.Clean };
				// move to a comile step?
				List<string> files = new List<string>();
				foreach (string l in da.list)
				{
					files.AddRange(mdata.getFiles(l));
				}
				for (int i = 0; i < files.Count; ++i)
				{
					var l = files[i];
					mdata.add(l);
					if (i % 20 == 0)
					{
						dCompiler.ReportProgress((int)((100.0f * i) / files.Count), mdata.Count);
					}
				}

				e.Result = mdata;
			}
			catch (Exception ex)
			{
				e.Result = ex;
			}
		}

		private void dCompiler_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			dCompileResults.Text = string.Format("Compiling ({0}%) found {1}", e.ProgressPercentage, e.UserState);
		}

		private void dCompiler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			dCompile.Enabled = true;
			dSave.Enabled = true;
			string result = "";
			if (e.Result is Exception)
			{
				var x = (Exception) e.Result;
				mdata = new MusicData();
				result = x.ToString();
			}
			else
			{
				mdata = (MusicData)e.Result;
				result = string.Format("Found {0} songs", mdata.Count);
			}
			dCompileResults.Text = result;
		}
	}
}
