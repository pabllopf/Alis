namespace Alis.Core
{
    /// <summary>Define the main logic of game made with ALIS.</summary>
    public class Game 
    {
        /// <summary>Gets a value indicating whether this instance is running.</summary>
        /// <value>
        /// <c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
        private bool IsRunning { get; set; } = true;

        /// <summary>Gets or sets the render system.</summary>
        /// <value>The render system.</value>
        public Systems.RenderSystem RenderSystem { get; protected set; } = new Systems.RenderSystem();

        /// <summary>Gets or sets the scene system.</summary>
        /// <value>The scene system.</value>
        public Systems.SceneSystem SceneSystem { get; protected set; } = new Systems.SceneSystem();

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        public static Settings.Setting Setting { get; protected set; } = new Settings.Setting();

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
            }

            #region Exit()
            SceneSystem.Exit();
            RenderSystem.Exit();
            #endregion




            /*
            while (IsRunning) 
            {
                //Setting.Time.UpdateFixedDeltaTime();

                //if (Setting.Time.IsNewFrame())
                //{
                    //Setting.Time.UpdateTimeStep();

                    //for (int i = 0; i < Setting.Time.MaximunAllowedTimeStep; i++)
                    //{
                        BeforeUpdate();
                        Update();
                        AfterUpdate();
                    //}

                    FixedUpdate();
                    DispatchEvents();
                    //Setting.Time.CounterFrames();
                //}

                //Setting.Time.UpdateFixedTime();
            }

            Exit();*/
        }

        /// <summary>Resets the game.</summary>
        public void Reset() 
        {
        }

        /// <summary>Stops this game.</summary>
        public void Stop() 
        {
        }
    }
}
