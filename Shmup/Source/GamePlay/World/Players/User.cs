using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shmup
{
    public class User : Player
    {

        public User(int id, XElement data) : base(id, data)
        {
            //this.ship = new Ship(Globals.SPRITE_PATH + "vector", new Vector2(380, 390), new Vector2(32, 32), id);
            
        }

        public override void Update(Player enemy, Vector2 offset)
        {
            base.Update(enemy, offset); 
        }

        public virtual void Draw()
        {
            if (ship != null && !ship.isDead)
            {
                ship.Draw();
            }
        }

    }
}
