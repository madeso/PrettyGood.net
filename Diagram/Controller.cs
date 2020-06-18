using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram
{
	public abstract class Controller
	{
		internal ControllerList List;
		
		protected Diagram Diagram
		{
			get
			{
				return List.Dia;
			}
		}

		protected bool MiddleMouseIsDown
		{
			get
			{
				return List.MiddleMouseIsDown;
			}
		}

		protected Pnt WorldPos
		{
			get
			{
				return List.WorldPos;
			}
		}

		protected Pnt ViewPos
		{
			get
			{
				return List.ViewPos;
			}
		}

		public virtual void enter() { }
		public virtual void scroll(int delta, Pnt worldPos, Pnt viewPos) { }
		public virtual void leave() { }
		public virtual void move(Pnt lastWorldPos, Pnt lastViewPos, Pnt dstWorld, Pnt dstView) { }
		public virtual void mouseButtonChanged(System.Windows.Forms.MouseButtons btn, bool newState) { }

		// return true if handled, false otherwise
		public virtual bool keyStateChanged(System.Windows.Forms.Keys key, bool newState) { return false; }
	}
}
