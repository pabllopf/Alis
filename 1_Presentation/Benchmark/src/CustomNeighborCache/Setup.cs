using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomNeighborCache
{
    /// <summary>
    /// The custom neighbor cache benchmark class
    /// </summary>
    [Config(typeof(CustomConfig))]
    public partial class CustomNeighborCacheBenchmark
    {
        /// <summary>
        /// Gets or sets the value of the entity count
        /// </summary>
        [Params(1_000)]
        public int EntityCount { get; set; }

        /// <summary>
        /// Gets or sets the value of the arity
        /// </summary>
        [Params(1, 2, 3, 4, 5, 6, 7, 8)]
        public int Arity { get; set; }

        /// <summary>
        /// Setup this instance
        /// </summary>
        [IterationSetup]
        public void Setup()
        {
            SetupAlis();
            SetupFrent();
        }

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        [IterationCleanup]
        public void Cleanup()
        {
            DisposeAlis();
            DisposeFrent();
        }
    }
}

