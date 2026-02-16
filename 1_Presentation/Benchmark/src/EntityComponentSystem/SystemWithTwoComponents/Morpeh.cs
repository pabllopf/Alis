// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Morpeh.cs
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

using System;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Scellecs.Morpeh;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
    {
        /// <summary>
        ///     The context
        /// </summary>
        [Context] private readonly MorpehContext _context;

        /// <summary>
        ///     Morpehs the direct
        /// </summary>
        [BenchmarkCategory(Categories.Morpeh), Benchmark]
        public void Morpeh_Direct() => _context.MonoThreadDirectSystem.OnUpdate(0f);

        /// <summary>
        ///     Morpehs the stash
        /// </summary>
        [BenchmarkCategory(Categories.Morpeh), Benchmark]
        public void Morpeh_Stash() => _context.MonoThreadStashSystem.OnUpdate(0f);

        /// <summary>
        ///     The morpeh context class
        /// </summary>
        /// <seealso cref="MorpehBaseContext" />
        private sealed class MorpehContext : MorpehBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="MorpehContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public MorpehContext(int entityCount, int entityPadding)
            {
                MonoThreadDirectSystem = new DirectSystem {World = World};
                MonoThreadDirectSystem.OnAwake();

                MonoThreadStashSystem = new StashSystem {World = World};
                MonoThreadStashSystem.OnAwake();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.CreateEntity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.AddComponent<Component1>();
                                break;

                            case 1:
                                padding.AddComponent<Component2>();
                                break;
                        }
                    }

                    Entity entity = World.CreateEntity();
                    entity.AddComponent<Component1>();
                    entity.SetComponent(new Component2 {Value = 1});
                }

                World.Commit();
            }

            /// <summary>
            ///     Gets the value of the mono thread direct system
            /// </summary>
            public ISystem MonoThreadDirectSystem { get; }

            /// <summary>
            ///     Gets the value of the mono thread stash system
            /// </summary>
            public ISystem MonoThreadStashSystem { get; }

            /// <summary>
            ///     The direct system class
            /// </summary>
            /// <seealso cref="ISystem" />
            private sealed class DirectSystem : ISystem
            {
                /// <summary>
                ///     The filter
                /// </summary>
                private Filter _filter;

                /// <summary>
                ///     Gets or sets the value of the scene
                /// </summary>
                public World World { get; set; }

                /// <summary>
                ///     Ons the awake
                /// </summary>
                public void OnAwake()
                {
                    _filter = World.Filter.With<Component1>().With<Component2>().Build();
                }

                /// <summary>
                ///     Ons the update using the specified delta time
                /// </summary>
                /// <param name="deltaTime">The delta time</param>
                public void OnUpdate(float deltaTime)
                {
                    foreach (Entity entity in _filter)
                    {
                        entity.GetComponent<Component1>().Value += entity.GetComponent<Component2>().Value;
                    }
                }

                /// <summary>
                ///     Disposes this instance
                /// </summary>
                void IDisposable.Dispose()
                {
                }
            }

            /// <summary>
            ///     The stash system class
            /// </summary>
            /// <seealso cref="ISystem" />
            private sealed class StashSystem : ISystem
            {
                /// <summary>
                ///     The filter
                /// </summary>
                private Filter _filter;

                /// <summary>
                ///     The stash
                /// </summary>
                private Stash<Component1> _stash1;

                /// <summary>
                ///     The stash
                /// </summary>
                private Stash<Component2> _stash2;

                /// <summary>
                ///     Gets or sets the value of the scene
                /// </summary>
                public World World { get; set; }

                /// <summary>
                ///     Ons the awake
                /// </summary>
                public void OnAwake()
                {
                    _stash1 = World.GetStash<Component1>();
                    _stash2 = World.GetStash<Component2>();
                    _filter = World.Filter.With<Component1>().With<Component2>().Build();
                }

                /// <summary>
                ///     Ons the update using the specified delta time
                /// </summary>
                /// <param name="deltaTime">The delta time</param>
                public void OnUpdate(float deltaTime)
                {
                    foreach (Entity entity in _filter)
                    {
                        _stash1.Get(entity).Value += _stash2.Get(entity).Value;
                    }
                }

                /// <summary>
                ///     Disposes this instance
                /// </summary>
                public void Dispose()
                {
                    _stash1.Dispose();
                    _stash2.Dispose();
                }
            }
        }
    }
}