using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Fennecs_Components;
using BenchmarkDotNet.Attributes;
using fennecs;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The fennecs
        /// </summary>
        [Context] private readonly FennecsBaseContext _fennecs;

        /// <summary>
        /// Fennecses this instance
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs()
        {
            World world = _fennecs.World;

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Spawn().Add<Component1>();
            }
        }
    }
}
