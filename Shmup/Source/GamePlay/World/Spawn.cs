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
        public int ownerID;
        public MyTimer coolDown;
        public bool canSpawn = true;
        
        public Spawn(Vector2 pos, Vector2 dim, int owner) : base("none", pos, dim)
        {
            ownerID = owner;   
        }

        public override void Update() {
            base.Update();
        }

        public virtual void SpawnEnemy()
        {

        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
