using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    class PlusMinus : Input
    {
        Down plus = new Down();
        Down minus = new Down();

        public KeyCode Plus
        {
            get
            {
                return plus.key;
            }
            set
            {
                plus.key = value;
            }
        }
        public KeyCode Minus
        {
            get
            {
                return minus.key;
            }
            set
            {
                minus.key = value;
            }
        }

        public void update(KeyCode key, bool down)
        {
            plus.update(key, down);
            minus.update(key, down);
        }

        public int Value
        {
            get
            {
                return (plus.IsDown ? 1 : 0) - (minus.IsDown ? 1 : 0);
            }
        }
    }
}
