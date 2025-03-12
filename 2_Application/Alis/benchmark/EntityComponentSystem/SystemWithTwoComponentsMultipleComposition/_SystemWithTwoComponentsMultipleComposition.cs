using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    [BenchmarkCategory(Categories.System)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// Gets or sets the value of the entity count
        /// </summary>
        [Params(100000)]
        public int EntityCount { get; set; }

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this, EntityCount);

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        [GlobalCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}
