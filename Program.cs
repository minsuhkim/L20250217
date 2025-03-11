using System.Reflection;
using System.Text;
using SDL2;

namespace L20250217
{
    public class EventClass
    {
        public delegate void DelegateSample();
        public DelegateSample delegateSample;
        public event DelegateSample EventSample;

        public void Do()
        {
            EventSample?.Invoke();
        }
    }

    public class Program
    {
        public static int Compare(GameObject first, GameObject second)
        {
            SpriteRenderer spriteRenderer1 = first.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer2 = second.GetComponent<SpriteRenderer>();
            if(spriteRenderer1 == null || spriteRenderer2 == null)
            {
                return 0;
            }
            return spriteRenderer1.orderLayer - spriteRenderer2.orderLayer;
        }

        public static void Test()
        {
            Console.WriteLine("Test");
        }

        public static void Test1(int a)
        {
            Console.WriteLine($"Test {a}");
        }

        static void Main(string[] args)
        {
            Action testAction = Test;
            Action<int> test1Action = Test1;

            testAction();
            test1Action(1);

            Func<int, int> testFunc = (int a) =>
            {
                return a + 1;
            };

            Console.WriteLine(testFunc(1));

            //Engine.Instance.Init();
            //Engine.Instance.SetSortCompare(Compare);

            //Engine.Instance.Load("level02.map");
            //Engine.Instance.Run();

            //Engine.Instance.Quit();

            //Engine.Instance.Stop();
        }
    }
}