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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
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
            /// <param name="entityCount">The entity count</param>
            public LeopotamEcsContext(int entityCount)
            {
                MonoThreadSystem = new EcsSystems(World).Add(new MonoThreadRunSystem()).ProcessInjects();

                MonoThreadSystem.Init();

                for (int i = 0; i < entityCount; ++i)
                {
                    EcsEntity entity = World
                        .NewEntity()
                        .Replace(new Component1())
                        .Replace(new Component2 {Value = 1});

                    switch (i % 4)
                    {
                        case 0:
                            entity.Replace(new Padding1());
                            break;

                        case 1:
                            entity.Replace(new Padding2());
                            break;

                        case 2:
                            entity.Replace(new Padding3());
                            break;

                        case 3:
                            entity.Replace(new Padding4());
                            break;
                    }
                }
            }

            /// <summary>
            ///     Gets the value of the mono thread system
            /// </summary>
            public EcsSystems MonoThreadSystem { get; }

            private record struct Padding1;

            private record struct Padding2;

            private record struct Padding3;

            private record struct Padding4;

            /// <summary>
            ///     The mono thread run system class
            /// </summary>
            /// <seealso cref="IEcsRunSystem" />
            private sealed class MonoThreadRunSystem : IEcsRunSystem
            {
                /// <summary>
                ///     The filter
                /// </summary>
                private readonly EcsFilter<Component1, Component2> _filter;

                /// <summary>
                ///     Runs this instance
                /// </summary>
                public void Run()
                {
                    for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                    {
                        _filter.Get1(i).Value += _filter.Get2(i).Value;
                    }
                }
            }
        }
    }
}