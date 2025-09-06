// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Ecs.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
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