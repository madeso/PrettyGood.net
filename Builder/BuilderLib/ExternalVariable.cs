﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PrettyGood.Util;

namespace BuilderLib
{
	public class ExternalVariable : Variable
	{
		public readonly string name;
		public string value = "";
		public readonly string description;

		public enum Type
		{
			Folder,
			Text,
			File,
			FileExist
		}

		public Type type;

		public ExternalVariable(string name, string type, string description)
		{
			this.name = name;
			this.type = (Type) Enum.Parse(typeof(Type), type, true);
			this.description = description;
		}

		public override string Name
		{
			get { return name; }
		}

		public override string Value
		{
			get
			{
				return value;
			}
		}

		protected override string verify(string s)
		{
			if (type == Type.File)
			{
				// verify it got a extension?
				return s;
			}
			else if ( type == Type.FileExist )
			{
				FileInfo fi = new FileInfo(s);
				if (fi.Exists) return s;
				throw new Exception(s + " does not exist");
			}
			else if (type == Type.Folder )
			{
				FileUtil.MakeSurePathExist(s);
				return s;
			}
			else //if (type == Type.Text)
			{
				return s;
			}
		}
	}
}
