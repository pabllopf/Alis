using Alis.Core;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Benchmarks
{
    class Program
    {
        

        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());

            //var summary = BenchmarkRunner.Run<Test_Scene_Update_Benchmarks>();

            Console.WriteLine("End program. Please enter to clouse the console.");
            Console.ReadKey();
        }

        


    }

    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    public class Test_Scene_Update_Benchmarks
    {
        private  List<Scene> scenes;

        [Params(10)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            scenes = new List<Scene>();
            for (int i = 0; i < N; i++)
            {
                scenes.Add(new Scene("scene" + i));
            }
        }

        [Benchmark]
        public void Test_For_Parallel() 
        {
            Parallel.ForEach(scenes, scene =>
            {
                scene.Update().Wait();
            });
        }

        [Benchmark]
        public void Test_Simple_For()
        {
            for (int i = 0; i < scenes.Count - 1; i++)
            {
                scenes[i].Update().Wait();
            }
        }

        [Benchmark]
        public void Test_Foreach()
        {
            foreach (var scene in scenes)
            {
                scene.Update().Wait();
            }
        }


        [Benchmark]
        public void Test_ForEach()
        {
            scenes.ForEach(i => i.Update().Wait());
        }
    }
}
