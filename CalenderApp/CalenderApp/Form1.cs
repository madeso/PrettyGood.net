using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalenderApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.Activated += new EventHandler(_Activated);
			this.Move += new EventHandler(_Move);
			this.LocationChanged += new EventHandler(Form1_LocationChanged);
			this.MouseClick += new MouseEventHandler(_MouseClick);
		}

		void _MouseClick(object sender, MouseEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(string.Format("{0}, {1}", e.X, e.Y));
		}

		void Form1_LocationChanged(object sender, EventArgs e)
		{
			setBottom();
		}

		void _Move(object sender, EventArgs e)
		{
			setBottom();
		}

		void _Activated(object sender, EventArgs e)
		{
			setBottom();
		}

		private void setBottom()
		{
			PInvoke.setBottom(this.Handle);
		}

		protected override void OnPaintBackground(PaintEventArgs pe)
		{
			pe.Graphics.Clear(Color.Wheat);
			//pe.Graphics.Clear(Color.Transparent);
			using(var p = new Pen(Color.Black, 5) )
			{
				var d = DateTime.Now;
				var days = DateTime.DaysInMonth(d.Year, d.Month);
				var start = new DateTime(d.Year, d.Month, 1).DayOfWeek;

				var previousMonth = d.Month == 0 ? 11 : d.Month - 1;
				var previousYear = d.Month == 0 ? d.Year - 1 : d.Year;
				var previousDays = DateTime.DaysInMonth(previousYear, previousMonth);

				List<DateTime> calender = new List<DateTime>();
				var starti = C(start);
				for (int i = 0; i < starti; ++i)
				{
					calender.Add(new DateTime(previousYear, previousMonth, previousDays - (starti - i) + 1));
				}
				for (int i = 1; i <= days; ++i)
				{
					calender.Add(new DateTime(d.Year, d.Month, i) );
				}
				var ccount = calender.Count;
				int ed = 0;
				while ( (ccount+ed) % 7 != 0)
				{
					ed += 1;
					calender.Add(new DateTime(d.Year, d.Month+1, ed));
				}
				ccount = calender.Count;

				var index = 0;
				var sf = new StringFormat();

				sf.Alignment = StringAlignment.Center;
				pe.Graphics.DrawString(DateTime.Now.ToString("MMMM"), monthFont, Brushes.White, new RectangleF(0, 0, Width, monthFont.Height), sf);

				sf.Alignment = StringAlignment.Far;
				pe.Graphics.DrawString(DateTime.Now.Year.ToString(), yearFont, Brushes.White, new RectangleF(0, Height - yearFont.Height, Width, yearFont.Height), sf);

				for (int i = 0; i < 7; ++i)
				{
					var da = calender[i];
					Draw(ccount, headerFont, pe, index, Brushes.Goldenrod, da.ToString("ddd"));
					++index;
				}

				foreach(var da in calender)
				{
					Draw(ccount, dateFont, pe, index, DetermineBrush(da), da.Day.ToString());

					++index;
				}
			}
		}

		private void Draw(int ccount, Font font, PaintEventArgs pe, int index, Brush color, string text)
		{
			int x = (index % 7) * (Width / 7);
			int total = Height - ( monthFont.Height + yearFont.Height );
			int y = monthFont.Height + (index / 7) * ( total / (ccount/7) );
			pe.Graphics.DrawString(text, font, color, x, y);
		}

		private int C(DayOfWeek start)
		{
			switch (start)
			{
				case DayOfWeek.Monday: return 0;
				case DayOfWeek.Tuesday: return 1;
				case DayOfWeek.Wednesday: return 2;
				case DayOfWeek.Thursday: return 3;
				case DayOfWeek.Friday: return 4;
				case DayOfWeek.Saturday: return 5;
				case DayOfWeek.Sunday: return 6;
				default: return 6;
			}
		}

		Font dateFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
		Font headerFont = new Font(FontFamily.GenericSansSerif, 7, FontStyle.Bold);
		Font monthFont = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
		Font yearFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

		private Brush DetermineBrush(DateTime da)
		{
			if (da.DayOfYear == DateTime.Now.DayOfYear) return Brushes.BlueViolet;
			else if (da.Month != DateTime.Now.Month) return Brushes.Gray;
			else if (da.DayOfWeek == DayOfWeek.Saturday || da.DayOfWeek == DayOfWeek.Sunday) return Brushes.Red;
			else return Brushes.Black;
		}
	}
}
