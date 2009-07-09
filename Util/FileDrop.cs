using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PrettyGood.Util
{
	public class FileDrop
	{
		Action<IEnumerable<string>> onfile;
		public FileDrop(Control f, Action<IEnumerable<string>> onfile)
		{
			this.onfile = onfile;
			f.AllowDrop = true;
			f.DragEnter += new DragEventHandler(f_DragEnter);
			f.DragDrop += new DragEventHandler(f_DragDrop);
		}

		void f_DragDrop(object sender, DragEventArgs e)
		{
			// transfer the filenames to a string array
			// (yes, everything to the left of the "=" can be put in the 
			// foreach loop in place of "files", but this is easier to understand.)
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

			// loop through the string array, adding each filename to the ListBox
			onfile(files);
		}

		void f_DragEnter(object sender, DragEventArgs e)
		{
			// make sure they're actually dropping files (not text or anything else)
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
			{
				// allow them to continue
				// (without this, the cursor stays a "NO" symbol
				e.Effect = DragDropEffects.All;
				Debug.WriteLine("ok");
			}

			Debug.WriteLine( new StringListCombiner(", ", " and ").combineFromEnumerable(e.Data.GetFormats()) );
		}
	}
}
