using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.FlecsNet_Components;
using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
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
                    .Set<Component1>(new());
            }
        }
    }
}
