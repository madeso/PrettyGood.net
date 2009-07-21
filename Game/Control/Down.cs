using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public class Down : Input
    {
		public List<KeyCode> keys = new List<KeyCode>();
        private bool down = false;

        public override void update(KeyCode key, bool down)
        {
			foreach (var k in keys) if (key == k) this.down = down;
        }

        public bool IsDown
        {
            get
            {
                return down;
            }
        }

		public override void frame(float delta)
        {
        }
    }
}
