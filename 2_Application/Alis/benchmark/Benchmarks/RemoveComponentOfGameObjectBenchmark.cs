using System.Diagnostics;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Entity;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Alis.Test.Benchmarks
{
    /// <summary>
    /// The clear component of game object benchmark class
    /// </summary>
    [MinColumn, MaxColumn, MedianColumn, MemoryDiagnoser]
    [MarkdownExporter, HtmlExporter, RPlotExporter]
    public class RemoveComponentOfGameObjectBenchmark
    {
        /// <summary>
        /// The game object
        /// </summary>
        private GameObject gameObject;

        /// <summary>
        /// The 
        /// </summary>
        [Params(0, 1, 10, 100, 1_000, 10_000, 1_000_000)]
        public int N;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            gameObject = new GameObject();
            for (int i = 0; i < N; i++)
            {
                gameObject.Add(new AudioSource());
            }
        }

        /// <summary>
        /// Clears the component
        /// </summary>
        [Benchmark]
        public void Remove_Component()
        {
            gameObject.Remove(new AudioSource());
        }
    }
}