using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shmup
{
    public class DisplayBar
    {
        public int border;
        public Regular2d bar, barBg;
        public Color color;

        public DisplayBar(Vector2 dims, int border, Color col)
        {
            this.border = border;
            color = col;
            bar = new Regular2d(Globals.SPRITE_PATH + "\\UI\\box", new Vector2(0, 0), new Vector2(dims.X - border * 2, dims.Y - border * 2));
            barBg = new Regular2d(Globals.SPRITE_PATH + "\\UI\\box", new Vector2(0, 0), new Vector2(dims.X, dims.Y));
            bar.rot = 3.14193f;
            barBg.rot = 3.14193f;
        }

        public virtual void Update(float current, float max)
        {
            bar.dim = new Vector2(bar.dim.X, current / max * (barBg.dim.Y - border * 2));
        }

        public virtual void draw(Vector2 offset)
        {
            barBg.Draw(offset, Vector2.Zero, Color.Black);
            bar.Draw( new Vector2(offset.X + border, offset.Y + border), Vector2.Zero, color);
        }

    }
}
