// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Arch.cs
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

using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Arch_Components;
using Arch.Core;
using Arch.Core.Utils;
using Arch.System;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithThreeComponents
{
    /// <summary>
    ///     The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
    {
        /// <summary>
        ///     The component
        /// </summary>
        private static readonly ComponentType[] _filter = [typeof(Component1), typeof(Component2), typeof(Component3)];

        /// <summary>
        ///     The filter
        /// </summary>
        private static readonly QueryDescription _queryDescription = new QueryDescription {All = _filter};

        /// <summary>
        ///     The arch
        /// </summary>
        [Context] private readonly ArchContext _arch;

        /// <summary>
        ///     The for each
        /// </summary>
        private ForEach3 _forEach3;

        /// <summary>
        ///     Sums the second and third component values into the first
        /// </summary>
        /// <param name="t0">The first component whose value will be increased</param>
        /// <param name="t1">The second component whose value is added</param>
        /// <param name="t2">The third component whose value is added</param>
        [Query]
        private static void ForEach(ref Component1 t0, Component2 t1, Component3 t2)
        {
            t0.Value += t1.Value + t2.Value;
        }

        /// <summary>
        ///     Benchmarks mono-threaded inline query with three components using Arch ECS
        /// </summary>
        [BenchmarkCategory(Categories.Arch), Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach3, Component1, Component2, Component3>(_queryDescription, ref _forEach3);
        }

        /// <summary>
        ///     Benchmarks source-generated mono-threaded query with three components using Arch ECS
        /// </summary>
        [BenchmarkCategory(Categories.Arch), Benchmark]
        public void Arch_MonoThread_SourceGenerated()
        {
            ForEachQuery(_arch.World);
        }

        /// <summary>
        ///     Benchmarks multi-threaded parallel query with three components using Arch ECS
        /// </summary>
        [BenchmarkCategory(Categories.Arch), Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.InlineParallelQuery<ForEach3, Component1, Component2, Component3>(_queryDescription, ref _forEach3);
        }

        /// <summary>
        ///     The for each
        /// </summary>
        public struct ForEach3 : IForEach<Component1, Component2, Component3>
        {
            /// <summary>
            ///     Sums the second and third component values into the first
            /// </summary>
            /// <param name="t0">The first component whose value will be increased</param>
            /// <param name="t1">The second component whose value is added</param>
            /// <param name="t2">The third component whose value is added</param>
            public void Update(ref Component1 t0, ref Component2 t1, ref Component3 t2)
            {
                t0.Value += t1.Value + t2.Value;
            }
        }

        /// <summary>
        ///     The arch context class
        /// </summary>
        /// <seealso cref="ArchBaseContext" />
        private sealed class ArchContext : ArchBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="ArchContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="_">Unused padding parameter for API compatibility</param>
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            {
            }
        }
    }
}