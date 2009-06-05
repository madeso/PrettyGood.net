using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PrettyGood.Util
{
	public class Listview<T>
	{
		ListView view;

		private class Item
		{
			public T t;
			public int Index;
		}

		public Listview(ListView view)
		{
			if (null == view) throw new NullReferenceException();
			this.view = view;

			view.View = View.Details;
			view.SmallImageList = new ImageList();
			view.LargeImageList = new ImageList();
		}

		public void add(Column c)
		{
			ColumnHeader ch = new ColumnHeader();
			ch.Tag = c;
			c.Header = ch;
			view.Columns.Add(ch);
		}

		public void specify(Column c, ColumnHeader ch)
		{
			ch.Tag = c;
			c.Header = ch;
		}

		IEnumerable<Column> Columns
		{
			get
			{
				foreach (ColumnHeader ch in view.Columns)
				{
					if (null == ch.Tag) yield return new Column(ch.Text);
					else yield return (Column)ch.Tag;
				}
			}
		}

		IndexCreator index = new IndexCreator();

		public ListViewItem add(T t)
		{
			ListViewItem it = new ListViewItem();
			Item i = new Item();
			i.t = t;
			it.Tag = i;
			i.Index = index.generate();
			updateText(it);
			view.Items.Add(it);
			return it;
		}

		public void updateText(ListViewItem it)
		{
			it.SubItems.Clear();
			bool first = true;

			Item i = (Item)it.Tag;
			T t = i.t;

			if (null == gf) it.Group = null;
			else it.Group = GetGroup(gf(t));

			if (bf != null)
			{
				it.Font = MakeBold(it.Font, bf(t));
			}

			SmallLargeImage si = null;
			if (smalliconf != null) si = smalliconf(t);
			if (si == null)
			{
				it.ImageIndex = -1;
			}
			else
			{
				it.ImageIndex = i.Index;
				Set(view.SmallImageList, i.Index, si.Small);
				Set(view.LargeImageList, i.Index, si.Large);
			}

			foreach (Column c in Columns)
			{
				string v = resolve(c.Pattern, t);
				if (first)
				{
					it.Text = v;
					first = false;
				}
				else
				{
					it.SubItems.Add(v);
				}
			}
		}

		static Bitmap emptyBitmap = new Bitmap(1, 1);

		private void Set(ImageList list, int index, Image image)
		{
			while (index >= list.Images.Count)
			{
				list.Images.Add(emptyBitmap);
			}
			list.Images[index] = image;
		}

		private static Font MakeBold(Font font, bool bold)
		{
			return new Font(font, bold ? FontStyle.Bold : FontStyle.Regular);
		}

		private ListViewGroup GetGroup(string p)
		{
			ListViewGroup g = view.Groups[p];
			if (g != null) return g;
			return view.Groups.Add(p, p);
		}

		Dictionary<string, Func<T, string>> converters = new Dictionary<string, Func<T, string>>();
		Func<T, string> gf;
		Func<T, bool> bf;
		Func<T, SmallLargeImage> smalliconf;

		public void add(string name, Func<T, string> c)
		{
			converters.Add(name, c);
		}

		public void groupfunction(Func<T, string> g)
		{
			gf = g;
		}

		public void icons(Func<T, SmallLargeImage> g)
		{
			smalliconf = g;
		}

		public void boldfunc(Func<T, bool> b)
		{
			bf = b;
		}

		private string lookup(T t, string name)
		{
			string ttl = name.ToLower();
			if (converters.ContainsKey(ttl))
			{
				return converters[ttl](t);
			}
			else return null;
		}

		public string resolve(Pattern p, T t)
		{
			return p.resolve(name => lookup(t, name));
		}

		public void clear()
		{
			view.Items.Clear();
			view.Groups.Clear();
			index.clear();
		}

		public T SingleSelectedItemOrNull
		{
			get
			{
				if (view.SelectedItems.Count != 1) return default(T);
				ListViewItem item = view.SelectedItems[0];
				return ((Item)item.Tag).t;
			}
		}
	}
}
