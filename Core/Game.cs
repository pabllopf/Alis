//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Game.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define the game.</summary>
    public class Game
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

        /// <summary>The is stopped</summary>
        [NotNull]
        private bool isStopped;

        /// <summary>Initializes a new instance of the <see cref="Game" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scenes">The scene.</param>        
        public Game([NotNull] Config config, [NotNull] params Scene[] scenes)
        {
            this.config = config;

            render = new Render(config);
            input = new Input(config);

            isRunning = true;
            isStopped = false;

            sceneManager = new SceneManager(scenes);

            OnAwake += VideoGame_OnAwake;
            OnStart += VideoGame_OnStart;
            OnUpdate += VideoGame_OnUpdate;
            OnFixedUpdate += VideoGame_OnFixedUpdate;
            OnStop += VideoGame_OnStop;
            OnExit += VideoGame_OnExit;
        }

        /// <summary>Initializes a new instance of the <see cref="Game" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="sceneManager">The scene manager.</param>
        [JsonConstructor]
        public Game(Config config, SceneManager sceneManager)
        {
            this.config = config ?? new Config("Default");

            render = new Render(this.config);
            input = new Input(this.config);

            isRunning = true;
            isStopped = false;

            this.sceneManager = sceneManager ?? new SceneManager(new Scene[] { new Scene("Default") });

            OnAwake += VideoGame_OnAwake;
            OnStart += VideoGame_OnStart;
            OnUpdate += VideoGame_OnUpdate;
            OnFixedUpdate += VideoGame_OnFixedUpdate;
            OnStop += VideoGame_OnStop;
            OnExit += VideoGame_OnExit;

            Logger.Warning("Build the videogame of json");
        }

        /// <summary>Occurs when [on awake].</summary>
        public event EventHandler<bool> OnAwake;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnStart;

        /// <summary>Occurs when [on update].</summary>
        public event EventHandler<bool> OnUpdate;

        /// <summary>Occurs when [on fixed update].</summary>
        public event EventHandler<bool> OnFixedUpdate;

        /// <summary>Occurs when [on exit].</summary>
        public event EventHandler<bool> OnStop;

        /// <summary>Occurs when [on exit].</summary>
        public event EventHandler<bool> OnExit;

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [NotNull]
        [JsonProperty("_Config")]
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
        [JsonProperty("_SceneManager")]
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        /// <summary>Gets a value indicating whether this instance is new frame.</summary>
        /// <value>
        /// <c>true</c> if this instance is new frame; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonIgnore]
        public bool IsNewFrame { get => config.Time.IsNewFrame(); }

        /// <summary>Loads the of file.</summary>
        /// <param name="file">The file.</param>
        /// <returns>Return game.</returns>
        [return: NotNull]
        public static Game LoadOfFile(string file) => LocalData.Load<Game>(file);

        /// <summary>Runs the of file.</summary>
        [return: NotNull]
        public static void RunOfFile() => LocalData.Load<Game>("Data", Environment.CurrentDirectory + "/Data").Run();

        /// <summary>Previews the render.</summary>
        /// <returns>Preview render</returns>
        public byte[] PreviewRender()
        {
            Task.WaitAll(input.Update(), sceneManager.Update());

            return render.FrameBytes();
        }

        /// <summary>Runs this instance.</summary>
        public void Run() 
        {
            Awake();
            Start();
            while (isRunning) 
            {
                if (!isStopped)
                {
                    if (IsNewFrame)
                    {
                        Update();
                    }

                    FixedUpdate();
                }
                else 
                {
                    Stop();
                }
            }

            Exit();
        }

        /// <summary>Awakes this instance.</summary>
        private void Awake()
        {
            Task.WaitAll(input.Awake(), sceneManager.Awake());
            render.Awake();

            OnAwake?.Invoke(this, true);
        }

        /// <summary>Starts this instance.</summary>
        private void Start()
        {
            Task.WaitAll(input.Start(), sceneManager.Start());
            render.Start();

            OnStart?.Invoke(this, true);
        }

        /// <summary>Update every frame the videogame.</summary>
        private void Update()
        {
            Task.WaitAll(input.Update(), sceneManager.Update());
            render.Update();

            OnUpdate?.Invoke(this, true);
        }

        /// <summary>Update every time the videogame.</summary>
        private void FixedUpdate() 
        {
            Task.WaitAll(input.FixedUpdate(), sceneManager.FixedUpdate());

            OnFixedUpdate?.Invoke(this, true);
        }

        /// <summary>Stops this instance.</summary>
        private void Stop()
        {
            Task.WaitAll(input.Stop(), sceneManager.Stop());
            render.Stop();
            OnStop?.Invoke(this, true);
        }

        /// <summary>Exit the videogame.</summary>
        private void Exit() 
        {
            Task.WaitAll(input.Exit(), sceneManager.Exit());
            render.Exit();

            OnExit?.Invoke(this, true);
        }

        #region DefineEvents

        /// <summary>Video the game on start.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnStart([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on update.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnUpdate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on exit.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnExit([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on stop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnStop([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on fixed update.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnFixedUpdate([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        /// <summary>Video the game on awake.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnAwake([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}