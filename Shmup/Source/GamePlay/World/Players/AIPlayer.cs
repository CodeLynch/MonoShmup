using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class AIPlayer : Player
    {
        Ship enemy;
        public AIPlayer(Ship enemy) : base()
        {
            spawns.Add(new Spawn(new Vector2(Globals.screenBound.Left + 20, Globals.screenBound.Top + 10), new Vector2(32, 32)));
            spawns.Add(new Spawn(new Vector2(Globals.screenBound.Right - 20, Globals.screenBound.Top + 10), new Vector2(32, 32)));
            spawns[spawns.Count - 1].coolDown.AddToTimer(8000);
            this.enemy = enemy;
        }

        public override void Update(Player enemy, Vector2 offset)
        {
          base.Update(enemy, offset);
        }

        public virtual void Draw()
        {
            if(enemy != null && !enemy.isDead)
            {

                for (int i = 0; i < chars.Count; i++)
                {
                    chars[i].Draw();
                }
                for (int i = 0; i < spawns.Count; i++)
                {
                    spawns[i].Draw();
                }
            }
        }
    }
}
