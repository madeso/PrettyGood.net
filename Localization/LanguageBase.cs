using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Reflection;
using PrettyGood.Util;

namespace PrettyGood.Localization
{
	public class LanguageBase : Module
	{
		private static void Setup(Module mod)
		{
			Type t = mod.GetType();
			string basename = t.Name;
			FieldInfo[] fields = t.GetFields();
			foreach (FieldInfo info in fields)
			{
				string name = info.Name;
				object o = info.GetValue(mod);

				if (o is Str)
				{
					Str s = (Str)o;
					s.setup(name, mod, ExtractArguments(info));
				}
				else if (o is Module)
				{
					Module m = (Module) o;
					m.setup(name, mod);
					Setup(m);
				}
			}
		}

		private static List<Arg> ExtractArguments(FieldInfo info)
		{
			List<Arg> arguments;
			object[] args = info.GetCustomAttributes(typeof(Args), false);
			arguments = new List<Arg>();
			foreach (Args arg in args)
			{
				foreach (string name in arg.Names)
				{
					arguments.Add(Arg.Parse(name));
				}
			}
			return arguments;
		}
		private static void Read(Module container, XmlElement language, LanguageReport rep)
		{
			Dictionary<string, XmlElement> map;
			map = Xml.MapElements(language, "string", "id");
			foreach (Str s in container.Strings)
			{
				if (map.ContainsKey(s.Name) == false)
				{
					rep.add("Missing string " + s.Name + " in " + Xml.PathOf(language));
					s.setDefault();
				}
				else
				{
					XmlElement el = map[s.Name];
					s.Value = Xml.GetAttributeString(el, "value");
				}
			}

			map = Xml.MapElements(language, "module", "id");
			foreach (Module mod in container.Modules)
			{
				if (map.ContainsKey(mod.Name) == false)
				{
					rep.add("Missing module " + mod.Name + " in " + Xml.PathOf(language));
					Read(mod, null, rep);
				}
				else
				{
					Read(mod, map[mod.Name], rep);
				}
			}
		}
		private static void Write(Module container, XmlDocument doc, XmlElement language, LanguageReport rep)
		{
			foreach (Str s in container.Strings)
			{
				XmlElement e = Xml.AppendElement(doc, language, "string");
				Xml.AddAttribute(doc, e, "id", s.Name);
				Xml.AddAttribute(doc, e, "value", s.Value);
			}

			foreach (Module mod in container.Modules)
			{
				XmlElement e = Xml.AppendElement(doc, language, "module");
				Xml.AddAttribute(doc, e, "id", mod.Name);
				Write(mod, doc, e, rep);
			}
		}

		public void loadFile(string path, LanguageReport rep)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(path);
			read(doc, rep);
		}

		public void saveFile(string path, LanguageReport rep)
		{
			XmlDocument doc = new XmlDocument();
			write(doc, rep);
			doc.Save(path);
		}

		public void read(XmlDocument doc, LanguageReport rep)
		{
			XmlElement el = doc["language"];
			Read(this, el, rep);
			setup(Xml.GetAttributeString(el, "id"), null);
		}
		public void write(XmlDocument doc, LanguageReport rep)
		{
			XmlElement el = Xml.AppendElement(doc, doc, "language");
			Xml.AddAttribute(doc, el, "id", Name);
			Write(this, doc, el, rep);
		}
		public LanguageBase()
		{
			Setup(this);
			setup("default", null);
		}
	}
}
