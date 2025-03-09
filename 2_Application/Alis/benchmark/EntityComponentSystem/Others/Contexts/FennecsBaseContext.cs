using System;
using fennecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    namespace Fennecs_Components
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
    /// The fennecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class FennecsBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FennecsBaseContext"/> class
        /// </summary>
        public FennecsBaseContext()
        {
            World = new World();
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
