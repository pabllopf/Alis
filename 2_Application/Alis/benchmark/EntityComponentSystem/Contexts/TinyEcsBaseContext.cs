using System;
using TinyEcs;

namespace Alis.Benchmark.EntityComponentSystem.Contexts
{
    namespace TinyEcs_Components
    {
        public record struct Component1(int Value);

        public record struct Component2(int Value);

        public record struct Component3(int Value);
    }

    /// <summary>
    /// The tiny ecs base context class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class TinyEcsBaseContext : IDisposable
    {
        /// <summary>
        /// Gets the value of the world
        /// </summary>
        public World World { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyEcsBaseContext"/> class
        /// </summary>
        public TinyEcsBaseContext()
        {
            World = new World();
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public virtual void Dispose()
        {
            World?.Dispose();
        }
    }
}
