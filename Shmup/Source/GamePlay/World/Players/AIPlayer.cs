using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shmup
{
    public class AIPlayer : Player
    {
        Ship enemy;

        public AIPlayer(Ship enemy, int id, XElement data) : base(id, data)
        {
            /*spawns.Add(new PopcornSpawn(new Vector2(Globals.screenBound.Right - 20, Globals.screenBound.Top + 10), new Vector2(32, 32), id));
            spawns.Add(new MidSpawn(new Vector2(Globals.screenBound.Left + 52, Globals.screenBound.Top + 40), new Vector2(32, 32), id, 2));
            spawns[spawns.Count - 1].coolDown.AddToTimer(8000);*/
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
