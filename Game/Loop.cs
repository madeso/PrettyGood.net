using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Game
{
    public abstract class Loop
    {
        private class InnerMost : IDisposable
        {
            Loop old;
            public static Loop Loop = null;

            public InnerMost(Loop loop)
            {
                old = Loop;
                Loop = loop;
            }

            public void Dispose()
            {
                Loop = old;
            }
        }

       protected Game game
        {
            get;
            private set;
        }

        public Loop(Game game)
        {
            outer = InnerMostLoop;
            this.game = game;
        }

        public abstract void onUpdate(float delta);
        public abstract void onRender();
        public abstract void onKey(KeyCode key, bool down);
        public abstract void onAxis();

        public static void DoLoop(Loop loop)
        {
            using (InnerMost im = new InnerMost(loop))
            {
                loop.beginLoop();
                while (loop.isLooping)
                {
                    loop.game.render();
                    float delta = loop.calculateDelta();
                    loop.game.frameSystems(delta);
                    loop.game.processEvents();
                    loop.game.sendEvents(loop);
                    loop.onUpdate(delta);
                }
            }
        }
        public static Loop InnerMostLoop
        {
            get
            {
                return InnerMost.Loop;
            }
        }

        protected void renderOuter()
        {
            if (outer != null) outer.onRender();
        }
        protected void sendKey(KeyCode key, bool down)
        {
            if (outer != null) outer.onKey(key, down);
        }
        protected void sendAxis()
        {
            if (outer != null) outer.onAxis();
        }
        protected void abort()
        {
            keepLooping = false;
        }
        bool isLooping
        {
            get
            {
                return keepLooping;
            }
        }
        protected void doSubLoop(Loop loop)
        {
            enterSubLoop();
            DoLoop(loop);
            leaveSubLoop();
        }

        void beginLoop()
        {
            timer.Reset();
        }

        float calculateDelta()
        {
            addCurrentToDelta();
            float delta = passedTime;
            passedTime = 0;
            return delta;
        }

        private void addCurrentToDelta()
        {
            passedTime += timer.GetElapsedTime();
            timer.Reset();
        }

        void enterSubLoop()
        {
            addCurrentToDelta();
        }

        void leaveSubLoop()
        {
            timer.Reset();
        }

        Clock timer = new Clock();
        float passedTime = 0;
        private Loop outer = null;
        private bool keepLooping = true;
    }
}
