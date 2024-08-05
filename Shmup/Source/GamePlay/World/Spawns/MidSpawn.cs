using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class MidSpawn: Spawn
    {
        //1 means it moves up
        //2 means it moves right
        //3 means it moves down
        //4 means it moves left
        public int direction;
        public MidSpawn(Vector2 pos, Vector2 dim, int owner, int dir) : base(pos, dim, owner)
        {
            direction = dir;
            ownerID = owner;
            coolDown = new MyTimer(2000);
        }

        public override void Update()
        {
            if (canSpawn)
            {
                coolDown.UpdateTimer();
                if (coolDown.isReady())
                {
                    SpawnEnemy();
                    coolDown.ResetToZero();
                }
            }
        }

        public override void SpawnEnemy()
        {
            Enemy tempEnemy = new Mid(pos, ownerID, direction);
            if (tempEnemy != null)
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
