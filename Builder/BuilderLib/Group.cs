using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;
using System.Xml;
using System.IO;

namespace BuilderLib
{
	public class Group
	{
		public readonly string Name;

		public Group(string name)
		{
			Name = name;
		}

		List<BuildAction> actions;
		List<Group> groups;
		BuildEnviroment enviroment;

		public static Group Load(string file, ExternalVariableList ev)
		{
			XmlElement root = Xml.Open(Xml.FromFile(file), "project");
			Group p = new Group( Xml.GetAttributeString(root, "name") );

			AutoVarData avd = new AutoVarData();
			avd.externals = ev;
			avd.ProjectFolder = new FileInfo(file).Directory.FullName;
			Read(root, p, avd, null);

			return p;
		}

		private static void Read(XmlElement root, Group p, AutoVarData avd, BuildEnviroment parent)
		{
			p.enviroment = BuildEnviroment.Read(root, avd, parent);
			p.actions = new List<BuildAction>(BuildAction.Read(root, avd, p.enviroment));
			p.groups = new List<Group>(Group.Read(root, avd, p.enviroment));
		}

		public IEnumerable<BuildAction> Actions
		{
			get
			{
				foreach (var a in actions) yield return a;
				foreach (var g in groups) foreach (var a in g.Actions) yield return a;
			}
		}

		private static IEnumerable<Group> Read(XmlElement root, AutoVarData avd, BuildEnviroment parent)
		{
			foreach (var x in root.ElementsNamed("group"))
			{
				Group g = new Group("");
				Group.Read(x, g, avd, parent);
				yield return g;
			}
		}
	}
}
