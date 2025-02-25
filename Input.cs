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
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
            }
        }

        static public bool GetKeyDown(ConsoleKey key)
        {
            if(keyInfo.Key == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public void ClearInput()
        {
            keyInfo = new ConsoleKeyInfo();
        }
    }
}
