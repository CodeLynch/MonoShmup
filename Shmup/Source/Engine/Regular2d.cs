using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Shmup
{
    public class Regular2d
    {
        public float rot;
        public Vector2 pos, dim;
        public Texture2D tex;
        public Regular2d(string texturePath, Vector2 pos, Vector2 dim) {
        
            this.pos = pos;
            this.dim = dim;
            if(texturePath != "none")
            {
                tex = Globals.content.Load<Texture2D>(texturePath);
            }
            else
            {
                
                tex = new Texture2D(Globals.spriteBatch.GraphicsDevice, 1, 1);
                tex.SetData<Color>(new Color[] { Color.Transparent });
            }
        }

        public virtual void Update(){

        }
        public virtual void Draw() {
            if (tex != null) {
                Globals.spriteBatch.Draw(tex, new Rectangle((int)(pos.X), (int)(pos.Y), (int)(dim.X), (int)(dim.Y)), null, Color.White, rot, new Vector2(tex.Bounds.Width/2, tex.Bounds.Height/2), new SpriteEffects(), 0);
            }
        }
        public virtual void Draw(Vector2 offset)
        {
            if (tex != null)
            {
                Globals.spriteBatch.Draw(tex, new Rectangle((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), (int)(dim.X), (int)(dim.Y)), null, Color.White, rot, new Vector2(tex.Bounds.Width / 2, tex.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
        public virtual void Draw(Vector2 offset, Vector2 origin, Color col)
        {
            if (tex != null)
            {
                Globals.spriteBatch.Draw(tex, new Rectangle((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), (int)(dim.X), (int)(dim.Y)), null, col, rot, new Vector2(origin.X, origin.Y), new SpriteEffects(), 0);
            }
        }
    }
}
