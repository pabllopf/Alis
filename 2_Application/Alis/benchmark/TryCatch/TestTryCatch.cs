// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestTryCatch.cs
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

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.TryCatch
{
    /// <summary>
    ///     The test try catch class
    /// </summary>
    public class TestTryCatch
    {
        /// <summary>
        ///     Gets or sets the value of the n
        /// </summary>
        [Params(10, 100, 1000)]
        // ReSharper disable once MemberCanBePrivate.Global
        public int N { get; set; }

        /// <summary>
        ///     Calls the internal method without try catch
        /// </summary>
        [Benchmark]
        public void CallInternalMethodWithoutTryCatch()
        {
            for (int i = 0; i < N; i++)
            {
                Sum(1, 2);
            }
        }

        /// <summary>
        ///     Calls the internal method with try catch
        /// </summary>
        [Benchmark]
        public void CallInternalMethodWithTryCatch()
        {
            for (int i = 0; i < N; i++)
            {
                try
                {
                    Sum(1, 2);
                }
                catch (KeyNotFoundException)
                {
                }
            }
        }

        /// <summary>
        ///     Sums the a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        private static int Sum(int a, int b) => a + b;
    }
}