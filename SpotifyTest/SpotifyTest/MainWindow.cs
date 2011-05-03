using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrettyGood.Util;
using System.Xml;
using System.Threading;

namespace PrettyGood.SpotifyTest
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			updateActions();
			updateButtons();
		}

		XmlElement get(string uri)
		{
			var url = string.Format("http://ws.spotify.com/lookup/1/?uri={0}", uri);
			bool done = false;
			string xml = "";
			while (done == false)
			{
				Encoding enc = Encoding.UTF8;
				xml = Web.FetchString(url, ref enc);
				if (xml.StartsWith("You"))
				{
					Thread.Sleep(1000 * 10);
					int i = 0;
					++i;
				}
				else
				{
					Thread.Sleep(100);
					done = true;
				}
			}
			return Xml.Open(Xml.FromSource(xml), "track");
		}

		private void dAbort_Click(object sender, EventArgs e)
		{
			if (dWorker.CancellationPending) return;
			dWorker.CancelAsync();
			updateButtons();
		}

		private void updateButtons()
		{
			dStart.Enabled = dWorker.IsBusy == false;
			dAbort.Enabled = dWorker.CancellationPending == false && dStart.Enabled == false;
		}

		private void dWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var d = new List<Data>();
			try
			{
				var t = (string)e.Argument;
				var l = new List<string>(Strings.RemoveEmpty(t.Split("\n\r\t ".ToCharArray())));
				for (int i = 0; i < l.Count; ++i)
				{
					var s = l[i];
					if (s.StartsWith("spotify:track:"))
					{
						var x = get(s);
						var artist = x["artist"]["name"].InnerText;
						var album = x["album"]["name"].InnerText;
						var trackn = x["track-number"].InnerText;
						var title = x["name"].InnerText;
						d.Add(new Data { Track = x, Artist = artist, Album = album, Title = title, Tracknumber=trackn });
						dWorker.ReportProgress((int)(100.0f * i / l.Count), string.Format("{0} - {1} - {2}", artist, title, album));
						if (dWorker.CancellationPending) return;
					}
					else
					{
						dWorker.ReportProgress((int)(100.0f * i / l.Count), string.Format("{0} is not a spotify URI", s));
					}
				}
			}
			catch (Exception ex)
			{
				dWorker.ReportProgress(0, string.Format("Error: {0}", ex.Message));
				dWorker.ReportProgress(0, "Aborting due to error");
			}

			e.Result = d;
		}

		private void dStart_Click(object sender, EventArgs e)
		{
			if (dWorker.IsBusy != false) return;
			if (dWorker.CancellationPending) return;
			dOutput.Text = "";
			data = null;
			updateActions();
			var cl = Clipboard.GetText();
			if (false == cl.StartsWith("spotify:track:"))
			{
				MessageBox.Show(this, "The clipboard needs to contain a list of Spotify URIs", "Clipboard error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			dWorker.RunWorkerAsync(cl);
			updateButtons();
		}

		private void dWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			var s = (string) e.UserState;
			dOutput.AppendText(s + "\r\n");
			dProgress.Value = e.ProgressPercentage;
		}

		List<Data> data = null;

		private void dWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			updateButtons();
			dProgress.Value = 0;
			data = (List<Data>)e.Result;
			updateActions();
		}

		private void updateActions()
		{
			dSaveXml.Enabled = data != null;
			//dSavePlaylist.Enabled = data != null;
		}

		private void dSaveXml_Click(object sender, EventArgs e)
		{
			if (sfdXml.ShowDialog() != DialogResult.OK) return;
			ElementBuilder b = new ElementBuilder().child("spotify");
			b.comment(" Each track element is the track returned by spotify call http://developer.spotify.com/en/metadata-api/lookup/track/ ");

			foreach(var d in data)
			{
				b.Element.AppendChild( b.Document.ImportNode(d.Track, true) );
			}

			b.Document.Save(sfdXml.FileName);
		}

		PlayListSaver pl = new PlayListSaver();
		private void dSavePlaylist_Click(object sender, EventArgs e)
		{
			pl.data = data;
			pl.ShowDialog(this);
		}
	}
}
