using System;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    /// <summary>
    /// The leopotam ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class LeopotamEcsBaseContext : IDisposable
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
        /// Initializes a new instance of the <see cref="LeopotamEcsBaseContext"/> class
        /// </summary>
        public LeopotamEcsBaseContext()
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
