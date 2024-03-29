﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Xml;

namespace SlnDeps
{
	class Logic
	{
		public static void toGraphviz(string source, string target, string format, List<string> exclude, bool simplify, string style, bool reverseArrows)
		{
			if (target.Trim() == "" || target.Trim() == "?") target = Path.ChangeExtension(source, null);
			if (Directory.Exists(target)) target = Path.Combine(target, Path.GetFileNameWithoutExtension(source));
			if (format.Trim() == "" || format.Trim() == "?") format = "svg";

			logic(source, exclude, target, format, simplify, style, reverseArrows);
		}

		internal static string getFile(string source, string target, string format)
		{
			if (target.Trim() == "" || target.Trim() == "?") target = Path.ChangeExtension(source, null);
			if (Directory.Exists(target)) target = Path.Combine(target, Path.GetFileNameWithoutExtension(source));
			if (format.Trim() == "" || format.Trim() == "?") format = "svg";

			var f = Path.ChangeExtension(target, format);
			return f;
		}

		public static IEnumerable<string> GetProjects(string source)
		{
			Solution s = new Solution(source, new List<string>(), false, false);
			foreach (var p in s.projects)
			{
				yield return p.Value.Name;
			}
		}

		public class Project
		{
			public Solution Solution;
			public string DisplayName;
			public string Name
			{
				get
				{
					return DisplayName.Replace('-', '_');
				}
				set
				{
					DisplayName = value;
				}
			}
			public string Path;
			public string Id;

			public Build Type = Build.Unknown;

			public enum Build
			{
				Unknown, Application, Static, Shared
			}

			public override string ToString()
			{
				return Name;
			}

			public List<string> sdeps = new List<string>();
			public List<Project> deps = new List<Project>();

			internal void resolve(Dictionary<string, Project> projects)
			{
				foreach (var s in sdeps)
				{
					deps.Add(projects[s]);
				}
			}

			internal void loadInformation()
			{
				var p = Gen(Path);
				if (File.Exists(p) == false) return;
				XmlDocument doc = new XmlDocument();
				doc.Load(p);
				var l = new List<string>();
				foreach (XmlElement n in doc.SelectNodes("VisualStudioProject/Configurations/Configuration[@ConfigurationType]"))
				{
					var v = n.Attributes["ConfigurationType"].Value;
					if( l.Contains(v) == false ) l.Add(v);
				}
				Type = Build.Unknown;
				if (l.Count != 0)
				{
					var suggestedType = l[0];
					if (suggestedType == "2") Type = Build.Shared;
					else if (suggestedType == "4") Type = Build.Static;
					else if (suggestedType == "1") Type = Build.Application;
				}
			}

			private static string Gen(string pa)
			{
				var p = pa;
				if (File.Exists(p)) return p;
				p = pa + ".vcxproj";
				if (File.Exists(p)) return p;
				return "";
			}
		}

		public class Solution
		{
			public Dictionary<string, Project> projects = new Dictionary<string, Project>();
			private string Name;
			private List<string> includes;
			private bool reverseArrows = false;

			public Solution(string slnpath, List<string>exclude, bool simplify, bool reverseArrows)
			{
				this.reverseArrows = reverseArrows;
				setup(slnpath, exclude, simplify);
			}

			private void setup(string slnpath, List<string> exclude, bool dosimplify)
			{
				includes = exclude;
				Name = Path.GetFileNameWithoutExtension(slnpath);
				var lines = new List<string>(File.ReadAllLines(slnpath));
				//if (IsValidFile(lines) ==false) throw new Exception("Invalid sln file");

				Project currentProject = null;
				Project depProject = null;

				foreach (var line in lines)
				{
					if (line.StartsWith("Project"))
					{
						var eq = line.IndexOf('=');
						var data = line.Substring(eq + 1).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
						var name = data[0].Trim().Trim('"').Trim();
						var relativepath = data[1].Trim().Trim('"').Trim();
						var id = data[2].Trim().Trim('"').Trim();

						currentProject = new Project { Solution = this, Name = name, Path = Path.Combine(Path.GetDirectoryName(slnpath), relativepath), Id = id };
						projects.Add(currentProject.Id, currentProject);
					}
					else if (line == "EndProject")
					{
						currentProject = null;
						depProject = null;
					}
					else if (line.Trim() == "ProjectSection(ProjectDependencies) = postProject")
					{
						depProject = currentProject;
					}
					else if (depProject != null && line.Trim().StartsWith("{"))
					{
						var id = line.Split("=".ToCharArray())[0].Trim();
						depProject.sdeps.Add(id);
					}
					else
					{
						Console.Write("");
					}
				}

				if (dosimplify) simplify();

				foreach (var p in projects)
				{
					p.Value.resolve(projects);
					p.Value.loadInformation();
				}
			}

