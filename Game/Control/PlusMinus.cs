using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public class PlusMinus : Input
    {
        Down plus = new Down();
        Down minus = new Down();

        public List<KeyCode> Plus
        {
            get
            {
                return plus.keys;
            }
            set
            {
                plus.keys = value;
            }
        }
        public List<KeyCode> Minus
        {
            get
            {
                return minus.keys;
            }
            set
            {
                minus.keys = value;
            }
        }

        public override void update(KeyCode key, bool down)
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

        public override void frame(float delta)
        {
        }
    }
}
