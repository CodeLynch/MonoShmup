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
            base.speed = 4.5f;
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