			private static bool IsValidFile(List<string> lines)
			{
				foreach (string line in lines)
				{
					if (line == "Microsoft Visual Studio Solution File, Format Version 10.00") return true;
				}
				return false;
			}

			private List<string> Graphviz
			{
				get
				{
					List<string> lines = new List<string>();
					lines.Add("digraph " + Name.Replace("-", "_") + " {");

					lines.Add("/* projects */");
					lines.Add("");

					foreach (var p in projects)
					{
						var pro = p.Value;
						if (Exclude(pro.Name)) continue;

						string decoration = "label=\"" + pro.DisplayName + "\"";

						string shape = "plaintext";

						if (pro.Type == Project.Build.Application)
						{
							shape = "folder";
						}
						else if (pro.Type == Project.Build.Shared)
						{
							shape = "ellipse";
						}
						else if (pro.Type == Project.Build.Static)
						{
							shape = "component";
						}

						decoration += ", shape=" + shape;

						lines.Add(" " + pro.Name + " [" + decoration + "]" + ";");
					}

					lines.Add("");
					lines.Add("/* dependencies */");
					lines.Add("");

					bool addspace = false;

					foreach (var p in projects)
					{
						if (p.Value.deps.Count == 0) continue;
						if (Exclude(p.Value.Name)) continue;
						if (addspace) lines.Add("");
						else addspace = true;
						foreach (var s in p.Value.deps)
						{
							if (Exclude(s.Name)) continue;
							if( reverseArrows )
								lines.Add(" " + s.Name + " -> " + p.Value.Name + ";");
							else
								lines.Add(" " + p.Value.Name + " -> " + s.Name + ";");
						}
					}

					lines.Add("}");
					return lines;
				}
			}

			bool Exclude(string p)
			{
				if (includes != null)
				{
					foreach (var s in includes)
					{
						if (s.ToLower().Trim() == p.ToLower().Trim()) return false;
					}
				}
				return true;
			}

			internal void writeGraphviz(string targetFile)
			{
				File.WriteAllLines(targetFile, Graphviz.ToArray());
			}

			private void simplify()
			{
				foreach (var pe in projects)
				{
					simplify(pe.Value);
				}
			}

			private void simplify(Project p)
			{
				List<string> deps = new List<string>();
				foreach (var d in p.sdeps)
				{
					if (hasDependency(p, d, false) == false)
					{
						deps.Add(d);
					}
				}
				p.sdeps = deps;
			}

			private bool hasDependency(Project p, string sd, bool self)
			{
				foreach (var d in p.sdeps)
				{
					if (self && d == sd) return true;
					if (hasDependency(projects[d], sd, true)) return true;
				}
				return false;
			}
		}

		private static void logic(string solutionFilePath, List<string> exlude, string targetFile, string format, bool simplify, string style, bool reverseArrows)
		{
			Solution s = new Solution(solutionFilePath, exlude, simplify, reverseArrows);
			s.writeGraphviz(targetFile);
			graphviz(targetFile, format, style);
		}

		private static void graphviz(string targetFile, string format, string style)
		{
			var f = style;
			if (f.Length != 0) f = " -K" + f;
			var s = new ProcessStartInfo("dot", "-T" + format + f + " -O " + targetFile);
			var p = Process.Start(s);
			p.WaitForExit();
		}
	}
}