using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Shmup
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        GamePlay gameplay;
        Bound bound;
        Regular2d cursor;
        MainMenu menu;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.screenWidth = 800;
            Globals.screenHeight = 500;
            Globals.screenBound = new Rectangle(35, 10, Globals.screenWidth - 70, Globals.screenHeight - 89);
            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            cursor = new Regular2d(Globals.SPRITE_PATH + "\\cursor\\cursor", Vector2.Zero, new Vector2(16, 16));
            Globals.baseEffect = Globals.content.Load<Effect>("shaders\\AntiAlias");

            bound = new Bound(Globals.screenBound, 3);
            Globals.keyboard = new MyKeyboard();
            Globals.mouse = new MyMouseControl();
            menu = new MainMenu(ChangeGameState, ExitGame);
            gameplay = new GamePlay(ChangeGameState);


        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


                Globals.gameTime = gameTime;
                Globals.keyboard.Update();
                Globals.mouse.Update();
            if (Globals.gameState == 0)
            {
                menu.Update();
            }
            else if(Globals.gameState == 1) 
            {
                gameplay.Update();

            }
                Globals.keyboard.UpdateOld();
                Globals.mouse.UpdateOld();
                base.Update(gameTime);

        }

        public virtual void ChangeGameState(Object info)
        {

            Globals.gameState = Convert.ToInt32(info, Globals.culture);
        }

        public virtual void ExitGame(Object info)
        {
            System.Environment.Exit(0);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            if (Globals.gameState == 0)
            {
                menu.Draw();
            }
            else
            {
                gameplay.Draw();
                bound.DrawRectangle(Globals.spriteBatch, Color.LimeGreen);            
            }
            Globals.baseEffect.Parameters["xSize"].SetValue((float)cursor.tex.Bounds.Width);
            Globals.baseEffect.Parameters["ySize"].SetValue((float)cursor.tex.Bounds.Height);
            Globals.baseEffect.Parameters["xDraw"].SetValue((float)cursor.dim.X);
            Globals.baseEffect.Parameters["yDraw"].SetValue((float)cursor.dim.Y);
            Globals.baseEffect.Parameters["filterColor"].SetValue(Color.White.ToVector4());
            Globals.baseEffect.CurrentTechnique.Passes[0].Apply();
            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMouse.Y), Vector2.Zero, Color.White);
            base.Draw(gameTime);

            Globals.spriteBatch.End();
        }
    }
}
