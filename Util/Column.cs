using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGood.Util
{
	public class Column
	{
		string display;
		Pattern defaultPattern;

		public Column(string name)
		{
			display = name;
			defaultPattern = new Pattern("eval " + name);
		}

		ColumnHeader header;

		public ColumnHeader Header
		{
			get
			{
				return header;
			}
			set
			{
				header = value;
				updateText();
			}
		}

		public void updateText()
		{
			if (header != null) header.Text = display;
		}

		public Pattern Pattern
		{
			get
			{
				return defaultPattern;
			}
		}
	}
}
