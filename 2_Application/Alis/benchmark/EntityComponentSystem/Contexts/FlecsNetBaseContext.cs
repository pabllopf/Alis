using System;
using Flecs.NET.Core;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    namespace FlecsNet_Components
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
    /// The flecs net base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class FlecsNetBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlecsNetBaseContext"/> class
        /// </summary>
        public FlecsNetBaseContext()
        {
            World = World.Create();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            World.Dispose();
        }
    }
}
