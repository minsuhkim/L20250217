using System.Reflection;
using System.Text;
using SDL2;

namespace L20250217
{
    public delegate int Command(int a, int b);

    public class Sample
    {
        public Command command;

        public void Sort()
        {
            if (command(1, 2) > 0)
            {
                Console.WriteLine(command(1, 2));
            }
        }
    }

    public class Program
    {
        static int Add(int A, int B)
        {
            return A + B;
        }

        static int Sub(int A, int B)
        {
            return A - B;
        }

        static void Main(string[] args)
        {
            //Command command = Sub;
            // Command command = new Command(Sub);
            // 익명함수(람다)
            // 한 번 쓰고 버리는 함수, 3줄 이하의 짧은 함수일 때 사용
            Command command = new Command((int A, int B) =>
            {
                return A * B;
            });


            // 위 두 코드가 같은 역할
            Console.WriteLine(command(3, 2));

            Sample sample = new Sample();
            sample.command = Add;
            sample.Sort();

            //Engine.Instance.Init();

            //Engine.Instance.Load("level02.map");
            //Engine.Instance.Run();

            //Engine.Instance.Quit();

            //Engine.Instance.Stop();
        }
    }
}