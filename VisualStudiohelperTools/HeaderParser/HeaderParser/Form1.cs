using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HeaderParser
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void dGo_Click(object sender, EventArgs e)
		{
			var g = new Graph();
			var pl = new PathList(dInclude.Text.Split(";".ToCharArray()), dIgnoreFolders.Text.Split(";".ToCharArray()));
			Logic.Parse(g, pl, dInput.Text, x => handle(x));
			g.runDot(Path.ChangeExtension(dInput.Text, null), "png", dLayout.Text);
		}

		private Logic.MissingFileAction handle(string file)
		{
			return Logic.MissingFileAction.NoParse;
			//throw new NotImplementedException();
		}

		private void dBrowseInput_Click(object sender, EventArgs e)
		{
			if (ofd.ShowDialog() == DialogResult.OK) dInput.Text = ofd.FileName;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var s = Properties.Settings.Default;
			s.Reload();
			dInput.Text = s.Input;
			dInclude.Text = s.IncludeFolders;
			dIgnoreFolders.Text = s.IgnoreFolders;
			dLayout.Text = s.Layout;
			dInsertMissingHeaders.Checked = s.InsertMissingHeaders;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			var s = Properties.Settings.Default;
			s.Input = dInput.Text;
			s.IncludeFolders = dInclude.Text;
			s.IgnoreFolders = dIgnoreFolders.Text;
			s.Layout = dLayout.Text;
			s.InsertMissingHeaders = dInsertMissingHeaders.Checked;
			s.Save();
		}
	}
}
