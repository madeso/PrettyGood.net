using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public abstract class LevelObject :  IDisposable
    {
        public abstract void draw(Game g);
        public abstract void update(float time);

        public World world
        {
            get;
            set;
        }

        public abstract void Dispose();
    }
}
