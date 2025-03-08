using System.Text;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Strings
{
    /// <summary>
    /// The string manipulation benchmark class
    /// </summary>
    [MemoryDiagnoser(displayGenColumns: true)]
    [Config(typeof(Config))]
    public class StringManipulationBenchmark
    {
        /// <summary>
        /// The iterations
        /// </summary>
        private const int Iterations = 10000;

        /// <summary>
        /// Bads the string manipulation base line
        /// </summary>
        /// <returns>The result</returns>
        [Benchmark(Baseline = true)]
        public string BadStringManipulation_BaseLine()
        {
            string result = "";
            for (int i = 0; i < Iterations; i++)
            {
                result += "A"; 
            }
            return result;
        }

        /// <summary>
        /// Normals the string manipulation
        /// </summary>
        /// <returns>The string</returns>
        [Benchmark]
        public string NormalStringManipulation()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append("A");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Perfects the string manipulation
        /// </summary>
        /// <returns>The string</returns>
        [Benchmark]
        public string PerfectStringManipulation()
        {
            return string.Create(Iterations, 'A', (span, value) =>
            {
                span.Fill(value);
            });
        }
    }
}