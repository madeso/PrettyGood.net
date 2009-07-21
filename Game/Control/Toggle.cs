using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
	public class Toggle : Hit
	{
		private bool enabled = false;

		public bool IsToggled
		{
			get
			{
				return enabled;
			}
		}

		public override void frame(float delta)
		{
			if (IsHit) enabled = !enabled;
			base.frame(delta);
		}
	}
}
