using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Popcorn:Enemy
    {
        public Popcorn(Vector2 pos) : base(Globals.SPRITE_PATH + "\\Enemies\\Popcorn", pos, new Vector2(16,16))
        {
            Random r = new Random();
            float min = 2.0f;
            float max = 4.0f;
            float randomFloat = (float)(r.NextDouble() * (max - min) + min);

            base.speed = randomFloat;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
