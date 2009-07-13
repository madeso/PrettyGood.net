using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuilderLib;

namespace BuilderLocal
{
	public partial class UserVariables : Form
	{
		ExternalVariableList vars;

		class Data
		{
			public string Name;
			public string Description;
			public string Value;
		}

		public UserVariables(ExternalVariableList vars)
		{
			InitializeComponent();
			
			this.vars = vars;

			List<Data> datas = new List<Data>();

			foreach (var v in vars.Variables)
			{
				datas.Add(new Data { Name=v.name, Description=v.description, Value=v.value });
			}

			dVariables.SetObjects(datas);
		}

		private void dOK_Click(object sender, EventArgs e)
		{
			foreach (Data d in dVariables.Objects)
			{
				vars.set(d.Name, d.Value);
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void dCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
