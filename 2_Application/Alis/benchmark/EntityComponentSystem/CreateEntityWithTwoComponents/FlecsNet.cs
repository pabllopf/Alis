using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
    {
        /// <summary>
        /// The flecs
        /// </summary>
        [Context]
        private readonly FlecsNetBaseContext _flecs;

        /// <summary>
        /// Flecses the net
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet()
        {
            World world = _flecs.World;

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Entity()
                    .Set<Component1>(new())
                    .Set<Component2>(new());
            }
        }
    }
}
