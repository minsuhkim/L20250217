namespace L20250217
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Engine.Instance.Load();
            Engine.Instance.Run();

            //Engine.Instance.Stop();
        }
    }
}