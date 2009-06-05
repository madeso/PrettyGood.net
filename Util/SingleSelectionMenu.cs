using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGood.Util
{
	public class SingleSelectionMenu
	{
		ToolStripMenuItem root;
		List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();

		public SingleSelectionMenu(ToolStripMenuItem root)
		{
			this.root = root;
			root.DropDown = new ToolStripDropDown();
		}

		public ToolStripMenuItem append(string name, Action<ToolStripMenuItem> onclick)
		{
			ToolStripMenuItem it = new ToolStripMenuItem(name);
			root.DropDown.Items.Add(it);
			it.Click += delegate(object sender, EventArgs e)
			{
				onclick(it);
				check(it);
			};
			return it;
		}

		public void check(ToolStripMenuItem it)
		{
			foreach (ToolStripMenuItem i in items)
			{
				i.Checked = i == it;
			}
		}
	}
}
