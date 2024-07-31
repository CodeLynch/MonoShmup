﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Shmup
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        World world;
        Regular2d cursor;
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
            Globals.keyboard = new MyKeyboard();
            Globals.mouse = new MyMouseControl();
            world = new World();


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();
            world.Update();
            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Globals.spriteBatch.Begin();

            world.Draw();
            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMouse.Y), Vector2.Zero, Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
