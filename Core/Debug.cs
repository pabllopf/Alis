namespace Alis.Core
{
    using System;

    public class Debug
    {
        public static void Log(String message) 
        {
            Console.WriteLine(message);
        }

        public static void Error(String message) 
        {
            Console.WriteLine(message);
        }
    }
}
