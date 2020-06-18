using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.Controllers
{
	class MiddleMouseDrag : Controller
	{
		public override void move(Pnt lastWorldPos, Pnt lastViewPos, Pnt dstWorld, Pnt dstView)
		{
			if (MiddleMouseIsDown) Diagram.translate(dstWorld);
		}
	}
}
