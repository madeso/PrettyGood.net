using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.Controllers
{
	public class ZoomWithScrollWheel : Controller
	{
		public override void scroll(int delta, Pnt worldPos, Pnt viewPos)
		{
			Pnt wp = WorldPos;
			var s = Diagram.ZoomScale;
			Diagram.zoom((delta / 120.0f) * 0.10f );
			var ns = Diagram.ZoomScale;
			Pnt nwp = WorldPos;

			Diagram.translate(nwp-wp);
		}
	}
}
