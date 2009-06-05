using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrettyGood.Util
{
	public class Pattern
	{
		public Pattern(string patt)
		{
			int i = 0;
			node = Parse(ref i, patt);
			if (i != patt.Length) throw new Exception("format error");
		}

		private static Node Parse(ref int i, string patt)
		{
			Parser p = new Parser();
			p.action(ref i, patt);
			return p.node;
		}

		private class Parser
		{
			bool space = false;
			public CombinedNode node = new CombinedNode();

			StringBuilder b = new StringBuilder();

			public void action(ref int i, string patt)
			{
				while (i < patt.Length)
				{
					char c = patt[i];
					++i;

					if (c == ')')
					{
						doAppend();
						return;
					}
					else if (c == '(')
					{
						doAppend();
						node.add(Parse(ref i, patt));
					}
					else if (c == ' ')
					{
						doAppend();
						space = true;
					}
					else
					{
						b.Append(c);
						space = false;
					}
				}
				doAppend();
			}

			private void doAppend()
			{
				if (false == space)
				{
					string s = b.ToString();
					if (false == string.IsNullOrEmpty(s))
					{
						node.add(new StringNode(s));
					}
					b = new StringBuilder();
				}
			}
		}

		public string resolve(Func<string, string> provider)
		{
			return node.resolve(provider);
		}

		internal abstract class Node
		{
			internal abstract string resolve(Func<string, string> provider);
		}

		Node node;

		internal class CombinedNode : Node
		{
			List<Node> nodes = new List<Node>();
			internal  void add(Node n)
			{
				nodes.Add(n);
			}
			internal  override string resolve(Func<string, string> provider)
			{
				List<string> strings = new List<string>();
				foreach (Node n in nodes)
				{
					strings.Add(n.resolve(provider));
				}
				return Eval(strings, provider);
			}

			public override string ToString()
			{
				return "(" + new StringSeperator(" ").Append(nodes.ToArray()).ToString() + ")";
			}
		}

		internal class StringNode : Node
		{
			readonly string str;
			internal StringNode(string s)
			{
				str = s;
			}
			internal override string resolve(Func<string, string> provider)
			{
				return str;
			}

			public override string ToString()
			{
				return str;
			}
		}

		internal static string Eval(List<string> strings, Func<string, string> provider)
		{
			string cmd = strings[0].ToLower();
			if (cmd == "eval")
			{
				return provider(strings[1].ToLower());
			}
			else if( cmd == "empty?" )
			{
				if (string.IsNullOrEmpty(strings[1]))
				{
					return strings[2];
				}
				else
				{
					return strings[3];
				}
			}
			else if (cmd == "orempty")
			{
				if (string.IsNullOrEmpty(strings[1]))
				{
					return strings[2];
				}
				else
				{
					return strings[1];
				}
			}
			else return null;
		}
	}
}
