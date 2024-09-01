using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shmup
{
    public class UI
    {
        public Regular2d pauseOverlay;
        public Button2d resetButton;
        public SpriteFont font;
        public DisplayBar playerHealth;
        public UI(PassObject reset) {
            pauseOverlay = new Regular2d(Globals.SPRITE_PATH + "\\UI\\pause", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 - 32), new Vector2(64, 64));
            font = Globals.content.Load<SpriteFont>("fonts\\Score");
            playerHealth = new DisplayBar(new Vector2(8, 69), 2, Color.LimeGreen);
            resetButton = new Button2d(Globals.SPRITE_PATH + "\\UI\\button", new Vector2(Globals.screenWidth/2 , Globals.screenHeight/2 + 25), new Vector2(140, 50), "fonts\\SmallScore", "Reset Game", reset , "");
        }
        public void Update(World w)
        {
            playerHealth.Update(w.user.ship.health, w.user.ship.healthMax);
            if (w.user.ship.isDead)
            {
                resetButton.Update();
            }
        }

        public void Draw(World w)
        {
            Globals.baseEffect.Parameters["xSize"].SetValue(1.0f);
            Globals.baseEffect.Parameters["ySize"].SetValue(1.0f);
            Globals.baseEffect.Parameters["xDraw"].SetValue(1.0f);
            Globals.baseEffect.Parameters["yDraw"].SetValue(1.0f);
            Globals.baseEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.baseEffect.CurrentTechnique.Passes[0].Apply();

            string tempStr = "Score: " + GameGlobals.score;
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(50, 10), Color.LimeGreen);
            playerHealth.draw(new Vector2(Globals.screenWidth/2 - 39, 490));

            if (w.user.ship.isDead)
            {
                tempStr = "YOU ARE DEAD";
                Vector2 strDim = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth/2 - strDim.X/2, Globals.screenHeight/2 - 50), Color.LimeGreen);
                resetButton.Draw();
            }
            if (GameGlobals.paused)
            {
                tempStr = "PAUSED";
                Vector2 strDim = font.MeasureString(tempStr);
                Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDim.X / 2, Globals.screenHeight / 2 - 120), Color.LimeGreen);

                pauseOverlay.Draw();
            }
            
        }
    }
    

}
