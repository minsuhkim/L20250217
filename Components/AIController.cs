using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class AIController : Component
    {
        public AIController()
        {
        }

        private float elapsedTime = 0f;

        public CharacterController2D characterController2D;

        public override void Awake()
        {
            characterController2D = GetComponent<CharacterController2D>();
        }

        public override void Update()
        {
            if(elapsedTime >= 500f)
            {
                elapsedTime = 0f;
                Random rand = new Random();
                int direction = rand.Next(0, 4);
                if (direction == 0)
                {
                    characterController2D.Move(0, 1);
                }
                else if (direction == 1)
                {
                    characterController2D.Move(1,0);
                }
                else if (direction == 2)
                {
                    characterController2D.Move(-1, 0);
                }
                else if (direction == 3)
                {
                    characterController2D.Move(0, -1);
                }
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }

        }

        private void OnTriggerEnter2D(GameObject other)
        {
            //Console.WriteLine($"trigger 감지: {other.name}");
        }
    }
}
