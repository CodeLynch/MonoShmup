using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Pilot: Regular2d
    {
        public Pilot(Vector2 pos, Vector2 dim):base(Globals.SPRITE_PATH + "\\face\\pilot", pos, dim)
        {
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
