using System;
using System.Collections.Generic;
using System.Linq;
using PrettyGood.Util;
using System.Text;

namespace BuilderLib
{
	public class DefinedVariable : Variable
	{
		private string name;
		private string value;

		public DefinedVariable(string name, string value)
		{
			this.name = name;
			this.value = value;
		}

		public override string Name
		{
			get { return name; }
		}

		public override string Value
		{
			get { return value; }
		}

		protected override string verify(string s)
		{
			return s;
		}
	}
}
