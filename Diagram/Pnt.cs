using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Diagram
{
	public struct Pnt
	{
		public float X;
		public float Y;

		public Pnt(float x, float y)
		{
			this.X = x;
			this.Y = y;
		}

		public Pnt(Point p)
		{
			this.X = p.X;
			this.Y = p.Y;
		}

		public Pnt(PointF p)
		{
			this.X = p.X;
			this.Y = p.Y;
		}

		public Pnt(Size s)
		{
			this.X = s.Width;
			this.Y = s.Height;
		}

		public Pnt(SizeF s)
		{
			this.X = s.Width;
			this.Y = s.Height;
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", X, Y);
		}

		public static Pnt operator+(Pnt lhs, Pnt rhs)
		{
			return new Pnt(lhs.X + rhs.X, lhs.Y + rhs.Y);
		}
		public static Pnt operator -(Pnt lhs, Pnt rhs)
		{
			return new Pnt(lhs.X - rhs.X, lhs.Y - rhs.Y);
		}
		public static Pnt operator *(Pnt pnt, float scale)
		{
			return new Pnt(pnt.X * scale, pnt.Y * scale);
		}
		public static Pnt operator *(float scale, Pnt pnt)
		{
			return new Pnt(pnt.X * scale, pnt.Y * scale);
		}
		public static Pnt operator /(Pnt pnt, float divide)
		{
			float scale = 1 / divide;
			return new Pnt(pnt.X * scale, pnt.Y * scale);
		}
		public PointF PointF
		{
			get
			{
				return new PointF(X, Y);
			}
		}
		public SizeF SizeF
		{
			get
			{
				return new SizeF(X, Y);
			}
		}

		public Point Point
		{
			get
			{
				return new Point((int)X, (int)Y);
			}
		}
		public Size Size
		{
			get
			{
				return new Size((int)X, (int)Y);
			}
		}
	}
}
