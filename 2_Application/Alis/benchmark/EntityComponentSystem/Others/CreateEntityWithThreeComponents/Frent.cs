using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Core;
using static Alis.Benchmark.EntityComponentSystem.Others.Contexts.FrentBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The id
        /// </summary>
        private static readonly EntityType _entityType = Entity.EntityTypeOf([Component<Component1>.ID, Component<Component2>.ID, Component<Component3>.ID], []);

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
                world.Create<Component1, Component2, Component3>(default, default, default);
        }

        /// <summary>
        /// Frents the bulk
        /// </summary>
        [BenchmarkCategory(Categories.Frent)]
        [Benchmark]
        public void Frent_Bulk()
        {
            World world = _frent.World;
            var chunks = world.CreateMany<Component1, Component2, Component3>(EntityCount);

            chunks.Span2 = chunks.Span2[..chunks.Span1.Length];
            chunks.Span3 = chunks.Span3[..chunks.Span1.Length];
            for (int i = 0; i < chunks.Span1.Length; i++)
            {
                chunks.Span1[i] = default;
                chunks.Span2[i] = default;
                chunks.Span3[i] = default;
            }
        }
    }
}
