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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        ///     The component
        /// </summary>
        private static readonly ComponentType[] _filter = [typeof(Component1)];

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
        private ForEach1 _forEach;

        /// <summary>
        ///     Fors the each using the specified t 0
        /// </summary>
        /// <param name="t0">The </param>
        [Query]
        private static void ForEach(ref Component1 t0)
        {
            ++t0.Value;
        }

        /// <summary>
        ///     Arches the mono thread
        /// </summary>
        [BenchmarkCategory(Categories.Arch), Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
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
            world.InlineParallelQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }

        /// <summary>
        ///     The for each
        /// </summary>
        private struct ForEach1 : IForEach<Component1>
        {
            /// <summary>
            ///     Updates the t 0
            /// </summary>
            /// <param name="t0">The </param>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0)
            {
                ++t0.Value;
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