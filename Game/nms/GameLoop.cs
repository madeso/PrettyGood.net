using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using Game.Control;
using SFML.Window;

namespace Game.nms
{
    public class GameLoop : Loop, IDisposable
    {
        World world;

        public GameLoop(Game g)
            : base(g)
        {
            //sp.SubRect = new IntRect(378, 420, 210, 252);
            world = new World(g, "test.tmx", "");

            Dictionary<string, World.ObjectCreator> creators = new Dictionary<string, World.ObjectCreator>();

            creators.Add("player", x => new Player(g, this, x));

            world.parseObjectLayers(creators);

            inputList
                .add(rightLeftMovement)
                .add(jumpButton);
        }

        

        InputList inputList = new InputList();
        public PlusMinus rightLeftMovement = new PlusMinus { Plus= KeyCode.Right, Minus=KeyCode.Left };
        public Hit jumpButton = new Hit { keys = { KeyCode.LShift, KeyCode.RShift}  };

        public override void onUpdate(float delta)
        {
            world.update(delta);
            inputList.frame(delta);
        }

        public override void onRender()
        {
            world.render(debugCollision);
        }

        bool debugCollision = false;

        public override void onKey(SFML.Window.KeyCode key, bool down)
        {
            // escape isnt handled properly?
            if (/*down && */key == SFML.Window.KeyCode.Escape) abort();
            if (key == SFML.Window.KeyCode.Tab) debugCollision = down;
            inputList.update(key, down);
        }

        public override void onAxis()
        {
        }

        public void Dispose()
        {
            world.Dispose();
            world = null;
            
        }
    }
}
