using System.Text;

namespace L20250217
{
    public class Program
    {
        // Network에 접속했지만 비밀번호가 틀림
        class CustomException : Exception
        {
            public CustomException() : base("이건 내가 만든 예외")
            {
            }
        }

        class WrongPasswordException : Exception
        {
            public WrongPasswordException() : base("비밀번호 틀림")
            {
            }
        }
        static void Main(string[] args)
        {

            Engine.Instance.Load("level02.map");
            Engine.Instance.Run();

            //Engine.Instance.Stop();

            // 정렬
            int[] numbers = { 1, 5, 2, 3, 6, 7, 4, 8, 10, 9 };

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] < numbers[j])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + ", ");
            }


            //StreamReader sr = null;

            //try
            //{
            //    List<string> scene = new List<string>();
            //    sr = new StreamReader("level02.map");
            //    while (!sr.EndOfStream)
            //    {
            //        scene.Add(sr.ReadLine());
            //        throw new CustomException();
            //    }
            //    sr.Close();

            //    //throw new WrongPasswordException();
            //}
            //catch(FileNotFoundException e)
            //{
            //    Console.WriteLine(e.FileName);
            //    Console.WriteLine(e.Source);
            //    Console.WriteLine(e.Message);
            //}
            //catch(CustomException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch(WrongPasswordException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //// 가장 큰 exception이 제일 마지막에 와야함
            //catch(Exception e)
            //{

            //}
            //finally
            //{
            //    // network,file 입출력
            //    Console.WriteLine("finally");
            //    sr.Close();
            //}
        }
    }
}