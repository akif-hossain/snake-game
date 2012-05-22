using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class Body
    {
        public Texture2D body;
        private Vector2 bodyPosition;
        private Vector2 bodyVelocity;

        public Body()
        {
            bodyPosition = new Vector2(0,0);
            bodyVelocity = new Vector2(0, 0);
        }

        public int dX()
        {
            return (int)bodyPosition.X;
        }

        public int dY()
        {
            return (int)bodyPosition.Y;
        }

        public int vX()
        {
            return (int)bodyVelocity.X;
        }

        public int vY()
        {
            return (int)bodyVelocity.Y;
        }

        public void setV(int x, int y)
        {
            bodyVelocity.X = x;
            bodyVelocity.Y = y;

        }

        public void setDX(int x)
        {
            bodyPosition.X = x;
        }

        public void setDY(int y)
        {
            bodyPosition.Y = y;
        }

        public void updateBody(int stageWidth, int stageHeight)
        {
            
            bodyPosition.X += bodyVelocity.X*this.body.Width;
            if (bodyPosition.X >= stageWidth)
                bodyPosition.X = 0;
            else if (bodyPosition.X < 0)
                bodyPosition.X = stageWidth-20;
            
            bodyPosition.Y += bodyVelocity.Y*this.body.Height;
            if (bodyPosition.Y >= stageHeight)
                bodyPosition.Y = 0;
            else if (bodyPosition.Y < 0)
                bodyPosition.Y = stageHeight-20;
        }
    }
}
