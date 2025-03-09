using Alis.Benchmark.ECS.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.SystemWithOneComponent
{
    public partial class SystemWithOneComponent
    {
        private sealed class RelEcsContext : RelEcsBaseContext
        {
            private sealed class MonoThreadRunSystem : ISystem
            {
                public void Run(World world)
                {
                    foreach (Component1 c in world.Query<Component1>().Build())
                    {
                        c.Value++;
                    }
                }
            }

            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            public RelEcsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World
                        .Spawn()
                        .Add(new Component1());
                }
            }
        }

        [Context]
        private readonly RelEcsContext _relEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run(_relEcs.World);
    }
}
