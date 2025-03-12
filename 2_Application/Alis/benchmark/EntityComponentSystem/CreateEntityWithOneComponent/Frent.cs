using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Core;
using static Alis.Benchmark.EntityComponentSystem.Contexts.FrentBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The id
        /// </summary>
        private static readonly EntityType _entityType = Entity.EntityTypeOf([Component<Component1>.ID], []);

        /// <summary>
        /// The frent
        /// </summary>
        [Context]
        private readonly FrentBaseContext _frent;

        /// <summary>
        /// Frents this instance
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent()
        {
            World world = _frent.World;
            world.EnsureCapacity(_entityType, EntityCount);

            for (int i = 0; i < EntityCount; i++)
                world.Create<Component1>(default);
        }

        /// <summary>
        /// Frents the bulk
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Bulk()
        {
            World world = _frent.World;
            var chunks = world.CreateMany<Component1>(EntityCount);

            for (int i = 0; i < chunks.Span.Length; i++)
                chunks.Span[i] = new();
        }
    }
}
