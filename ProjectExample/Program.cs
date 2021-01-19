
using Alis.Tools;
using System;
using System.Diagnostics;
using System.Reflection;

namespace ProjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            new AudioSource().Play();


            Console.WriteLine("example:" + new Application().ToString());
        }
    }
}
