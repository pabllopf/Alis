using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Core.Entities;
using BenchmarkDotNet.Attributes;

namespace Alis.Core.Benchmark
{
    /// <summary>
    /// The for vs foreach vs foreach class
    /// </summary>
    public class For_vs_Foreach_vs_ForEach
    {
        /// <summary>
        /// The gameobjects
        /// </summary>
        private List<GameObject> gameObjects_1;

        /// <summary>
        /// The size of list
        /// </summary>
        [Params(10, 1_000, 100_000)] public int size_of_list;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            gameObjects_1 = new List<GameObject>(size_of_list);
            gameObjects_1.ForEach(i => i = new GameObject($"Obj {Array.IndexOf(gameObjects_1.ToArray(), i)}"));
        }

        /// <summary>
        /// Tests the with for
        /// </summary>
        [Benchmark]
        public void Test_With_For()
        {
            for (var i = 0; i < gameObjects_1.Count; i++)
                if (gameObjects_1[i].Name != string.Empty)
                {
                }
        }

        /// <summary>
        /// Tests the with foreach
        /// </summary>
        [Benchmark]
        public void Test_With_Foreach()
        {
            foreach (var gameObject in gameObjects_1)
                if (gameObject.Name != string.Empty)
                {
                }
        }

        /// <summary>
        /// Tests the with for each
        /// </summary>
        [Benchmark]
        public void Test_With_ForEach()
        {
            gameObjects_1.ForEach(i =>
            {
                if (i.Name != string.Empty)
                {
                }
            });
        }

        /// <summary>
        /// Tests the with parallel
        /// </summary>
        [Benchmark]
        public void Test_With_Parallel()
        {
            Parallel.ForEach(gameObjects_1, i =>
            {
                if (i.Name != string.Empty)
                {
                }
            });
        }
    }
}