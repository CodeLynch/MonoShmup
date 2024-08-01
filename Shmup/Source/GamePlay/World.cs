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


namespace Shmup
{
    public class World
    {
        public int score;
        public Ship ship;
        public Pilot pilot;
        public List<Projectile> projectiles = new();
        public List<Enemy> enemies = new();
        public List<Spawn> spawnpts = new();
        public UI ui;
        public PassObject resetGame;

        public World(PassObject reset)
        {
            score = 0;
            ship = new Ship(Globals.SPRITE_PATH + "vector", new Vector2(380, 390), new Vector2(32, 32));
            pilot = new Pilot(new Vector2(Globals.screenWidth/2, 460), new Vector2(64, 64));
            GameGlobals.PassProjectile = AddProjectile;
            GameGlobals.PassEnemy = AddEnemy;

            spawnpts.Add(new Spawn(new Vector2(0, 0), new Vector2(32, 32)));
            spawnpts.Add(new Spawn(new Vector2(Globals.screenWidth/2, 0), new Vector2(32, 32)));
            spawnpts[spawnpts.Count - 1].spawnTimer.AddToTimer(1000000);
            spawnpts.Add(new Spawn(new Vector2(Globals.screenWidth, 0), new Vector2(32, 32)));
            spawnpts[spawnpts.Count - 1].spawnTimer.AddToTimer(5000000);

            ui = new UI();

            resetGame = reset;
        }

        public virtual void Update()
        {
            if (ship.isDead) {
                if (Globals.keyboard.GetPress("Enter"))
                {
                    resetGame(null);
                }
            }
            else
            {

            ship.Update();

            for (int i = 0; i < spawnpts.Count; i++)
            {
                spawnpts[i].Update();
            }

            for (int i = 0; i < projectiles.Count; i++) {
                projectiles[i].Update(enemies.ToList<Char2D>());
                if (projectiles[i].isHit) { 
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(ship);
                if (enemies[i].isDead)
                {
                    score += 5;
                    enemies.RemoveAt(i);
                    i--;
                }
            }
            }

            ui.Update(this);
        }

        public virtual void AddEnemy(object o)
        {
            enemies.Add((Enemy)o);
        }
        public virtual void AddProjectile(object o)
        {
            projectiles.Add((Projectile) o);
        }

        public virtual void Draw()
        {

            if (!ship.isDead) { 
                ship.Draw();
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Draw();
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Draw();
                }
                for (int i = 0; i < spawnpts.Count; i++)
                {
                    spawnpts[i].Draw();
                }
            }

            pilot.Draw();
            ui.Draw(this);
        }


    }
}
