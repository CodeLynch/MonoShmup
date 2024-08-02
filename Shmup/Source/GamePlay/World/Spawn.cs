using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Spawn: Regular2d
    {
        public MyTimer burstTimer = new MyTimer(100);
        public MyTimer coolDown = new MyTimer(3000);
        private int counter = 0;
        private bool canSpawn = false;
        public Spawn(Vector2 pos, Vector2 dim) : base(Globals.SPRITE_PATH + "\\enemies\\popcorn", pos, dim)
        {
        }

        public override void Update() {
            coolDown.UpdateTimer();
            if (coolDown.isReady())
            {
                canSpawn = !canSpawn;
                coolDown.ResetToZero();
            }
            if (canSpawn)
            {
                burstTimer.UpdateTimer();
                if (burstTimer.isReady()) { 
                counter++;
                if(counter > 5)
                    {
                        Debug.WriteLine("spawn limit.");
                    }
                    else
                    {
                        SpawnEnemy();
                    }
                burstTimer.ResetToZero();
                }
            }
            else
            {
                counter = 0;
            }
           

            
            base.Update();
        
        }

        public virtual void SpawnEnemy()
        {
           
            GameGlobals.PassEnemy(new Popcorn(pos));
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
