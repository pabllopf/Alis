using System;
using DefaultEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    /// <summary>
    /// The default ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class DefaultEcsBaseContext : IDisposable
    {
        /// <summary>
        /// The component
        /// </summary>
        public struct Component1
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        public struct Component2
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        public struct Component3
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
        /// Initializes a new instance of the <see cref="DefaultEcsBaseContext"/> class
        /// </summary>
        public DefaultEcsBaseContext()
        {
            World = new World();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}
