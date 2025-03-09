using System;
using Scellecs.Morpeh;

namespace Alis.Benchmark.EntityComponentSystem.Others.Contexts
{
    /// <summary>
    /// The morpeh base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class MorpehBaseContext : IDisposable
    {
        /// <summary>
        /// The component
        /// </summary>
        public struct Component1 : IComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        public struct Component2 : IComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The component
        /// </summary>
        public struct Component3 : IComponent
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
        /// Initializes a new instance of the <see cref="MorpehBaseContext"/> class
        /// </summary>
        public MorpehBaseContext()
        {
            World = World.Create();
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
