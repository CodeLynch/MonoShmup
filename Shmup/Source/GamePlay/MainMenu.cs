using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Shmup
{
    public class MainMenu
    {
        public Regular2d bg;
        public PassObject playGame, exitGame;
        public List<Button2d> buttons = new List<Button2d>();
        public MainMenu(PassObject playDelegate, PassObject exitDelegate)
        {
            playGame = playDelegate;
            exitGame = exitDelegate;
            bg = new Regular2d(Globals.SPRITE_PATH + "\\ui\\backgrounds\\tempBg", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2 ), new Vector2(800, 600));
            buttons.Add(new Button2d(Globals.SPRITE_PATH + "\\ui\\button", new Vector2(Globals.screenWidth/2, 400), new Vector2(128, 32), "fonts\\SmallScore", "Play", playDelegate, 1));
            buttons.Add(new Button2d(Globals.SPRITE_PATH + "\\ui\\button", new Vector2(Globals.screenWidth/2, 440), new Vector2(128, 32), "fonts\\SmallScore", "Exit", exitDelegate, null));

        }

        public virtual void Update()
        {
            for(int i=0; i < buttons.Count; i++) {
                buttons[i].Update();
            }

        }

        public virtual void Draw()
        {
            bg.Draw();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw();
            }

        }
    }
}
