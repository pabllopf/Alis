using System;

namespace Alis.Benchmark.ECS.Others.Contexts
{
    internal class LeopotamEcsLiteBaseContext : IDisposable
    {
        public struct Component1
        {
            public int Value;
        }

        public struct Component2
        {
            public int Value;
        }

        public struct Component3
        {
            public int Value;
        }

        public EcsWorld World { get; }

        public LeopotamEcsLiteBaseContext()
        {
            World = new EcsWorld();
        }

        public virtual void Dispose()
        {
            World.Destroy();
        }
    }
}
