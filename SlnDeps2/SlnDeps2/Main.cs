using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SlnDeps
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void dBrowseSource_Click(object sender, EventArgs e)
		{
			if (ofd.ShowDialog() != DialogResult.OK) return;
			dSource.Text = ofd.FileName;
		}

		private void dBrowseTarget_Click(object sender, EventArgs e)
		{
			if (sfd.ShowDialog() != DialogResult.OK) return;
			dTarget.Text = sfd.FileName;
		}

		private void dGo_Click(object sender, EventArgs e)
		{
			List<string> items = new List<string>();
			foreach (var c in dExcludes.CheckedItems)
			{
				items.Add(c.ToString());
			}
			if (items.Count == 0) items = null;
			Logic.toGraphviz(dSource.Text, dTarget.Text, dFormat.Text, items, dSimplifyLinks.Checked);
		}

		private void dFillExcludes_Click(object sender, EventArgs e)
		{
			dExcludes.Items.Clear();
			foreach (var s in Logic.GetProjects(dSource.Text))
			{
				dExcludes.Items.Add(s, true);
			}
		}
	}
}
