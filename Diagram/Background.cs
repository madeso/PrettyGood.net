using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram
{
	public interface Background
	{
		void paint(System.Drawing.Size windowSize, System.Drawing.Rectangle region, System.Drawing.Graphics g);
	}
}
