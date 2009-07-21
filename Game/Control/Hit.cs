using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public class Hit : Down
    {
        private bool old = false;

        public bool IsHit
        {
            get
            {
                return IsDown && !old;
            }
        }
        
        public override void frame(float delta)
        {
            old = IsDown;
        }
    }
}
