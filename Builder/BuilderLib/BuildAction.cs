using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;
using System.Xml;

namespace BuilderLib
{
	public class BuildAction
	{
		BuildEnviroment enviroment;

		public readonly string type;
		public readonly string context;
		public readonly string description;
		public readonly string baseAction;

		public BuildAction(BuildEnviroment env, string Type, string Context, string description, string baseAction)
		{
			this.enviroment = env;
			this.type = Type;
			this.context = Context;
			this.description = description;
			this.baseAction = baseAction;
		}

		internal static IEnumerable<BuildAction> Read(XmlElement root, AutoVarData avd, BuildEnviroment parent)
		{
			foreach (var e in Xml.ElementsNamed(root, "action"))
			{
				BuildAction action = new BuildAction(BuildEnviroment.Read(e, avd, parent), Xml.GetAttributeString(e,"type"), Xml.GetAttributeString(e, "context"), Xml.GetAttributeString(e, "description"), Xml.GetAttributeString(e, "base") );
				yield return action;
			}
		}

		public void execute()
		{
			BaseAction ba = BaseAction.Load(baseAction, enviroment);
			ba.execute(enviroment);
		}
	}
}
