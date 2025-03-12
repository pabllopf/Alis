using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Arch_Components;
using Arch.Core.Utils;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The component
        /// </summary>
        private static readonly ComponentType[] _archetype = [typeof(Component1), typeof(Component2), typeof(Component3)];

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
            Arch.Core.World world = _arch.World;
            world.Reserve(_archetype, EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Create(_archetype);
            }
        }
    }
}
