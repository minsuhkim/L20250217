using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Engine
    {
        protected bool isRun = true;

        public void Input()
        {

        }

        public void Load()
        {
            world = new World();
        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            world.Render();
        }

        public void Run()
        {
            while (isRun)
            {
                Input();
                Update();
                Render();
            }
        }

        public World world;

    }
}
