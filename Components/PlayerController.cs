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
        public SpriteRenderer spriteRenderer;
        public CharacterController2D characterController2D;

        public override void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            characterController2D = GetComponent<CharacterController2D>();
        }

        public override void Update()
        {
            if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_UP))
            {
                //if (!PredictCollision(X, Y - 1))
                //{
                //    Y--;
                //}
                //spriteIndexY = 2;
                if (characterController2D.Move(transform.X, transform.Y - 1))
                {
                    transform.Translate(0, -1);
                }
                spriteRenderer.spriteIndexY = 2;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                //if (!PredictCollision(X, Y + 1))
                //{
                //    Y++;
                //}
                //spriteIndexY = 3;
                if (characterController2D.Move(transform.X, transform.Y + 1))
                {
                    transform.Translate(0, 1);
                }
                spriteRenderer.spriteIndexY = 3;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                //if (!PredictCollision(X - 1, Y))
                //{
                //    X--;
                //}
                //spriteIndexY = 0;
                if (characterController2D.Move(transform.X - 1, transform.Y))
                {
                    transform.Translate(-1, 0);
                }
                spriteRenderer.spriteIndexY = 0;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                //if (!PredictCollision(X + 1, Y))
                //{
                //    X++;
                //}
                //spriteIndexY = 1;
                if (characterController2D.Move(transform.X + 1, transform.Y))
                {
                    transform.Translate(1, 0);
                }
                spriteRenderer.spriteIndexY = 1;
            }
        }
    }
}
