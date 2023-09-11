namespace Enemy_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.SetCursorPosition(0, 20);
            //Console.Write("123");
            Console.CursorVisible = false;
            Enemy1 enemy1 = new Enemy1(0, 0, 40, 10);
            Enemy1 enemy2 = new Enemy1(0, 0, 40, 10);
            while (true)
            {
                Thread.Sleep(500);

                enemy2.Print();
            }
        }
    }
}