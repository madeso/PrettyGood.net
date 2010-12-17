using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HeaderParser
{
	public class Logic
	{
		public enum MissingFileAction
		{
			Throw, Ignore, NoParse
		}

		public static Node Parse(Graph g, PathList pl, string file, Func<string, MissingFileAction> missingFile)
		{
			var wasCreated = g.has(file);
			var me = g.create(file, pl.simplify(file));
			if (wasCreated==false && Path.IsPathRooted(file) && pl.exclude(file) == false)
			{
				var li = File.ReadAllLines(file);
				foreach (var a in li)
				{
					var l = a.Trim();
					if (l.StartsWith("#include"))
					{
						var f = l.Substring("#include".Length).Trim();
						var i = f.IndexOf("//");
						if (i > 0) f = f.Substring(0, i).Trim();
						var c = f[0];
						if (c != '"' && c != '<') continue;
						f = f.Substring(1, f.Length-2);
						var path = pl.resolve(f, c == '"', Path.GetDirectoryName(file));
						if (path == null)
						{
							switch (missingFile(file))
							{
								case MissingFileAction.Ignore:
									break;
								case MissingFileAction.NoParse:
									path = file;
									break;
								case MissingFileAction.Throw:
									throw new Exception("Missing file " + file);
									break;
							}
						}

						var child = Parse(g, pl, path, missingFile);
						if (child != null)
						{
							g.link(me, child);
						}
					}
				}
			}
			return me;
		}
	}
}
