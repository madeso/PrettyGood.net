using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace PrettyGood.Util
{
	public static class FileUtil
	{
		public class Combiner
		{
			string path;

			internal Combiner(Environment.SpecialFolder folder)
			{
				path = System.Environment.GetFolderPath(folder);
			}

			private Combiner(string path)
			{
				this.path = path;
			}

			public Combiner dir(string name)
			{
				string safe = name;
				List<char> cs = new List<char>(InvalidPathCharacters());
				foreach (char c in cs)
				{
					safe = safe.Replace(c, '_');
				}
				return new Combiner(Path.Combine(path, safe));
			}
			const string kExtraInvalidCharacters = ".:\' !?()#,&";

			private IEnumerable<char> InvalidPathCharacters()
			{
				foreach (char c in System.IO.Path.GetInvalidPathChars())
					yield return c;
				foreach (char c in kExtraInvalidCharacters)
					yield return c;
			}

			public string Directory
			{
				get
				{
					return path;
				}
			}

			public string file(string name, string extention)
			{
				string safe = name;
				foreach (char c in InvalidFileCharacters())
				{
					safe = safe.Replace(c, '_');
				}
				return Path.Combine(path, safe + "." + extention);
			}

			private IEnumerable<char> InvalidFileCharacters()
			{
				foreach (char c in System.IO.Path.GetInvalidFileNameChars())
					yield return c;
				foreach (char c in kExtraInvalidCharacters)
					yield return c;
			}
		}

		private static Combiner OsFilePath(Environment.SpecialFolder folder)
		{
			return new Combiner(folder);
		}
		private static Combiner RelativeApplicationPath(Combiner c)
		{
			return c.dir(App.Company).dir(App.AppCode);
		}
		private static Combiner PathFor(Environment.SpecialFolder folder)
		{
			return RelativeApplicationPath(OsFilePath(folder));
		}
		public static Combiner GetCommonPathFor()
		{
			return PathFor(Environment.SpecialFolder.CommonApplicationData);
		}
		public static Combiner GetUserPathFor()
		{
			return PathFor(Environment.SpecialFolder.ApplicationData);
		}
		public static Combiner GetUserDocument()
		{
			return OsFilePath(Environment.SpecialFolder.MyDocuments);
		}

		public static void MakeSurePathExist(string path)
		{
			System.IO.FileInfo fi = new System.IO.FileInfo(path);
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(fi.DirectoryName);
			if (dir.Exists == false)
			{
				dir.Create();
			}
		}

		public static string GetTempFilePath(string extension)
		{
			List<string> used = new List<string>();
			string result;

			while (true)
			{
				string path = System.IO.Path.GetTempFileName();
				used.Add(path);
				path = System.IO.Path.ChangeExtension(path, extension);
				if (System.IO.File.Exists(path))
				{
				}
				else
				{
					result = path;
					break;
				}
			}

			foreach (string path in used)
			{
				System.IO.File.Delete(path);
			}

			return result;
		}

		public static void OpenFolder(string p)
		{
			string windir = Environment.GetEnvironmentVariable("WINDIR");
			Process prc = new Process();
			prc.StartInfo.FileName = windir + @"\explorer.exe";
			prc.StartInfo.Arguments = p;
			prc.Start();
		}
	}
}
