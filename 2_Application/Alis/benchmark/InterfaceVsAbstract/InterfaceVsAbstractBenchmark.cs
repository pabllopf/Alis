// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InterfaceVsAbstractBenchmark.cs
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

using Alis.Benchmark.InterfaceVsAbstract.Instancies;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.InterfaceVsAbstract
{
    /// <summary>
    ///     The interface vs abstract benchmark class
    /// </summary>
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class InterfaceVsAbstractBenchmark
    {
        /// <summary>
        ///     The abstract shapes
        /// </summary>
        private Shape[] abstractShapes;

        /// <summary>
        ///     The interface shapes
        /// </summary>
        private IShape[] interfaceShapes;

        /// <summary>
        ///     The
        /// </summary>
        [Params(10, 100, 1000)] public int N;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            interfaceShapes = new IShape[N];
            abstractShapes = new Shape[N];

            for (int i = 0; i < N; i++)
            {
                interfaceShapes[i] = new CircleInterface(i + 1);
                abstractShapes[i] = new CircleAbstract(i + 1);
            }
        }

        /// <summary>
        ///     Interfaces the method call
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public float InterfaceMethodCall()
        {
            float sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += interfaceShapes[i].GetArea();
            }

            return sum;
        }

        /// <summary>
        ///     Abstracts the method call
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public float AbstractMethodCall()
        {
            float sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += abstractShapes[i].GetArea();
            }

            return sum;
        }
    }
}