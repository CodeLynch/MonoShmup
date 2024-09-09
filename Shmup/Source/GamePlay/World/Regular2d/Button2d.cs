using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Shmup
{
    public class Button2d: Regular2d
    {
        public bool isPressed, isHovered;
        public string label;
        public Color hoverColor;
        public Color pressedColor;
        public SpriteFont font;
        public Object info;
        PassObject buttonClick;
        public Button2d(string texPath, Vector2 pos, Vector2 dim, string fontPath, string label, PassObject buttonClick, Object info):base(texPath, pos, dim)
        {
            this.info = info;
            if(fontPath != "")
            {
                font = Globals.content.Load<SpriteFont>(fontPath);
            }
            this.label = label;
            this.buttonClick = buttonClick;
            this.info = info;
            isPressed = false;
            hoverColor = new Color(0, 255, 1);
            pressedColor = new Color(0, 100, 1);
        }

        public virtual void Update()
        {
            if (Hover())
            {
                isHovered = true;
                if (Globals.mouse.LeftClick())
                {

                    isHovered = false;
                    isPressed = true;
                }
                else if (Globals.mouse.LeftClickRelease())
                {
                    OnButtonClick();
                }
            }
            else
            {
                isHovered = false;
            }

            if (!Globals.mouse.LeftClick() && !Globals.mouse.LeftClickHold()) { 
                isPressed = false;
            }
            base.Update();
        }

        public virtual void ResetState()
        {
            isPressed = false;
            isHovered = false;
        }

        public virtual void OnButtonClick()
        {
            if(buttonClick != null)
            {
                buttonClick(this.info);
            }
            ResetState();
        }

        public override void Draw()
        {
            Color tempColor = Color.White;
            if (isPressed)
            {
                tempColor = pressedColor;
            }
            else if (isHovered) {
                tempColor = hoverColor;
            }
            else
            {
                tempColor = Color.LimeGreen;
            }
            Globals.baseEffect.Parameters["xSize"].SetValue((float)this.tex.Bounds.Width);
            Globals.baseEffect.Parameters["ySize"].SetValue((float)this.tex.Bounds.Height);
            Globals.baseEffect.Parameters["xDraw"].SetValue((float)this.dim.X);
            Globals.baseEffect.Parameters["yDraw"].SetValue((float)this.dim.Y);
            Globals.baseEffect.Parameters["filterColor"].SetValue(tempColor.ToVector4());
            Globals.baseEffect.CurrentTechnique.Passes[0].Apply();

            base.Draw();

            Vector2 strDim = font.MeasureString(label);
            Globals.spriteBatch.DrawString(font, label, pos + new Vector2(-strDim.X/2, -strDim.Y/2 - 5), tempColor);
        }
    }
}
