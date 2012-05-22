using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Snake_Game
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState oldState;
        SpriteFont font;
        Food food  = new Food();
        Body[] body;
        int numOfElem;
        Texture2D grid, topMenu;
        float delay;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            

            this.Window.Title = "Snake Game";
            
            oldState = Keyboard.GetState();
            numOfElem = 1;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            grid = Content.Load<Texture2D>("grid");
            topMenu = Content.Load<Texture2D>("top");
            food.food = Content.Load<Texture2D>("food");
            font = Content.Load<SpriteFont>("font");

            body = new Body[100];
            for (int i = 0; i < body.Length; i++)
            {
                body[i] = new Body();
                body[i].body = Content.Load<Texture2D>("body");
            }
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed||key.IsKeyDown(Keys.Escape))
                this.Exit();
            delay += gameTime.ElapsedGameTime.Milliseconds;

            if (delay >= 150)
            {
                if (collisionOccured())
                {
                    food.randomize(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
                    if (numOfElem<body.Length)
                        numOfElem++;
                    
                }
                updateBody2();
                delay = 0;
                
            }
            
            trackInputs();
            
            base.Update(gameTime);
        }

        private void updateBody2()
        {
            Body temp = new Body();
            Body temp2 = new Body();
            temp.setDX(body[0].dX());
            temp.setDY(body[0].dY());
            body[0].updateBody(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);

            for (int i = 1; i < numOfElem; i++)
            {
                if (body[0].dX() == body[i].dX() && body[0].dY() == body[i].dY())
                    Initialize();
            }

            for (int i = 1; i < numOfElem; i++)
            {
                temp2.setDX(body[i].dX());
                temp2.setDY(body[i].dY());
                body[i].setDX(temp.dX());
                body[i].setDY(temp.dY());
                temp.setDX(temp2.dX());
                temp.setDY(temp2.dY());
            }
        }

        //Check for collision with food
        private bool collisionOccured()
        {
            if (body[0].dX() == food.dX() && body[0].dY() == food.dY())
                return true;
            else
                return false;
            
        }

        //Tracking Inputs
        private void trackInputs()
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Down))
            {
                if (!oldState.IsKeyDown(Keys.Down))
                {
                    body[0].setV(0,1);
                }
            }
            if (key.IsKeyDown(Keys.Up))
            {
                if (!oldState.IsKeyDown(Keys.Up))
                {
                    body[0].setV(0,-1);
                }
            }
            if (key.IsKeyDown(Keys.Left))
            {
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    body[0].setV(-1,0);
                }
            }
            if (key.IsKeyDown(Keys.Right))
            {
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    body[0].setV(1,0);
                }
            }

            oldState = key;

        }

        protected override void Draw(GameTime gameTime)
        {
            this.graphics.PreferredBackBufferWidth = 300;
            this.graphics.PreferredBackBufferHeight = 500;
            this.graphics.ApplyChanges();

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            //spriteBatch.Draw(grid, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(topMenu, new Vector2(0, 0), Color.DarkGray);
            spriteBatch.Draw(food.food, new Vector2(food.dX(),food.dY()) ,Color.White);
            spriteBatch.DrawString(font, "Points: " + (numOfElem - 1) * 10, new Vector2(20, 20), Color.Red);
            //spriteBatch.DrawString(
            for (int i = 0;i < numOfElem;i++)
                spriteBatch.Draw(body[i].body, new Vector2(body[i].dX(), body[i].dY()), Color.White);
            spriteBatch.End();


        }
    }
}
