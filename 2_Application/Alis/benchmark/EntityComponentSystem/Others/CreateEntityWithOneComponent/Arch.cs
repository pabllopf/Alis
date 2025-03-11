using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.Arch_Components;
using Arch.Core;
using Arch.Core.Utils;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The component
        /// </summary>
        private static readonly ComponentType[] _archetype = [typeof(Component1)];

        /// <summary>
        /// The arch
        /// </summary>
        [Context]
        private readonly ArchBaseContext _arch;

        /// <summary>
        /// Arches this instance
        /// </summary>
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.Reserve(_archetype, EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Create(_archetype);
            }
        }
    }
}
