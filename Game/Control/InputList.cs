using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;

namespace Game.Control
{
    public class InputList
    {
        List<Input> inputs = new List<Input>();

        public InputList add(Input inp)
        {
            inputs.Add(inp);
            return this;
        }

        public void update(KeyCode key, bool down)
        {
            foreach (var x in inputs) x.update(key, down);
        }
    }
}
