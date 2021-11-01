using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Core.Entities;
using BenchmarkDotNet.Attributes;

namespace Alis.Core.Benchmark
{
    public class For_vs_Foreach_vs_ForEach
    {
        private List<GameObject> gameObjects_1;

        [Params(10, 1_000, 100_000)] public int size_of_list;

        [GlobalSetup]
        public void Setup()
        {
            gameObjects_1 = new List<GameObject>(size_of_list);
            gameObjects_1.ForEach(i => i = new GameObject($"Obj {Array.IndexOf(gameObjects_1.ToArray(), i)}"));
        }

        [Benchmark]
        public void Test_With_For()
        {
            for (var i = 0; i < gameObjects_1.Count; i++)
                if (gameObjects_1[i].Name != string.Empty)
                {
                }
        }

        [Benchmark]
        public void Test_With_Foreach()
        {
            foreach (var gameObject in gameObjects_1)
                if (gameObject.Name != string.Empty)
                {
                }
        }

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