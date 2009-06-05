using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PrettyGood.Util
{
	public static class Reflect
	{
		public static IEnumerable<KeyValuePair<string, T>> PublicStaticValuesOf<T>()
		{
			Type t = typeof(T);
			System.Reflection.FieldInfo[] infos = t.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
			foreach (System.Reflection.FieldInfo mi in infos)
			{
				yield return new KeyValuePair<string, T>(mi.Name, (T)mi.GetValue(null));
			}
			System.Reflection.PropertyInfo[] pinfos = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
			foreach (System.Reflection.PropertyInfo pi in pinfos)
			{
				yield return new KeyValuePair<string, T>(pi.Name, (T)pi.GetValue(null, null));
			}
		}

		public static IEnumerable<Member> MembersOf<Member, Owner>(Owner o)
			where Member : class
			where Owner : class
		{
			Type t = typeof(Owner);
			foreach (FieldInfo fi in t.GetFields())
			{
				object m = fi.GetValue(o);
				Member mc = m as Member;
				if (m != null)
				{
					yield return mc;
				}
			}
		}

		public static T GetEnumValue<T>(string p)
		{
			foreach (KeyValuePair<string, T> mi in PublicStaticValuesOf<T>())
			{
				if (p.ToLower().Trim().CompareTo(mi.Key.ToLower().Trim()) == 0)
				{
					return mi.Value;
				}
			}
			string data = new Util.StringSeperator(", ").Append(CSharp.Keys<string, T>(PublicStaticValuesOf<T>())).ToString();
			throw new Exception(p + " is not a valid " + typeof(T).Name + ", valid values are " + data);
		}
	}
}
