using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public interface LevelObject
    {
        void draw(Game g);
        void update(float time);
    }
}
