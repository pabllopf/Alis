using System;
using System.Linq;
using System.Reflection;

namespace Alis.Core.Ecs.Sample
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
            Console.WriteLine("Seleccione un ejemplo para ejecutar:");
            Console.WriteLine("1. Update_Component");
            Console.WriteLine("2. Update_Systems");
            Console.WriteLine("3. Uniforms_And_Entities");
            Console.WriteLine("4. Uniforms_And_Entities_initeable");
            Console.WriteLine("5. Simple_Game");
            Console.WriteLine("6. Queries");
            Console.Write("Ingrese el número de ejemplo (1-6): ");
            string input = Console.ReadLine();
            int opcion;
            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Entrada inválida. Debe ser un número entre 1 y 6.");
                return;
            }
            switch (opcion)
            {
                case 1:
                    Samples.Update_Component();
                    break;
                case 2:
                    Samples.Update_Systems();
                    break;
                case 3:
                    Samples.Uniforms_And_Entities();
                    break;
                case 4:
                    Samples.Uniforms_And_Entities_initeable();
                    break;
                case 5:
                    Samples.Simple_Game();
                    break;
                case 6:
                    Samples.Queries();
                    break;
                default:
                    Console.WriteLine("Opción fuera de rango. Debe ser un número entre 1 y 6.");
                    break;
            }
        }
    }
}
