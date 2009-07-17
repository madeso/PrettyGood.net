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
                .add(rightLeft)
                .add(upDown);
        }

        class Player : LevelObject
        {
            Sprite sp;
            GameLoop loop;
            // SFML.Graphics.Font font
            //String2D text;
            //Font font;

            public Player(Game g, GameLoop loop, Layer.ObjectData da)
            {
                this.loop = loop;
                sp = Tiles.CreateSprite(g.fetchImage("worldtexture.png"), 89, 42, 42);
                sp.Position = da.pos;
                //font = new Font("cheeseburger.ttf");
                //text = new String2D("", font);
            }

            public override void draw(Game g)
            {
                g.draw(sp);
                //g.draw(text);
            }

            private void applyMovement(Vector2 mov)
            {
                float x = sp.Position.X;
                float y = sp.Position.Y;
                var re = world.CollisionLayer.moveObject(ref x, ref y, Constants.kTileSize, Constants.kTileSize, mov.X, mov.Y);
                sp.Position = new Vector2(x,y);
                //sp.Position += mov;

                /*float fx;
                float fy;
                bool cr = world.CollisionLayer.placeFree(sp.Position.X, sp.Position.Y, Constants.kTileSize, Constants.kTileSize, out fx, out fy);

                text.Text = string.Format("{0}|{1} {2},{3}", re, cr, fx, fy);
                text.Position = sp.Position;*/
            }

            public override void update(float delta)
            {
                const float kPlayerSpeed = 300;
                applyMovement(new Vector2(loop.rightLeft.Value, -loop.upDown.Value).GetNormalized() * kPlayerSpeed * delta);
                world.suggestViewCenter(sp.Position);
            }

            public override void Dispose()
            {
                //text.Dispose();
                //font.Dispose();
            }
        }

        InputList inputList = new InputList();
        PlusMinus rightLeft = new PlusMinus { Plus= KeyCode.Right, Minus=KeyCode.Left };
        PlusMinus upDown = new PlusMinus { Plus = KeyCode.Up, Minus = KeyCode.Down };

        public override void onUpdate(float delta)
        {
            world.update(delta);
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
