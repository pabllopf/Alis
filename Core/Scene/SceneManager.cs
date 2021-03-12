//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>Manage the scenes of the videogame.</summary>
    public class SceneManager
    {
        /// <summary>The scenes</summary>
        [NotNull]
        private List<Scene> scenes;

        /// <summary>The current scene</summary>
        [NotNull]
        private Scene currentScene;

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManager"/> class.
        /// </summary>
        [JsonConstructor]
        public SceneManager()
        {
            scenes = new List<Scene> { new Scene("Default") };
            currentScene = scenes[0];

            OnCreate += SceneManager_OnCreate;
            OnLoadScene += SceneManager_OnLoadScene;
            OnDestroy += SceneManager_OnDestroy;

            OnCreate.Invoke(null, true);
        }

        /// <summary>Initializes a new instance of the <see cref="SceneManager" /> class.</summary>
        /// <param name="scenes">The scenes.</param>
        public SceneManager([NotNull] List<Scene> scenes)
        {
            this.scenes = scenes;
            currentScene = scenes[0];

            OnCreate += SceneManager_OnCreate;
            OnLoadScene += SceneManager_OnLoadScene;
            OnDestroy += SceneManager_OnDestroy;

            OnCreate.Invoke(null, true);
        }

        /// <summary>Finalizes an instance of the <see cref="SceneManager" /> class.</summary>
        ~SceneManager() => OnDestroy.Invoke(null, true);

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [on load scene].</summary>
        public event EventHandler<bool> OnLoadScene;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        [NotNull]
        [JsonProperty]
        public List<Scene> Scenes { get => scenes; set => scenes = value; }

        /// <summary>Gets or sets the current scene.</summary>
        /// <value>The current scene.</value>
        [NotNull]
        [JsonProperty]
        public Scene CurrentScene { get => currentScene; set => currentScene = value; }

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

                currentScene.Start().Wait();

                watch.Stop();
                Logger.Log($"  Time to Start scene manager: " + watch.ElapsedMilliseconds + " ms");
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

                currentScene.Update().Wait();

                watch.Stop();
                Logger.Log($"  Time to Update scene manager: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        #region DefineEvents

        /// <summary>Scenes the manager on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Scenes the manager on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Scenes the manager on load scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnLoadScene([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Scenes the manager on delete scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnDeleteScene([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Scenes the manager on add scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void SceneManager_OnAddScene([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}