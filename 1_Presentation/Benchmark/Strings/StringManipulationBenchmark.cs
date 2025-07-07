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
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.Strings
{
    /// <summary>
    ///     The string manipulation benchmark class
    /// </summary>
    [ Config(typeof(CustomConfig))]
    public class StringManipulationBenchmark
    {
        /// <summary>
        ///     The iterations
        /// </summary>
        private const int Iterations = 10000;

        /// <summary>
        ///     Bads the string manipulation base line
        /// </summary>
        /// <returns>The result</returns>
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
        ///     Normals the string manipulation
        /// </summary>
        /// <returns>The string</returns>
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
        ///     Perfects the string manipulation
        /// </summary>
        /// <returns>The string</returns>
        [Benchmark]
        public string PerfectStringManipulation()
        {
            return string.Create(Iterations, 'A', (span, value) => { span.Fill(value); });
        }
    }
}