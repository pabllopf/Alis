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
        private readonly Memory<Scene> scenes;

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

            current = this;
            
            Logger.Info();
        }

        /// <summary>Occurs when [on change scene].</summary>
        public static event EventHandler<bool> OnChangeScene;

        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        [NotNull]
        [JsonProperty("_Scenes")]
        public Scene[] Scenes => scenes.ToArray();

        /// <summary>Gets the current scene.</summary>
        /// <value>The current scene.</value>
        [NotNull]
        [JsonProperty("_CurrentScene")]
        public Scene CurrentScene => currentScene;

        /// <summary>Loads the specified name.</summary>
        /// <param name="name">The name.</param>
        public static void Load(string name)
        {
            Span<Scene> span = current.scenes.Span;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] != null && span[i].Name.Equals(name))
                {
                    Logger.Log(string.Format(ChangeScene, name, current.currentScene.Name));
                    current.currentScene.IsActive = false;
                    current.currentScene = span[i];
                    current.currentScene.IsActive = true;

                    OnChangeScene?.Invoke(current.currentScene, true);

                    current.Awake().Wait();
                    current.Start().Wait();
                    return;
                }
            }

            Logger.Warning(string.Format(DontChangeScene, name, current.currentScene.Name));
        }

        /// <summary>Awakes this instance.</summary>
        /// <returns>Awake scene.</returns>
        internal Task Awake() => Task.Run(() => currentScene?.Awake());

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Start() => Task.Run(() => currentScene?.Start());

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Update() => Task.Run(() => currentScene?.Update());

        /// <summary>Fix the update.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task FixedUpdate() => Task.Run(() => currentScene?.FixedUpdate());

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Exit() => Task.Run(() => currentScene?.Exit());

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal Task Stop() => Task.Run(() => currentScene?.Stop());

        #region Events

        /// <summary>Scenes the manager on change scene.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private static void SceneManager_OnChangeScene([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}