// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BenchmarkHelper.cs
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
using System.Diagnostics;
using System.Threading;

namespace Alis.Test.Helper
{
    /// <summary>
    /// The benchmark helper class
    /// </summary>
    public static class BenchmarkHelper
    {
        /// <summary>
        /// Measures the action
        /// </summary>
        /// <param name="action">The action</param>
        /// <exception cref="Exception">The method took {elapsedMilliseconds} ms, which exceeds the limit of {maxMilliseconds} ms.</exception>
        /// <exception cref="Exception">The method used {memoryUsed} bytes of memory, which exceeds the limit of {maxMemoryBytes} bytes.</exception>
        public static BenchmarkResult Measure(Action action)
        {
            // Warm-up
            action();
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            
            ThreadPriority originalPriority = Thread.CurrentThread.Priority;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            
            try
            {
                long startTimestamp = Stopwatch.GetTimestamp();
                action(); 
                long endTimestamp = Stopwatch.GetTimestamp();
                
                double elapsedNanoseconds = (endTimestamp - startTimestamp) * (1_000_000_000.0 / Stopwatch.Frequency);
                
                return new BenchmarkResult()
                {
                    ElapsedMilliseconds = (long)elapsedNanoseconds / 1_000_000,
                    ElapsedNanoseconds = elapsedNanoseconds
                };
            }
            finally
            {
                Thread.CurrentThread.Priority = originalPriority;
            }
        }

    }
}