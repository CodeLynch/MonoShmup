using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Bound
    {
        private static Texture2D _pointTexture;
        public int lineWidth;
        public Rectangle boundRec;
        public Bound(Rectangle bounds, int lineWidth) { 
            this.lineWidth = lineWidth;
            boundRec = bounds;

        }
        public void DrawRectangle(SpriteBatch spriteBatch, Color color)
        {
            
             _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
             _pointTexture.SetData<Color>(new Color[] { Color.White });
            spriteBatch.Draw(_pointTexture, new Rectangle(boundRec.X, boundRec.Y, lineWidth, boundRec.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(boundRec.X, boundRec.Y, boundRec  .Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(boundRec.X + boundRec.Width, boundRec.Y, lineWidth, boundRec.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(boundRec.X, boundRec.Y + boundRec.Height, boundRec.Width + lineWidth, lineWidth), color);
        }
    }
}
