namespace Alis.Core
{
    using Systems;
    using FluentApi;
    using Settings;
    using System.Text.Json.Serialization;

    /// <summary>Define the main logic of game made with ALIS.</summary>
    public class Game 
    {
        #region Constructor

        public Game() 
        {
            IsRunning = true;
            RenderSystem = new RenderSystem();
            SceneSystem = new SceneSystem();
        }

        [JsonConstructor]
        public Game(NotNull<bool> isRunning, NotNull<RenderSystem> renderSystem, NotNull<SceneSystem> sceneSystem) 
        {
            IsRunning = isRunning.Value;
            RenderSystem = renderSystem.Value;
            SceneSystem = sceneSystem.Value;
        }

        #endregion

        #region Properties

        /// <summary>Gets a value indicating whether this instance is running.</summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
        [JsonPropertyName("_IsRunning")]
        private bool IsRunning { get; set; } = true;

        /// <summary>Gets or sets the render system.</summary>
        /// <value>The render system.</value>
        [JsonIgnore]
        public RenderSystem RenderSystem { get; protected set; } = new RenderSystem();

        /// <summary>Gets or sets the scene system.</summary>
        /// <value>The scene system.</value>
        [JsonIgnore]
        public SceneSystem SceneSystem { get; protected set; } = new SceneSystem();

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [JsonPropertyName("_Setting")]
        public static Setting Setting { get; protected set; } = new Setting();

        #endregion

        /// <summary>Runs this instance.</summary>
        public void Run() 
        {
            #region Awake()
            SceneSystem.Awake();
            RenderSystem.Awake();
            #endregion

            #region Start()
            SceneSystem.Start();
            RenderSystem.Start();
            #endregion

            while (IsRunning) 
            {
                Setting.Time.SyncFixedDeltaTime();

                if (Setting.Time.IsNewFrame())
                {
                    Setting.Time.UpdateTimeStep();

                    for (int i = 0; i < Setting.Time.MaximunAllowedTimeStep; i++)
                    {
                        #region BeforeUpdate()
                        SceneSystem.BeforeUpdate();
                        RenderSystem.BeforeUpdate();
                        #endregion

                        #region Update()
                        SceneSystem.Update();
                        RenderSystem.Update();
                        #endregion

                        #region AfterUpdate()
                        SceneSystem.AfterUpdate();
                        RenderSystem.AfterUpdate();
                        #endregion
                    }

                    #region FixedUpdate()
                    SceneSystem.FixedUpdate();
                    RenderSystem.FixedUpdate();
                    #endregion

                    #region DispatchEvents()
                    SceneSystem.DispatchEvents();
                    RenderSystem.DispatchEvents();
                    #endregion

                    Setting.Time.CounterFrames();
                }

                Setting.Time.UpdateFixedTime();
            }

            #region Exit()
            SceneSystem.Exit();
            RenderSystem.Exit();
            #endregion
        }

        /// <summary>Resets the game.</summary>
        public void Reset() 
        {
            SceneSystem.Reset();
            RenderSystem.Reset();
        }

        /// <summary>Stops this game.</summary>
        public void Stop() 
        {
            SceneSystem.Stop();
            RenderSystem.Stop();
        }

        #region Destructor

        ~Game() 
        {
        
        }

        #endregion
    }
}
