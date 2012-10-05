using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PrettyGood.Localization
{
	public partial class LanguageEdit : UserControl
	{
		public LanguageEdit()
		{
			InitializeComponent();
			updateGui();
		}

		LanguageBase lang;

		public LanguageBase Language
		{
			get
			{
				return lang;
			}
			set
			{
				lang = value;
				updateGui();
			}
		}

		private void updateGui()
		{
			dOverview.Nodes.Clear();
			Walk(dOverview.Nodes, Language);
			doEnable();
		}

		Str editing = null;

		private void doEnable()
		{
			dOverview.Enabled = Language != null;
			bool e = editing != null;
			dValue.Enabled = e;
			dInformation.Enabled = e;

			setupEditText();
		}

		private void setupEditText()
		{
			if (editing != null)
			{
				dValue.Text = editing.Value;
				dValue.SelectAll();
				dValue.Focus();
				dDefault.Text = editing.Default;
				dInformation.Text = "";
			}
			else
			{
				dValue.Text = "";
				dDefault.Text = "";
				dInformation.Text = "";
			}
		}

		private static void Walk(TreeNodeCollection c, Module mod)
		{
			if (mod == null) return;
			TreeNode n = new TreeNode(mod.Name);
			n.Tag = mod;
			c.Add(n);
			foreach (Module m in mod.Modules)
			{
				Walk(n.Nodes, m);
			}
			foreach (Str ls in mod.Strings)
			{
				TreeNode s = new TreeNode(ls.Name);
				s.Tag = ls;
				ls.bind(s);
				n.Nodes.Add(s);
			}
		}

		private void dValue_TextChanged(object sender, EventArgs e)
		{
			if (editing != null)
			{
				editing.Value = dValue.Text;
			}
		}

		private void dOverview_AfterSelect(object sender, TreeViewEventArgs e)
		{
			editing = null;
			Object o = e.Node.Tag;
			if (o is Str)
			{
				editing = (Str)o;
			}
			doEnable();
		}
	}
}
