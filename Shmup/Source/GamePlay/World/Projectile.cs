using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Projectile: Regular2d
    {
        public bool isHit;
        public float speed;
        public Vector2 direction;
        public Char2D owner;
        public MyTimer timer;
        

        public Projectile(string texPath, Vector2 pos, Vector2 dim, Char2D owner, Vector2 tar ): base(texPath, pos, dim) {

            isHit = false;
            speed = 10f;
            this.owner = owner;

            direction = tar - this.owner.pos;
            direction.Normalize();
            timer = new MyTimer(700);
        }

        public virtual void Update(List<Char2D> hits)
        {
            pos += direction * speed;
            timer.UpdateTimer();
            if (timer.isReady())
            {
                isHit = true;
            }
            if (DidHit(hits))
            {
                isHit = true;
            }
            if(pos.X >= Globals.screenBound.Right || 
                pos.Y >= Globals.screenBound.Bottom || 
                pos.X <= Globals.screenBound.Left || 
                pos.Y <= Globals.screenBound.Top)
            {
                isHit = true;
            }
        }

        public virtual bool DidHit(List<Char2D> hits) {
            for(int i = 0; i < hits.Count; i++)
            {
                if(Vector2.Distance(this.pos, hits[i].pos) < hits[i].hitDistance)
                {
                    hits[i].TakeDamage(1f);
                    SetScore(GameGlobals.score + 1);
                    if (hits[i].isDead)
                    {
                        SetScore(GameGlobals.score + 2);
                    }
                    return true;
                }
            }
            return false;
        }

        public override void Draw()
        {
            /*Globals.baseEffect.Parameters["xSize"].SetValue((float)tex.Bounds.Width);
            Globals.baseEffect.Parameters["ySize"].SetValue((float)tex.Bounds.Height);
            Globals.baseEffect.Parameters["xDraw"].SetValue((float)((int)dim.X));
            Globals.baseEffect.Parameters["yDraw"].SetValue((float)((int)dim.Y));
            Globals.baseEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.baseEffect.CurrentTechnique.Passes[0].Apply();
           */ base.Draw();
        }

        public virtual void SetScore(int score)
        {
            GameGlobals.score = score;
        }
    }
}
