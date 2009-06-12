using System;
using System.Collections.Generic;
using System.Text;

namespace PrettyGood.Util
{
	public static class Strings
	{
		public static IEnumerable<string> RemoveEmpty(IEnumerable<string> p)
		{
			foreach (string s in p)
			{
				if (String.IsNullOrEmpty(s) == false) yield return s;
			}
		}

		public static IEnumerable<string> Sort(IEnumerable<string> strings)
		{
			List<string> str = new List<string>(strings);
			str.Sort();
			return str;
		}

		public static IEnumerable<string> Unique(IEnumerable<string> strings)
		{
			SortedList<string, string> list = new SortedList<string, string>();
			foreach(string s in strings)
			{
				if (list.ContainsKey(s) == false)
				{
					list.Add(s, s);
				}
			}
			foreach (KeyValuePair<string, string> s in list)
			{
				yield return s.Key;
			}
		}

		public static string FirstChars(string s, int count, string extra)
		{
			int l = s.Length;
			if (s.Length + extra.Length > count) return s.Substring(0, count - extra.Length) + extra;
			else return s;
		}

		public static string FirstChars(string s, int count)
		{
			return FirstChars(s, count, "...");
		}

		public static IEnumerable<string> Enumerate(params string[] args)
		{
			return CSharp.Enumerate<string>(args);
		}

		internal static string RemoveFromEndIfFound(string str, string extra)
		{
			if (str.EndsWith(extra)) return str.Substring(0, str.Length - extra.Length);
			else return str;
		}
	}
}
