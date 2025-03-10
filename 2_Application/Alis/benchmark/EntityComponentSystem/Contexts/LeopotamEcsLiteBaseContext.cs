using System;
using Leopotam.EcsLite;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    /// The leopotam ecs lite base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class LeopotamEcsLiteBaseContext : IDisposable
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
        public EcsWorld World { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LeopotamEcsLiteBaseContext"/> class
        /// </summary>
        public LeopotamEcsLiteBaseContext()
        {
            World = new EcsWorld();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            World.Destroy();
        }
    }
}
