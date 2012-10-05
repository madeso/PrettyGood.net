using System;
using System.Collections.Generic;
using System.Text;

namespace PrettyGood.Localization
{
	public abstract class Arg
	{
		public readonly string Name;
		protected Arg(string name)
		{
			Name = name;
		}
		public abstract string Format(object o);

		public static Arg Parse(string name)
		{
			return new TextArg(name);
		}
	}
}
