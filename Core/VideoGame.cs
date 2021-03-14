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
    using Alis.Tools;
    using Newtonsoft.Json;
    using SFML.Audio;
    using SFML.System;

    /// <summary>Define the game.</summary>
    public class VideoGame
    {
        /// <summary>The configuration</summary> 
        [NotNull]
        private Config config;

        /// <summary>The scene manager</summary>
        [NotNull]
        private SceneManager sceneManager;

        /// <summary>The render</summary>
        [NotNull]
        private Render render;

        /// <summary>The input</summary>
        [NotNull]
        private Input input;

        /// <summary>The is running</summary>
        [NotNull]
        private bool isRunning;

        /// <summary>The clock</summary>
        [NotNull]
        private Clock clock = new Clock();

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scenes">The scenes.</param>
        [JsonConstructor]
        public VideoGame([NotNull] Config config, [NotNull] List<Scene> scenes)
        {
            this.config = config;

            render = new Render(config);
            input = new Input(config);

            this.clock = new Clock();
            isRunning = true;

            sceneManager = new SceneManager(scenes);

            OnCreate += VideoGame_OnCreate;
            OnStart += VideoGame_OnStart;
            OnUpdate += VideoGame_OnUpdate;
            OnDestroy += VideoGame_OnDestroy;

            OnCreate.Invoke(this, true);
        }

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scenes">The scene.</param>        
        public VideoGame([NotNull] Config config, [NotNull] params Scene[] scenes)
        {
            this.config = config;

            render = new Render(config);
            input = new Input(config);

            this.clock = new Clock();
            isRunning = true;

            sceneManager = new SceneManager(scenes);

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
        [NotNull]
        public Config Config { get => config; set => config = value; }

        /// <summary>Gets or sets the render.</summary>
        /// <value>The render.</value>
        [NotNull]
        [JsonIgnore]
        public Render Render { get => render; set => render = value; }

        /// <summary>Gets or sets the input.</summary>
        /// <value>The input.</value>
        [NotNull]
        [JsonIgnore]
        public Input Input { get => input; set => input = value; }

        /// <summary>Gets or sets the scene manager.</summary>
        /// <value>The scene manager.</value>
        [NotNull]
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        /// <summary>Loads the of file.</summary>
        /// <param name="file">The file.</param>
        [return: NotNull]
        public static VideoGame LoadOfFile(string file) 
        {
            return LocalData.Load<VideoGame>(file);
        }

        /// <summary>Loads the of file.</summary>
        /// <param name="file">The file.</param>
        [return: NotNull]
        public static void RunOfFile()
        {
            LocalData.Load<VideoGame>("Data", Environment.CurrentDirectory + "/Data").Run();
        }


        /// <summary>Runs this instance.</summary>
        /// <returns>return true</returns>
        public void Run()
        {
            Start();
            Update();
        }

        /// <summary>Starts the asynchronous.</summary>
        /// <returns>Start the videogame.</returns>
        [return: NotNull]
        private void Start()
        {
            Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                OnStart.Invoke(this, true);

                Task.WaitAll(input.Start(), sceneManager.Start());

                watch.Stop();
                Logger.Log($" Time to Start Videogame: " + watch.ElapsedMilliseconds + " ms");
            }).Wait();

            render.Start();
        }

        private bool firstTime = true;

        public byte[] PreviewRender() 
        {
            Task.WaitAll(input.Update(), sceneManager.Update());

            return render.FrameBytes();
        }

        /// <summary>Updates this instance.</summary>
        private void Update()
        {
            while (isRunning) 
            {
                if (clock.ElapsedTime.AsMilliseconds() >= 0.1f)
                {
                    var watch = new Stopwatch();
                    watch.Start();

                    Task.Run(() =>
                    {
                        OnUpdate.Invoke(this, true);
                        Task.WaitAll(input.Update(), sceneManager.Update());
                    }).Wait();

                    //isRunning = false;

                    watch.Stop();
                    Logger.Log($" Time to Update One Frame Videogame: " + (watch.ElapsedMilliseconds) + " ms");

                    render.Update();

                    //Task.Delay(1000).Wait();
                    clock.Restart();
                }

               
            }

            render.Exit();

            GC.Collect();
            GC.WaitForFullGCComplete();
        }

        #region DefineEvents

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
