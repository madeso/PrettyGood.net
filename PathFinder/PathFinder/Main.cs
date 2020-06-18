using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PathFinder
{
	public partial class Main : Form
	{
		DirectoryInfo current = new DirectoryInfo(Directory.GetCurrentDirectory());
		string filter = "*";
		string currentFilter = "*";
		string dirfilter = "*";

		public Main()
		{
			InitializeComponent();

			updateView();
		}

		private void dInput_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				handleInput(dInput.Text);
				updateView();
			}
		}

		public class ObjectView
		{
			public ObjectView(DirectoryInfo dir)
			{
				Target = dir.FullName;
				Name = dir.Name;
			}

			public ObjectView(FileInfo file)
			{
				Target = file.FullName;
				Name = file.Name;
			}

			public readonly string Target;
			public readonly string Name;
		}

		private void updateView()
		{
			AutoCompleteStringCollection ss = new AutoCompleteStringCollection();
			
			Text = string.Format("{0} ({1})({2})", current.FullName, dirfilter, currentFilter);

			List<ObjectView> obj = new List<ObjectView>();

			foreach (DirectoryInfo dir in current.GetDirectories(dirfilter, SearchOption.TopDirectoryOnly))
			{
				obj.Add(new ObjectView(dir));
				ss.Add("cd " + dir.Name);
			}
			foreach (FileInfo file in current.GetFiles(currentFilter, SearchOption.TopDirectoryOnly))
			{
				obj.Add(new ObjectView(file));
				ss.Add("ed " + file.Name);
				ss.Add("ru " + file.Name);
			}

			dView.SetObjects(obj);
			dInput.AutoCompleteCustomSource = ss;
		}

		private void handleInput(string p)
		{
			if (p.StartsWith("cd "))
			{
				string folder = p.Remove(0, 3);
				currentFilter = filter;
				current = new DirectoryInfo(current.FullName + "/" + folder);
			}
			else if( p.StartsWith("fi ") )
			{
				string f = p.Remove(0, 3);
				filter = f;
				currentFilter = f;
			}
			else if (p.StartsWith("cf "))
			{
				string f = p.Remove(0, 3);
				currentFilter = f;
			}
			else if (p.StartsWith("df "))
			{
				string f = p.Remove(0, 3);
				dirfilter = f;
			}
			else if (p.StartsWith("ff "))
			{
				string f = p.Remove(0, 3);
				dirfilter = f;
				filter = f;
				currentFilter = f;
			}
			else if (p.StartsWith("ed "))
			{
				string f = p.Remove(0, 3);
				launch(f, "edit");
			}
			else if (p.StartsWith("ru "))
			{
				string f = p.Remove(0, 3);
				launch(f, "run");
			}
			else if (p.StartsWith("\\\\"))
			{
				current = new DirectoryInfo(p);
			}
		}

		private void launch(string f, string verb)
		{
			try
			{
				var fi = new FileInfo(current.FullName + "/" + f);
				var pi = new System.Diagnostics.ProcessStartInfo(fi.FullName);
				pi.WorkingDirectory = current.FullName;
				pi.Verb = verb;
				System.Diagnostics.Process.Start(pi);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
