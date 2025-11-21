// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:_SystemWithTwoComponents.cs
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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    [BenchmarkCategory(Categories.System), Config(typeof(CustomConfig))]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class SystemWithTwoComponents
    {
        /// <summary>
        ///     Gets or sets the value of the gameObject count
        /// </summary>
        [Params(1_000)]
        public int EntityCount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the gameObject padding
        /// </summary>
        [Params(0, 10)]
        public int EntityPadding { get; set; }

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this, EntityCount, EntityPadding);

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        [GlobalCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}