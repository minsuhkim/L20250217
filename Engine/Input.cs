using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250217
{
    public class Input
    {
        public Input()
        {

        }

        static protected ConsoleKeyInfo keyInfo;
        static public void Process()
        {
            //if (Console.KeyAvailable)
            //{
            //    keyInfo = Console.ReadKey(true);
            //}
        }

        static public bool GetKeyDown(ConsoleKey key)
        {
            return keyInfo.Key == key;
        }

        static public bool GetKey(SDL.SDL_Keycode key)
        {
            return Engine.Instance.myEvent.key.keysym.sym == key;
        }

        static public bool GetKeyDown(SDL.SDL_Keycode key)
        {
            if(Engine.Instance.myEvent.type == SDL.SDL_EventType.SDL_KEYDOWN)
            {
                return Engine.Instance.myEvent.key.keysym.sym == key;
            }
            return false;
        }

        static public bool GetKeyUp(SDL.SDL_Keycode key)
        {
            if (Engine.Instance.myEvent.type == SDL.SDL_EventType.SDL_KEYUP)
            {
                return Engine.Instance.myEvent.key.keysym.sym == key;
            }
            return false;
        }

        static public void ClearInput()
        {
            keyInfo = new ConsoleKeyInfo();
        }
    }
}
