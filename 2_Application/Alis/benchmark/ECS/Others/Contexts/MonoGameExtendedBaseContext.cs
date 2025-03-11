using System;

namespace Alis.Benchmark.ECS.Others.Contexts
{
    internal class MonoGameExtendedBaseContext : IDisposable
    {
        public sealed class Component1
        {
            public int Value;
        }

        public sealed class Component2
        {
            public int Value;
        }

        public sealed class Component3
        {
            public int Value;
        }

        public World World { get; }

        public MonoGameExtendedBaseContext()
        {
            World = new WorldBuilder().Build();
        }

        public virtual void Dispose()
        {
            World.Dispose();
        }
    }
}
