using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class PlayerController : Component
    {
        public override void Update()
        {
            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            {
                //if (!PredictCollision(X, Y - 1))
                //{
                //    Y--;
                //}
                //spriteIndexY = 2;

                gameObject.transform.Translate(0, -1);
                gameObject.GetComponent<SpriteRenderer>().spriteIndexY = 2;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                //if (!PredictCollision(X, Y + 1))
                //{
                //    Y++;
                //}
                //spriteIndexY = 3;
                gameObject.transform.Translate(0, 1);
                gameObject.GetComponent<SpriteRenderer>().spriteIndexY = 3;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                //if (!PredictCollision(X - 1, Y))
                //{
                //    X--;
                //}
                //spriteIndexY = 0;
                gameObject.transform.Translate(-1, 0);
                gameObject.GetComponent<SpriteRenderer>().spriteIndexY = 0;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                //if (!PredictCollision(X + 1, Y))
                //{
                //    X++;
                //}
                //spriteIndexY = 1;
                gameObject.transform.Translate(1, 0);
                gameObject.GetComponent<SpriteRenderer>().spriteIndexY = 1;
            }
        }
    }
}
