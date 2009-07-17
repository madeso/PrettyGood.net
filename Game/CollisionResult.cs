using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class CollisionResult
    {
        public readonly bool X;
        public readonly bool Y;


        public CollisionResult(bool x, bool y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0} & {1})", X, Y);
        }
    }
}
