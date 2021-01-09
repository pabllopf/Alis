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
            Stopwatch stopwatch = Stopwatch.StartNew();

            Crypted<string> passwordCrypted = new Crypted<string>("this is the password");
            passwordCrypted.Value = "i change passwd";
            Console.WriteLine("value:  '" + passwordCrypted.Value + "'");

            stopwatch.Stop(); 
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));

            Console.WriteLine("----------------------------------------------------------------------");

            Stopwatch stopwatch2 = Stopwatch.StartNew();

            string passwordCrypted2 = "password2";
            Console.WriteLine("value:  '" + passwordCrypted2 + "'");

            stopwatch2.Stop();
            Console.WriteLine("Time elapsed normal string: {0}", stopwatch2.Elapsed.ToString("hh\\:mm\\:ss\\.fff"));


            Console.ReadKey();
        }
    }


   
    public class Login 
    {
        public Crypted<string> username;

        public Crypted<string> password;

        public Login() 
        {
            username = new Crypted<string>("Pablo");

            password = new Crypted<string>("Password");
        }
    }
        
}
