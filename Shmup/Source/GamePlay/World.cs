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
        public UI ui;
        public PassObject resetGame;

        public World(PassObject reset)
        {
            
            pilot = new Pilot(new Vector2(Globals.screenWidth/2, 460), new Vector2(64, 64));
            user = new User();
            aiPlayer = new AIPlayer(user.ship);


            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassEnemy = AddEnemy;

            

            ui = new UI();

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

                user.Update(aiPlayer, Vector2.Zero);
                aiPlayer.Update(user, Vector2.Zero);
                

                for (int i = 0; i < projectiles.Count; i++) {
                    projectiles[i].Update(aiPlayer.chars.ToList<Char2D>());
                    if (projectiles[i].isHit) { 
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }
                
            }

            ui.Update(this);
        }

        public virtual void AddEnemy(object o)
        {
            aiPlayer.AddChar((Enemy)o);
        }
        public virtual void AddProjectile(object o)
        {
            projectiles.Add((Projectile) o);
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
