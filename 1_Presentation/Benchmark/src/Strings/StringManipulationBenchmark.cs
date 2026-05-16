// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StringManipulationBenchmark.cs
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

using System.Text;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Strings
{
    /// <summary>
    ///     The string manipulation benchmark class
    /// </summary>
    [Config(typeof(CustomConfig))]
    public class StringManipulationBenchmark
    {
        /// <summary>
        ///     The iterations
        /// </summary>
        private const int Iterations = 10000;

        /// <summary>
        ///     Benchmarks naive string concatenation using the + operator (baseline for comparison)
        /// </summary>
        /// <returns>The concatenated result string</returns>
        [Benchmark(Baseline = true)]
        public string BadStringManipulation_BaseLine()
        {
            string result = "";
            for (int i = 0; i < Iterations; i++)
            {
                result += "A";
            }

            return result;
        }

        /// <summary>
        ///     Benchmarks string building using StringBuilder
        /// </summary>
        /// <returns>The built result string</returns>
        [Benchmark]
        public string NormalStringManipulation()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append("A");
            }

            return sb.ToString();
        }

        /// <summary>
        ///     Benchmarks string creation using string.Create with Span fill for optimal performance
        /// </summary>
        /// <returns>The created result string</returns>
        [Benchmark]
        public string PerfectStringManipulation()
        {
            return string.Create(Iterations, 'A', (span, value) => { span.Fill(value); });
        }
    }
}