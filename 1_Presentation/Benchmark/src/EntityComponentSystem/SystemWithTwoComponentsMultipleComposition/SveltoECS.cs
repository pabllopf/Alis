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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
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
            /// <param name="entityCount">The gameObject count</param>
            public SveltoECSContext(int entityCount)
            {
                Engine = new SveltoEngine();
                Root.AddEngine(Engine);

                uint id = 0;
                for (int i = 0; i < entityCount; ++i)
                {
                    EntityInitializer entity = (i % 4) switch
                    {
                        0 => Factory.BuildEntity<Entity1>(id++, Group),
                        1 => Factory.BuildEntity<Entity2>(id++, Group),
                        2 => Factory.BuildEntity<Entity3>(id++, Group),
                        _ => Factory.BuildEntity<Entity4>(id++, Group)
                    };

                    entity.Get<Component2>() = new Component2 {Value = 1};
                }

                Scheduler.SubmitEntities();
            }

            /// <summary>
            ///     Gets the value of the engine
            /// </summary>
            public SveltoEngine Engine { get; }

            private record struct Padding1 : IEntityComponent;

            private record struct Padding2 : IEntityComponent;

            private record struct Padding3 : IEntityComponent;

            private record struct Padding4 : IEntityComponent;

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
            ///     The gameObject class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1, Component2, Padding1}" />
            private sealed class Entity1 : GenericEntityDescriptor<Component1, Component2, Padding1>
            {
            }

            /// <summary>
            ///     The gameObject class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1, Component2, Padding2}" />
            private sealed class Entity2 : GenericEntityDescriptor<Component1, Component2, Padding2>
            {
            }

            /// <summary>
            ///     The gameObject class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1, Component2, Padding3}" />
            private sealed class Entity3 : GenericEntityDescriptor<Component1, Component2, Padding3>
            {
            }

            /// <summary>
            ///     The gameObject class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1, Component2, Padding4}" />
            private sealed class Entity4 : GenericEntityDescriptor<Component1, Component2, Padding4>
            {
            }

            /// <summary>
            ///     The gameObject class
            /// </summary>
            /// <seealso cref="GenericEntityDescriptor{Component1, Component2}" />
            private sealed class Entity : GenericEntityDescriptor<Component1, Component2>
            {
            }
        }
    }
}