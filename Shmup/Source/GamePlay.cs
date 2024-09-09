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
        public PassObject setGameState;
        public GamePlay(PassObject setGameState) {
            playState = 0;
            this.setGameState = setGameState;
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
            world = new World(ResetWorld, setGameState);
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
