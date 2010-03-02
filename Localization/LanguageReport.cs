using System;
using System.Collections.Generic;
using System.Text;

namespace Localization
{
	public class LanguageReport
	{
		private List<string> messages = new List<string>();
		public IEnumerable<string> Messages
		{
			get
			{
				foreach (string m in messages)
				{
					yield return m;
				}
			}
		}
		public void add(string message)
		{
			messages.Add(message);
		}
	}
}
