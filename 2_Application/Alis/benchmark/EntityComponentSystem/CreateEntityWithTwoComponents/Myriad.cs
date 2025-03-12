using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Myriad_Components;
using BenchmarkDotNet.Attributes;
using Myriad.ECS.Command;
using Myriad.ECS.Worlds;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
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
                buffer.Create().Set(new Component1()).Set(new Component2());
            }

            buffer.Playback().Dispose();
        }
    }
}
