
using System;
using System.Linq;
using System.Reflection;

namespace Frent.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(Samples).GetMethods().Where(m => m.GetCustomAttribute<SampleAttribute>() is not null).ToArray();
            Console.WriteLine($"Pick a sample: 0-{methods.Length + 1}");
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"[{i}] {methods[i].Name.Replace('_', ' ')}");
            }

            int userOption;
            while (!int.TryParse(Console.ReadLine(), out userOption) || userOption > methods.Length + 1 || userOption < 0)
                Console.WriteLine("Write a valid input");

            methods[userOption].Invoke(null, []);

            Console.WriteLine("\n\nSample Completed. Press Enter to exit");
        }
    }
}
