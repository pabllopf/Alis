//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Scene.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>Define a scene.</summary>
    public class Scene
    {
        /// <summary>The name</summary>
        [JsonProperty]
        [NotNull]
        private string name;

        /// <summary>The game objects</summary>
        [JsonProperty]
        [NotNull]
        private List<GameObject> gameObjects;

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        public Scene()
        {
            name = "Default Scene";
            gameObjects = new List<GameObject>();

            OnCreate += Scene_OnCreate;
            OnDestroy += Scene_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        [JsonConstructor]
        public Scene([NotNull] string name)
        {
            this.name = name;
            gameObjects = new List<GameObject>();

            OnCreate += Scene_OnCreate;
            OnDestroy += Scene_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="Scene" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="gameObjects">The game objects.</param>
        public Scene([NotNull] string name, [NotNull] params GameObject[] gameObjects)
        {
            this.name = name;
            this.gameObjects = new List<GameObject>(gameObjects);

            OnCreate += Scene_OnCreate;
            OnDestroy += Scene_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="Scene" /> class.</summary>
        ~Scene() => OnDestroy.Invoke(this, true);

        /// <summary>Occurs when [on create].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Called when [destroy].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [NotNull]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the game objects.</summary>
        /// <value>The game objects.</value>
        [NotNull]
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }

        /// <summary>Adds the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Add([NotNull] GameObject gameObject) 
        {
            if (gameObjects.Find(i => i.Name.Equals(gameObject.Name)) is null) 
            {
                gameObjects.Add(gameObject);
            }
        }

        /// <summary>Removes the specified game object.</summary>
        /// <param name="gameObject">The game object.</param>
        public void Remove([NotNull] GameObject gameObject) 
        {
            if (gameObjects.Find(i => i.Name.Equals(gameObject.Name)) != null)
            {
                gameObjects.Remove(gameObject);
            }
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Start()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                int numTask = (gameObjects.Count / Environment.ProcessorCount) + 1;
                List<Task> tasks = new List<Task>(numTask);

                int index = 0;

                for (int i = 0; i < gameObjects.Count; i++)
                {
                    if (index == numTask)
                    {
                        tasks.Add(ProcessGameObjectsStart(i - index, i, false));
                        index = 0;
                    }
                    else
                    {
                        if (i == gameObjects.Count - 1)
                        {
                            tasks.Add(ProcessGameObjectsStart(i - index, i, true));
                            index = 0;
                        }
                    }

                    index++;
                }

                Task.WaitAll(tasks.ToArray());

                watch.Stop();
                Console.WriteLine($"  Time to Start scene loaded: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Update()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                int numTask = (gameObjects.Count / Environment.ProcessorCount) + 1;
                List<Task> tasks = new List<Task>(numTask);

                int index = 0;

                for (int i = 0; i < gameObjects.Count; i++)
                {
                    if (index == numTask)
                    {
                        tasks.Add(ProcessGameObjectsUpdate(i - index, i, false));
                        index = 0;
                    }
                    else
                    {
                        if (i == gameObjects.Count - 1)
                        {
                            tasks.Add(ProcessGameObjectsUpdate(i - index, i, true));
                            index = 0;
                        }
                    }

                    index++;
                }

                Task.WaitAll(tasks.ToArray());

                watch.Stop();
                Console.WriteLine($"  Time to Update scene loaded: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        /// <summary>Processes the game objects start.</summary>
        /// <param name="init">The initialize.</param>
        /// <param name="end">The end.</param>
        /// <param name="isLast">if set to <c>true</c> [is last].</param>
        /// <returns>Return none.</returns>
        [return: NotNull]
        private Task ProcessGameObjectsStart([NotNull] int init, [NotNull] int end, [NotNull] bool isLast)
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                for (int i = init; i <= end - 1; i++)
                {
                    if (gameObjects[i].Active)
                    {
                        gameObjects[i].Start();
                    }
                }

                if (isLast)
                {
                    if (gameObjects[end].Active)
                    {
                        gameObjects[end].Start();
                    }
                }

                watch.Stop();
                Console.WriteLine($"    Time to start the GameObjects: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        /// <summary>Processes the game objects update.</summary>
        /// <param name="init">The initialize.</param>
        /// <param name="end">The end.</param>
        /// <param name="isLast">if set to <c>true</c> [is last].</param>
        /// <returns>Return none</returns>
        [return: NotNull]
        private Task ProcessGameObjectsUpdate([NotNull] int init, [NotNull] int end, [NotNull] bool isLast)
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                for (int i = init; i <= end - 1; i++)
                {
                    if (gameObjects[i].Active)
                    {
                        gameObjects[i].Update();
                    }
                }

                if (isLast)
                {
                    if (gameObjects[end].Active)
                    {
                        gameObjects[end].Update();
                    }
                }

                watch.Stop();
                Console.WriteLine($"    Time to update the GameObjects: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        #region DefineEvents

        /// <summary>Scenes the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Scenes the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Scene_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}