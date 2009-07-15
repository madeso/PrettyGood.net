using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public abstract class LevelObject
    {
        public abstract void draw(Game g);
        public abstract void update(float time);

        public World world
        {
            get;
            set;
        }
    }
}
