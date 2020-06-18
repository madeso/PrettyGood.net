using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RegView
{
	public class IniFile
	{
		public class Category
		{
			public Dictionary<string, string> keys = new Dictionary<string, string>();
		}

		public IniFile(string path)
		{
			string current = "";
			Category c = null;

			foreach (string line in File.ReadAllLines(path))
			{
				string sline = line.Trim();
				if (sline.Length == 0) continue;
				if (sline[0] == '[')
				{
					current = sline;
					c = null;
				}
				else
				{
					if (c == null)
					{
						if (categories.ContainsKey(current))
						{
							c = categories[current];
						}
						else
						{
							c = new Category();
							categories.Add(current, c);
						}
					}

					int index = sline.IndexOf('=');
					if (index > 0)
					{
						string name = sline.Substring(0, index).Trim();
						string val = sline.Substring(index + 1).Trim();
						c.keys.Add(name, val);
					}
				}
			}
		}

		public Dictionary<string, Category> categories = new Dictionary<string,Category>();
	}
}
