using Alis.Core;
using Alis.Core.SFML;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks
{
    [MarkdownExporterAttribute.GitHub]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn, IterationsColumn]
    public class Test_Scenes_Core
    {
        private NewScene[] newScenes;

        private Scene[] scenes;

        [Params(5)]
        public int N;

        [Params(5)]
        public int NN;

        [Params(5)]
        public int NNN;

        [GlobalSetup]
        public void Setup()
        {
            newScenes = new NewScene[N];
            scenes = new Scene[N];

            int index = 0;
            Parallel.For(index, newScenes.Length, i =>
            {
                List<GameObject> gameObjects = new List<GameObject>();
                List<NewGameObject> newgameObjects = new List<NewGameObject>();

                for (int j = 0; j < NN; j++)
                {
                    var gameobject = new GameObject("game" + j);

                    List<Component> components = new List<Component>();

                    for (int z = 0; z < NNN; z++)
                    {
                        gameobject.Add(new Sprite(""));
                        components.Add(new Sprite(""));
                    }

                    var newgameobject = new NewGameObject("game" + j, components.ToArray());

                    gameObjects.Add(gameobject);
                    newgameObjects.Add(newgameobject);
                }

                newScenes[i] = new NewScene("scene " + i, newgameObjects.ToArray());
                scenes[i] = new Scene("scene " + i, gameObjects.ToArray());
            });
        }


        //[Benchmark]
        public void Test_New_Implementation_v1()
        {
            for (int j = 0; j < scenes.Length; j++)
            {
                scenes[j].Update().Wait();
            }
        }

        //[Benchmark]
        public void Test_New_Implementation_v2()
        { 
            Task[] tasks = new Task[Environment.ProcessorCount];
            int limitOfTasksByProcessor = (scenes.Length / Environment.ProcessorCount) + 1;
            int init = 0;
            int end = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > scenes.Length ? scenes.Length : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            scenes[j].Update().Wait();
                        }
                    });
                }
            }

            Task.WaitAll();
        }


        [Benchmark]
        public void Test_New_Implementation_v3()
        {
            int processorCount = Environment.ProcessorCount;
            int size = scenes.Length;
            int limitOfTasksByProcessor = (size / processorCount) + 1;
            int init = 0;
            int end = 0;

            Task[] tasks = new Task[processorCount];

            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > size ? size : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            scenes[j].Update().Wait();
                        }
                    });
                }
            }

            Task.WaitAll();
        }

        [Benchmark]
        public void Test_New_Implementation_v4()
        {
            int processorCount = Environment.ProcessorCount;
            int size = newScenes.Length;
            int limitOfTasksByProcessor = (size / processorCount) + 1;
            int init = 0;
            int end = 0;

            Task[] tasks = new Task[processorCount];

            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > size ? size : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            newScenes[j].Update();
                        }
                    });
                }
            }

            Task.WaitAll();
        }


        [Benchmark]
        public void Test_New_Implementation_v5()
        {
            int processorCount = Environment.ProcessorCount;
            int size = newScenes.Length;
            int limitOfTasksByProcessor = (size / processorCount) + 1;
            int init = 0;
            int end = 0;

            Task[] tasks = new Task[processorCount];

            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > size ? size : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            newScenes[j].Update();
                        }
                    });
                }
            }

            Task.WaitAll();
        }

    }

    public class NewScene
    {
        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The game objects</summary>
        [NotNull]
        private NewGameObject[] gameObjects;

        [NotNull]
        private readonly int numOfGameObjects;

        [NotNull]
        private readonly int limitOfTasksByProcessor;

        [NotNull]
        private int init;
        
        [NotNull]
        private int end;

        [NotNull]
        private Task[] tasks;

        /// <summary>Initializes a new instance of the <see cref="NewScene" /> struct.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        public NewScene(string name, NewGameObject[] gameObjects)
        {
            this.name = name;
            this.gameObjects = gameObjects;
            
            tasks = new Task[Environment.ProcessorCount];
            numOfGameObjects = gameObjects.Length;
            limitOfTasksByProcessor = (gameObjects.Length / Environment.ProcessorCount) + 1;

            init = 0;
            end = 0;
        }

        /// <summary>Updates this instance.</summary>
        /// <returns></returns>
        [return: NotNull]
        public void Update()
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > numOfGameObjects ? numOfGameObjects : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            gameObjects[j].Update();
                        }
                    });
                }
            }

            Task.WaitAll();
        }
    }

    public class NewGameObject
    {
        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The game objects</summary>
        [NotNull]
        private Component[] components;

        [NotNull]
        private readonly int numOfGameObjects;

        [NotNull]
        private readonly int limitOfTasksByProcessor;

        [NotNull]
        private int init;

        [NotNull]
        private int end;

        [NotNull]
        private Task[] tasks;

        /// <summary>Initializes a new instance of the <see cref="NewScene" /> struct.</summary>
        /// <param name="name">The name.</param>
        /// <param name="components">The game objects.</param>
        public NewGameObject(string name, Component[] components)
        {
            this.name = name;
            this.components = components;

            tasks = new Task[Environment.ProcessorCount];
            numOfGameObjects = components.Length;
            limitOfTasksByProcessor = (components.Length / Environment.ProcessorCount) + 1;

            init = 0;
            end = 0;
        }

        /// <summary>Updates this instance.</summary>
        /// <returns></returns>
        [return: NotNull]
        public void Update()
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                init = i * limitOfTasksByProcessor;
                end = ((i + 1) * limitOfTasksByProcessor) > numOfGameObjects ? numOfGameObjects : ((i + 1) * limitOfTasksByProcessor);

                if (init <= end)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        for (int j = init; j < end; j++)
                        {
                            components[j].Update();
                        }
                    });
                }
            }

            Task.WaitAll();
        }
    }
}





