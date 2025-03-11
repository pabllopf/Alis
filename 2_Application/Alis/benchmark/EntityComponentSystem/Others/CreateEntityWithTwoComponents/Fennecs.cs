using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.Fennecs_Components;
using BenchmarkDotNet.Attributes;
using fennecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
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
                world.Spawn().
                    Add<Component1>().Add<Component2>();
            }
        }
    }
}
