using System;
using System.Collections.Generic;
using System.Text;

namespace PrettyGood.Util
{
	public static class Delegates
	{
		public delegate void VoidVoid();
		public delegate void Void<T>(T t);
	}
}
