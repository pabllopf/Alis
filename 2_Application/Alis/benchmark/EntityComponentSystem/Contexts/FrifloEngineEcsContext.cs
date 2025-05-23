// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrifloEngineEcsContext.cs
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
using System.Runtime.InteropServices;
using Alis.Benchmark.EntityComponentSystem.Contexts.FrifloEngine_Components;
using Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent;
using Friflo.Engine.ECS;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    namespace FrifloEngine_Components
    {
        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Component1 : IComponent
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Component2 : IComponent
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The component
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Component3 : IComponent
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }
    }

    /// <summary>
    ///     The friflo engine ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class FrifloEngineEcsBaseContext : IDisposable
    {
        /// <summary>
        ///     The job one
        /// </summary>
        public readonly QueryJob<Component1> jobOne;

        /// <summary>
        ///     The job three
        /// </summary>
        public readonly QueryJob<Component1, Component2, Component3> jobThree;

        /// <summary>
        ///     The job two
        /// </summary>
        public readonly QueryJob<Component1, Component2> jobTwo;

        /// <summary>
        ///     The job two with composition
        /// </summary>
        public readonly QueryJob<Component1, Component2> jobTwoWithComposition;

        /// <summary>
        ///     The query one
        /// </summary>
        public readonly ArchetypeQuery<Component1> queryOne;

        /// <summary>
        ///     The query three
        /// </summary>
        public readonly ArchetypeQuery<Component1, Component2, Component3> queryThree;

        /// <summary>
        ///     The query two
        /// </summary>
        public readonly ArchetypeQuery<Component1, Component2> queryTwo;


        /// <summary>
        ///     Initializes a new instance of the <see cref="FrifloEngineEcsBaseContext" /> class
        /// </summary>
        protected FrifloEngineEcsBaseContext()
        {
            ParallelJobRunner runner = new ParallelJobRunner(Environment.ProcessorCount);
            EntityStore = new EntityStore(PidType.UsePidAsId) {JobRunner = runner};
            queryOne = EntityStore.Query<Component1>();
            queryTwo = EntityStore.Query<Component1, Component2>();
            queryThree = EntityStore.Query<Component1, Component2, Component3>();

            jobOne = queryOne.ForEach(SystemWithOneComponent.SystemWithOneComponent.FrifloEngineEcsContext.ForEach);
            jobTwo = queryTwo.ForEach(SystemWithTwoComponents.SystemWithTwoComponents.FrifloEngineEcsContext.ForEach);
            jobThree = queryThree.ForEach(SystemWithThreeComponents.SystemWithThreeComponents.FrifloEngineEcsContext.ForEach);
            jobTwoWithComposition = queryTwo.ForEach(SystemWithTwoComponentsMultipleComposition.SystemWithTwoComponentsMultipleComposition.FrifloEngineEcsContext.ForEach);
        }

        /// <summary>See padding notes</summary>
        /// <param name="entityCount"></param>
        /// <param name="padding">
        ///     has no influence on benchmarks performance for: SystemWith...Components
        ///     e.g. Params[Params(0, 10)] at <see cref="SystemWithOneComponent.EntityPadding" />
        /// </param>
        /// <param name="componentTypes"></param>
        protected FrifloEngineEcsBaseContext(int entityCount, int padding, ComponentTypes componentTypes) : this()
        {
            EntityStore.EnsureCapacity(entityCount + padding * entityCount);

            Archetype archetype = EntityStore.GetArchetype(componentTypes);
            archetype.EnsureCapacity(entityCount);

            for (int index = 0; index < entityCount; index++)
            {
                for (int n = 0; n < padding; n++)
                {
                    EntityStore.CreateEntity();
                }

                archetype.CreateEntity();
            }
        }

        /// <summary>
        ///     Gets the value of the gameObject store
        /// </summary>
        protected EntityStore EntityStore { get; }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            EntityStore.JobRunner?.Dispose();
        }
    }
}