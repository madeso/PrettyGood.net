﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegView
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dOpen.ShowDialog() == DialogResult.OK)
			{
				IniFile f = new IniFile(dOpen.FileName);
			}
		}
	}
}
