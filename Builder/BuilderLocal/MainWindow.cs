using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuilderLib;
using PrettyGood.Util;

namespace BuilderLocal
{
	public partial class MainWindow : Form
	{
		Group root;
		ExternalVariableList variables = new ExternalVariableList();

		public MainWindow()
		{
			InitializeComponent();
			Text = App.ReadableAppName;
		}

		private void dOpen_Click(object sender, EventArgs e)
		{
			try
			{
				if (dOpenProject.ShowDialog() == DialogResult.OK)
				{
					string file = dOpenProject.FileName;
					open(file);
				}
			}
			catch (Exception ex)
			{
				Show(ex);
			}
		}

		public void open(string file)
		{
			root = Group.Load(dOpenProject.FileName, variables);
			updateActions();
			variables.load(ExternalVariableFile);
			Text = file + " - " + App.ReadableAppName;
		}

		private static string ExternalVariableFile
		{
			get
			{
				return FileUtil.GetUserPathFor().file("variables", "var");
			}
		}

		private void Show(Exception ex)
		{
			List<string> data = new List<string>();
			Exception x = ex;
			while (x != null)
			{
				data.Add(x.Message);
				x = x.InnerException;
			}
			data.Reverse();
			MessageBox.Show(new StringListCombiner(Environment.NewLine).combine(data), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void updateActions()
		{
			dActions.SetObjects( root.Actions );
		}

		private void dActions_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				var a = (BuildAction)dActions.SelectedObject;
				run(a);
			}
			catch (Exception ex)
			{
				Show(ex);
			}
		}

		private void run(BuildAction a)
		{
			a.execute();
		}

		private void dVariables_Click(object sender, EventArgs e)
		{
			ShowVariableDialog();
		}

		private bool ShowVariableDialog()
		{
			return new UserVariables(variables).ShowDialog() == DialogResult.OK;
		}
	}
}
