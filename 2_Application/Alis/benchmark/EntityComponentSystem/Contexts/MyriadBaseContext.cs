using System;
using Myriad.ECS;
using Myriad.ECS.Worlds;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    namespace Myriad_Components
    {
        /// <summary>
        /// The component
        /// </summary>
        internal struct Component1
            : IComponent
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
            : IComponent
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
            : IComponent
        {
            /// <summary>
            /// The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        /// The padding
        /// </summary>
        internal struct Padding1
            : IComponent
        {
        }

        /// <summary>
        /// The padding
        /// </summary>
        internal struct Padding2
            : IComponent
        {
        }

        /// <summary>
        /// The padding
        /// </summary>
        internal struct Padding3
            : IComponent
        {
        }

        /// <summary>
        /// The padding
        /// </summary>
        internal struct Padding4
            : IComponent
        {
        }
    }

    /// <summary>
    /// The myriad base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class MyriadBaseContext
        : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyriadBaseContext"/> class
        /// </summary>
        public MyriadBaseContext()
        {
            World = new WorldBuilder().Build();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
        }
    }
}
