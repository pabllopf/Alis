using System;
using Frent;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    /// <summary>
    /// The frent base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class FrentBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; } = new();
        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => World.Dispose();

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
}
