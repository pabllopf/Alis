using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithThreeComponents
{
    [BenchmarkCategory(Categories.CreateEntity)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class CreateEntityWithThreeComponents
    {
        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this);

        [IterationCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}
