using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public class Hit : Input
    {
        public List<KeyCode> keys = new List<KeyCode>();
        private bool down = false;
        private bool old = false;

        public void update(KeyCode key, bool down)
        {
            foreach(var k in keys) if (key == k) this.down = down;
        }

        public bool IsDown
        {
            get
            {
                return down;
            }
        }

        public bool IsHit
        {
            get
            {
                return down && !old;
            }
        }
        
        public void frame(float delta)
        {
            old = down;
        }
    }
}
