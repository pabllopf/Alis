using System;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.FrifloEngine_Components;
using Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent;
using Friflo.Engine.ECS;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    namespace FrifloEngine_Components
    {
        /// <summary>
        /// The component
        /// </summary>
        internal struct Component1 : IComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        internal struct Component2 : IComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        internal struct Component3 : IComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }
    }

    /// <summary>
    /// The friflo engine ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class FrifloEngineEcsBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the entity store
        /// </summary>
        protected EntityStore EntityStore { get; }
        /// <summary>
        /// The query one
        /// </summary>
        public readonly ArchetypeQuery<Component1> queryOne;
        /// <summary>
        /// The query two
        /// </summary>
        public readonly ArchetypeQuery<Component1, Component2> queryTwo;
        /// <summary>
        /// The query three
        /// </summary>
        public readonly ArchetypeQuery<Component1, Component2, Component3> queryThree;
        
        /// <summary>
        /// The job one
        /// </summary>
        public readonly QueryJob<Component1> jobOne;
        /// <summary>
        /// The job two
        /// </summary>
        public readonly QueryJob<Component1, Component2> jobTwo;
        /// <summary>
        /// The job three
        /// </summary>
        public readonly QueryJob<Component1, Component2, Component3> jobThree;
        /// <summary>
        /// The job two with composition
        /// </summary>
        public readonly QueryJob<Component1, Component2> jobTwoWithComposition;


        /// <summary>
        /// Initializes a new instance of the <see cref="FrifloEngineEcsBaseContext"/> class
        /// </summary>
        protected FrifloEngineEcsBaseContext()
        {
            ParallelJobRunner runner = new ParallelJobRunner(Environment.ProcessorCount);
            EntityStore = new EntityStore(PidType.UsePidAsId) { JobRunner = runner };
            queryOne    = EntityStore.Query<Component1>();
            queryTwo    = EntityStore.Query<Component1, Component2>();
            queryThree  = EntityStore.Query<Component1, Component2, Component3>();
            
            jobOne = queryOne.ForEach(SystemWithOneComponent.SystemWithOneComponent.FrifloEngineEcsContext.ForEach);
            jobTwo = queryTwo.ForEach(SystemWithTwoComponents.SystemWithTwoComponents.FrifloEngineEcsContext.ForEach);
            jobThree = queryThree.ForEach(SystemWithThreeComponents.SystemWithThreeComponents.FrifloEngineEcsContext.ForEach);
            jobTwoWithComposition = queryTwo.ForEach(SystemWithTwoComponentsMultipleComposition.SystemWithTwoComponentsMultipleComposition.FrifloEngineEcsContext.ForEach);
        }

        /// <summary>See padding notes</summary>
        /// <param name="entityCount"></param>
        /// <param name="padding">
        /// has no influence on benchmarks performance for: SystemWith...Components
        /// e.g. Params[Params(0, 10)] at <see cref="SystemWithOneComponent.EntityPadding"/>
        /// </param>
        /// <param name="componentTypes"></param>
        protected FrifloEngineEcsBaseContext(int entityCount, int padding, ComponentTypes componentTypes) : this()
        {

            EntityStore.EnsureCapacity(entityCount + (padding * entityCount));

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
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            EntityStore.JobRunner?.Dispose();
        }
    }
}
