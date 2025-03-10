using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using MonoGame.Extended.Entities;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The mono game extended
        /// </summary>
        [Context]
        private readonly MonoGameExtendedBaseContext _monoGameExtended;

        /// <summary>
        /// Monoes the game extended
        /// </summary>
        [BenchmarkCategory(Categories.MonoGameExtended)]
        [Benchmark]
        public void MonoGameExtended()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _monoGameExtended.World.CreateEntity();
                entity.Attach(new MonoGameExtendedBaseContext.Component1());
                entity.Attach(new MonoGameExtendedBaseContext.Component2());
                entity.Attach(new MonoGameExtendedBaseContext.Component3());
            }
        }
    }
}
