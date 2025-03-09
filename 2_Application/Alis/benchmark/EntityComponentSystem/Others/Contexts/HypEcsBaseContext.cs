using System;
using HypEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    /// <summary>
    /// The hyp ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class HypEcsBaseContext : IDisposable
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
        /// Initializes a new instance of the <see cref="HypEcsBaseContext"/> class
        /// </summary>
        public HypEcsBaseContext()
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