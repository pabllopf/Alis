using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class Log
    {
        public static void Print(String message) 
        {
            Console.WriteLine(message);
        }

        public static void WaitToPressKey() 
        {
            Console.ReadKey();
        }
    }
}
