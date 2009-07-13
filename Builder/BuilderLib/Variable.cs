using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;

namespace BuilderLib
{
	public abstract class Variable
	{
		public string getResolved(BuildEnviroment enviroment)
		{
			return verify( enviroment.resolve(Value, Name) );
		}

		public abstract string Name
		{
			get;
		}

		public abstract string Value
		{
			get;
		}

		protected abstract string verify(string s);
	}
}
