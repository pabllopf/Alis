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
using System.Linq;
using System.Reflection;

namespace Frent.Sample
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
            MethodInfo[] methods = typeof(Samples).GetMethods().Where(m => m.GetCustomAttribute<SampleAttribute>() is not null).ToArray();
            Console.WriteLine($"Pick a sample: 0-{methods.Length + 1}");
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"[{i}] {methods[i].Name.Replace('_', ' ')}");
            }

            int userOption;
            while (!int.TryParse(Console.ReadLine(), out userOption) || userOption > methods.Length + 1 || userOption < 0)
            {
                Console.WriteLine("Write a valid input");
            }

            methods[userOption].Invoke(null, []);

            Console.WriteLine("\n\nSample Completed. Press Enter to exit");
        }
    }
}