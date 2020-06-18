using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Diagram
{
	class BackgroundGradient : Background
	{
		public Color Start = Color.PowderBlue;
		public Color End = Color.PeachPuff;

		public void paint(System.Drawing.Size windowSize, System.Drawing.Rectangle region, System.Drawing.Graphics g)
		{
			using (Brush b = new LinearGradientBrush(new Point(0, 0), new Point(windowSize), Start, End))
			{
				g.FillRectangle(b, region);
			}
		}
	}
}
