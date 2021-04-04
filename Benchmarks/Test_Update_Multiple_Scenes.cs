//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Test_Update_Multiple_Scenes.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Benchmarks
{
    using Alis.Core;
    using Alis.Core.SFML;
    using BenchmarkDotNet.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Define the test of gameobjects update</summary>
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MedianColumn, IterationsColumn]
    public class Test_Update_Multiple_Scenes
    {
        /// <summary>The number of game objects</summary>
        [Params(1000000)]
        public int numOfGameObjects = 1000000;

        [Params(10)]
        public int numOfComponents = 10;

        /// <summary>The game objects</summary>
        private GameObject[] gameObjects;

        /// <summary>Setups this instance.</summary>
        [GlobalSetup]
        public void Setup()
        {
            gameObjects = new GameObject[numOfGameObjects];

            Parallel.For(0, numOfGameObjects, i => 
            {
                List<Component> components = new List<Component>();

                for (int j = 0; j < numOfComponents; j++) 
                {
                    components.Add(new Sprite(""));
                }

                gameObjects[i] = new GameObject("gameobject" + i, new Transform(), components.ToArray());
            });
        }

        /// <summary>Tests the update simple for.</summary>
        [Benchmark]
        public void Test_Update_Simple_For() 
        {
            for (int j = 0; j < gameObjects.Length; j++)
            {
                gameObjects[j].Update();
            }
        }

        /// <summary>Tests the update simple foreach.</summary>
        //[Benchmark]
        public void Test_Update_Simple_Foreach()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update();
            }
        }

        /// <summary>Tests the update simple parallel.</summary>
        [Benchmark]
        public void Test_Update_Simple_Parallel()
        {
            Parallel.ForEach(gameObjects, gameObject => gameObject.Update());
        }

        /// <summary>Tests the update simple task.</summary>
        //[Benchmark]
        public void Test_Update_Simple_Task()
        {
            Task.Run(() => 
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].Update();
                }
            }).Wait();
        }

        [Benchmark]
        public void Test_Update_Custom_Method_Mix()
        {
            int procesor = Environment.ProcessorCount;
            int limit = (gameObjects.Length / procesor) + 1;

            if (limit <= 3) 
            {
                for (int i = 0; i < gameObjects.Length;i++) 
                {
                    if (!gameObjects[i].IsStatic && gameObjects[i].IsActive)
                    {
                        gameObjects[i].Update();
                    }
                }

                return;
            }

            Task[] tasks = new Task[Environment.ProcessorCount];

            for (int i = 0; i < tasks.Length; i++) 
            {
                tasks[i] = Task.Run(() => AuxProcess(i * limit, (i + 1) * limit, gameObjects.Length, ref gameObjects));
            }

            Task.WaitAll(tasks);
        }

        private void AuxProcess(int init, int end, int length, ref GameObject[] games) 
        {
            for (int j = init; j < end; j++)
            {
                if (j < length)
                {
                    games[j].Update();
                }
            }
        }


        /// <summary>Tests the update custom method.</summary>
        //[Benchmark]
        public void Test_Update_Custom_Method()
        {
            if (gameObjects.Length == 0) 
            {
                return;
            }

            int procesor = Environment.ProcessorCount;

            if ((gameObjects.Length / procesor) + 1 <= 4)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].Update();
                }

                return;
            }

            Task[] tasks = new Task[procesor];
            int limitOfTasksByProcessor = (gameObjects.Length / procesor) + 1;
            int init = 0;
            int end = 0;

            for (int i = 0; i < procesor; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > gameObjects.Length ? gameObjects.Length : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            if (!gameObjects[j].IsStatic && gameObjects[j].IsActive)
                            {
                                gameObjects[j].Update();
                            }
                        }
                    });
                }
            }

            Task.WaitAll(tasks);
        }
    }
}
