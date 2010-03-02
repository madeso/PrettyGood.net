using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
	public abstract class Module
	{
		private List<Module> modules = new List<Module>();
		private List<Str> strings = new List<Str>();

		public void add(Str s)
		{
			strings.Add(s);
		}
		public void add(Module m)
		{
			modules.Add(m);
		}

		public IEnumerable<Module> Modules
		{
			get
			{
				foreach (Module m in modules)
				{
					yield return m;
				}
			}
		}

		public IEnumerable<Str> Strings
		{
			get
			{
				foreach (Str s in strings)
				{
					yield return s;
				}
			}
		}

		public void setup(string name, Module mod)
		{
			if (mod != null)
			{
				mod.add(this);
			}
			Name = name;
		}

		public void debug(string s)
		{
			foreach (Str ls in Strings)
			{
				ls.Value = s;
			}
			foreach (Module m in Modules)
			{
				m.debug(s);
			}
		}
		public void setDefault()
		{
			foreach (Str ls in Strings)
			{
				ls.setDefault();
			}
			foreach (Module m in Modules)
			{
				m.setDefault();
			}
		}

		public String Name;
	}
}
