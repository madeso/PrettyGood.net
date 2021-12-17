using System.Collections.Generic;
using System.Linq;

namespace TextLines
{
	internal static class TextLinesApp
	{
		public static string[] GetLines(string data)
		{
			return data.Split('\n');
		}

		public static string ToText(IEnumerable<string> data)
		{
			return string.Join("\n", data);
		}



		public static IEnumerable<string> Trim(IEnumerable<string> p)
		{
			foreach (var s in p)
			{
				yield return s.Trim();
			}
		}
		public static string Trim(string p) => ToText(Trim(GetLines(p)));



		public static IEnumerable<string> RemoveEmpty(IEnumerable<string> p)
		{
			foreach (var s in p)
			{
				if (s.Length != 0) yield return s;
			}
		}
		public static string RemoveEmpty(string p) => ToText(RemoveEmpty(GetLines(p)));



		public static IEnumerable<string> ExcludeContaining(IEnumerable<string> p, string m)
		{
			foreach (var s in p)
			{
				if (s.Contains(m))
				{
					// pass
				}
				else
				{
					yield return s;
				}
			}
		}
		public static string ExcludeContaining(string p, string m) => ToText(ExcludeContaining(GetLines(p), m));



		public static IEnumerable<string> Unique(IEnumerable<string> s)
		{
			Dictionary<string, string> ss = new Dictionary<string, string>();
			foreach (var v in s)
			{
				if (ss.ContainsKey(v))
				{
				}
				else
				{
					yield return v;
					ss.Add(v, v);
				}
			}
		}
		public static string Unique(string p) => ToText(Unique(GetLines(p)));


		public static IEnumerable<string> Sort(IEnumerable<string> p)
		{
			List<string> ss = new List<string>();
			foreach (var s in p)
			{
				ss.Add(s);
			}
			ss.Sort();
			return ss;
		}
		public static string Sort(string p) => ToText(Sort(GetLines(p)));
	}
}