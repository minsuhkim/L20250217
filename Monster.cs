using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Monster : GameObject
    {
        public Monster(int inX, int inY, char inShape)
        {
            X = inX;
            Y = inY;
            Shape = inShape;
            orderLayer = 5;
            isTrigger = true;
        }

        public override void Update()
        {
            Random rand = new Random();
            int direction = rand.Next(0, 5);
            if(direction == 0)
            {                
            }
            else if(direction == 1)
            {
                if (!PredictCollision(X + 1, Y))
                {
                    X++;
                }                
            }
            else if(direction == 2)
            {
                if (!PredictCollision(X - 1, Y))
                {
                    X--;
                }
            }
            else if(direction == 3)
            {
                if (!PredictCollision(X, Y + 1))
                {
                    Y++;
                }
            }
            else if(direction == 4)
            {
                if (!PredictCollision(X, Y - 1))
                {
                    Y--;
                }
            }

            if (X < 0)
            {
                X = 0;
            }
            if(Y < 0)
            {
                Y = 0;
            }
        }
    }
}
