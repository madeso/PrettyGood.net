using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WindowsFormsApplication1
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void dRun_Click(object sender, EventArgs e)
		{
			if (dFolder.ShowDialog() != DialogResult.OK) return;
			var d = dFolder.SelectedPath;
			var r = doit(d);
			dStatus.Text = r;
		}

		private string doit(string d)
		{
			int c = 0;
			int p = 0;
			foreach (var f in Directory.GetFiles(d, "*.vcxproj", SearchOption.AllDirectories))
			{
				++p;
				c += Fix(f);
			}

			return string.Format("{0} fixes in {1} projects", c, p);
		}

		private int Fix(string f)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(f);
			var proj = doc["Project"];

			int count = 0;

			var ig = proj["ItemGroup"];
			count += Remove(ig, "ProjectConfiguration", "Include");
			count += Remove(proj, "PropertyGroup", "Condition");
			doc.Save(f);
			return count;
		}

		private static int Remove(XmlElement proj, string nodename, string attribute)
		{
			List<XmlElement> templates = new List<XmlElement>();

			foreach (var o in proj.ChildNodes)
			{
				var n = o as XmlElement;
				if (n != null && n.Name == nodename)
				{
					var a = n.Attributes[attribute];
					if (a != null && a.Value.Contains("Template|"))
					{
						templates.Add(n);
					}
				}
			}

			foreach (var t in templates)
			{
				proj.RemoveChild(t);
			}

			return templates.Count;
		}
	}
}
