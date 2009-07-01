using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PrettyGood.Util;

namespace PrettyGood.LastFm
{
	public class Image
	{
		internal Image(XmlElement el)
		{
			this.size = Xml.GetAttributeString(el, "size");
			this.url = Xml.GetFirstTextOrNull(el);
		}

		public readonly string url;
		public readonly string size;
	}
}
