using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram
{
	class ControllerList
	{
		Diagram d;
		internal ControllerList(Diagram d)
		{
			this.d = d;
		}
		internal Diagram Dia
		{
			get
			{
				return d;
			}
		}
		internal bool MiddleMouseIsDown
		{
			get;
			private set;
		}

		List<Controller> controllers = new List<Controller>();

		public ControllerList add(Controller c)
		{
			c.List = this;
			controllers.Add(c);
			return this;
		}

		internal void enter()
		{
			foreach (var c in controllers) c.enter();
		}

		internal void scroll(int delta, Pnt view)
		{
			Pnt lastWorldPos = WorldPos;
			Pnt lastViewPos = ViewPos;
			ViewPos = view;
			foreach (var c in controllers) c.scroll(delta, lastWorldPos, lastViewPos);
		}

		internal void leave()
		{
			foreach (var c in controllers) c.leave();
		}

		internal void mouseButtonChanged(System.Windows.Forms.MouseButtons button, bool newState)
		{
			if (button == System.Windows.Forms.MouseButtons.Middle) MiddleMouseIsDown = newState;
			foreach (var c in controllers) c.mouseButtonChanged(button, newState);
		}

		internal bool keyStateChanged(System.Windows.Forms.Keys key, bool newState)
		{
			foreach (var c in controllers)
			{
				if (c.keyStateChanged(key, newState)) return true;
			}

			return false;
		}

		internal Pnt WorldPos
		{
			get
			{
				return Dia.viewToWorld(ViewPos);
			}
		}

		internal Pnt ViewPos = new Pnt(0, 0);

		internal void move(Pnt view)
		{
			Pnt lastWorldPos = WorldPos;
			Pnt lastViewPos = ViewPos;
			ViewPos = view;

			Pnt dstWorld = WorldPos - lastWorldPos;
			Pnt dstView = ViewPos - lastViewPos;

			foreach (var c in controllers) c.move(lastWorldPos, lastViewPos, dstWorld, dstView);
		}
	}
}
