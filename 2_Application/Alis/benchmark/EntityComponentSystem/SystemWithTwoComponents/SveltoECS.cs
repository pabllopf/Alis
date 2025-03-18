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

using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
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
                        switch (j % 2)
                        {
                            case 0:
                                Factory.BuildEntity<Padding1Entity>(id++, Group);
                                break;

                            case 1:
                                Factory.BuildEntity<Padding2Entity>(id++, Group);
                                break;
                        }
                    }

                    EntityInitializer entity = Factory.BuildEntity<Entity>(id++, Group);
                    entity.GetOrAdd<Component2>() = new Component2 {Value = 1};
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
                    (NB<Component1> c1, NB<Component2> c2, int count) = entitiesDB.QueryEntities<Component1, Component2>(Group);

                    for (int i = 0; i < count; i++)
                    {
                        c1[i].Value += c2[i].Value;
                    }
                }
            }

            /// <summary>
            ///     The padding entity class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1}" />
            public sealed class Padding1Entity : GenericEntityDescriptor<Component1>
            {
            }

            /// <summary>
            ///     The padding entity class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component2}" />
            public sealed class Padding2Entity : GenericEntityDescriptor<Component2>
            {
            }

            /// <summary>
            ///     The entity class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1, Component2}" />
            public sealed class Entity : GenericEntityDescriptor<Component1, Component2>
            {
            }
        }
    }
}