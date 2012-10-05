using System;
using System.Collections.Generic;
using System.Text;

namespace PrettyGood.Localization
{
	[AttributeUsage(AttributeTargets.Field)]
	public class Args : Attribute
	{
		public readonly string[] Names;

		public Args(params string[] names)
		{
			Names = names;
		}
	}
}
