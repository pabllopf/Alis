//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Manage the scenes of the videogame.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SceneManager
    {
        /// <summary>The scenes</summary>
        private List<Scene> scenes;

        /// <summary>The current scene</summary>
        private Scene currentScene;

        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        [JsonProperty]
        public List<Scene> Scenes { get => scenes; set => scenes = value; }

        /// <summary>Gets or sets the current scene.</summary>
        /// <value>The current scene.</value>
        [JsonProperty]
        public Scene CurrentScene { get => currentScene; set => currentScene = value; }

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [on add scene].</summary>
        public event EventHandler<bool> OnAddScene;

        /// <summary>Occurs when [on delete scene].</summary>
        public event EventHandler<bool> OnDeleteScene;

        /// <summary>Occurs when [on load scene].</summary>
        public event EventHandler<bool> OnLoadScene;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Initializes a new instance of the <see cref="SceneManager" /> class.</summary>
        /// <param name="scenes">The scenes.</param>
        [JsonConstructor]
        public SceneManager(List<Scene> scenes)
        {
            Logger.Info();

            this.scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));

            OnCreate += SceneManager_OnCreate;
            OnAddScene += SceneManager_OnAddScene;
            OnDeleteScene += SceneManager_OnDeleteScene;
            OnLoadScene += SceneManager_OnLoadScene;
            OnDestroy += SceneManager_OnDestroy;

            OnCreate.Invoke(null, true);

            currentScene = scenes[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManager"/> class.
        /// </summary>
        public SceneManager()
        {
            Logger.Info();

            scenes = new List<Scene> { new Scene("Default") };

            OnCreate += SceneManager_OnCreate;
            OnAddScene += SceneManager_OnAddScene;
            OnDeleteScene += SceneManager_OnDeleteScene;
            OnLoadScene += SceneManager_OnLoadScene;
            OnDestroy += SceneManager_OnDestroy;

            OnCreate.Invoke(null, true);

            currentScene = scenes[0];
        }

        /// <summary>Finalizes an instance of the <see cref="SceneManager" /> class.</summary>
        ~SceneManager() => OnDestroy?.Invoke(null, true);

        internal Task Start()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                int numTask = (currentScene.GameObjects.Count / Environment.ProcessorCount) + 1;
                List<Task> tasks = new List<Task>(numTask);

                int index = 0;

                for (int i = 0; i < currentScene.GameObjects.Count; i++)
                {
                    if (index == numTask)
                    {
                        tasks.Add(ProcessGameObjectsStart(i - index, i, false));
                        index = 0;
                    }
                    else
                    {
                        if (i == currentScene.GameObjects.Count - 1)
                        {
                            tasks.Add(ProcessGameObjectsStart(i - index, i, true));
                            index = 0;
                        }
                    }

                    index++;
                }

                Task.WaitAll(tasks.ToArray());

                watch.Stop();
                Console.WriteLine($"  Time to Start scene manager: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        private Task ProcessGameObjectsStart(int init, int end, bool isLast)
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                for (int i = init; i <= end - 1; i++)
                {
                    if (currentScene.GameObjects[i].Active)
                    {
                        currentScene.GameObjects[i].Start();
                    }
                }

                if (isLast)
                {
                    if (currentScene.GameObjects[end].Active) 
                    {
                        currentScene.GameObjects[end].Start();
                    }
                }

                watch.Stop();
                Console.WriteLine($"    Time to start the GameObjects: " + watch.ElapsedMilliseconds + " ms");
            });
        }


        /// <summary>Updates this instance.</summary>
        /// <returns>return none</returns>
        public Task Update()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                int numTask = (currentScene.GameObjects.Count / Environment.ProcessorCount) + 1;
                List<Task> tasks = new List<Task>(numTask);

                int index = 0;

                for (int i = 0; i < currentScene.GameObjects.Count; i++) 
                {
                    if (index == numTask)
                    {
                        tasks.Add(ProcessGameObjects(i - index, i, false));
                        index = 0;
                    }
                    else
                    {
                        if (i == currentScene.GameObjects.Count - 1)
                        {
                            tasks.Add(ProcessGameObjects(i - index, i, true));
                            index = 0;
                        }
                    }

                    index++;
                }

                Task.WaitAll(tasks.ToArray());

                Console.WriteLine("DIVISION: " + numTask);
                Console.WriteLine("GAMEOBJECTS: " + currentScene.GameObjects.Count);
                Console.WriteLine("PROCESORS: " + Environment.ProcessorCount);

                watch.Stop();
                Console.WriteLine($"    Time to Update a Scene: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        private Task ProcessGameObjects(int init, int end, bool isLast) 
        {
            return Task.Run(()=> 
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                for (int i = init; i <= end - 1; i++) 
                {
                    if (currentScene.GameObjects[i].Active) 
                    {
                        currentScene.GameObjects[i].Update();
                    }
                }

                if (isLast) 
                {
                    if (currentScene.GameObjects[end].Active)
                    {
                        currentScene.GameObjects[end].Update();
                    }
                }

                watch.Stop();
                Console.WriteLine($"    Time to Update the GameObjects: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        /// <summary>Scenes the manager on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnCreate(object sender, bool e) => Logger.Info();

        /// <summary>Scenes the manager on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnDestroy(object sender, bool e) => Logger.Info();

        /// <summary>Scenes the manager on load scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnLoadScene(object sender, bool e) => Logger.Info();

        /// <summary>Scenes the manager on delete scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnDeleteScene(object sender, bool e) => Logger.Info();

        /// <summary>Scenes the manager on add scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnAddScene(object sender, bool e) => Logger.Info();
    }
}