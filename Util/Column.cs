using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGood.Util
{
	public class Column
	{
		string title;
		Pattern displayPattern;
		Pattern sortPattern = null;

		public Column(string name)
		{
			this.title = name;
			displayPattern = Pattern.Compile("%" + name + "%");
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
			if (header != null) header.Text = title;
		}

		public Pattern Display
		{
			get
			{
				return displayPattern;
			}
		}

		public Pattern Sort
		{
			get
			{
				if (sortPattern == null) return displayPattern;
				else return sortPattern;
			}
		}
	}
}
