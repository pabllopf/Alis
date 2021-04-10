//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SceneManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Manage the scenes of the videogame.</summary>
    public class SceneManager
    {
        /// <summary>The maximum number scene</summary>
        private const int MaxNumScene = 100;

        /// <summary>The scenes</summary>
        [NotNull]
        private Memory<Scene> scenes;

        /// <summary>The current scene</summary>
        [NotNull]
        private Scene currentScene;

        /// <summary>Initializes a new instance of the <see cref="SceneManager" /> class.</summary>
        /// <param name="scenes">The scenes.</param>
        [JsonConstructor]
        public SceneManager([NotNull] Scene[] scenes)
        {
            this.scenes = new Memory<Scene>(new Scene[MaxNumScene]);
            Span<Scene> span = this.scenes.Span;
            for (int i = 0; i < scenes.Length; i++) 
            {
                if (span[i] == null) 
                {
                    span[i] = scenes[i];
                }       
            }

            currentScene = scenes.Length > 0 ? scenes[0] : new Scene("default");
            Logger.Log("Defined the scene '" + currentScene.Name + "'");
        }

        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        [NotNull]
        [JsonProperty("_Scenes")]
        public Scene[] Scenes { get => scenes.ToArray();}

        /// <summary>Awakes this instance.</summary>
        /// <returns>Awake scene.</returns>
        internal Task Awake()
        {
            return Task.Run(() =>
            {
                currentScene?.Awake();
            });
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Start()
        {
            return Task.Run(() =>
            {
                currentScene?.Start();
                Logger.Log("Start the scene '" + currentScene?.Name + "'");
            });
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Update()
        {
            return Task.Run(() =>
            {
                currentScene?.Update();
            });
        }

        /// <summary>Fixeds the update.</summary>
        /// <returns>Return none</returns>
        internal Task FixedUpdate()
        {
            return Task.Run(() =>
            {
                currentScene?.FixedUpdate();
            });
        }

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        internal Task Exit()
        {
            return Task.Run(() =>
            {
                currentScene?.Exit();
                Logger.Log("Exit the scene '" + currentScene?.Name + "'");
            });
        }

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        internal Task Stop()
        {
            return Task.Run(() =>
            {
                currentScene?.Stop();
                Logger.Log("Stop the scene '" + currentScene?.Name + "'");
            });
        }
    }
}