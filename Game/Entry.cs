using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;

namespace Game
{
    static class Entry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Launcher());

            Launcher l = new Launcher();
            if (l.ShowDialog() == DialogResult.OK)
            {
                using (var game = new Game(l.Mode, l.Fullscreen))
                {
                    using (var loop = new nms.GameLoop(game))
                    {
                        Loop.DoLoop(loop);
                    }
                }
            }
        }
    }
}
