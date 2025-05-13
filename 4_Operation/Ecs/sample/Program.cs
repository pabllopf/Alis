using System;
using System.Linq;
using System.Reflection;

namespace Alis.Core.Ecs.Sample
{
    internal class Program
    {
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
        }
    }
}
