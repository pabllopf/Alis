namespace Alis.Core.Example
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Run();

            Console.WriteLine("process end");
            Console.ReadKey();
        }
    }
}
