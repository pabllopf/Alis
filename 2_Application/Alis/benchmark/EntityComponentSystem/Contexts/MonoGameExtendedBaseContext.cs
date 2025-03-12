using System;
using MonoGame.Extended.Entities;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    /// <summary>
    /// The mono game extended base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class MonoGameExtendedBaseContext : IDisposable
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
        /// Initializes a new instance of the <see cref="MonoGameExtendedBaseContext"/> class
        /// </summary>
        public MonoGameExtendedBaseContext()
        {
            World = new WorldBuilder().Build();
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
