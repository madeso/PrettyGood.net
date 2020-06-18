using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Diagram
{
	class SimpleBackground : Background
	{
		public Color Color = Color.CornflowerBlue;

		public void paint(System.Drawing.Size windowSize, System.Drawing.Rectangle region, System.Drawing.Graphics g)
		{
			using( Brush b = new SolidBrush(Color) )
			{
				g.FillRectangle(b, region);
			}
		}
	}
}
