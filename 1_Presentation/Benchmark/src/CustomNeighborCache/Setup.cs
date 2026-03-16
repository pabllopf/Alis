// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Setup.cs
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

using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomNeighborCache
{
    /// <summary>
    ///     The custom neighbor cache benchmark class
    /// </summary>
    [Config(typeof(CustomConfig))]
    public partial class CustomNeighborCacheBenchmark
    {
        /// <summary>
        ///     Gets or sets the value of the entity count
        /// </summary>
        [Params(1_000)]
        public int EntityCount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the arity
        /// </summary>
        [Params(1, 2, 3, 4, 5, 6, 7, 8)]
        public int Arity { get; set; }

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [IterationSetup]
        public void Setup()
        {
            SetupAlis();
            SetupFrent();
        }

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        [IterationCleanup]
        public void Cleanup()
        {
            DisposeAlis();
            DisposeFrent();
        }
    }
}