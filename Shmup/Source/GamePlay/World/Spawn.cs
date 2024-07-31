using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Spawn: Regular2d
    {
        public MyTimer spawnTimer = new MyTimer(2500);
        public Spawn(Vector2 pos, Vector2 dim) : base(Globals.SPRITE_PATH + "\\enemies\\popcorn", pos, dim)
        {
        }

        public override void Update() {

            spawnTimer.UpdateTimer();
            if (spawnTimer.isReady())
            {
                SpawnEnemy();
                spawnTimer.ResetToZero();
            }
            base.Update();
        
        }

        public virtual void SpawnEnemy()
        {
            //   GameGlobals.PassEnemy(new Popcorn(new Vector2(pos.X, pos.Y)));
            GameGlobals.PassEnemy(new Popcorn(pos));
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
