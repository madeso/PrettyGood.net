using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using PrettyGood.Util;

namespace Game
{
    public class Animation
    {
        List<Sprite> sprites = new List<Sprite>();
        float timePerFrame;
        float currentFrameTime=0;
        int index = 0;

        public Animation(Game g, string file, string animationName)
        {
            var x = Xml.Open(Xml.FromFile(file), "animations");
            var sx = x.ElementsNamed("animation", animationName).FirstOrNull();
            if( sx == null ) throw new Exception(file + " does not contain " + animationName);

            timePerFrame = sx.GetAttributeFloat("time");

            int size = sx.GetAttributeInt("size");
            string img = sx.GetAttributeString("img");
            int start = sx.GetAttributeInt("start");
            int end = sx.GetAttributeInt("end");

            if (end < start) throw new Exception("end < start");

            for (int spriteIndex = start; spriteIndex <= end; ++spriteIndex)
            {
                sprites.Add(Tiles.CreateSprite(g.fetchImage(img), spriteIndex, size, size));
            }

            reset();
        }

        public void frame(float delta)
        {
            currentFrameTime += delta;
            while (currentFrameTime > timePerFrame)
            {
                currentFrameTime -= timePerFrame;
                index = (index + 1) % sprites.Count;
            }
        }

        public void reset()
        {
            index = 0;
            currentFrameTime = 0;
        }

        public void render(Game g, Vector2 pos)
        {
            var s = CurrentSprite;
            s.Position = pos;
            g.draw(s);
        }

        Sprite CurrentSprite
        {
            get
            {
                return sprites[index];
            }
        }
    }
}
