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
                X++;
            }
            else if(direction == 2)
            {
                X--;
            }
            else if(direction == 3)
            {
                Y++;
            }
            else if(direction == 4)
            {
                Y--;
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
