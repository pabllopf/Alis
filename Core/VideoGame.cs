//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>Define the game.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VideoGame
    {
        /// <summary>The configuration</summary>
        [JsonProperty]
        private Config config;

        /// <summary>The scene manager</summary>
        [JsonProperty]
        private SceneManager sceneManager;

        /// <summary>The render</summary>
        [JsonProperty]
        private Render render;

        /// <summary>The input</summary>
        [JsonProperty]
        private Input input;

        /// <summary>The is running</summary>
        [JsonProperty]
        private bool isRunning;

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <exception cref="ArgumentNullException">config null</exception>
        [JsonConstructor]
        public VideoGame([NotNull] Config config)
        {
            this.config = config;
            sceneManager = new SceneManager(new List<Scene>() { new Scene("Default") });
            input = new Input();
            render = new Render();
            isRunning = true;

            OnCreate += VideoGame_OnCreate;
            OnStart += VideoGame_OnStart;
            OnUpdate += VideoGame_OnUpdate;
            OnDestroy += VideoGame_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scene">The scene.</param>
        public VideoGame([NotNull] Config config, [NotNull] params Scene[] scene)
        {
            this.config = config;
            sceneManager = new SceneManager(new List<Scene>(scene));
            input = new Input();
            render = new Render();
            isRunning = true;

            OnCreate += VideoGame_OnCreate;
            OnStart += VideoGame_OnStart;
            OnUpdate += VideoGame_OnUpdate;
            OnDestroy += VideoGame_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Finalizes an instance of the <see cref="VideoGame" /> class.</summary>
        ~VideoGame() => OnDestroy.Invoke(this, true);

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnStart;

        /// <summary>Occurs when [on update].</summary>
        public event EventHandler<bool> OnUpdate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        public Config Config { get => config; set => config = value; }

        /// <summary>Gets or sets the render.</summary>
        /// <value>The render.</value>
        public Render Render { get => render; set => render = value; }
        
        /// <summary>Gets or sets the input.</summary>
        /// <value>The input.</value>
        public Input Input { get => input; set => input = value; }

        /// <summary>Gets or sets the scene manager.</summary>
        /// <value>The scene manager.</value>
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        /// <summary>Runs this instance.</summary>
        /// <returns>return true</returns>
        public bool Run() => StartAsync().Result && UpdateAsync().Result;

        /// <summary>Starts the asynchronous.</summary>
        /// <returns>Start the videogame.</returns>
        private async Task<bool> StartAsync()
        {
            return await Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                OnStart.Invoke(this, true);

                Task.WaitAll(input.Start(), render.Start(), sceneManager.Start());

                watch.Stop();
                Console.WriteLine($" Time to Start Videogame: " + watch.ElapsedMilliseconds + " ms");

                return true;
            });
        }

        /// <summary>Updates the asynchronous.</summary>
        /// <returns>Update the videogame</returns>
        private async Task<bool> UpdateAsync()
        {
            return await Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                while (isRunning) 
                {
                    Task.Delay(1000).Wait();

                    OnUpdate.Invoke(this, true);

                    Task.WaitAll(input.Update(), render.Update(), sceneManager.Update());

                    isRunning = false;
                }

                watch.Stop();
                Console.WriteLine($" Time to Update One Frame Videogame: 1000 + " + (watch.ElapsedMilliseconds - 1000) + " ms");

                return true;
            });
        }

        #region Events

        /// <summary>Video the game on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnCreate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnDestroy([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on start.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnStart([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on update.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnUpdate([NotNull] object sender, [NotNull] bool e)
        {
        }

        #endregion
    }
}
