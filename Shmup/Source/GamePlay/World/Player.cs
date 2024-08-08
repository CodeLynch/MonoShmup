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
        public int id;
        public Ship ship;
        public List<Char2D> chars = new();
        public List<Spawn> spawns = new();
        public Player(int id) {
            this.id = id;
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
                if (!spawns[i].canSpawn)
                {
                    spawns.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddChar(Object o)
        {
            Char2D tempChar = (Char2D)o;
            tempChar.ownerID = id;
            chars.Add(tempChar);
        }

        public virtual void AddSpawnPoint(Object o){
            Spawn tempSpawn = (Spawn)o;
            tempSpawn.ownerID = id;
            spawns.Add(tempSpawn);
        }

        public List<Char2D> getAllChars()
        {
            List<Char2D> allChars = new();
            allChars.AddRange(chars.ToList<Char2D>());

            return allChars;

        }

        public virtual void SetScore(int score)
        {
            GameGlobals.score = score;
        }


    }
}
