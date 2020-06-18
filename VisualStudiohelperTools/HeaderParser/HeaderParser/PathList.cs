using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HeaderParser
{
	public class PathList
	{
		List<string> paths = new List<string>();
		List<string> excludes = new List<string>();

		public PathList(string[] a, string[] x)
		{
			paths.AddRange(a);
			excludes.AddRange(x);
		}

		public bool exclude(string p)
		{
			foreach (var x in excludes)
			{
				if(string.IsNullOrEmpty(x)) continue;
				if (p.StartsWith(x)) return true;
			}
			return false;
		}

		internal string simplify(string file)
		{
			foreach (var p in paths)
			{
				if (file.StartsWith(p)) return file.Substring(p.Length).Replace('\\', '/');
			}
			return file.Replace('\\', '/');
		}

		internal string resolve(string name, bool useLocal, string local)
		{
			if (Path.IsPathRooted(name)) return name;
			if (useLocal)
			{
				var suggested = Path.Combine(local, name);
				if (File.Exists(suggested)) return suggested;
			}

			foreach (var p in paths)
			{
				var suggested = Path.Combine(p, name);
				if (File.Exists(suggested)) return suggested;
			}

			return null;
		}
	}
}
