using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SlnDeps
{
	class Logic
	{
		public static void toGraphviz(string source, string target, string format, List<string> exclude)
		{
			if (target.Trim() == "" || target.Trim() == "?") target = Path.ChangeExtension(source, null);
			if (Directory.Exists(target)) target = Path.Combine(target, Path.GetFileNameWithoutExtension(source));
			if (format.Trim() == "" || format.Trim() == "?") format = "svg";

			logic(source, exclude, target, format);
		}

		public static IEnumerable<string> GetProjects(string source)
		{
			Solution s = new Solution(source);
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
		}

		public class Solution
		{
			public Dictionary<string, Project> projects = new Dictionary<string, Project>();
			private string Name;
			private List<string> includes;

			public Solution(string slnpath, List<string>exclude)
			{
				setup(slnpath, exclude);
			}

			public Solution(string slnpath)
			{
				setup(slnpath, new List<string>());
			}

			private void setup(string slnpath, List<string> exclude)
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
				}

				foreach (var p in projects)
				{
					p.Value.resolve(projects);
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
					lines.Add("digraph " + Name + " {");

					lines.Add("/* projects */");
					lines.Add("");

					foreach (var p in projects)
					{
						if (Exclude(p.Value.Name)) continue;
						lines.Add(" " + p.Value.Name + " [label=\"" + p.Value.DisplayName + "\"]" + ";");
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
							lines.Add(" " + s.Name + " -> " + p.Value.Name + ";");
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
		}

		private static void logic(string solutionFilePath, List<string> exlude, string targetFile, string format)
		{
			Solution s = new Solution(solutionFilePath, exlude);
			s.writeGraphviz(targetFile);
			graphviz(targetFile, format);
		}

		private static void graphviz(string targetFile, string format)
		{
			var s = new ProcessStartInfo("dot", "-T" + format + " -O " + targetFile);
			var p = Process.Start(s);
			p.WaitForExit();
		}
	}
}