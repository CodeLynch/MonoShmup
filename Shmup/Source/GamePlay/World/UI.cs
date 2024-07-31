using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class UI
    {
        public SpriteFont font;
        public DisplayBar playerHealth;
        public UI() {
            font = Globals.content.Load<SpriteFont>("fonts\\Score");
            playerHealth = new DisplayBar(new Vector2(8, 69), 2, Color.LimeGreen);
        }
        public void Update(World w)
        {
            playerHealth.Update(w.ship.health, w.ship.healthMax);

        
        }

        public void Draw(World w)
        {
            string tempStr = "Score: " + w.score;
            //Vector2 strDim = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(0, 0), Color.LimeGreen);
            playerHealth.draw(new Vector2(Globals.screenWidth/2 - 39, 490));

        }
    }
    

}
