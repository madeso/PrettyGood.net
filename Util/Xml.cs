using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PrettyGood.Util
{
	public static class Xml
	{
		public static bool HasAttribute(XmlElement element, string search)
		{
			XmlAttribute attribute = element.Attributes[search];
			return attribute != null;
		}

		public static string GetAttributeString(XmlElement element, string name)
		{
			XmlAttribute attribute = element.Attributes[name];
			if (attribute == null) throw new Exception(element.Name + " is missing text attribute \"" + name + "\"");
			else return attribute.Value;
		}

		public static IEnumerable<XmlElement> ElementsNamed(XmlNode root, string childName)
		{
			foreach (XmlNode node in root.ChildNodes)
			{
				XmlElement el = node as XmlElement;
				if (el == null) continue;
				if (el.Name != childName) continue;
				yield return el;
			}
		}

		public static IEnumerable<XmlElement> Elements(XmlNode root)
		{
			foreach (XmlNode node in root.ChildNodes)
			{
				XmlElement el = node as XmlElement;
				if (el == null) continue;
				yield return el;
			}
		}

		private const string kValueType = "id";

		public static IEnumerable<XmlElement> ElementsNamed(XmlNode root, string childName, string valueName)
		{
			foreach (XmlNode node in root.ChildNodes)
			{
				XmlElement el = node as XmlElement;
				if (el == null) continue;
				if (el.Name != childName) continue;
				if (HasAttribute(el, kValueType) == false) continue;
				string val = GetAttributeString(el, kValueType);
				if (val != valueName) continue;
				yield return el;
			}
		}

		public static IEnumerable<XmlElement> Enumerate(XmlNode root, string path)
		{
			string[] elements = path.Split("/".ToCharArray());

			List<XmlNode> active = new List<XmlNode>();
			List<XmlNode> future = new List<XmlNode>();
			active.Add(root);
			foreach (string p in elements)
			{
				foreach (XmlNode a in active)
				{
					foreach (XmlElement e in ElementsNamed(a, p) )
					{
						future.Add(e);
					}
				}
				active.Clear();
				CSharp.Swap(ref active, ref future);
			}

			foreach (XmlNode node in active)
			{
				yield return (XmlElement) node;
			}
		}
		public static XmlElement FirstOrNull(IEnumerable<XmlElement> elements)
		{
			foreach (XmlElement e in elements)
			{
				return e;
			}
			return null;
		}
		public static XmlElement FirstOrNull(XmlNode root, string path)
		{
			return FirstOrNull(Enumerate(root, path));
		}

		public static XmlElement Open(Loader path, string p)
		{
			try
			{
				XmlDocument doc = Open(path);
				XmlElement el = FirstOrNull(doc, p);
				if (el == null) throw new Exception(p + " not found in " + path);
				else return el;
			}
			catch (Exception e)
			{
				throw new Exception("while reading " + path + " for node: " + p, e);
			}
		}

		public interface Loader
		{
			void load(XmlDocument doc);
		}

		public static Loader FromFile(string path)
		{
			return new FileLoader(path);
		}
		public static Loader FromSource(string source)
		{
			return new SourceLoader(source);
		}

		private class FileLoader : Loader
		{
			private readonly string path;
			public FileLoader(string path)
			{
				this.path = path;
			}
			
			public void load(XmlDocument doc)
			{
				doc.Load(path);
			}
			public override string ToString()
			{
				return path;
			}
		}
		private class SourceLoader : Loader
		{
			private readonly string source;
			public SourceLoader(string source)
			{
				this.source = source;
			}

			public void load(XmlDocument doc)
			{
				doc.LoadXml(source);
			}

			public override string ToString()
			{
				return Strings.FirstChars(source, 10);
			}
		}

		private static XmlDocument Open(Loader loader)
		{
			try
			{
				XmlDocument doc = new XmlDocument();
				loader.load(doc);
				return doc;
			}
			catch (Exception e)
			{
				throw new Exception("while opening xml: " + loader, e);
			}
		}

		public static XmlElement FirstElement(XmlElement e)
		{
			foreach (XmlElement el in Elements(e))
			{
				return el;
			}
			throw new Exception(e.Name + " is missing element");
		}

		public static IEnumerable<KeyValuePair<string, string>> Attributes(XmlElement el)
		{
			foreach (XmlAttribute a in el.Attributes)
			{
				yield return new KeyValuePair<string, string>(a.Name, a.Value);
			}
		}

		public static string NameOf(XmlElement element)
		{
			string attribute = "";
			if (HasAttribute(element, "id"))
			{
				attribute = "[" + GetAttributeString(element, "id") + "]";
			}
			return element.Name + attribute; ;
		}

		public static string PathOf(XmlElement element)
		{
			XmlElement c = element;
			string result = "";
			while (c != null)
			{
				result = NameOf(c) + "/" + result;
			}
			return result;
		}

		public static Dictionary<string, XmlElement> MapElements(XmlElement root, string type, string key)
		{
			if (root == null) return new Dictionary<string, XmlElement>();
			Dictionary<string, XmlElement> map = new Dictionary<string, XmlElement>();
			foreach (XmlElement module in Xml.ElementsNamed(root, type))
			{
				string name = Xml.GetAttributeString(module, key);
				map.Add(name, module);
			}
			return map;
		}

		public static string GetAttributeString(XmlElement element, string name, string def)
		{
			if (def==null || HasAttribute(element, name)) return GetAttributeString(element, name);
			else return def;
		}

		public static XmlElement AppendElement(XmlDocument doc, XmlNode cont, string name)
		{
			XmlElement el = doc.CreateElement(name);
			cont.AppendChild(el);
			return el;
		}
		public static void AddAttribute(XmlDocument doc, XmlNode elem, string name, string value)
		{
			XmlAttribute a = doc.CreateAttribute(name);
			a.InnerText = value;
			elem.Attributes.Append(a);
		}

		public static string GetTextOfSubElement(XmlNode node, params string[] ps)
		{
			foreach (string p in ps)
			{
				string res = GetTextOfSubElementOrNull(node, p);
				if (res != null) return res;
			}
			throw new Exception("node is missing " +  new StringSeperator(", ", " or").Append((object[])ps).ToString() + ", a requested sub node");
		}

		private static string GetSmartText(XmlNode el)
		{
			if (el is XmlText)
			{
				XmlText text = (XmlText)el;
				return text.Value;
			}
			else if (el is XmlCDataSection)
			{
				XmlCDataSection text = (XmlCDataSection)el;
				return text.Value;
			}
			else throw new Exception("Failed to get smart text of node");
		}

		public static string GetTextOfSubElementOrNull(XmlNode node, string p)
		{
			XmlElement el = node[p];
			if (el == null) return null;
			else return GetSmartText(el.FirstChild);
		}
	}
}
