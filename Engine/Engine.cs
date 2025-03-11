using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Engine
    {
        private Engine()
        {

        }

        // 더블 버퍼링
        static public char[,] backBuffer = new char[20, 40];
        static public char[,] frontBuffer = new char[20, 40];

        // 엔진은 단 하나만의 인스턴스를 가져야 하므로 싱글톤으로 제작
        static protected Engine instance;
        static public Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        protected bool isRunning = true;
        public nint myWindow;
        public nint myRenderer;
        public SDL.SDL_Event myEvent;

        public bool Init()
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) < 0)
            {
                Console.WriteLine("Fail Init.");
                return false;
            }

            myWindow = SDL.SDL_CreateWindow(
                "Game",
                100, 100,
                640, 480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            myRenderer = SDL.SDL_CreateRenderer(myWindow, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE);

            world = new World();

            return true;
        }

        public bool Quit()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);

            SDL.SDL_Quit();
            return true;
        }

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


            

            for (int y = 0; y < scene.Count; y++)
            {
                for (int x = 0; x < scene[y].Length; x++)
                {
                    if (scene[y][x] == '*')
                    {
                        GameObject wall = new GameObject();
                        wall.name = "Player";
                        wall.transform.X = x;
                        wall.transform.Y = y;

                        wall.AddComponent(new BoxCollider2D());
                        SpriteRenderer spriteRenderer = wall.AddComponent(new SpriteRenderer());
                        spriteRenderer.LoadBmp("wall.bmp");
                        spriteRenderer.Shape = '*';
                        spriteRenderer.orderLayer = 1;

                        world.Instantiate(wall);
                    }
                    else if (scene[y][x] == 'P')
                    {
                        GameObject player = new GameObject();
                        player.name = "Player";
                        player.transform.X = x;
                        player.transform.Y = y;

                        player.AddComponent(new PlayerController());
                        player.AddComponent(new CharacterController2D());
                        SpriteRenderer spriteRenderer = player.AddComponent(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 0;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("player.bmp", true);
                        spriteRenderer.Shape = 'P';
                        spriteRenderer.processTime = 150.0f;
                        spriteRenderer.orderLayer = 3;

                        world.Instantiate(player);
                    }
                    else if (scene[y][x] == 'M')
                    {
                        GameObject monster = new GameObject();
                        monster.name = "Monster";
                        monster.transform.X = x;
                        monster.transform.Y = y;
                        monster.AddComponent<CharacterController2D>();

                        SpriteRenderer spriteRenderer = monster.AddComponent(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("monster.bmp");
                        spriteRenderer.Shape = 'M';
                        spriteRenderer.orderLayer = 4;

                        monster.AddComponent<AIController>(new AIController());

                        world.Instantiate(monster);
                    }
                    else if (scene[y][x] == 'G')
                    {
                        GameObject goal = new GameObject();
                        goal.name = "Goal";
                        goal.transform.X = x;
                        goal.transform.Y = y;

                        SpriteRenderer spriteRenderer = goal.AddComponent(new SpriteRenderer());
                        spriteRenderer.colorKey.r = 255;
                        spriteRenderer.colorKey.g = 255;
                        spriteRenderer.colorKey.b = 255;
                        spriteRenderer.colorKey.a = 255;
                        spriteRenderer.LoadBmp("goal.bmp");
                        spriteRenderer.Shape = 'G';
                        spriteRenderer.orderLayer = 2;

                        world.Instantiate(goal);
                    }

                    GameObject floor = new GameObject();
                    floor.name = "Floor";
                    floor.transform.X = x;
                    floor.transform.Y = y;

                    SpriteRenderer spriteRenderer2 = floor.AddComponent(new SpriteRenderer());
                    spriteRenderer2.LoadBmp("floor.bmp");
                    spriteRenderer2.orderLayer = 0;


                    spriteRenderer2.Shape = ' ';

                    world.Instantiate(floor);
                }
            }
            world.Sort();
        }

        public void ProcessInput()
        {
            Input.Process();
        }

        public void Awake()
        {
            world.Awake();
        }

        protected void Update()
        {
            world.Update();
        }

        protected void Render()
        {
            SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
            SDL.SDL_RenderClear(myRenderer);
            
            world.Render();

            // '메모리에 있는 걸 한 방에 붙여줘'라는 함수가 C#에는 없음
            for (int Y = 0; Y < 20; Y++)
            {
                for (int X = 0; X < 40; X++)
                {
                    if (backBuffer[Y, X] != frontBuffer[Y, X])
                    {
                        frontBuffer[Y, X] = backBuffer[Y, X];
                        Console.SetCursorPosition(X, Y);
                        Console.Write(backBuffer[Y, X]);
                    }
                }
            }

            SDL.SDL_RenderPresent(myRenderer);
        }

        public void Run()
        {
            Console.CursorVisible = false;
            Awake();

            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);

                Time.Update();

                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;
                }

                Update();
                Render();
            }
        }

        public void SetSortCompare(World.SortCompare sortCompare)
        {
            world.sortCompre = sortCompare;
        }

        public World world;

    }
}
