using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SlnDeps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                theMain(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void theMain(string[] args)
        {
            string source = "";
            string target = "";
            string format = "";
            string exclude = "";

            if (args.Length > 0) source = args[0];
            if (args.Length > 1) target = args[1];
            if (args.Length > 2) format = args[2];
            if (args.Length > 3) exclude = args[3];

            if (args.Length == 0)
            {
                Console.WriteLine(" SlnDeps ");
                Console.WriteLine(" - generates a graphviz dependency from a vs2005 or vs2008 and runs graphviz's dot on it");
                Console.WriteLine(" - if dot is not in your path it will fail");
                Console.WriteLine(" - usage: SlnDeps.exe my-solution.sln target-dir-or-file dot-format(svg, png etc) semi-colon-seperated-list-of-projects-to-exclude");
                return;
            }

            if (target.Trim() == "" || target.Trim() == "?") target = Path.ChangeExtension(source, null);
            if (Directory.Exists(target)) target = Path.Combine(target, Path.GetFileNameWithoutExtension(source));
            if (format.Trim() == "" || format.Trim() == "?") format = "svg";

            Run(source, exclude, target, format);
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
            private List<string> excludes;

            public Solution(string slnpath, IEnumerable<string> exclude)
            {
                excludes = new List<string>(exclude);
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
                foreach (var s in excludes)
                {
                    if (s.ToLower().Trim() == p.ToLower().Trim()) return true;
                }
                return false;
            }

            internal void writeGraphviz(string targetFile)
            {
                File.WriteAllLines(targetFile, Graphviz.ToArray());
            }
        }

        private static void Run(string solutionFilePath, string exlude, string targetFile, string format)
        {
            Solution s = new Solution(solutionFilePath, exlude.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
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