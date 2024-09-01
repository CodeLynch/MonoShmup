using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Char2D: Regular2d
    {
        public int ownerID;
        public bool isDead;
        public float hitDistance, health, healthMax;
        public Char2D(string texPath, Vector2 pos, Vector2 dim, int owner) : base(texPath, pos, dim)
        {
            ownerID = owner;
            isDead = false;
            health = 1;
            healthMax = health;

            hitDistance = 16f;
        }

        public virtual void Update(Player enemy)
        {
            base.Update();
        }
        public virtual void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0) { 
                isDead = true;
            }
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
