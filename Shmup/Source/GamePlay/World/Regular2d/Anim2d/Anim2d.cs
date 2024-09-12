using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class Anim2d: Regular2d
    {
        public Vector2 frames;
        public List<FrameAnim> frameAnimList = new List<FrameAnim>();
        public Color color;
        public bool frameAnims;
        public int currentAnim = 0;
        public Anim2d(string texPath, Vector2 pos, Vector2 dim, Vector2 frames, Color color): base(texPath, pos, dim)
        {

            this.frames = new Vector2 (frames.X, frames.Y);
            this.color = color;
        }

#region Properties
        public Vector2 Frames
        {
            set
            {
                frames = value;
                if(tex != null)
                {
                    frameSize = new Vector2(tex.Bounds.Width/frames.X, tex.Bounds.Height/frames.Y);
                }
            }
            get { return frames; }
        }        
#endregion

        public override void Update()
        {
            if (frameAnims && frameAnimList != null && frameAnimList.Count > currentAnim)
            {

            }
            else
            {
                base.Update();
            }
        }

        public virtual int GetIndexFromName(string name)
        {
            for (int i = 0; i < frameAnimList.Count; i++) {
                if (frameAnimList[i].name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual void SetAnimByName(string name)
        {
            int tempIndex = GetIndexFromName(name);

            if(tempIndex != -1)
            {
                if(tempIndex != currentAnim)
                {
                    frameAnimList[tempIndex].Reset();
                }
                currentAnim = tempIndex;
            }
        }

        public override void Draw()
        {
            if(frameAnims && frameAnimList[currentAnim].Frames > 0)
            {
               // frameAnimList[currentAnim].Draw(tex, dim, frameSize, shift, pos, rot, color, spriteFx;
            }
            else
            {
                base.Draw();
            }
        }
    }
}
