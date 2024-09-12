using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Pilot: Regular2d
    {
        private List<Texture2D> faces = new List<Texture2D>();
        private Texture2D currentFace;

        public Pilot(Vector2 pos, Vector2 dim):base(Globals.SPRITE_PATH + "\\face\\pilot", pos, dim)
        {
            faces.Add(Globals.content.Load<Texture2D>(Globals.SPRITE_PATH + "\\face\\pilot"));
            faces.Add(Globals.content.Load<Texture2D>(Globals.SPRITE_PATH + "\\face\\pilot2"));
            faces.Add(Globals.content.Load<Texture2D>(Globals.SPRITE_PATH + "\\face\\pilot3"));
            currentFace = faces[0];
        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("A"))
            {
                currentFace = faces[2];
            }
            else if (Globals.keyboard.GetPress("D"))
            {
                
                currentFace = faces[1];
            }
            else
            {
                currentFace = faces[0];
            }
            base.Update();
        }

        public override void Draw()
        {
            Globals.spriteBatch.Draw(currentFace, new Rectangle((int)(pos.X), (int)(pos.Y), (int)(dim.X), (int)(dim.Y)), null, Color.White, rot, new Vector2(currentFace.Bounds.Width / 2, currentFace.Bounds.Height / 2), new SpriteEffects(), 0);
            
        }
    }
}
