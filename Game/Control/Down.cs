using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    class Down : Input
    {
        public KeyCode key;
        private bool down = false;

        public void update(KeyCode key, bool down)
        {
            if (key == this.key) this.down = down;
        }

        public bool IsDown
        {
            get
            {
                return down;
            }
        }

        public void frame(float delta)
        {
        }
    }
}
