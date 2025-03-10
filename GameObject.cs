using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class GameObject
    {
        public int X;
        public int Y;

        public char Shape;  //Mesh, Sprite
        public int orderLayer;
        public bool isTrigger = false;
        public bool isCollide = false;

        public SDL.SDL_Color color;
        public int spriteSize = 15;

        IntPtr myTexture;
        IntPtr mySurface;

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            //x,y위치에 shape 출력
            //Console.SetCursorPosition(X, Y);
            //Console.Write(Shape);
            Engine.backBuffer[Y, X] = Shape;

            //SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            SDL.SDL_Rect myRect;
            myRect.x = X * spriteSize;
            myRect.y = Y * spriteSize;
            myRect.w = spriteSize;
            myRect.h = spriteSize;
            //SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref myRect);

            unsafe
            {   //  이미지 정보 가져와서 나중에 할 일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);     // GPU 옆에 있는 VRAM으로 옮김

                SDL.SDL_Rect sourceRect;        // 이미지 원본
                sourceRect.x = 0;
                sourceRect.y = 0;
                sourceRect.w = surface->w;
                sourceRect.h = surface->h;
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
                    myTexture,
                    ref sourceRect,
                    ref myRect);
            }

        }

        public bool PredictCollision(int newX, int newY)
        {
            for (int i = 0; i < Engine.Instance.world.GetAllGameObjects.Count; i++)
            {
                if (Engine.Instance.world.GetAllGameObjects[i].isCollide == true &&
                        Engine.Instance.world.GetAllGameObjects[i].X == newX &&
                        Engine.Instance.world.GetAllGameObjects[i].Y == newY)
                {
                    return true;
                }
            }
            return false;
        }

        public void LoadBmp(string filename)
        {
            // SDL C, 접근할 수 있는 게 없어서
            mySurface = SDL.SDL_LoadBMP(filename);             // bmp파일을 ssd에서 ram으로 가져와서 stack에서 가르키도록 함
            unsafe
            {   //  이미지 정보 가져와서 나중에 할 일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);     // GPU 옆에 있는 VRAM으로 옮김
            }

            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);

        }
    }
}
