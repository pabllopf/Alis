using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alis.Core.Benchmark
{
    public class For_vs_Foreach_vs_ForEach
    {
        [Params(10, 1_000, 100_000)]
        public int size_of_list;

        private List<GameObject> gameObjects_1;

        [GlobalSetup]
        public void Setup()
        {
            gameObjects_1 = new List<GameObject>(size_of_list);
            gameObjects_1.ForEach(i => i = new GameObject($"Obj { Array.IndexOf(gameObjects_1.ToArray(), i)}"));
        }

        [Benchmark]
        public void Test_With_For() 
        {
            for (int i = 0; i < gameObjects_1.Count; i++) 
            {
                if (gameObjects_1[i].Name.Value != string.Empty) 
                {
                
                }
            }
        }
        
        [Benchmark]
        public void Test_With_Foreach()
        {
            foreach (GameObject gameObject in gameObjects_1) 
            {
                if (gameObject.Name.Value != string.Empty)
                {

                }
            }
        }

        [Benchmark]
        public void Test_With_ForEach()
        {
            gameObjects_1.ForEach(i =>
            {
                if (i.Name.Value != string.Empty) 
                {
                }
            });
        }

        [Benchmark]
        public void Test_With_Parallel()
        {
            Parallel.ForEach(gameObjects_1, i =>
            {
                if (i.Name.Value != string.Empty)
                {
                }
            });
        }
    }
}
