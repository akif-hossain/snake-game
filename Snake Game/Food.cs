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
    class Food
    {
        private Vector2 foodPosition;
        public Texture2D food;
        public Food()
        {
            foodPosition = new Vector2();
            foodPosition.X = 100;
            foodPosition.Y = 0;
        }

        public int dX()
        {
            return (int)foodPosition.X;
        }

        public int dY()
        {
            return (int)foodPosition.Y;
        }

        public void randomize(int stageWidth, int stageHeight)
        {
            Random r1 = new Random();
            Random r2 = new Random();

            //Snapping to the grid
            foodPosition.X = r1.Next(stageWidth-20);
            if (foodPosition.X % 20 != 0)
            {
                if ((foodPosition.X % 20) < 10)
                    foodPosition.X -= (foodPosition.X % 20);
                else
                    foodPosition.X += 20-(foodPosition.X % 20);
            }
            foodPosition.Y = r2.Next(stageHeight-20);
            if ((foodPosition.Y % 20) != 0)
            {
                if (foodPosition.Y % 20 < 10)
                    foodPosition.Y -= (foodPosition.Y % 20);
                else
                    foodPosition.Y += 20-(foodPosition.Y % 20);
            }
        }

    }
}
