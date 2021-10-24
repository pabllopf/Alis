namespace Alis.Core
{
    /// <summary>Define the main logic of game made with ALIS.</summary>
    public class Game 
    {
        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="Game" /> class.</summary>
        /// <param name="configuration">The configuration of the game.</param>
        [System.Text.Json.Serialization.JsonConstructor]
        public Game(Configuration configuration)
        {
            IsRunning = true;
            Config = configuration;
            RenderSystem = new RenderSystem(configuration);
            SceneSystem = new SceneSystem(configuration);
        }

        #endregion

        #region Properties 

        /// <summary>Gets a value indicating whether this instance is running.</summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_IsRunning")]
        public bool IsRunning { get; private set; }

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [System.Text.Json.Serialization.JsonPropertyName("_Configuration")]
        public Configuration Config { get; protected set ; }

        /// <summary>Gets or sets the render system.</summary>
        /// <value>The render system.</value>
        [System.Text.Json.Serialization.JsonIgnore]
        public RenderSystem RenderSystem { get; protected set; }

        /// <summary>Gets or sets the scene system.</summary>
        /// <value>The scene system.</value>
        [System.Text.Json.Serialization.JsonIgnore]
        public SceneSystem SceneSystem { get; protected set; }

        #endregion

        #region Run

        /// <summary>Runs this instance.</summary>
        public void Run() 
        {
            Awake();
            Start();
            while (IsRunning) 
            {
                Config.Time.UpdateFixedDeltaTime();

                if (Config.Time.IsNewFrame())
                {
                    Config.Time.UpdateTimeStep();

                    for (int i = 0; i < Config.Time.MaximunAllowedTimeStep; i++)
                    {
                        BeforeUpdate();
                        Update();
                        AfterUpdate();
                    }

                    FixedUpdate();
                    DispatchEvents();
                    SyncStates();
                    Config.Time.CounterFrames();
                }

                Config.Time.UpdateFixedTime();
            }

            Exit();
        }

        #endregion

        /// <summary>Awakes this instance.</summary>
        private void Awake()
        {
            RenderSystem.Awake();
            SceneSystem.Awake();
        }

        /// <summary>Starts this instance.</summary>
        private void Start()
        {
            RenderSystem.Start();
            SceneSystem.Start();
        }

        /// <summary>Befores the update.</summary>
        private void BeforeUpdate()
        {
            RenderSystem.BeforeUpdate();
            SceneSystem.BeforeUpdate();
        }

        /// <summary>Updates this instance.</summary>
        private void Update()
        {
            RenderSystem.Update();
            SceneSystem.Update();
        }

        /// <summary>Afters the update.</summary>
        private void AfterUpdate()
        {
            RenderSystem.AfterUpdate();
            SceneSystem.AfterUpdate();
        }

        /// <summary>Fixeds the update.</summary>
        private void FixedUpdate()
        {
            RenderSystem.FixedUpdate();
            SceneSystem.FixedUpdate();
        }

        private void SyncStates() 
        {
            RenderSystem.Configuration = Config;
            SceneSystem.Configuration = Config;
        }

        private void DispatchEvents() 
        {
            RenderSystem.DispatchEvents();
            SceneSystem.DispatchEvents();
        }

        /// <summary>Stops this instance.</summary>
        private void Stop()
        {
            RenderSystem.Stop();
            SceneSystem.Stop();
        }

        /// <summary>Resets this instance.</summary>
        private void Reset()
        {
            RenderSystem.Reset();
            SceneSystem.Reset();
        }

        /// <summary>Exits this instance.</summary>
        private void Exit()
        {
            RenderSystem.Exit();
            SceneSystem.Exit();
        }

        #region Destroyer

        /// <summary>Finalizes an instance of the <see cref="Game" /> class.</summary>
        ~Game() 
        {
        
        }

        #endregion
    }
}
