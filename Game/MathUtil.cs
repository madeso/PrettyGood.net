using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Game
{
    public static class MathUtil
    {
        public static float Square(this float x)
        {
            return x * x;
        }
        public static float Root(this float x)
        {
            return (float)Math.Sqrt(x);
        }
        public static float Length(this Vector2 vec)
        {
            return (vec.X.Square() + vec.Y.Square()).Root();
        }
        public static Vector2 GetNormalized(this Vector2 vec)
        {
            float length = vec.Length();
            if (length < 0.001f) return vec;
            return vec / length;
        }
    }
}
