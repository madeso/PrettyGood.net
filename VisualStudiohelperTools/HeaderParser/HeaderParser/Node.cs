using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeaderParser
{
	public class Node
	{
		public string Id;
		public string Display;

		public override string ToString()
		{
			return Display;
		}
	}
}
