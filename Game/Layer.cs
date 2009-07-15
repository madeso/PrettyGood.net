using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;
using SFML.Graphics;

namespace Game
{
    public class Layer
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
    }
}
