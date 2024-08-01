using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup 
{ 
    public class Ship : Char2D
    {
        private float speed;
        private MyTimer fireTimer = new MyTimer(150);
        public Ship(string texPath, Vector2 pos, Vector2 dim) : base(texPath, pos, dim)
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

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
