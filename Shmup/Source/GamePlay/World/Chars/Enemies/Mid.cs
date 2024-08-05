using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Mid:Enemy
    {
        public MyTimer shootTimer;
        //1 means it moves up
        //2 means it moves right
        //3 means it moves down
        //4 means it moves left
        public int direction;
        public Mid(Vector2 pos, int owner, int dir):base(Globals.SPRITE_PATH + "\\Enemies\\mid", pos, new Vector2(64,64), owner)
        {
            direction = dir;
            base.speed = 1.5f;
            base.health = 4f;
            if (dir == 1)
            {
                base.rot = 0;
            }
            else if (dir == 2) { 
            
                base.rot = Globals.RotateTowards(pos, new Vector2(pos.X + 50, pos.Y));
            }
            else if (dir == 3) { 
            
                base.rot = Globals.RotateTowards(pos, new Vector2(pos.X, pos.Y + 50));
            }
            else { 
                base.rot = Globals.RotateTowards(pos, new Vector2(pos.X - 50, pos.Y));
            }

            shootTimer = new MyTimer(3000);
            shootTimer.AddToTimer(2000);
        }

        public override void Update(Player enemy)
        {
            if (this.pos.X + dim.X / 2 >= Globals.screenBound.Right ||
                this.pos.Y + dim.Y / 2 >= Globals.screenBound.Bottom ||
                this.pos.X - dim.X / 2 <= Globals.screenBound.Left ||
                this.pos.Y - dim.Y / 2 <= Globals.screenBound.Top)
            {
                isDead = true;
            }
            if (direction == 1)
            {
                pos = new Vector2(pos.X, pos.Y - speed);
            }
            else if (direction == 2)
            {
                pos = new Vector2(pos.X + speed, pos.Y);
            }
            else if (direction == 3)
            {
                pos = new Vector2(pos.X, pos.Y + speed);
            }
            else if (direction == 4)
            {
                pos = new Vector2(pos.X - speed, pos.Y);
            }
            shootTimer.UpdateTimer();
            if (shootTimer.isReady())
            {
                GameGlobals.PassProjectile(new MidBullet(enemy.ship.pos, pos, this));
                shootTimer.ResetToZero();
            }
            base.Update();
        }
    }
}
