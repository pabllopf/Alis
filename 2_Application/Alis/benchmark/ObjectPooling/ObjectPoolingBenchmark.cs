using Alis.Benchmark.ObjectPooling.Instancies;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ObjectPooling
{
    /// <summary>
    /// The object pooling benchmark class
    /// </summary>
    [MemoryDiagnoser, Config(typeof(Config))]
    public class ObjectPoolingBenchmark
    {
        /// <summary>
        /// The object pool
        /// </summary>
        private ObjectPool<PooledObject> objectPool;
    
        /// <summary>
        /// The 
        /// </summary>
        [Params(100)]
        public int N;
    
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            objectPool = new ObjectPool<PooledObject>();
        }
    
        /// <summary>
        /// Withouts the pooling
        /// </summary>
        [Benchmark]
        public void WithoutPooling()
        {
            for (int i = 0; i < N; i++)
            {
                PooledObject obj = new PooledObject();
                obj.Value = i;
            }
        }
    
        /// <summary>
        /// Adds the pooling
        /// </summary>
        [Benchmark]
        public void WithPooling()
        {
            for (int i = 0; i < N; i++)
            {
                PooledObject obj = objectPool.Get();
                obj.Value = i;
                objectPool.Return(obj);
            }
        }
    }
}