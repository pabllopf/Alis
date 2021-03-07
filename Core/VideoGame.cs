//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define the game.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VideoGame
    {
        /// <summary>The configuration</summary>
        private Config config;

        /// <summary>The scene manager</summary>
        private SceneManager sceneManager;
       
        /// <summary>The render</summary>
        private Render render;

        /// <summary>The input</summary>
        private Input input;

        /// <summary>The is running</summary>
        private bool isRunning;

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <exception cref="ArgumentNullException">config null</exception>
        [JsonConstructor]
        public VideoGame(Config config)
        {
            Logger.Info();

            this.config = config ?? throw new ArgumentNullException(nameof(config));

            this.sceneManager = new SceneManager(new List<Scene>() { new Scene("Default") });

            this.input = new Input();

            this.render = new Render();

            isRunning = true;

            InitEvents();
        }

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scene">The scene.</param>
        public VideoGame(Config config, params Scene[] scene)
        {
            Logger.Info();

            this.config = config ?? throw new ArgumentNullException(nameof(config));

            this.sceneManager = new SceneManager(new List<Scene>(scene ?? throw new ArgumentNullException(nameof(scene))));

            this.input = new Input();

            this.render = new Render();

            isRunning = true;

            InitEvents();
        }

        /// <summary>Finalizes an instance of the <see cref="VideoGame" /> class.</summary>
        ~VideoGame() => OnDestroy?.Invoke(null, true);

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
        [JsonProperty]
        public Config Config { get => config; set => config = value; }

        /// <summary>Gets or sets the render.</summary>
        /// <value>The render.</value>
        [JsonProperty]
        public Render Render { get => render; set => render = value; }
        
        /// <summary>Gets or sets the input.</summary>
        /// <value>The input.</value>
        [JsonProperty]
        public Input Input { get => input; set => input = value; }

        /// <summary>Gets or sets the scene manager.</summary>
        /// <value>The scene manager.</value>
        [JsonProperty]
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        /// <summary>Runs this instance.</summary>
        public void Run()
        {
            StartAsync().Wait();
            UpdateAsync().Wait();
        }

        /// <summary>Starts the asynchronous.</summary>
        /// <returns>Start the videogame.</returns>
        private async Task StartAsync()
        {
            await Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                watch.Stop();
                Console.WriteLine($" Time to Start Videogame: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        /// <summary>Updates the asynchronous.</summary>
        /// <returns>Update the videogame</returns>
        private async Task UpdateAsync()
        {
            await Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                Task.WaitAll
                (
                    input.Update(),
                    render.Update(),
                    sceneManager.Update()
                );
                
                watch.Stop();
                Console.WriteLine($" Time to Update One Frame Videogame: 1000 + " + (watch.ElapsedMilliseconds - 1000) + " ms");
            });
        }


        /*
        /// <summary>Runs this instance.</summary>
        /// <returns>Return the value</returns>
        public bool Run()
        {
            Logger.Info();
            return Start() && Update();
        }*/

        /*
        /// <summary>Starts this instance.</summary>
        /// <returns>Return false if fail something.</returns>
        private bool Start()
        {
            Logger.Info();
            
            OnStart?.Invoke(null, true);

            return true;
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return false if fail something.</returns>
        private bool Update()
        {
            isRunning = true;
            while (isRunning) 
            {
                OnUpdate?.Invoke(null, true);

                input.Update();
                sceneManager.Update();
            }

            return true;
        }*/

        #region Events

        /// <summary>Initializes the events.</summary>
        private void InitEvents() 
        {
            OnCreate += VideoGame_OnCreate;
            OnStart += VideoGame_OnStart;
            OnDestroy += VideoGame_OnDestroy;

            OnCreate?.Invoke(null, true);
        }

        /// <summary>Video the game on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnCreate(object sender, bool e) => Logger.Info();

        /// <summary>Video the game on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnDestroy(object sender, bool e) => Logger.Info();

        /// <summary>Video the game on start.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnStart(object sender, bool e) => Logger.Info();

        #endregion
    }
}
