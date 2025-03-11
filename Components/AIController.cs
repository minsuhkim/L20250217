using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class AIController : GameObject
    {
        public AIController(int inX, int inY, char inShape)
        {
        }

        private float elapsedTime = 0f;

        public override void Update()
        {
            //if(elapsedTime >= 500f)
            //{
            //    elapsedTime = 0f;
            //    Random rand = new Random();
            //    int direction = rand.Next(0, 4);
            //    if (direction == 0)
            //    {
            //        if (!PredictCollision(X, Y - 1))
            //        {
            //            Y--;
            //        }
            //    }
            //    else if (direction == 1)
            //    {
            //        if (!PredictCollision(X + 1, Y))
            //        {
            //            X++;
            //        }
            //    }
            //    else if (direction == 2)
            //    {
            //        if (!PredictCollision(X - 1, Y))
            //        {
            //            X--;
            //        }
            //    }
            //    else if (direction == 3)
            //    {
            //        if (!PredictCollision(X, Y + 1))
            //        {
            //            Y++;
            //        }
            //    }
            //}
            //else
            //{
            //    elapsedTime += Time.deltaTime;
            //}

            //Console.SetCursorPosition(30, 10);
            //Console.Write(Time.deltaTime);
        }
    }
}
