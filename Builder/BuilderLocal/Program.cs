using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PrettyGood.Util;

namespace BuilderLocal
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			App.Setup("sirGustav", "Builder 0.1", "builder");
			ConsoleArguments args = new ConsoleArguments();
			Application.Run(new MainWindow());
		}
	}
}
