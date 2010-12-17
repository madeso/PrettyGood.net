using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace HeaderParser
{
	public class Graph
	{
		class Link
		{
			public Node From;
			public Node To;
		}

		Dictionary<string, Node> nodes = new Dictionary<string, Node>();
		List<Link> links = new List<Link>();

		public Node create(string sid, string display)
		{
			if (sid == null) throw new NullReferenceException("sid");
			if (nodes.ContainsKey(sid))
			{
				return nodes[sid];
			}

			id++;
			var n = new Node { Id = string.Format("node{0}", id), Display = display };
			nodes.Add(sid, n);
			return n;
		}

		int id = 0;

		public void link(Node from, Node to)
		{
			if (from == null) throw new NullReferenceException("from");
			if (to == null) throw new NullReferenceException("to");
			links.Add(new Link { From = from, To = to });
		}

		public string[] GraphizSource
		{
			get
			{
				List<string> lines = new List<string>();
				lines.Add("digraph G { ");

				lines.Add("  /* nodes */");
				foreach (var k in nodes)
				{
					var n = k.Value;
					lines.Add(string.Format("  {0} [label=\"{1}\"];", n.Id, n.Display));
				}

				lines.Add("  ");
				lines.Add("  /* links */");
				foreach (var l in links)
				{
					lines.Add(string.Format("  {0} -> {1};", l.From.Id, l.To.Id));
				}

				lines.Add("}");
				return lines.ToArray();
			}
		}

		public void runDot(string file, string format, string layout)
		{
			File.WriteAllLines(file, GraphizSource);
			RunDot(file, format, layout);
		}

		private static void RunDot(string targetFile, string format, string style)
		{
			var f = style;
			if (f.Length != 0) f = " -K" + f;
			var s = new ProcessStartInfo("dot", "-T" + format + f + " -O " + targetFile);
			var p = Process.Start(s);
			p.WaitForExit();
		}

		internal bool has(string file)
		{
			return nodes.ContainsKey(file);
		}
	}
}
