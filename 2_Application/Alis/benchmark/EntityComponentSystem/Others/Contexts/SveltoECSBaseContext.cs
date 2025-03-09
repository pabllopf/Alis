using System;
using Svelto.ECS;
using Svelto.ECS.Schedulers;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    /// <summary>
    /// The svelto ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class SveltoECSBaseContext : IDisposable
    {
        /// <summary>
        /// The component
        /// </summary>
        public struct Component1 : IEntityComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        public struct Component2 : IEntityComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        public struct Component3 : IEntityComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// Gets the value of the group
        /// </summary>
        public static ExclusiveGroup Group { get; } = new();

        /// <summary>
        /// Gets the value of the scheduler
        /// </summary>
        public SimpleEntitiesSubmissionScheduler Scheduler { get; }
        /// <summary>
        /// Gets the value of the root
        /// </summary>
        public EnginesRoot Root { get; }
        /// <summary>
        /// Gets the value of the factory
        /// </summary>
        public IEntityFactory Factory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SveltoECSBaseContext"/> class
        /// </summary>
        public SveltoECSBaseContext()
        {
            Scheduler = new SimpleEntitiesSubmissionScheduler();
            Root = new EnginesRoot(Scheduler);
            Factory = Root.GenerateEntityFactory();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            Root.Dispose();
            Scheduler.Dispose();
        }
    }
}
