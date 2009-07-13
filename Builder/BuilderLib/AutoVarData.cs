using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BuilderLib
{
	class AutoVarData
	{
		public string ProjectFolder;
		public string InstallFolder = GetInstallFolder();

		public static string GetInstallFolder()
		{
			return Environment.CurrentDirectory;
		}

		public ExternalVariableList externals;

		internal string getFile(string filename, string ext)
		{
			string file = Path.Combine(InstallFolder, Path.ChangeExtension(filename, ext));
			return file;
		}
	}
}
