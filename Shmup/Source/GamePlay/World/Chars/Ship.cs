using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup 
{ 
    public class Ship : Char2D
    {
        private float speed;
        private MyTimer fireTimer = new MyTimer(150);
        public Ship(string texPath, Vector2 pos, Vector2 dim, int owner) : base(texPath, pos, dim, owner)
        {
            health = 5;
            healthMax = health;
            speed = 3f;
            
        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
            }
            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed, pos.Y);
            }
            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
            }
            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
            }
            if (Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectile(new Bullet(new Vector2(this.pos.X, this.pos.Y - 10), new Vector2(pos.X, pos.Y), this));
            }
            if (Globals.mouse.LeftClickHold())
            {
                fireTimer.UpdateTimer();
                if (fireTimer.isReady())
                {
                    GameGlobals.PassProjectile(new Bullet(new Vector2(this.pos.X, this.pos.Y - 10), new Vector2(pos.X, pos.Y), this));
                    fireTimer.ResetToZero();
                }
            }

            if (this.pos.X + dim.X/2 >= Globals.screenBound.Right)
            {
                this.pos.X = Globals.screenBound.Right - dim.X / 2;
            }
             if (this.pos.Y + dim.Y/2 >= Globals.screenBound.Bottom)
            {
                this.pos.Y = Globals.screenBound.Bottom - dim.Y / 2;
            }
             if (this.pos.X - dim.X / 2 <= Globals.screenBound.Left)
            {
                this.pos.X = Globals.screenBound.Left + dim.X/2;
            }
             if (this.pos.Y - dim.Y/2 <= Globals.screenBound.Top)
            {
                this.pos.Y = Globals.screenBound.Top + dim.Y /2;
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
