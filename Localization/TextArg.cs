using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
	public class TextArg : Arg
	{
		public TextArg(string name) : base(name)
		{
		}

		public override string Format(object o)
		{
			return o.ToString();
		}
	}
}
