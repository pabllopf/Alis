// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LeopotamEcs.cs
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
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        ///     The leopotam ecs
        /// </summary>
        [Context] private readonly LeopotamEcsContext _leopotamEcs;

        /// <summary>
        ///     Leopotams the ecs
        /// </summary>
        [BenchmarkCategory(Categories.LeopotamEcs), Benchmark]
        public void LeopotamEcs() => _leopotamEcs.MonoThreadSystem.Run();

        /// <summary>
        ///     The leopotam ecs context class
        /// </summary>
        /// <seealso cref="LeopotamEcsBaseContext" />
        private sealed class LeopotamEcsContext : LeopotamEcsBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="LeopotamEcsContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public LeopotamEcsContext(int entityCount, int entityPadding)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.NewEntity();
                    }

                    World.NewEntity()
                        .Replace(new Component1());
                }
            }

            /// <summary>
            ///     Gets the value of the mono thread system
            /// </summary>
            public EcsSystems MonoThreadSystem { get; }

            /// <summary>
            ///     The mono thread run system class
            /// </summary>
            /// <seealso cref="IEcsRunSystem" />
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                /// <summary>
                ///     The filter
                /// </summary>
                private readonly EcsFilter<Component1> _filter;

                /// <summary>
                ///     Runs this instance
                /// </summary>
                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        ++_filter.Get1(i).Value;
                    }
                }
            }
        }
    }
}