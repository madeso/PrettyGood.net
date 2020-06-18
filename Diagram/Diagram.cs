using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagram
{
	public partial class Diagram : UserControl
	{
		public Diagram()
		{
			InitializeComponent();
			CenterView();
			this.MouseWheel += new MouseEventHandler(Diagram_MouseWheel);
			controller = new ControllerList(this);

			controller
				.add(new Controllers.MiddleMouseDrag())
				.add(new Controllers.ZoomWithScrollWheel())
				;
		}

		Background background = new BackgroundGradient();
		ControllerList controller;

		Pnt drawingSize = new Pnt(100, 100);
		Pnt displacement = new Pnt(0, 0);

		private void Diagram_MouseEnter(object sender, EventArgs e)
		{
			controller.enter();
		}

		void Diagram_MouseWheel(object sender, MouseEventArgs e)
		{
			controller.scroll(e.Delta, new Pnt(e.Location));
		}

		internal Pnt viewToWorld(Pnt view)
		{
			return new Pnt(view.X, view.Y) * ZoomScale;
		}

		private void Diagram_MouseLeave(object sender, EventArgs e)
		{
			controller.leave();
		}

		private void Diagram_MouseMove(object sender, MouseEventArgs e)
		{
			controller.move(new Pnt(e.Location));
		}

		private void Diagram_MouseUp(object sender, MouseEventArgs e)
		{
			controller.mouseButtonChanged(e.Button, false);
		}

		private void Diagram_MouseDown(object sender, MouseEventArgs e)
		{
			controller.mouseButtonChanged(e.Button, true);
		}

		private void Diagram_KeyUp(object sender, KeyEventArgs e)
		{
			e.Handled = controller.keyStateChanged(e.KeyCode, false);
		}

		private void Diagram_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = controller.keyStateChanged(e.KeyCode, true);
		}

		public void CenterView()
		{
			displacement = (new Pnt(Width, Height) - drawingSize) / 2;
		}

		Color paperColor = Color.Wheat;

		protected override void OnPaint(PaintEventArgs e)
		{
			background.paint(Size, e.ClipRectangle, e.Graphics);

			Pnt drawingSize = this.drawingSize * ZoomScale;
			e.Graphics.DrawRectangle(Pens.Black, displacement.X, displacement.Y, drawingSize.X, drawingSize.Y);
			using(Brush b = new SolidBrush(paperColor) )
			{
				e.Graphics.FillRectangle(b, displacement.X, displacement.Y, drawingSize.X, drawingSize.Y);
			}
		}

		internal void translate(Pnt move)
		{
			displacement += move;
			Invalidate();
		}

		public float ZoomScale
		{
			get
			{
				if (zoomFactor < 0)
				{
					return 1 / (1 - zoomFactor);
				}
				else
				{
					return 1 + zoomFactor;
				}
			}
		}

		float zoomFactor = 0;

		internal void zoom(float p)
		{
			zoomFactor += p;
			Invalidate();
		}
	}
}
