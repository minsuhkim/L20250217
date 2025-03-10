using System.Reflection;
using System.Text;
using SDL2;

namespace L20250217
{
    public class Program
    {
        class Data
        {
            public void Count()
            {
                Console.WriteLine("Count");
            }

            private void FuncA()
            {
                Console.WriteLine("private FuncA");
            }

            protected void Sum()
            {
                Console.WriteLine("protected Sum");
            }

            public static void StaticFunction()
            {
                Console.WriteLine("Static Func");
            }

            public static void Add(int A, int B)
            {
                Console.WriteLine($"{A} + {B} = {A + B}");
            }

            private float Silver = 3;
            public int Gold = 1;
            protected int Money = 2;

            public int MP
            {
                get;
                set;
            }
        }

        static void Main(string[] args)
        {
            //Data d = new Data();
            //Type classType = d.GetType();
            //MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            //foreach (MethodInfo info in methods)
            //{
            //    //Console.WriteLine($"{info.name}");
            //    if (info.name.CompareTo("Add") == 0)
            //    {
            //        ParameterInfo[] paramInfos = info.GetParameters();
            //        foreach (ParameterInfo paramInfo in paramInfos)
            //        {
            //            Console.WriteLine(paramInfo.name);
            //        }
            //        //Object[] param = { 3, 5 };
            //        //info.Invoke(d, param);
            //    }
            //}

            //FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            //foreach (FieldInfo info in fields)
            //{
            //    Console.WriteLine($"{info.FieldType} {info.name} : {info.GetValue(d)}");
            //    info.SetValue(d, 10);
            //    Console.WriteLine($"{info.FieldType} {info.name} : {info.GetValue(d)}");
            //}

            //PropertyInfo[] propertyInfos = classType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            //foreach (PropertyInfo info in propertyInfos)
            //{
            //    Console.WriteLine($"{info.name} {info.GetValue(d)}");
            //}

            Engine.Instance.Init();

            Engine.Instance.Load("level02.map");
            Engine.Instance.Run();

            Engine.Instance.Quit();

            //Engine.Instance.Stop();
        }
    }
}