using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
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
                _monoGameExtended.World.CreateEntity().Attach(new MonoGameExtendedBaseContext.Component1());
            }
        }
    }
}
