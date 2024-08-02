using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class GamePlay
    {
        public int playState;
        public World world;
        public GamePlay() {
            playState = 0;

            ResetWorld(null);
        }
        public virtual void Update()
        {
            if(playState == 0)
            {
                world.Update();
            }
        }

        public virtual void ResetWorld(Object o)
        {
            GameGlobals.score = 0;
            world = new World(ResetWorld);
        }

        public virtual void Draw()
        {
            if (playState == 0)
            {
                world.Draw();
            }
        }
    }
}
