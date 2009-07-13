using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PrettyGood.Util;
using System.IO;

namespace BuilderLib
{
	public class BaseAction
	{
		List<string> commands = new List<string>();

		public void add(IEnumerable<string> cmd)
		{
			commands.AddRange(cmd);
		}

		internal void execute(BuildEnviroment enviroment)
		{
			foreach (var c in commands)
			{
				var v = enviroment.run(c);
				v.WaitForExit();
				if (v.ExitCode != 0)
				{
					throw new Exception("failed to run cmd");
				}
				string err = v.StandardError.ReadToEnd();
				string msg = v.StandardOutput.ReadToEnd();
			}
		}

		public static BaseAction Load(string name, BuildEnviroment env)
		{
			string file = Path.Combine(AutoVarData.GetInstallFolder(), Path.ChangeExtension(name, "act"));

			var root = Xml.Open(Xml.FromFile(file), "action");
			BaseAction act = new BaseAction();
			act.add(CreateMatchingActions(root, env));
			if (act.commands.Count == 0) throw new Exception("Missing commands for " + name);
			return act;
		}

		private static IEnumerable<string> CreateActions(XmlElement root, BuildEnviroment e)
		{
			foreach (var x in root.ElementsNamed("action"))
			{
				yield return x.GetFirstText();
			}
		}

		private static IEnumerable<string> CreateMatchingActions(XmlElement root, BuildEnviroment e)
		{
			foreach (var x in root.ElementsNamed("test"))
			{
				string action = x.GetAttributeString("action");
				string lhs = x.GetAttributeString("lhs");
				string rhs = x.GetAttributeString("rhs");

				string lhsValue = e.resolve(lhs);
				string rhsValue = e.resolve(rhs);

				bool ok = false;

				if (action == "=")
				{
					if (lhsValue == rhsValue) ok = true;
				}
				else throw new Exception("unsupported test action " + action);

				if (ok)
				{
					foreach (var s in CreateActions(x, e)) yield return s;
				}
			}
		}
	}
}
