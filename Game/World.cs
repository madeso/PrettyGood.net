using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrettyGood.Util;
using System.IO;
using SFML.Graphics;

namespace Game
{
    public class World
    {
        public const string kCollisionLayerName = "_collision";

        private List<KeyValuePair<string, string>> properties = new List<KeyValuePair<string, string>>();

        public IEnumerable<KeyValuePair<string, string>> Properties
        {
            get
            {
                return properties;
            }
        }

        public World(Game game, string file, string relative)
        {
            this.game = game;
            var root = Xml.Open(Xml.FromFile(file), "map");
            var tileset = root.FirstElement("tileset");
            var tilewidth = tileset.GetAttributeInt("tilewidth");
            var tileheight = tileset.GetAttributeInt("tileheight");
            var imagepath = Path.Combine(relative, tileset.FirstElement("image").GetAttributeString("source"));
            var image = game.fetchImage(imagepath);

            foreach (var pr in root.FirstElement("properties").ElementsNamed("property"))
            {
                string name = pr.GetAttributeString("name");
                string value = pr.GetAttributeString("value");
                properties.Add(new KeyValuePair<string, string>(name, value));
            }

            foreach (var la in root.ElementsNamed("layer"))
            {
                Layer l = new Layer(this, la, tilewidth, tileheight, image);
                if (l.Name.ToLower() == kCollisionLayerName)
                {
                    if (collisionLayer != null) throw new Exception("Multiple collision layers are not cool");
                    collisionLayer = l;
                }
                else
                {
                    addLayer(l);
                }
            }
        }

        private void addLayer(Layer l)
        {
            layers.Add(l);
        }

        Game game;

        public void render(bool renderCollision)
        {
            game.setBackgroundColor(new Color(85, 144, 222));

            game.setCenter(center);
            foreach (var x in layers) x.render(game);
            if (renderCollision && collisionLayer != null) collisionLayer.render(game);
            game.clearCenter();
        }

        public IEnumerable<Layer> Layers
        {
            get
            {
                return layers;
            }
        }

        Layer collisionLayer;
        List<Layer> layers = new List<Layer>();

        const string kObjectId = "@";
        const string kObjectProp = "object";

        public delegate LevelObject ObjectCreator(Layer.ObjectData data);

        internal void parseObjectLayers( Dictionary<string, ObjectCreator> creators )
        {
            var objProp = new Dictionary<int, ObjectCreator>();

            foreach (var p in Properties)
            {
                if (p.Key.ToLower() == kObjectProp)
                {
                    string[] data = p.Value.Split('=');
                    string name = data[1].Trim().ToLower();
                    objProp.Add(int.Parse(data[0]), creators[name]);
                }
            }

            foreach (var la in Layers)
            {
                if (la.Name.StartsWith(kObjectId))
                {
                    la.removeSprites();
                    foreach (var o in la.ObjectDatas)
                    {
                        if (o.gid != 0)
                        {
                            int idZero = o.gid - 1;
                            add(la, objProp[idZero](o));
                        }
                    }
                }
            }
        }

        private void add(Layer la, LevelObject levelObject)
        {
            la.add(levelObject);
            levelObject.world = this;
        }

        internal void update(float delta)
        {
            foreach (var x in layers) x.update(delta);
        }

        Vector2 center = new Vector2(0, 0);

        internal void suggestViewCenter(Vector2 vector2)
        {
            center = vector2;
        }
    }
}
