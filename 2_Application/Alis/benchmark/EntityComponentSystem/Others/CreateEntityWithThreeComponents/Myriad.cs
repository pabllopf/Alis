using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.Myriad_Components;
using BenchmarkDotNet.Attributes;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The myriad
        /// </summary>
        [Context]
        private readonly MyriadBaseContext _myriad;

        /// <summary>
        /// Myriads this instance
        /// </summary>
        [BenchmarkCategory(Categories.Myriad)]
        [Benchmark]
        public void Myriad()
        {
            World world = _myriad.World;

            CommandBuffer buffer = new CommandBuffer(world);

            for (int i = 0; i < EntityCount; ++i)
            {
                buffer.Create().Set(new Component1()).Set(new Component2()).Set(new Component3());
            }

            buffer.Playback().Dispose();
        }
    }
}
