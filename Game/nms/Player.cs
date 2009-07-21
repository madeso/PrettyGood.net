using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace Game.nms
{
    class Player : LevelObject
    {
        Vector2 pos = new Vector2(0,0);
        GameLoop loop;
        float yVel = 0;
        int bonusJumps = 0;
        State state = State.Idle;

        class AnimationGroup
        {
            public Animation anIdle;
            public Animation anMove;
            public Animation anJumping;
            public Animation anFalling;
        }

        // left=0, right = 1
        AnimationGroup[] anims;
        
        bool facingRight = true;

        // SFML.Graphics.Font font
        //String2D text;
        //Font font;

        State CurrentState
        {
            get
            {
                return state;
            }
            set
            {
                bool changed = state != value;
                state = value;
                if( changed ) CurrentAnimation.reset();
            }
        }

        enum State
        {
            Idle,
            Move,
            Jumping,
            Falling
        }

        Animation CurrentAnimation
        {
            get
            {
                AnimationGroup a = anims[ facingRight?1:0 ];
                switch (CurrentState)
                {
                    case State.Idle: return a.anIdle;
                    case State.Move: return a.anMove;
                    case State.Jumping: return a.anJumping;
                    case State.Falling: return a.anFalling;
                    default: throw new Exception("epic fail in animation/state selection");
                }
            }
        }

        public Player(Game g, GameLoop loop, Layer.ObjectData da)
        {
            this.loop = loop;
            anims = new AnimationGroup[] {
                new AnimationGroup { 
                    anIdle = new Animation(g, Constants.kAnimationFile, "idleLeft"),
                    anMove = new Animation(g, Constants.kAnimationFile, "moveLeft"),
                    anJumping = new Animation(g, Constants.kAnimationFile, "jumpingLeft"),
                    anFalling = new Animation(g, Constants.kAnimationFile, "fallingLeft")
                },
                new AnimationGroup { 
                    anIdle = new Animation(g, Constants.kAnimationFile, "idleRight"),
                    anMove = new Animation(g, Constants.kAnimationFile, "moveRight"),
                    anJumping = new Animation(g, Constants.kAnimationFile, "jumpingRight"),
                    anFalling = new Animation(g, Constants.kAnimationFile, "fallingRight")
                }
            };

            pos = da.pos;
            //font = new Font("cheeseburger.ttf");
            //text = new String2D("", Font.DefaultFont);
        }

        public override void draw(Game g)
        {
            CurrentAnimation.render(g, pos);
            //text.Position = pos;
            //g.draw(text);
        }

        private void applyPlayerMovement(float delta, float input)
        {
            float movx = input * Constants.kPlayerSpeed * delta;
            float x = pos.X;
            float y = pos.Y;
            var re = world.CollisionLayer.moveObject(ref x, ref y, Constants.kTileSize, Constants.kTileSize, movx, 0);

            if (Math.Abs(input) > 0.1)
            {
                facingRight = input > 0;
            }

            pos = new Vector2(x, y);
        }

        public override void update(float delta)
        {
            float move = loop.rightLeftMovement.Value;
            applyPlayerMovement(delta, move);
            applyGravityAndbasicJump(delta, move);
            world.suggestViewCenter(pos);
            CurrentAnimation.frame(delta);
        }

        private void applyGravityAndbasicJump(float delta, float move)
        {
            float y = pos.Y;
            float x = pos.X;
            var re = world.CollisionLayer.moveObject(ref x, ref y, Constants.kTileSize, Constants.kTileSize, 0, yVel * delta);
            pos = new Vector2(pos.X, y);
            bool onGround = false;
            if (re.Y)
            {
                //if (yVel >= -18) onGround = true;
                yVel = 0;
                bonusJumps = Constants.kNumberOfBonusJumps;
            }
            else
            {
                yVel += Constants.kGravity;
            }

			yVel = MathUtil.MaxMin(-Constants.kMaxSpeed, yVel, Constants.kMaxSpeed);

            float tempx;
            float tempy;
            onGround = false == world.CollisionLayer.placeFree(pos.X, y + Constants.kJumpTest, Constants.kTileSize, Constants.kTileSize, out tempx, out tempy);

            bool isMoving = Math.Abs(move) > 0.1;

            if( onGround )
            {
                CurrentState = isMoving ? State.Move : State.Idle;
            }
            else 
            {
                CurrentState = yVel > 0.0 ? State.Falling : State.Jumping;
            }

            if (onGround && loop.jumpButton.IsHit)
            {
                yVel = -Constants.kJumpSpeed;
            }
            else if (Math.Abs(yVel) < Constants.kBonusJumpEpsilon && loop.jumpButton.IsHit && bonusJumps > 0)
            {
                yVel = -Constants.kJumpSpeed;
                bonusJumps -= 1;
            }

            //text.Text = string.Format("{0} / {1}", onGround, yVel);
        }

        public override void Dispose()
        {
            //text.Dispose();
            //font.Dispose();
        }
    }
}
