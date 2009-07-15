using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public interface Input
    {
        void update(KeyCode key, bool down);
    }
}
