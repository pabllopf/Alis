using System;
using Arch.Core;
using Arch.Core.Utils;
using Schedulers;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    namespace Arch_Components
    {
        /// <summary>
        /// The component
        /// </summary>
        internal struct Component1
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        internal struct Component2
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        internal struct Component3
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }
    }

    /// <summary>
    /// The arch base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class ArchBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; }
        /// <summary>
        /// Gets or sets the value of the job scheduler
        /// </summary>
        public JobScheduler JobScheduler { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchBaseContext"/> class
        /// </summary>
        public ArchBaseContext()
        {
            World = World.Create();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchBaseContext"/> class
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="amount">The amount</param>
        public ArchBaseContext(ComponentType[] archetype, int amount)
        {
            JobScheduler = new JobScheduler(new JobScheduler.Config
            {
                ThreadPrefixName = "Arch.Samples",
                ThreadCount = 0,
                MaxExpectedConcurrentJobs = 64,
                StrictAllocationMode = false,
            });
            
            World = World.Create();
            World.SharedJobScheduler = JobScheduler;
            World.Reserve(archetype, amount);

            for (int index = 0; index < amount; index++)
            {
                World.Create(archetype);
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            World.Destroy(World);
            JobScheduler?.Dispose();
        }
    }
}
