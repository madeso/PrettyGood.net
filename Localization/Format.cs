using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
	public class Format
	{
		Str str = null;
		Dictionary<string, string> values = new Dictionary<string,string>();

		public Format(Str s)
		{
			str = s;
		}

		public Format arg(string name, object v)
		{
			values.Add(name, str.matchArgument(name, v) );
			return this;
		}

		public string String
		{
			get
			{
				// improve parsing
				string temp = str.Value;
				foreach (KeyValuePair<string, string> kvp in values)
				{
					temp = temp.Replace(kvp.Key, kvp.Value);
				}
				return temp;
			}
		}
	}
}
