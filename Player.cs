using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Player : GameObject
    {
        public Player(int inX, int inY, char inShape)
        {
            //X = inX;
            //Y = inY;
            //Shape = inShape;
            //orderLayer = 4;
            //isTrigger = true;

            //color.r = 0;
            //color.g = 0;
            //color.b = 255;
            //color.a = 0;

            //isAnimation = true;

            //colorKey.r = 255;
            //colorKey.g = 0;
            //colorKey.b = 255;
            //colorKey.a = 255;

            //LoadBmp("Data/player.bmp");
        }

        private float elapsedTime = 0f;

        public void Render()
        {
            ////x,y위치에 shape 출력
            ////Console.SetCursorPosition(X, Y);
            ////Console.Write(Shape);
            //Engine.backBuffer[Y, X] = Shape;

            ////SDL.SDL_SetRenderDrawColor(Engine.Instance.myRenderer, color.r, color.g, color.b, color.a);
            //SDL.SDL_Rect myRect;
            //myRect.x = X * spriteSize;
            //myRect.y = Y * spriteSize;
            //myRect.w = spriteSize;
            //myRect.h = spriteSize;
            ////SDL.SDL_RenderFillRect(Engine.Instance.myRenderer, ref myRect);

            //unsafe
            //{   //  이미지 정보 가져와서 나중에 할 일이 있음
            //    SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);     // GPU 옆에 있는 VRAM으로 옮김

            //    SDL.SDL_Rect sourceRect;        // 이미지 원본

            //    if (elapsedTime > 150.0f)
            //    {
            //        elapsedTime = 0;
            //        int cellSizeX = surface->w / 5;
            //        int cellSizeY = surface->h / 5;
            //        sourceRect.x = cellSizeX * spriteIndexX;
            //        sourceRect.y = cellSizeY * spriteIndexY;
            //        sourceRect.w = cellSizeX;
            //        sourceRect.h = cellSizeY;
            //        spriteIndexX++;
            //        spriteIndexX %= 5;
            //    }
            //    else
            //    {
            //        elapsedTime += Time.deltaTime;
            //        int cellSizeX = surface->w / 5;
            //        int cellSizeY = surface->h / 5;
            //        sourceRect.x = cellSizeX * spriteIndexX;
            //        sourceRect.y = cellSizeY * spriteIndexY;
            //        sourceRect.w = cellSizeX;
            //        sourceRect.h = cellSizeY;
            //    }

            //        SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
            //            myTexture,
            //            ref sourceRect,
            //            ref myRect);
            //}
        }

        public override void Update()
        {
            //if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            //{
            //    if (!PredictCollision(X, Y - 1))
            //    {
            //        Y--;
            //    }
            //    spriteIndexY = 2;
            //}
            //else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            //{
            //    if (!PredictCollision(X, Y + 1))
            //    {
            //        Y++;
            //    }
            //    spriteIndexY = 3;
            //}
            //else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            //{
            //    if (!PredictCollision(X - 1, Y))
            //    {
            //        X--;
            //    }
            //    spriteIndexY = 0;
            //}
            //else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            //{
            //    if (!PredictCollision(X + 1, Y))
            //    {
            //        X++;
            //    }
            //    spriteIndexY = 1;
            //}
        }
    }
}
