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
			enableSave();
		}

		private void enableSave()
		{
			if (data == null) data = new List<Data>();
			bool hasData = data.Count > 0;
			dMapMusic.Enabled = hasData;
			dSave.Enabled = hasData;
		}

		class CompileData
		{
			public List<string> list;
			public bool Clean;
			public bool Words;
			public bool SmartReplace;
		}

		MusicData mdata = new MusicData();
		private void dCompile_Click(object sender, EventArgs e)
		{
			dCompileStatus.Text = "Compiling";
			dCompile.Enabled = false;
			dSave.Enabled = false;
			dMapMusic.Enabled = false;
			dCompiler.RunWorkerAsync(new CompileData { list = new List<string>(Util.Strings.RemoveEmpty(dRoots.Lines)), Clean = dClean.Checked, SmartReplace=dSmartReplace.Checked, Words=dWords.Checked });
		}

		class CompileResult
		{
			public MusicData mdata = new MusicData();
			public List<string> log = new List<string>();
			public Exception ex = null;
		}

		private void dCompiler_DoWork(object sender, DoWorkEventArgs e)
		{
			CompileResult result = new CompileResult();
			try
			{
				var da = (CompileData)e.Argument;
				result.mdata = new MusicData { Clean = da.Clean, SmartReplace = da.SmartReplace, Words = da.Words };

				List<string> files = new List<string>();
				foreach (string l in da.list)
				{
					files.AddRange(result.mdata.getFiles(l));
				}
				for (int i = 0; i < files.Count; ++i)
				{
					var l = files[i];
					result.mdata.add(l, ref result.log);
					if (i % 20 == 0)
					{
						dCompiler.ReportProgress((int)((100.0f * i) / files.Count), result.mdata.Count);
					}
				}

				result.log.Add("-----------------------------");
				result.log.Add(string.Format("found {0} entries", result.mdata.Count));
			}
			catch (Exception ex)
			{
				result.log.Add(string.Format("Error: {0}", ex.Message));
				result.ex = ex;
			}

			e.Result = result;
		}

		private void dCompiler_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			dCompileStatus.Text = string.Format("Compiling ({0}%) found {1}", e.ProgressPercentage, e.UserState);
		}

		List<string> log = new List<string>();

		private void dCompiler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			dCompile.Enabled = true;
			enableSave();
			string result = "";
			var r = (CompileResult)e.Result;
			mdata = r.mdata;
			log = r.log;
			
			if( r.ex != null )
			{
				result = r.ex.ToString();
			}
			else
			{
				result = string.Format("Found {0} songs", mdata.Count);
			}
			dCompileStatus.Text = result;
		}

		private void dShowCompilationResults_Click(object sender, EventArgs e)
		{
			new LogDisplay(log).ShowDialog(this);
		}

		List<string> lines;

		private void dMapMusic_Click(object sender, EventArgs e)
		{
			dOutput.Items.Clear();
			lines = new List<string>();

			foreach (var d in data)
			{
				var l = mdata.getPath(d.Artist, d.Album, d.Title, d.Tracknumber);
				if (l != "")
				{
					lines.Add(l);
				}
				else
				{
					var lvi = new ListViewItem(string.Format("Missing from library: {0} - {1} - {2}\r\n", d.Artist, d.Title, d.Album));
					lvi.Tag = d;
					dOutput.Items.Add(lvi);
				}
			}
		}

		private void dMapWorker_DoWork(object sender, DoWorkEventArgs e)
		{

		}

		private void dMapWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{

		}

		private void dMapWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

		}

		private void dOutput_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}

		private IEnumerable<Data> SelectedData()
		{
			foreach (ListViewItem i in dOutput.SelectedItems)
			{
				yield return (Data)i.Tag;
			}
		}

		private void overideArtistToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (sfd.ShowDialog() != DialogResult.OK) return;
			List<string> errors = new List<string>();
			var info = MusicData.ExtractInformation(sfd.FileName, ref errors);
			foreach (var d in SelectedData())
			{
				mdata.overideArtist(d.Artist, info.Artist);
			}
		}
	}
}
