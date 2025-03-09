using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    [BenchmarkCategory(Categories.System)]
    [MemoryDiagnoser]
#if CHECK_CACHE_MISSES
    [HardwareCounters(BenchmarkDotNet.Diagnosers.HardwareCounter.CacheMisses)]
#endif
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// Gets or sets the value of the entity count
        /// </summary>
        [Params(100000)]
        public int EntityCount { get; set; }

        /// <summary>
        /// Gets or sets the value of the entity padding
        /// </summary>
        [Params(0, 10)]
        public int EntityPadding { get; set; }

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup() => BenchmarkOperations.SetupContexts(this, EntityCount, EntityPadding);

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        [GlobalCleanup]
        public void Cleanup() => BenchmarkOperations.CleanupContexts(this);
    }
}
