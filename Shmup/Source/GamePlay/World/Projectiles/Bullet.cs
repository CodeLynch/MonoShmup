﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Bullet : Projectile
    {
        public Bullet(Vector2 tar, Vector2 pos, Char2D owner) : base(Globals.SPRITE_PATH + "\\projectiles\\bullet", pos, new Vector2(8,8), owner, tar)

        {
        }

        public override void Update(List<Char2D> hits)
        {
            base.Update(hits);
        }

        public override bool DidHit(List<Char2D> hits)
        {
            for (int i = 0; i < hits.Count; i++)
            {
                if (Vector2.Distance(this.pos, hits[i].pos) < hits[i].hitDistance && hits[i].ownerID != 1)
                {
                    hits[i].TakeDamage(1f);
                    SetScore(GameGlobals.score + 1);
                    if (hits[i].isDead)
                    {
                        SetScore(GameGlobals.score + 2);
                    }
                    return true;
                }
            }
            return false;
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
