using System;
using RelEcs;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    /// The rel ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class RelEcsBaseContext : IDisposable
    {
        /// <summary>
        /// The component class
        /// </summary>
        public sealed class Component1
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component class
        /// </summary>
        public sealed class Component2
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component class
        /// </summary>
        public sealed class Component3
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelEcsBaseContext"/> class
        /// </summary>
        public RelEcsBaseContext()
        {
            World = new World();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            // World.Destroy();
        }
    }
}