/*
private readonly Task[] tasks = new Task[Environment.ProcessorCount];
private int limitOfTasksByProcessor;
private int init = 0;
private int end = 0;

[Benchmark]
public void Test_New_Implementation()
{
    for (int i = 0; i < tasks.Length; i++)
    {
        init = i * limitOfTasksByProcessor;
        end = ((i + 1) * limitOfTasksByProcessor) > newScenes.Length ? newScenes.Length : ((i + 1) * limitOfTasksByProcessor);

        if (init <= end)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = init; j < end; j++)
                {
                    newScenes[j].Update();
                }
            });
        }
    }

    Task.WaitAll();
}

[Benchmark]
public void Test_New_Implementation_V2()
{
    Task[] tasks = new Task[Environment.ProcessorCount];
    int limitOfTasksByProcessor = (newScenes.Length / Environment.ProcessorCount) + 1;
    int init = 0;
    int end = 0;

    Parallel.For(0, tasks.Length, i =>
    {
        init = i * limitOfTasksByProcessor;
        end = ((i + 1) * limitOfTasksByProcessor) > newScenes.Length ? newScenes.Length : ((i + 1) * limitOfTasksByProcessor);

        if (init <= end)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = init; j < end; j++)
                {
                    newScenes[j].Update();
                }
            });
        }
    });

    Task.WaitAll();
}

[Benchmark]
public void Test_New_Implementation_V3()
{
    Task[] tasks = new Task[Environment.ProcessorCount];
    int limitOfTasksByProcessor = (newScenes.Length / Environment.ProcessorCount) + 1;
    int init = 0;
    int end = 0;

    Parallel.For(0, tasks.Length, i =>
    {
        init = i * limitOfTasksByProcessor;
        end = ((i + 1) * limitOfTasksByProcessor) > newScenes.Length ? newScenes.Length : ((i + 1) * limitOfTasksByProcessor);

        if (init <= end)
        {
            tasks[i] = Task.Run(() =>
            {
                Parallel.For(init, end, j =>
                {
                    newScenes[j].Update();
                });
            });
        }
    });

    Task.WaitAll();
}*/

/*
[Benchmark]
public void Test_New_Implementation_v2()
{
    int processorCount = Environment.ProcessorCount;
    Task[] tasks = new Task[processorCount];
    int lastElement = tasks.Length - 1;

    int limitOfTasksByProcessor = (newScenes.Length / processorCount) + 1;
    int init = 0;
    int end = 0;
    int index = 0;

    Parallel.For(index, tasks.Length, i =>
    {
        init = i * limitOfTasksByProcessor;
        end = lastElement.Equals(i) ? newScenes.Length : (i + 1) * limitOfTasksByProcessor;

        tasks[i] = Task.Run(() =>
        {
            for (int j = init; j < end ; j++)
            {
                newScenes[j].Update();
            }
        });
    });

    Task.WaitAll(tasks);
}*/


/*[Benchmark]
public void Test_Simple_For()
{
    for (int i = 0; i < newScenes.Length; i++)
    {
        newScenes[i].Update();
    }
}


[Benchmark]
public void Test_Simple_Foreach()
{
   foreach(NewScene newScene in newScenes)
    {
        newScene.Update();
    }
}



[Benchmark]
public void Test_Task_For()
{
    Task.Run(() =>
    {
        for (int i = 0; i < newScenes.Length; i++)
        {
            newScenes[i].Update();
        }
    }).Wait();
}

[Benchmark]
public void Test_Parallel_For()
{
    Parallel.ForEach(newScenes, scene => scene.Update());
}


[Benchmark]
public void Test_Task_And_Parallel()
{
    int num = Environment.ProcessorCount;
    Task[] tasks = new Task[num];
    int limitTask = (newScenes.Length / num) + 1;
    int init = 0;
    int end = 0;
    int index = 0;

    Parallel.For(index, tasks.Length, i =>
    {
        init = i * limitTask;
        end = ((tasks.Length - 1) != i) ? (i + 1) * limitTask : newScenes.Length;

        tasks[i] = Task.Run(() =>
        {
            for (int j = init; j < end; j++)
            {
                newScenes[j].Update();
            }
        });
    });

    Task.WaitAll(tasks);
}*/

