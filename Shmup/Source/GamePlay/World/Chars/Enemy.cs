﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Enemy: Char2D
    {
        public float speed;
        public Enemy(string texPath,Vector2 pos, Vector2 dim, int owner): base(texPath, pos, dim, owner)
        {
            speed = 2f;
        }

        public override void Update(Player enemy)
        {
            
            AI(enemy.ship);
            base.Update();
        }

        public virtual void AI(Ship ship)
        {
            pos += Globals.RadialMovement(ship.pos, pos, speed);
            rot = Globals.RotateTowards(pos, ship.pos);

            if (Vector2.Distance(this.pos, ship.pos) < 16) 
            {
                ship.TakeDamage(1f);
                isDead = true;
            }
        }

       
        public override void Draw()
        {
            base.Draw();
        }
    }
}
