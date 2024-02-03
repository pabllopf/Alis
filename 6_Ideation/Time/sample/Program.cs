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
using System.Threading;

namespace Alis.Core.Aspect.Time.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            // Create a new Clock instance
            Clock clock = new Clock();
            clock.Start();

            // Create a new TimeConfiguration instance
            TimeConfiguration timeConfig = new TimeConfiguration(0.02f, 0.15f);

            // Create a new TimeManager instance
            TimeManager timeManager = new TimeManager();

            int i = 0;
            while (i < 1000)
            {
                Thread.Sleep(1);
                i++;
            }

            // Stop the clock and print the elapsed time
            clock.Stop();
            Console.WriteLine($"Elapsed time: {clock.ElapsedMilliseconds} ms");

            // Print some TimeManager properties
            Console.WriteLine($"DeltaTime: {timeManager.DeltaTime}");
            Console.WriteLine($"TimeScale: {timeConfig.TimeScale}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}