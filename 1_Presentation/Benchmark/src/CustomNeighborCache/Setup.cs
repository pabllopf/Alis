using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomNeighborCache
{
    [Config(typeof(CustomConfig))]
    public partial class CustomNeighborCacheBenchmark
    {
        [Params(1_000)]
        public int EntityCount { get; set; }

        [Params(1, 2, 3, 4, 5, 6, 7, 8)]
        public int Arity { get; set; }

        [IterationSetup]
        public void Setup()
        {
            SetupAlis();
            SetupFrent();
        }

        [IterationCleanup]
        public void Cleanup()
        {
            DisposeAlis();
            DisposeFrent();
        }
    }
}

