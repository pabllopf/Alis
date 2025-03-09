using System.Runtime.CompilerServices;
using Alis.Benchmark.ECS.Others.Contexts;
using Alis.Benchmark.ECS.Others.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.SystemWithOneComponent
{
    public partial class SystemWithOneComponent
    {
        private struct ForEach1 : IForEach<Component1>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0)
            {
                ++t0.Value;
            }
        }

        [Query]
        private static void ForEach(ref Component1 t0)
        {
            ++t0.Value;
        }

        private sealed class ArchContext : ArchBaseContext
        {
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            { }
        }

        private static readonly ComponentType[] _filter = [typeof(Component1)];
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        [Context]
        private readonly ArchContext _arch;
        private ForEach1 _forEach;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread()
        {
            World world = _arch.World;
            world.InlineQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
        
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MonoThread_SourceGenerated()
        {
           ForEachQuery(_arch.World);
        }
        
        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch_MultiThread()
        {
            World world = _arch.World;
            world.InlineParallelQuery<ForEach1, Component1>(_queryDescription, ref _forEach);
        }
    }
}
