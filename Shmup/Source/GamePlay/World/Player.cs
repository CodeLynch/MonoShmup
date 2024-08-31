using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Shmup
{
    public class Player
    {
        public int id;
        public Ship ship;
        public List<Char2D> chars = new();
        public List<Spawn> spawns = new();
        public Player(int id, XElement Data) {
            this.id = id;
            LoadData(Data);
        }

        public void LoadData(XElement data)
        {
            List<XElement> spawnData = (from tag in data.Descendants("SpawnPoint") select tag).ToList<XElement>();

            Type sType = null;

            foreach (XElement spawn in spawnData)
            {
                sType = Type.GetType("Shmup."+ spawn.Element("Type").Value, true);

           
                spawns.Add((Spawn)Activator.CreateInstance(
                    sType, new Vector2(
                            Convert.ToInt32(
                                spawn.Element("Pos").Element("x").Value, Globals.culture),
                            Convert.ToInt32(
                                spawn.Element("Pos").Element("y").Value, Globals.culture)
                            ), new Vector2(32, 32), id)
                    );
                spawns[spawns.Count - 1].coolDown.AddToTimer(Convert.ToInt32(
                                spawn.Element("TimerAdd").Value, Globals.culture));
            }

            if(data.Element("Ship") != null)
            {
                ship = new Ship(Globals.SPRITE_PATH + "vector", new Vector2(Convert.ToInt32(
                                data.Element("Ship").Element("Pos").Element("x").Value, Globals.culture),
                            Convert.ToInt32(
                                data.Element("Ship").Element("Pos").Element("y").Value, Globals.culture)
                            ), new Vector2(32, 32), id);
            }
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
