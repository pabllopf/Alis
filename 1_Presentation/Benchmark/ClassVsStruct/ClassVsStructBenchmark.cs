// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClassVsStructBenchmark.cs
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

using Alis.Benchmark.ClassVsStruct.Instancies;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.ClassVsStruct
{
    /// <summary>
    ///     The class vs struct benchmark class
    /// </summary>
    [Config(typeof(CustomConfig))]
    public class ClassVsStructBenchmark
    {
        /// <summary>
        ///     The iterations
        /// </summary>
        private const int Iterations = 1_000;

        /// <summary>
        ///     Usings this instance
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark(Baseline = true)]
        public int UsingClass()
        {
            ClassPoint obj = new ClassPoint(1, 2);
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += obj.X + obj.Y;
            }

            return sum;
        }
        
        [Benchmark]
        public int UsingSealedClass()
        {
            SealedClassPoint obj = new SealedClassPoint(1, 2);
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += obj.X + obj.Y;
            }

            return sum;
        }

        /// <summary>
        ///     Usings the struct
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int UsingStruct()
        {
            StructPoint obj = new StructPoint(1, 2);
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += obj.X + obj.Y;
            }

            return sum;
        }
        
        
        /// <summary>
        ///     Usings the struct
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int UsingRefStruct()
        {
            StructRefPoint obj = new StructRefPoint(1, 2);
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += obj.X + obj.Y;
            }

            return sum;
        }
        
        [Benchmark]
        public int UsingRecord()
        {
            RecordPoint obj = new RecordPoint(1, 2);
            int sum = 0;
            for (int i = 0; i < Iterations; i++)
            {
                sum += obj.X + obj.Y;
            }

            return sum;
        }
    }
}