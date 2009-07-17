using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;
using System.IO;

namespace BuilderLib
{
	public class BuildEnviroment
	{
		internal BuildEnviroment Parent
		{
			get;
			private set;
		}

		Dictionary<string, Variable> variables = new Dictionary<string, Variable>();
		internal static BuildEnviroment Read(System.Xml.XmlElement root, AutoVarData avd, BuildEnviroment parent)
		{
			BuildEnviroment env = new BuildEnviroment();
			env.Parent = parent;

			env.readVariables(root, avd);

			return env;
		}

		private void readVariables(System.Xml.XmlElement root, AutoVarData avd)
		{
			foreach (var x in root.ElementsNamed("var"))
			{
				add(x.GetAttributeString("name"), x.GetFirstText());
			}

			foreach (var x in root.ElementsNamed("autovar"))
			{
				add(avd, x.GetAttributeString("type").Trim().ToLower(), x);
			}
		}

		private void add(AutoVarData avd, string type, System.Xml.XmlElement x)
		{
			if (type == "projectfolder") add(x.GetAttributeString("target"), avd.ProjectFolder);
			else if (type == "installfolder") add(x.GetAttributeString("target"), avd.InstallFolder);
			else if (type == "enviroment") add(x.GetAttributeString("target"), Environment.GetEnvironmentVariable(x.GetFirstText()));
			else if (type == "version") addVersion(avd, x.GetAttributeString("for"), x.GetAttributeString("version").ToLower());
			else if (type == "external") add( avd.externals.get(x.GetAttributeString("ui"), x.GetAttributeString("target"), x.GetAttributeString("description")));
			else throw new Exception("unknwon autovar " + type);
		}

		private void addVersion(AutoVarData avd, string app, string version)
		{
			string file = avd.getFile(app, "ver");
			var x = Xml.Open(Xml.FromFile(file), "versions");
			bool added = false;
			List<string> foundVersions = new List<string>();

			readVariables(x, avd);

			foreach (var e in x.ElementsNamed("for"))
			{
				string ver = e.GetAttributeString("version").ToLower();
				foundVersions.Add(ver);
				if (ver == version)
				{
					readVariables(e, avd);
					added = true;
				}
			}

			if (added == false)
			{
				throw new Exception("Didnt find version " + version + " in " + file + " found " + new StringListCombiner(", ", " and ", "none").combine(foundVersions) );
			}
		}

		private void add(string aname, string value)
		{
			string name = aname.Trim().ToUpper();
			if (variables.ContainsKey(name)) throw new Exception("Already contains " + name);
			DefinedVariable var = new DefinedVariable(name, value);
			add(var);
		}

		void add(Variable var)
		{
			variables.Add(var.Name.ToUpper(), var);
		}

		public string resolve(string s)
		{
			return Strings.ExpandEnviroment(s, x => this[x]);
		}

		public string resolve(string Value, string name)
		{
			return Strings.ExpandEnviroment(Value, x => x == name ? Parent[x] : this[x]);
		}

		internal string this[string x]
		{
			get
			{
				if (variables.ContainsKey(x)) return variables[x].getResolved(this);
				else if (Parent != null) return Parent[x];
				else throw new Exception("Missing variable " + x);
			}
		}

		Dictionary<string, string> AllVariables()
		{
			Dictionary<string, string> vars = new Dictionary<string, string>();

			foreach (var v in variables)
			{
				vars.Add(v.Key, v.Value.Value);
			}

			if (Parent != null)
			{
				foreach (var v in Parent.AllVariables())
				{
					if (false == vars.ContainsKey(v.Key))
					{
						vars.Add(v.Key, v.Value);
					}
				}
			}

			return vars;
		}

		private void Copy(System.Collections.Specialized.StringDictionary dst, Dictionary<string, string> src)
		{
			dst.Clear();
			List<string> missing = new List<string>();
			foreach (var v in src)
			{
				if (string.IsNullOrEmpty(v.Value)) missing.Add(v.Key);
				else dst[v.Key.ToUpper()] = resolve(v.Value);
			}

			if (missing.Count != 0) throw new Exception("Missing " + new StringListCombiner(", ", " and ", "none").combine(missing));
		}

		internal System.Diagnostics.Process run(string c)
		{
			string command = resolve(c);
			System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
			var foobar = AllVariables();
			Copy(start.EnvironmentVariables, foobar);

			start.CreateNoWindow = true;
			start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

			string name = command.Trim().Split(' ')[0];
			start.FileName = name;

			if (File.Exists(start.FileName) == false)
			{
				// get a fullpath
				string pathEnv = start.EnvironmentVariables["PATH"];
				if (string.IsNullOrEmpty(pathEnv)) throw new Exception("Missing path enviroment variable");
				foreach (string folder in pathEnv.Split(";".ToCharArray()))
				{
					string p = Path.Combine(folder, name);
					if (File.Exists(p))
					{
						start.FileName = p;
						break;
					}
				}
			}

			start.Arguments = command.Trim().Remove(0, name.Length); //"/C " + command;
			start.UseShellExecute = false;
			start.RedirectStandardError = true;
			start.RedirectStandardOutput = true;
			try
			{
				return System.Diagnostics.Process.Start(start);
			}
			catch (Exception e)
			{
				throw new Exception("for command " + start.FileName + ", called with " + start.Arguments + "; path is " + Environment.NewLine + start.EnvironmentVariables["PATH"], e);
			}
		}
	}
}
