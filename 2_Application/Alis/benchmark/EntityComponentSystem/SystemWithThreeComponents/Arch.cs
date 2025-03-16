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

using System.Runtime.CompilerServices;
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
        private static readonly QueryDescription _queryDescription = new() {All = _filter};

        /// <summary>
        ///     The arch
        /// </summary>
        [Context] private readonly ArchContext _arch;

        /// <summary>
        ///     The for each
        /// </summary>
        private ForEach3 _forEach3;

        /// <summary>
        ///     Fors the each using the specified t 0
        /// </summary>
        /// <param name="t0">The </param>
        /// <param name="t1">The </param>
        /// <param name="t2">The </param>
        [Query]
        private static void ForEach(ref Component1 t0, Component2 t1, Component3 t2)
        {
            t0.Value += t1.Value + t2.Value;
        }

        /// <summary>
        ///     Arches the mono thread
        /// </summary>
        [BenchmarkCategory(Categories.Arch), Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach3, Component1, Component2, Component3>(_queryDescription, ref _forEach3);
        }

        /// <summary>
        ///     Arches the mono thread source generated
        /// </summary>
        [BenchmarkCategory(Categories.Arch), Benchmark]
        public void Arch_MonoThread_SourceGenerated()
        {
            ForEachQuery(_arch.World);
        }

        /// <summary>
        ///     Arches the multi thread
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
        private struct ForEach3 : IForEach<Component1, Component2, Component3>
        {
            /// <summary>
            ///     Updates the t 0
            /// </summary>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            /// <param name="t2">The </param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            /// <param name="entityCount">The entity count</param>
            /// <param name="_">The </param>
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            {
            }
        }
    }
}