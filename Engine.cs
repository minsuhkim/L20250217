using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Engine
    {
        private Engine()
        {

        }

        // 엔진은 단 하나만의 인스턴스를 가져야 하므로 싱글톤으로 제작
        static protected Engine instance;
        static public Engine Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }
        
        protected bool isRunning = true;

        public void Load(string fileName)
        {
            //file 에서 로딩
            // Byte 단위로 읽어올 수 있는 빨대
            //string tempScene = "";
            //byte[] buffer = new byte[1024];
            //FileStream fs = new FileStream(fileName, FileMode.Open);
            //fs.Seek(0, SeekOrigin.End);
            //long fileSize = fs.Position;

            //fs.Seek(0, SeekOrigin.Begin);
            //int readCount = fs.Read(buffer, 0, (int)fileSize);
            //tempScene = Encoding.UTF8.GetString(buffer);
            //tempScene = tempScene.Replace("\0", "");
            //string[] scene = tempScene.Split("\r\n");
            //fs.Close();


            List<string> scene = new List<string>();
            // line 단위로 읽어올 수 있는 빨대
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                scene.Add(sr.ReadLine());
            }
            sr.Close();


            world = new World();

            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if (scene[y][x] == '*')
                    {
                        GameObject wall = new Wall(x, y, scene[y][x]);
                        world.Instantiate(wall);
                    }
                    else if (scene[y][x] == ' ')
                    {

                    }
                    else if (scene[y][x] == 'P')
                    {
                        GameObject player = new Player(x, y, scene[y][x]);
                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new Monster(x, y, scene[y][x]);
                        world.Instantiate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        GameObject goal = new Goal(x, y, scene[y][x]);
                        world.Instantiate(goal);
                    }
                    GameObject floor = new Floor(x, y, ' ');
                    world.Instantiate(floor);
                }
            }

            // Loading Complete
            // Sort
            world.Sort();
        }

        public void ProcessInput()
        {
            Input.Process();
        }


        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            Console.Clear();
            world.Render();
        }

        public void Run()
        {
            while (isRunning)
            {
                ProcessInput();
                Update();
                Render();
            }
        }

        public World world;

    }
}
