using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;

namespace BuilderLib
{
	public class ExternalVariableList
	{
		Dictionary<string, ExternalVariable> variables = new Dictionary<string, ExternalVariable>();

		internal Variable get(string type, string name, string description)
		{
			string na = name.ToLower();
			if ( variables.ContainsKey(na) ) return variables[na];
			ExternalVariable ev = new ExternalVariable(na, type, description);
			variables.Add(na, ev);
			return ev;
		}

		public IEnumerable<ExternalVariable> Variables
		{
			get
			{
				return CSharp.Values(variables);
			}
		}

		public void set(string name, string value)
		{
			variables[name].value = value;
		}

		public void load(string file)
		{
			Dictionary<string, string> data = Disk.LoadStringStringDictionaryOrNull(file);
			foreach (var x in variables)
			{
				if (data.ContainsKey(x.Key))
				{
					x.Value.value = data[x.Key];
				}
			}
		}

		public void save(string file)
		{
			Dictionary<string, string> data = Disk.LoadStringStringDictionaryOrNull(file);
			foreach (var x in variables)
			{
				data[x.Key] = x.Value.value;
			}
			Disk.WriteStringStringDictionary(data, file);
		}
	}
}
