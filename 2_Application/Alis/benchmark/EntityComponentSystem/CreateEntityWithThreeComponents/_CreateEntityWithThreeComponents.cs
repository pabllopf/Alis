using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    [BenchmarkCategory(Categories.CreateEntity)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// Gets or sets the value of the entity count
        /// </summary>
        [Params(100000)]
        public int EntityCount { get; set; }

        /// <summary>
        /// Setup this instance
        /// </summary>
        [IterationSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this);

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        [IterationCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}
