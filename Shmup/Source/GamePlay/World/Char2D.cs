using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Char2D: Regular2d
    {
        public bool isDead;
        public float hitDistance, health, healthMax;
        public Char2D(string texPath, Vector2 pos, Vector2 dim) : base(texPath, pos, dim)
        {
            isDead = false;

            health = 1;
            healthMax = health;

            hitDistance = 16f;
        }

        public override void Update()
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
