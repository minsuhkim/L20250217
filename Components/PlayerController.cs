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
                characterController2D.Move(0, -1);
                spriteRenderer.spriteIndexY = 2;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_DOWN))
            {
                characterController2D.Move(0, 1);
                spriteRenderer.spriteIndexY = 3;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_LEFT))
            {
                characterController2D.Move(-1, 0);
                spriteRenderer.spriteIndexY = 0;
            }
            else if (Input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) || Input.GetKeyDown(SDL.SDL_Keycode.SDLK_RIGHT))
            {
                characterController2D.Move(1, 0);
                spriteRenderer.spriteIndexY = 1;
            }
        }

        public void OnTriggerEnter2D(GameObject other)
        {
            //Console.SetCursorPosition(300, 400);
            //Console.WriteLine($"trigger 감지: {other.name}");
            if (other.name == "Monster")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isGameOver = true;
            }
            else if (other.name == "Goal")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isFinish = true;
            }
        }
    }
}
