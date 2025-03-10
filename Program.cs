using System.Text;
using SDL2;

namespace L20250217
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine.Instance.Init();

            Engine.Instance.Load("level02.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();

            //Engine.Instance.Stop();
        }
    }
}