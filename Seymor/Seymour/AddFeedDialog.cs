﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seymour
{
	public partial class AddFeedDialog : Form
	{
		public AddFeedDialog()
		{
			InitializeComponent();
		}

		public string Url
		{
			get
			{
				return dFeedUrl.Text;
			}
		}

		private void AddFeedDialog_Load(object sender, EventArgs e)
		{
			dFeedUrl.SelectAll();
			dFeedUrl.Focus();
			this.ActiveControl = dFeedUrl;
		}

		private void dOk_Click(object sender, EventArgs e)
		{
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
