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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
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
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public MonoGameExtendedContext(int entityCount, int entityPadding)
            {
                _system = new UpdateSystem();
                World = new WorldBuilder().AddSystem(_system).Build();
                Time = new GameTime();

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.CreateEntity();
                    }

                    Entity entity = World.CreateEntity();
                    entity.Attach(new Component1());
                }
            }

            /// <summary>
            ///     Gets the value of the world
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
            ///     The update system class
            /// </summary>
            /// <seealso cref="EntityUpdateSystem" />
            public sealed class UpdateSystem : EntityUpdateSystem
            {
                /// <summary>
                ///     The components
                /// </summary>
                private ComponentMapper<Component1> _components;

                /// <summary>
                ///     Initializes a new instance of the <see cref="UpdateSystem" /> class
                /// </summary>
                public UpdateSystem()
                    : base(Aspect.All(typeof(Component1)))
                {
                }

                /// <summary>
                ///     Initializes the mapper service
                /// </summary>
                /// <param name="mapperService">The mapper service</param>
                public override void Initialize(IComponentMapperService mapperService)
                {
                    _components = mapperService.GetMapper<Component1>();
                }

                /// <summary>
                ///     Updates the game time
                /// </summary>
                /// <param name="gameTime">The game time</param>
                public override void Update(GameTime gameTime)
                {
                    foreach (int entityId in ActiveEntities)
                    {
                        ++_components.Get(entityId).Value;
                    }
                }
            }
        }
    }
}