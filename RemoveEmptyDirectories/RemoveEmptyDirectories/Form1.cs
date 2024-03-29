﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RemoveEmptyDirectories
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		enum Type { Remove, Show }

		struct Input
		{
			public string dir;
			public Type type;
		}

		private void dWork_DoWork(object sender, DoWorkEventArgs e)
		{
			var source = (Input)e.Argument;
			mess("started on " + source.dir);

			if (source.type == Type.Remove)
			{
				removeDirectoriesRec(source.dir);
			}
			else
			{
				showHiddenFiles(source.dir);
			}

			mess("done");
		}

		private void showHiddenFiles(string dir)
		{
			foreach (var d in Directory.GetDirectories(dir))
			{
				showHiddenFiles(d);
			}

			foreach (var f in Directory.GetFiles(dir))
			{
				var fi = new FileInfo(f);
				if ((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
				{
					mess("Setting " + f + " from " + fi.Attributes.ToString() + " to normal");
					fi.Attributes = FileAttributes.Normal;
				}
			}
		}

		private void removeDirectoriesRec(string dir)
		{
			if (false == Directory.Exists(dir))
			{
				mess(dir + " doesnt exist");
				return;
			}

			List<string> dirs = new List<string>(Directory.GetDirectories(dir));
			foreach (var sub in dirs)
			{
				removeDirectoriesRec(sub);
			}

			var files = Directory.GetFiles(dir);
			if (files.Count() > 0)
			{
				List<string> validfiles = new List<string>();
				foreach (var f in files)
				{
					if (IsUselessFile(f))
					{
						mess("Deleting " + f);
						try
						{
							File.Delete(f);
						}
						catch (Exception e)
						{
							mess(e.Message);
						}
					}
					else
					{
						if (IsStrangeFile(f))
						{
							validfiles.Add(f);
						}
					}
				}

				if (validfiles.Count < 10)
				{
					foreach (var f in validfiles)
					{
						mess("   " + f + ": " + new FileInfo(f).Attributes.ToString());
					}
				}
			}

			// contains non-empty subdirectories...
			if (Directory.GetDirectories(dir).Count() > 0) return;

			// contains files
			if (Directory.GetFiles(dir).Count() > 0) return;

			try
			{
				mess(dir + " removing...");
				var di = new DirectoryInfo(dir);
				di.Attributes = FileAttributes.Normal;

				Directory.Delete(dir);
			}
			catch (Exception e)
			{
				mess("ERROR: " + dir + " was not removed, " + e.Message);
				return;
			}

			mess(dir + " removed!");
		}

		private bool IsUselessFile(string filename)
		{
			var f = filename.ToLower();
			if (f.EndsWith("thumbs.db")) return true;
			if (f.EndsWith("desktop.ini")) return true;
			return false;
		}

		private bool IsStrangeFile(string filename)
		{
			var f = filename.ToLower();
			if (f.EndsWith(".mp3")) return false;
			if (f.EndsWith(".mod")) return false;
			if (f.EndsWith(".ogg")) return false;
			if (f.EndsWith(".sid")) return false;
			return true;
		}

		private void mess(string m)
		{
			dWork.ReportProgress(0, m);
		}

		private void dGo_Click(object sender, EventArgs e)
		{
			startAction(Type.Remove);
		}

		private void startAction(Type remove)
		{
			dGo.Enabled = false;
			dInput.Enabled = false;
			dOutput.Text = "";
			dWork.RunWorkerAsync(new Input { dir = dInput.Text, type = remove });
		}

		private void dWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			dOutput.AppendText((string)e.UserState + Environment.NewLine);
		}

		private void dWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			dGo.Enabled = true;
			dInput.Enabled = true;
		}

		private void dShow_Click(object sender, EventArgs e)
		{
			startAction(Type.Show);
		}
	}
}
