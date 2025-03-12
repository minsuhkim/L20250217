using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class SpriteRenderer : Renderer
    {
        public char Shape;
        public int orderLayer;

        public SDL.SDL_Color color;
        public int spriteSize = 30;

        protected bool isAnimation = false;
        protected IntPtr myTexture;
        protected IntPtr mySurface;

        public int spriteIndexX = 0;
        public int spriteIndexY = 0;

        public SDL.SDL_Color colorKey;

        protected string fileName;

        private SDL.SDL_Rect sourceRect;        // 이미지 원본
        private SDL.SDL_Rect destinationRect;

        private float elapsedTime = 0f;

        public float processTime = 100.0f;
        public int maxCellCountX = 5;
        public int maxCellCountY = 5;

        public SpriteRenderer()
        {

        }

        ~SpriteRenderer()
        {
            SDL.SDL_DestroyTexture(myTexture);
        }

        public override void Update()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;

            // Console
            Engine.backBuffer[Y, X] = Shape;

            // SCreen bitmap
            destinationRect.x = X * spriteSize;
            destinationRect.y = Y * spriteSize;
            destinationRect.w = spriteSize;
            destinationRect.h = spriteSize;

            unsafe
            {
                //  이미지 정보 가져와서 나중에 할 일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);     // GPU 옆에 있는 VRAM으로 옮김

                if (isAnimation)
                {
                    int cellSizeX = surface->w / maxCellCountX;
                    int cellSizeY = surface->h / maxCellCountY;
                    sourceRect.x = cellSizeX * spriteIndexX;
                    sourceRect.y = cellSizeY * spriteIndexY;
                    sourceRect.w = cellSizeX;
                    sourceRect.h = cellSizeY;

                    if (elapsedTime > processTime)
                    {
                        elapsedTime = 0;
                        spriteIndexX++;
                        spriteIndexX %= 5;
                    }
                    else
                    {
                        elapsedTime += Time.deltaTime;
                    }
                    
                }
                else
                {
                    sourceRect.x = 0;
                    sourceRect.y = 0;
                    sourceRect.w = surface->w;
                    sourceRect.h = surface->h;
                }
            }
        }

        public override void Render()
        {
            int X = gameObject.transform.X;
            int Y = gameObject.transform.Y;

            // Console
            Engine.backBuffer[Y, X] = Shape;

            unsafe
            {
                SDL.SDL_RenderCopy(Engine.Instance.myRenderer,
                    myTexture,
                    ref sourceRect,
                    ref destinationRect);
            }

        }

        public void LoadBmp(string inFileName, bool inIsAnimation = false)
        {
            string projectFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            isAnimation = inIsAnimation;
            fileName = inFileName;

            // SDL C, 접근할 수 있는 게 없어서
            mySurface = SDL.SDL_LoadBMP(projectFolder +"/data/" + fileName);             // bmp파일을 ssd에서 ram으로 가져와서 stack에서 가르키도록 함
            unsafe
            {   //  이미지 정보 가져와서 나중에 할 일이 있음
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)(mySurface);     // GPU 옆에 있는 VRAM으로 옮김
                SDL.SDL_SetColorKey(mySurface, 1, SDL.SDL_MapRGB(surface->format, colorKey.r, colorKey.g, colorKey.b));
            }

            myTexture = SDL.SDL_CreateTextureFromSurface(Engine.Instance.myRenderer, mySurface);
        }
    }
}
