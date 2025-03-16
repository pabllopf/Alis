// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SveltoECS.cs
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
using Svelto.DataStructures;
using Svelto.ECS;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        ///     The svelto ecs
        /// </summary>
        [Context] private readonly SveltoECSContext _sveltoECS;

        /// <summary>
        ///     Sveltoes the ecs
        /// </summary>
        [BenchmarkCategory(Categories.SveltoECS), Benchmark]
        public void SveltoECS() => _sveltoECS.Engine.Update();

        /// <summary>
        ///     The svelto ecs context class
        /// </summary>
        /// <seealso cref="SveltoECSBaseContext" />
        private sealed class SveltoECSContext : SveltoECSBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="SveltoECSContext" /> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public SveltoECSContext(int entityCount, int entityPadding)
            {
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                uint id = 0;
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Factory.BuildEntity<PaddingEntity>(id++, Group);
                    }

                    Factory.BuildEntity<Entity>(id++, Group);
                }

                Scheduler.SubmitEntities();
            }

            /// <summary>
            ///     Gets the value of the engine
            /// </summary>
            public SveltoEngine Engine { get; }

            /// <summary>
            ///     The svelto engine class
            /// </summary>
            /// <seealso cref="IQueryingEntitiesEngine" />
            public sealed class SveltoEngine : IQueryingEntitiesEngine
            {
                /// <summary>
                ///     Gets or sets the value of the entities db
                /// </summary>
                public EntitiesDB entitiesDB { get; set; }

                /// <summary>
                ///     Readies this instance
                /// </summary>
                public void Ready()
                {
                }

                /// <summary>
                ///     Updates this instance
                /// </summary>
                public void Update()
                {
                    (NB<Component1> entityViews, int count) = entitiesDB.QueryEntities<Component1>(Group);

                    for (int i = 0; i < count; i++)
                    {
                        ++entityViews[i].Value;
                    }
                }
            }

            /// <summary>
            ///     The padding entity class
            /// </summary>
            /// <seealso cref="IEntityDescriptor" />
            public sealed class PaddingEntity : IEntityDescriptor
            {
                /// <summary>
                ///     Gets the value of the components to build
                /// </summary>
                public IComponentBuilder[] componentsToBuild => Array.Empty<IComponentBuilder>();
            }

            /// <summary>
            ///     The entity class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1}" />
            public sealed class Entity : GenericEntityDescriptor<Component1>
            {
            }
        }
    }
}