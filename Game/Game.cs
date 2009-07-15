using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Game
{
    public class Game : IDisposable
    {
        internal void frameSystems(float delta)
        {
            // frame global stuff such as audio & physics...
        }

        internal void processEvents()
        {
            //System.Windows.Forms.Application.DoEvents(); // don't call this - it screws with the escape/tab characters :(
            window.DispatchEvents();
        }

        internal void sendEvents(Loop loop)
        {
            loop.onRender();
        }

        RenderWindow window;

        public Game(VideoMode mode, bool fullscreen)
        {
            Styles st = Styles.Titlebar;
            //if (fullscreen) st = Styles.Fullscreen;
            window = new RenderWindow(new VideoMode(640, 480), "", st);
            window.EnableKeyRepeat(false);

            window.KeyPressed += new EventHandler<KeyEventArgs>(window_KeyPressed);
            window.KeyReleased += new EventHandler<KeyEventArgs>(window_KeyReleased);
        }

        void window_KeyReleased(object sender, KeyEventArgs e)
        {
            Loop.InnerMostLoop.onKey(e.Code, false);
        }

        void window_KeyPressed(object sender, KeyEventArgs e)
        {
            Loop.InnerMostLoop.onKey(e.Code, true);
        }

        internal void render()
        {
            window.Clear(bkg);
            Loop.InnerMostLoop.onRender();
            window.Display();
        }

        public void Dispose()
        {
            foreach (var x in images) x.Value.Dispose();
            images.Clear();
            window.Dispose();
        }

        Dictionary<string, Image> images = new Dictionary<string, Image>();

        internal Image loadImage(string p)
        {
            if (images.ContainsKey(p)) return images[p];
            Image img = new Image(p);
            images.Add(p, img);
            return img;
        }

        internal void draw(Drawable sp)
        {
            window.Draw(sp);
        }

        Color bkg = Color.Black;
        internal void setBackgroundColor(Color color)
        {
            bkg = color;
        }
    }
}
