using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextLines
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		private void dUnique_Click(object sender, EventArgs e)
		{
			Lines = Unique(Lines);
		}

		IEnumerable<string> Lines
		{
			get
			{
				return dInput.Lines;
			}
			set
			{
				List<string> s = new List<string>(value);
				dInput.Lines = s.ToArray();
			}
		}

		private IEnumerable<string> Unique(IEnumerable<string> s)
		{
			Dictionary<string, string> ss = new Dictionary<string,string>();
			foreach (var v in s)
			{
				if (ss.ContainsKey(v))
				{
				}
				else
				{
					yield return v;
					ss.Add(v, v);
				}
			}
		}

		private void dTrim_Click(object sender, EventArgs e)
		{
			Lines = Trim(Lines);
		}

		private IEnumerable<string> Trim(IEnumerable<string> p)
		{
			foreach (var s in p)
			{
				yield return s.Trim();
			}
		}

		private void dRemoveEmpty_Click(object sender, EventArgs e)
		{
			Lines = RemoveEmpty(Lines);
		}

		private IEnumerable<string> RemoveEmpty(IEnumerable<string> p)
		{
			foreach (var s in p)
			{
				if (s.Length != 0) yield return s;
			}
		}

		private void dSort_Click(object sender, EventArgs e)
		{
			Lines = Sort(Lines);
		}

		private IEnumerable<string> Sort(IEnumerable<string> p)
		{
			List<string> ss = new List<string>();
			foreach (var s in p)
			{
				ss.Add(s);
			}
			ss.Sort();
			return ss;
		}
	}
}
