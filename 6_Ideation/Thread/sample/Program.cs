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

namespace Alis.Core.Aspect.Thread.Sample
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
            ThreadManager threadManager = new ThreadManager();

            CancellationTokenSource cts1 = new CancellationTokenSource();
            ThreadTask task1 = new ThreadTask(token =>
            {
                for (int i = 0; i < 10 && !token.IsCancellationRequested; i++)
                {
                    Console.WriteLine($"Task 1 - Count: {i}");
                    System.Threading.Thread.Sleep(1000);
                }
            }, cts1.Token);

            CancellationTokenSource cts2 = new CancellationTokenSource();
            ThreadTask task2 = new ThreadTask(token =>
            {
                for (int i = 0; i < 10 && !token.IsCancellationRequested; i++)
                {
                    Console.WriteLine($"Task 2 - Count: {i}");
                    System.Threading.Thread.Sleep(1000);
                }
            }, cts2.Token);

            threadManager.StartThread(task1);
            threadManager.StartThread(task2);

            Console.WriteLine("Press any key to stop threads...");
            Console.ReadKey();

            threadManager.StopAllThreads();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}