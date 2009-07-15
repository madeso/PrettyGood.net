using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Game
{
    class Clock
    {
        Stopwatch sw = new Stopwatch();
        
        public Clock()
        {
            sw.Start();
        }

        internal void Reset()
        {
            sw.Reset();
            sw.Start();
        }

        internal float GetElapsedTime()
        {
            return sw.ElapsedMilliseconds / 1000.0f;
        }
    }
}
