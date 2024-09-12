using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shmup
{
    public class FrameAnim
    {
        public bool isDone;
        public int frames, currentFrame, maxPasses, currentPass, actFrame;
        public string name;
        public Vector2 sheet, startFrame, sheetFrame, spriteDim;
        public MyTimer frametimer;

        public PassObject animAction;

        public FrameAnim(Vector2 spriteDim, Vector2 sheetDim, Vector2 start, int totalFrames, int spf, int maxPass, int actFrame,  PassObject animAct, string name = "")
        {
            this.spriteDim = spriteDim;
            this.sheet = sheetDim;
            startFrame = start;
            sheetFrame = new Vector2(start.X, start.Y);
            frames = totalFrames;
            currentFrame = 0;
            frametimer = new MyTimer(spf);
            maxPasses = maxPass;
            currentPass = 0;
            this.name = name;
            animAction = animAct;
            isDone = false;
            this.actFrame = actFrame;
        }

        public FrameAnim(Vector2 spriteDim, Vector2 sheetDim, Vector2 start, int totalFrames, int spf, int maxPass, string name = "")
        {
            this.spriteDim = spriteDim;
            this.sheet = sheetDim;
            startFrame = start;
            sheetFrame = new Vector2(start.X, start.Y);
            frames = totalFrames;
            currentFrame = 0;
            frametimer = new MyTimer(spf);
            maxPasses = maxPass;
            currentPass = 0;
            this.name = name;
            animAction = null;
            isDone = false;
            actFrame = 0;
        }
        #region Properties

        public int Frames
        {
            get { return frames; }
        }

        public int CurrentFrame
        {
            get { return currentFrame; }
        }
        public int CurrentPass
        {
            get { return currentPass; }
        }
        public int MaxPasses
        {
            get
            {
                return maxPasses;
            }
        }
        #endregion

        public void Update()
        {
            if (frames > 1)
            {
                frametimer.UpdateTimer();
                if(frametimer.isReady() && (maxPasses == 0 || maxPasses > currentPass))
                {
                    currentFrame++;
                    if(currentFrame >= frames)
                    {
                        currentPass++;
                    }
                    if(maxPasses == 0 || maxPasses > currentPass)
                    {
                        sheetFrame.X += 1;

                        if(sheetFrame.X >= sheet.X)
                        {
                            sheetFrame.X = 0;
                            sheetFrame.Y += 1;
                        }
                        if(currentFrame >= frames)
                        {
                            currentFrame = 0;
                            isDone = true;
                            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
                        }
                    }
                    frametimer.Reset();
                }
            }
            if(animAction != null && actFrame == currentFrame && !isDone)
            {
                animAction(null);
                isDone = true;
            }
        }

        public void Reset()
        {
            currentFrame = 0;
            currentPass = 0;
            sheetFrame = new Vector2(startFrame.X, startFrame.Y);
            isDone = false;
        }

        public bool AtEnd()
        {
            if (currentFrame + 1 >= frames)
            {
                return true;
            }
            return false;
        }

        public void Draw(Texture2D tex, Vector2 dims, Vector2 imgDim, Vector2 shift, Vector2 pos, float rot, Color color, SpriteEffects spriteFx)
        {
            Globals.spriteBatch.Draw(tex, new Rectangle((int)((pos.X + shift.X)), (int)((pos.Y + shift.Y)), (int)Math.Ceiling(dims.X), (int)Math.Ceiling(dims.Y)), new Rectangle((int)(sheetFrame.X * imgDim.X), (int)(sheetFrame.Y * imgDim.Y), (int)imgDim.X, (int)imgDim.Y), color, rot, imgDim / 2, spriteFx, 0);
        }



    }
}
