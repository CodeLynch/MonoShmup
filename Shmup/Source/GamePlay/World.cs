using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shmup;
using System.Diagnostics;


namespace Shmup
{
    public class World
    {
        public User user;
        public AIPlayer aiPlayer;
        public Pilot pilot;
        public List<Projectile> projectiles = new();
        public List<Char2D> allChars = new();
        public UI ui;
        public PassObject resetGame, setGameState;

        public World(PassObject reset, PassObject setGameState)
        {
            
            pilot = new Pilot(new Vector2(Globals.screenWidth/2, 460), new Vector2(64, 64));
            LoadData(1);

            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassEnemy = AddChar;
            GameGlobals.PassSpawn = AddSpawn;
            GameGlobals.paused = false;
            this.setGameState = setGameState;

            ui = new UI(reset);

            resetGame = reset;
        }

        public virtual void Update()
        {
            if (user.ship.isDead) {
                if (Globals.keyboard.GetPress("Enter"))
                {
                    resetGame(null);
                }
            }
            else
            {
                if (!GameGlobals.paused)
                {
                    allChars.Clear();
                    allChars.AddRange(user.getAllChars());
                    allChars.AddRange(aiPlayer.getAllChars());

                    user.Update(aiPlayer, Vector2.Zero);
                    aiPlayer.Update(user, Vector2.Zero);

                    allChars.Add(user.ship);
                    for (int i = 0; i < projectiles.Count; i++) {
                        projectiles[i].Update(allChars);
                        if (projectiles[i].isHit) { 
                            projectiles.RemoveAt(i);
                            i--;
                        }
                    }
                }
                if (Globals.keyboard.GetSinglepress("Space"))
                {
                    GameGlobals.paused = !GameGlobals.paused;
                }
                if (Globals.keyboard.GetSinglepress("Back"))
                {
                    resetGame(null);
                    setGameState(0);
                }
            }

            ui.Update(this);
        }

        public virtual void AddChar(object o)
        {
            Char2D tempChar = (Char2D) o;
            if(tempChar.ownerID == user.id)
            {
                user.AddChar(tempChar);
            }
            else if(tempChar.ownerID == aiPlayer.id)
            {
                aiPlayer.AddChar((Char2D)o);
            }

            //aiPlayer.AddChar((Enemy)o);
        }
        public virtual void AddSpawn(object o)
        {
            Spawn tempSpawn = (Spawn)o;
            if (tempSpawn.ownerID == user.id)
            {
                user.AddSpawnPoint(tempSpawn);
            }
            else if (tempSpawn.ownerID == aiPlayer.id)
            {
                aiPlayer.AddSpawnPoint((Enemy)o);
            }

            //aiPlayer.AddChar((Enemy)o);
        }
        public virtual void AddProjectile(object o)
        {
            projectiles.Add((Projectile) o);
        }

        public virtual void LoadData(int level)
        {
            XDocument xml = XDocument.Load("XML\\Levels\\Level" + level + ".xml");
            XElement tempElem = null;
            if(xml.Element("Root").Element("User") != null)
            {
                tempElem = xml.Element("Root").Element("User");
            }
            user = new User(1, tempElem);

            tempElem = null;
            if (xml.Element("Root").Element("AIPlayer") != null)
            {
                tempElem = xml.Element("Root").Element("AIPlayer");
            }

            aiPlayer = new AIPlayer(user.ship, 2, tempElem);

        }

        public virtual void Draw()
        {

            if (!user.ship.isDead) { 
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Draw();
                }
               
               
            }

            pilot.Draw();
            user.Draw();
            aiPlayer.Draw();
            ui.Draw(this);
        }


    }
}
