using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class PopcornSpawn : Spawn
    {
        private int counter = 0;
        private bool burst = false;
        private MyTimer burstTimer = new MyTimer(500);
        public PopcornSpawn(Vector2 pos, Vector2 dim, int owner) : base(pos, dim, owner)
        {
            ownerID = owner;
            coolDown = new MyTimer(5000);
        }

        public override void Update()
        {
            if (canSpawn)
            {
                coolDown.UpdateTimer();
                if (coolDown.isReady())
                {
                    burst = !burst;
                }
                if (burst)
                {
                    burstTimer.UpdateTimer();
                    if (burstTimer.isReady())
                    {
                        if(counter < 5)
                        {
                            SpawnEnemy();
                            counter++;
                        }
                        else
                        {
                            //canSpawn = false
                            burst = false;
                            coolDown.ResetToZero();
                            burstTimer.ResetToZero();
                            counter = 0;
                        }
                    }
                }
            }
            base.Update();

        }

        public override void SpawnEnemy()
        {
            Console.WriteLine("this is the pos " + base.pos);
            Enemy tempEnemy = new Popcorn(pos, ownerID);
            if(tempEnemy != null)
            {
                GameGlobals.PassEnemy(tempEnemy);
            }
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
