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
            Crypted<string> password = new Crypted<string>("this is the password");
            
            Console.WriteLine(password.Get());

            Console.ReadKey();
        }
    }

}
