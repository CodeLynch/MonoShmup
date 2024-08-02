using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Shmup
{
    public class Player
    {
        public Ship ship;
        public List<Char2D> chars = new();
        public List<Spawn> spawns = new();
        public Player() {
        }

        public virtual void Update(Player enemy, Vector2 offset) {
            if (ship != null)
            {
                ship.Update();
            }

            for (int i = 0; i < chars.Count; i++)
            {
                chars[i].Update(enemy);
                if (chars[i].isDead)
                {                    
                    chars.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < spawns.Count; i++)
            {
                spawns[i].Update();
            }
        }

        public virtual void AddChar(Object o)
        {

            chars.Add((Char2D)o);
        }

        public virtual void SetScore(int score)
        {
            GameGlobals.score = score;
        }


    }
}
