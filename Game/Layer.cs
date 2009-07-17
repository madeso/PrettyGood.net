using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;
using SFML.Graphics;

namespace Game
{
    public class Layer : IDisposable
    {
        public readonly string Name;
        int[] tiles;

        List<Sprite> sprites = new List<Sprite>();

        readonly int width;
        readonly int height;

        readonly int tilewidth;
        readonly int tileheight;

        public override string ToString()
        {
            return Name;
        }

        internal Layer(World world, System.Xml.XmlElement la, int tilewidth, int tileheight, SFML.Graphics.Image image)
        {
            Name = la.GetAttributeString("name");
            width = la.GetAttributeInt("width");
            height = la.GetAttributeInt("height");
            this.tilewidth = tilewidth;
            this.tileheight = tileheight;

            tiles = new int[ width*height ];

            var data = la.FirstElement("data");
            int index = 0;
            foreach (var tile in data.ElementsNamed("tile"))
            {
                var gid = tile.GetAttributeInt("gid");
                tiles[index] = gid;
                ++index;
            }

            foreach (var o in ObjectDatas)
            {
                if (o.gid != 0)
                {
                    var sp = Tiles.CreateSprite(image, o.gid, tilewidth, tileheight);
                    sp.Position = o.pos;
                    sprites.Add(sp);
                }
            }
        }

        public void update(float time)
        {
            foreach (var o in objects) o.update(time);
        }

        public void render(Game g)
        {
            foreach (var x in sprites) g.draw(x);
            foreach (var o in objects) o.draw(g);
        }

        internal void removeSprites()
        {
            sprites.Clear();
        }

        // refactor to readonly data...
        public class ObjectData
        {
            public int x;
            public int y;
            public int gid;
            public int index;
            public Vector2 pos;
        }

        public bool placeFree(float posX, float posY, float width, float height, out float fx, out float fy)
        {
            int freeX = -1, freeY=-1;
            float x = posX / tilewidth,
                dx = width / tilewidth,
                y = posY / tileheight,
                dy = height / tileheight;

            bool res = placeFreeBase(x, y, ref freeX, ref freeY) && placeFreeBase(x + dx, y, ref freeX, ref freeY) && placeFreeBase(x, y + dy, ref freeX, ref freeY) && placeFreeBase(x + dx, y + dy, ref freeX, ref freeY);

            fx = freeX * tilewidth;
            fy = tileheight;

            return res;
        }

        private bool placeFreeBase(float x, float y, ref int ox, ref int oy)
        {
            return placeFreeBase((int)x, (int)y,ref ox, ref oy);
        }

        private bool placeFreeBase(int x, int y, ref int ox, ref int oy)
        {
            if (x < 0) return true;
            if (y < 0) return true;
            if (x > width) return true;
            if (y > height) return true;
            bool free = getTileAt(x, y) == 0;
            if (!free)
            {
                ox = x;
                oy = y;
            }
            return free;
        }
        int getTileAt(int x, int y)
        {
            if (x < 0) return 0;
            if (y < 0) return 0;
            if (y >= height) return 0;
            if (x >= width) return 0;

            int index = x + y * width;

            // assert( index >= 0 );
            // assert(index < mWidth*mHeight);

            return tiles[index];
        }

        public CollisionResult moveObject(ref float x, ref float y, float w, float h, float mx, float my) {
		    bool collidedX = true;
		    bool collidedY = true;
		    float cx=0, cy=0;
            if (placeFree(x + mx, y, w, h, out cx, out cy))
            {
                x += mx;
                collidedX = false;
            }
            //else x = cx;

            if (placeFree(x, y + my, w, h, out cx, out cy))
            {
                y += my;
                collidedY = false;
            }
            //else y = cy;

		    return new CollisionResult(collidedX, collidedY);
	    }

        public IEnumerable<ObjectData> ObjectDatas
        {
            get
            {
                for (int index = 0; index < tiles.Length; ++index)
                {
                    int xl = index % width;
                    int yl = index / width;
                    yield return new ObjectData { x = xl, y = yl, gid = tiles[index], index=index, pos=new Vector2(xl * tilewidth, yl * tileheight) };
                }
            }
        }

        List<LevelObject> objects = new List<LevelObject>();

        internal void add(LevelObject levelObject)
        {
            objects.Add(levelObject);
        }

        public void Dispose()
        {
            foreach (var x in objects) x.Dispose();
            objects.Clear();
        }
    }
}
