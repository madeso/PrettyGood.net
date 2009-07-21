using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public abstract class Input
    {
        public abstract void update(KeyCode key, bool down);
		public abstract void frame(float delta);
    }
}
