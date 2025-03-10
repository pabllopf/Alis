using Alis.Benchmark.ECS.Intancies;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS
{
    /// <summary>
    /// The ecs benchmarks class
    /// </summary>
    [MemoryDiagnoser, Config(typeof(Config))]
    public class EcsBenchmarks
    {
        /// <summary>
        /// The dictionary ecs
        /// </summary>
        private DictionaryEcs dictionaryEcs;
        /// <summary>
        /// The array ecs
        /// </summary>
        private ArrayEcs arrayEcs;

        /// <summary>
        /// The 
        /// </summary>
        [Params(10, 100, 1000)]
        public int N;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            dictionaryEcs = new DictionaryEcs();
            arrayEcs = new ArrayEcs(N);
        
            for (int i = 0; i < N; i++)
            {
                dictionaryEcs.CreateEntity();
                arrayEcs.CreateEntity();
            }
        }

        /// <summary>
        /// Updates the dictionary ecs
        /// </summary>
        [Benchmark]
        public void UpdateDictionaryEcs()
        {
            dictionaryEcs.UpdateEntities();
        }

        /// <summary>
        /// Updates the array ecs
        /// </summary>
        [Benchmark]
        public void UpdateArrayEcs()
        {
            arrayEcs.UpdateEntities();
        }
    }
}