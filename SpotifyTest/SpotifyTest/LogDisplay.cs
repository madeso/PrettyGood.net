using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGood.SpotifyTest
{
	public partial class LogDisplay : Form
	{
		public LogDisplay(List<string> lines)
		{
			InitializeComponent();
			dLines.Lines = lines.ToArray();
		}

		private void dClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
