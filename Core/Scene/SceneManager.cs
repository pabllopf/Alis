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
    using System.Threading;
    using System.Threading.Tasks;
    using Alis.Tools;
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

        /// <summary>Initializes a new instance of the <see cref="SceneManager" /> class.</summary>
        /// <param name="scenes">The scenes.</param>
        [JsonConstructor]
        public SceneManager([NotNull] List<Scene> scenes)
        {
            this.scenes = scenes;

            OnCreate += SceneManager_OnCreate;
            OnLoadScene += SceneManager_OnLoadScene;
            OnDestroy += SceneManager_OnDestroy;

            if (scenes != null) 
            {
                currentScene = scenes[0];
            }

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
        [JsonProperty("_Scenes")]
        public List<Scene> Scenes { get => scenes; set => scenes = value; }

        internal Task Awake()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("awake scene manager");
            });
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Start()
        {
            return Task.Run(() =>
            {
                if (scenes.Count == 0) 
                {
                    scenes.Add(new Scene("Default"));
                }

                currentScene = scenes[0];
                currentScene.Start().Wait();
            });
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Update()
        {
            return Task.Run(() =>
            {
                currentScene.Update().Wait();
            });
        }

        internal Task FixedUpdate()
        {
            return Task.Run(() =>
            {
            });
        }

        internal Task Exit()
        {
            return Task.Run(() =>
            {
            });
        }

        internal Task Stop()
        {
            return Task.Run(() =>
            {
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