//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Manage the scenes of the videogame.</summary>
    public class SceneManager
    {
        #region Const Messages

        /// <summary>The change scene</summary>
        [NotNull]
        private const string ChangeScene = "Change scene of {0} to {1}. ";

        /// <summary>The don't change scene</summary>
        [NotNull]
        private const string DontChangeScene = "Don`t change scene of {0} to {1} because scene {1} dont' exits.";

        #endregion

        /// <summary>The maximum number scene</summary>
        [NotNull]
        private const int MaxNumScene = 100;

        /// <summary>The current</summary>
        [AllowNull]
        private static SceneManager current;

        /// <summary>The scenes</summary>
        [NotNull]
        private List<Scene> scenes;

        /// <summary>The scenes</summary>
        [NotNull]
        private List<Scene> temp;

        /// <summary>The current scene</summary>
        [NotNull]
        private Scene currentScene;

        /// <summary> Initializes static members of the <see cref="SceneManager"/> class. </summary>
        static SceneManager() 
        {
            OnChangeScene += SceneManager_OnChangeScene;
        }

        /// <summary>Initializes a new instance of the <see cref="SceneManager" /> class.</summary>
        /// <param name="scenes">The scenes.</param>
        public SceneManager([NotNull] params Scene[] scenes)
        {
            this.scenes = new List<Scene>();
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i] != null)
                {
                    this.scenes.Add(scenes[i]);
                    this.scenes[i].IsActive = false;
                }
                else 
                {
                    this.scenes.Add(new Scene("Default_" + i));
                    this.scenes[i].IsActive = false;
                }
            }

            currentScene = this.scenes[0];
            currentScene.IsActive = true;

            this.temp = new List<Scene>();

            current ??= this;
            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="SceneManager" /> class.</summary>
        /// <param name="scenes">The scenes.</param>
        /// <param name="currentScene">The current scene.</param>
        [JsonConstructor]
        internal SceneManager([NotNull] List<Scene> scenes, [NotNull] Scene currentScene)
        {
            this.scenes = scenes;
            this.currentScene = currentScene;
            this.currentScene.IsActive = true;
            temp = new List<Scene>();

            current ??= this;
            Logger.Info();
        }

        /// <summary>Occurs when [on change scene].</summary>
        public static event EventHandler<bool> OnChangeScene;

        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        [NotNull]
        [JsonProperty("_Scenes")]
        public List<Scene> Scenes { get => scenes; set => scenes = value; }

        /// <summary>Gets or sets the current scene.</summary>
        /// <value>The current scene.</value>
        [NotNull]
        [JsonProperty("_CurrentScene")]
        public Scene CurrentScene { get => currentScene; set => currentScene = value; }

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        [JsonIgnore]
        public static SceneManager Current { get => current; set => current = value; }

        /// <summary>Loads the specified name.</summary>
        /// <param name="name">The name.</param>
        public static void Load(int index)
        {
            if (current.currentScene != current.scenes[index])
            {
                Logger.Warning("Start scene: " + current.currentScene.Name);
                current.currentScene.IsActive = false;
                current.Exit().Wait();

                Render.Current.Clear();

                current.currentScene = current.scenes[index];
                current.currentScene.IsActive = true;

                current.Awake().Wait();
                current.Start().Wait();

                Logger.Warning("Current scene: " + current.currentScene.Name);
            }
        }

        public static void Load(string name)
        {
            Scene scene = current.scenes.Find(i => i.Name.Equals(name));
            if (scene != current.currentScene)
            {
                if (scene != null)
                {
                    Logger.Warning("Start scene: " + current.currentScene.Name);
                    current.currentScene.IsActive = false;
                    current.Exit().Wait();

                    Render.Current.Clear();

                    current.currentScene = scene;
                    current.currentScene.IsActive = true;

                    current.Awake().Wait();
                    current.Start().Wait();

                    Logger.Warning("Current scene: " + current.currentScene.Name);
                }
            }
        }

        public static void Reset(string name)
        {
            Scene scene = current.temp.Find(i => i.Name.Equals(name));

            if (!scene.Name.Equals(current.currentScene.Name))
            {
                Logger.Warning("Start scene: " + current.currentScene.Name);
                current.currentScene.IsActive = false;
                current.Exit().Wait();

                Render.Current.Clear();
                Input.Current.Clear();


                LocalData.Save("scene", scene);

                scene = LocalData.Load<Scene>("scene");

                
                scene.Awake();
                scene.Start();


                scene.IsActive = true;
                current.currentScene = scene;
                Logger.Warning("Current scene: " + current.currentScene.Name);
            }
        }

        public void AddScene(Scene scene)
        {
            scenes.Add(scene);
        }

        /// <summary>Awakes this instance.</summary>
        /// <returns>Awake scene.</returns>
        internal Task Awake()
        {
            return Task.Run(() => currentScene?.Awake());
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Start()
        {
            return Task.Run(() => currentScene?.Start());
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        public Task Update()
        {
            if (currentScene.IsActive)
            {
                return Task.Run(() => currentScene?.Update());
            }

            return Task.Run(() => Task.Delay(1));
        }

        /// <summary>Fix the update.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task FixedUpdate()
        {
            if (currentScene.IsActive)
            {
                return Task.Run(() => currentScene?.FixedUpdate());
            }

            return Task.Run(() => Task.Delay(1));
        }

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Exit()
        {
            if (!currentScene.IsActive)
            {
                return Task.Run(() => currentScene?.Exit());
            }

            return Task.Run(() => Task.Delay(1));
        }

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Stop()
        {
            if (currentScene.IsActive)
            {
                return Task.Run(() => currentScene?.Stop());
            }

            return Task.Run(() => Task.Delay(1));
        }

        #region Events

        /// <summary>Scenes the manager on change scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private static void SceneManager_OnChangeScene([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion

        /// <summary>The builder</summary>
        public static SceneManagerBuilder Builder() => new SceneManagerBuilder();

        /// <summary> Scene Manager Builder</summary>
        public class SceneManagerBuilder
        {
            /// <summary>The current</summary>
            [AllowNull]
            private SceneManagerBuilder current;

            [AllowNull]
            private List<Scene> scenes;

            /// <summary>Initializes a new instance of the <see cref="VideoGameBuilder" /> class.</summary>
            public SceneManagerBuilder() => current ??= this;

            /// <summary>Adds the scene.</summary>
            /// <param name="scene">The scene.</param>
            /// <returns>Return the builder</returns>
            public SceneManagerBuilder Scene(Scene scene) 
            {
                current.scenes ??= new List<Scene>();
                if (!current.scenes.Contains(scene)) 
                {
                    current.scenes.Add(scene);
                }

                return current;
            }

            /// <summary>Builds this instance.</summary>
            /// <returns>Build the scene manager</returns>
            public SceneManager Build()
            {
                //current.scenes.ForEach(i => Logger.Warning("Build scene " + i.Name));

                current.scenes ??= new List<Scene>() { new Scene("Default") };

                if (File.Exists(Environment.CurrentDirectory + "/Data/scenesTemp.json")) 
                {
                    File.Delete(Environment.CurrentDirectory + "/Data/scenesTemp.json");
                }

                LocalData.Save("scenesTemp", scenes);

                SceneManager sceneManager = new SceneManager(current.scenes.ToArray()); ;
                sceneManager.temp = LocalData.Load<List<Scene>>("scenesTemp");
                return sceneManager;
            }
        }
    }
}