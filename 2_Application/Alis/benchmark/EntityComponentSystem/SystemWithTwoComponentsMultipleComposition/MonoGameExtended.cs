// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonoGameExtended.cs
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
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        ///     The mono game extended
        /// </summary>
        [Context] private readonly MonoGameExtendedContext _monoGameExtended;

        /// <summary>
        ///     Monoes the game extended
        /// </summary>
        [BenchmarkCategory(Categories.MonoGameExtended), Benchmark]
        public void MonoGameExtended() => _monoGameExtended.World.Update(_monoGameExtended.Time);

        /// <summary>
        ///     The mono game extended context class
        /// </summary>
        /// <seealso cref="MonoGameExtendedBaseContext" />
        private sealed class MonoGameExtendedContext : MonoGameExtendedBaseContext
        {
            /// <summary>
            ///     The system
            /// </summary>
            private readonly UpdateSystem _system;

            /// <summary>
            ///     Initializes a new instance of the <see cref="MonoGameExtendedContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            public MonoGameExtendedContext(int entityCount)
            {
                _system = new UpdateSystem();
                World = new WorldBuilder().AddSystem(_system).Build();
                Time = new GameTime();

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Attach(new Component1());
                    entity.Attach(new Component2 {Value = 1});

                    switch (i % 4)
                    {
                        case 0:
                            entity.Attach(new Padding1());
                            break;

                        case 1:
                            entity.Attach(new Padding2());
                            break;

                        case 2:
                            entity.Attach(new Padding3());
                            break;

                        case 3:
                            entity.Attach(new Padding4());
                            break;
                    }
                }
            }

            /// <summary>
            ///     Gets the value of the scene
            /// </summary>
            public new World World { get; }

            /// <summary>
            ///     Gets the value of the time
            /// </summary>
            public GameTime Time { get; }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public override void Dispose()
            {
                World.Dispose();
                _system.Dispose();

                base.Dispose();
            }

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding3;

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding4;

            /// <summary>
            ///     The update system class
            /// </summary>
            /// <seealso cref="EntityUpdateSystem" />
            public sealed class UpdateSystem : EntityUpdateSystem
            {
                /// <summary>
                ///     The
                /// </summary>
                private ComponentMapper<Component1> _c1;

                /// <summary>
                ///     The
                /// </summary>
                private ComponentMapper<Component2> _c2;

                /// <summary>
                ///     Initializes a new instance of the <see cref="UpdateSystem" /> class
                /// </summary>
                public UpdateSystem()
                    : base(Aspect.All(typeof(Component1), typeof(Component2)))
                {
                }

                /// <summary>
                ///     Initializes the mapper service
                /// </summary>
                /// <param name="mapperService">The mapper service</param>
                public override void Initialize(IComponentMapperService mapperService)
                {
                    _c1 = mapperService.GetMapper<Component1>();
                    _c2 = mapperService.GetMapper<Component2>();
                }

                /// <summary>
                ///     Updates the game time
                /// </summary>
                /// <param name="gameTime">The game time</param>
                public override void Update(GameTime gameTime)
                {
                    foreach (int entityId in ActiveEntities)
                    {
                        _c1.Get(entityId).Value += _c2.Get(entityId).Value;
                    }
                }
            }
        }
    }
}