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
        public Popcorn(Vector2 pos, int owner) : base(Globals.SPRITE_PATH + "\\Enemies\\Popcorn", pos, new Vector2(16,16), owner)
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
            Globals.baseEffect.Parameters["xSize"].SetValue((float)this.tex.Bounds.Width);
            Globals.baseEffect.Parameters["ySize"].SetValue((float)this.tex.Bounds.Height);
            Globals.baseEffect.Parameters["xDraw"].SetValue((float)this.dim.X);
            Globals.baseEffect.Parameters["yDraw"].SetValue((float)this.dim.Y);
            Globals.baseEffect.Parameters["filterColor"].SetValue(Color.Yellow.ToVector4());
            Globals.baseEffect.CurrentTechnique.Passes[0].Apply();
            base.Draw();
        }
    }
}
