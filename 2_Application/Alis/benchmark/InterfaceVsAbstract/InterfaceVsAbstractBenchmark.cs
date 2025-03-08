using Alis.Benchmark.InterfaceVsAbstract.Instancies;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.InterfaceVsAbstract
{
    /// <summary>
    /// The interface vs abstract benchmark class
    /// </summary>
    [MemoryDiagnoser, Config(typeof(Config))]
    public class InterfaceVsAbstractBenchmark
    {
        /// <summary>
        /// The interface shapes
        /// </summary>
        private IShape[] interfaceShapes;
        
        /// <summary>
        /// The abstract shapes
        /// </summary>
        private Shape[] abstractShapes;
    
        /// <summary>
        /// The 
        /// </summary>
        [Params(100, 1000, 10000)]
        public int N;
    
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            interfaceShapes = new IShape[N];
            abstractShapes = new Shape[N];
        
            for (int i = 0; i < N; i++)
            {
                interfaceShapes[i] = new CircleInterface(i + 1);
                abstractShapes[i] = new CircleAbstract(i + 1);
            }
        }

        /// <summary>
        /// Interfaces the method call
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public float InterfaceMethodCall()
        {
            float sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += interfaceShapes[i].GetArea();
            }

            return sum;
        }

        /// <summary>
        /// Abstracts the method call
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public float AbstractMethodCall()
        {
            float sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += abstractShapes[i].GetArea();
            }

            return sum;
        }
    }
}