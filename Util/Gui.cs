using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PrettyGood.Util
{
	public static class Gui
	{
		public static void message(string message, MessageBoxIcon icon)
		{
			MessageBox.Show(message, App.ReadableAppName, MessageBoxButtons.OK, icon);
		}

		public static void information(string message)
		{
			Gui.message(message, MessageBoxIcon.Information);
		}

		public static bool yesno(string message)
		{
			return MessageBox.Show(message, App.ReadableAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
		}

		public static Font MakeBold(Font font, bool bold)
		{
			return new Font(font, bold ? FontStyle.Bold : FontStyle.Regular);
		}

		// todo: it looks funny, fix it
		public static void IntegrateEnumIntoToolstrip<T>(ToolStripMenuItem root, Action<T> action, T current) where T: IComparable
		{
			SingleSelectionMenu ss = new SingleSelectionMenu(root);
			ToolStripMenuItem it = null;
			foreach (KeyValuePair<string, T> k in Reflect.PublicStaticValuesOf<T>())
			{
				ToolStripMenuItem t = ss.append(k.Key, i => action((T)i.Tag));
				t.Tag = k.Value;
				if( 0==k.Value.CompareTo(current) )
				{
					it = t;
				}
			}
			if (it != null) ss.check(it);
		}

		/* old code - integrate to current when needed
		public static ImageList Images(string basePath, params string[] relativePaths)
		{
			ImageList list = new ImageList();
			foreach (string relativePath in relativePaths)
			{
				string path = "???";
				try
				{
					path = FileUtil.GetCommonPathFor(basePath + relativePath);
					Image img = Image.FromFile(path);
					list.Images.Add(img);
				}
				catch (Exception e)
				{
					throw new Exception("while loading image " + path, e);
				}
			}
			return list;
		}*/

		public static object InvokeOrCall(Control c, Delegate d, params object[] args)
		{
			if (c.InvokeRequired) return c.Invoke(d, args);
			else return d.DynamicInvoke(args);
		}
	}
}
