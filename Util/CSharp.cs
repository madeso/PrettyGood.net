using System;
using System.Collections.Generic;
using System.Text;

namespace PrettyGood.Util
{
	public static class CSharp
	{
		public static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		public static IEnumerable<T> Enumerate<T>(params T[] args)
		{
			foreach (T a in args)
			{
				yield return a;
			}
		}

		public static bool IsEmpty<T>(IEnumerable<T> e)
		{
			foreach (T a in e)
			{
				return false;
			}
			return true;
		}

		public static IEnumerable<K> Keys<K, V>(IEnumerable<KeyValuePair<K, V>> f)
		{
			foreach (KeyValuePair<K, V> i in f)
			{
				yield return i.Key;
			}
		}

		public static IEnumerable<Return> Convert<Return, Argument>(IEnumerable<Argument> e, Func<Argument, Return> c)
		{
			foreach (Argument a in e)
			{
				yield return c(a);
			}
		}
	}
}
