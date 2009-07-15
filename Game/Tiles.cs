using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Game
{
    class Tiles
    {
        public static Sprite CreateSprite(Image img, int gid, int mTileWidth, int mTileHeight)
        {
            const int kBase = 1;
            int index = gid - kBase;
            int tilesPerWidth = (int)(img.Width / mTileWidth);
            int left = (index % tilesPerWidth) * mTileWidth;
            int top = (index / tilesPerWidth) * mTileHeight;
            Sprite sprite = new Sprite(img);
            sprite.SubRect = new IntRect(left, top, left + mTileWidth, top + mTileHeight);
            return sprite;
        }
    }
}
