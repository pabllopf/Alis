using System;
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Logging;

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
            Logger.Info("Seleccione un ejemplo para ejecutar:");
            Logger.Info("1. Update_Component");
            Logger.Info("2. Update_Systems");
            Logger.Info("3. Uniforms_And_Entities");
            Logger.Info("4. Uniforms_And_Entities_initeable");
            Logger.Info("5. Simple_Game");
            Logger.Info("6. Queries");
            Console.Write("Ingrese el número de ejemplo (1-6): ");
            string input = Console.ReadLine();
            int opcion;
            if (!int.TryParse(input, out opcion))
            {
                Logger.Info("Entrada inválida. Debe ser un número entre 1 y 6.");
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
                    Logger.Info("Opción fuera de rango. Debe ser un número entre 1 y 6.");
                    break;
            }
        }
    }
}
