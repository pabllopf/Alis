using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core
{
    public class Game : HasBuilder<GameBuilder>
    {
        private bool isRunning;

        private Configuration configuration;

        private System[] systems;

        private RenderSystem renderSystem;

        private SceneSystem sceneSystem;

        #region Constructor

        public Game() 
        {
            this.configuration = new Configuration();
            isRunning = true;

            renderSystem = new RenderSystem(configuration);
            sceneSystem = new SceneSystem(configuration);

            systems = new System[2]
            {
                sceneSystem,
                renderSystem
            };
        }

        /// <summary>
        /// Constructor of game
        /// </summary>
        /// <param name="configuration">Include the configuration of the game.</param>
        public Game(Configuration configuration)
        {
            this.configuration = configuration;

            isRunning = true;

            renderSystem = new RenderSystem(configuration);
            sceneSystem = new SceneSystem(configuration);

            systems = new System[2] 
            {
                sceneSystem,
                renderSystem
            };
        }

        #endregion

        public Configuration Configuration
        {
            get => configuration; set
            {
                configuration = value;
            }
        }

        public SceneSystem SceneSystem
        {
            get => sceneSystem;
            set
            {
                sceneSystem = value;
                systems[0] = sceneSystem;
            }
        }

        public RenderSystem Render
        {
            get => renderSystem; 
            set
            {
                renderSystem = value;
                systems[1] = renderSystem;
            }
        }

        public virtual void Run() 
        {
            Awake();
            Start();
            while (isRunning) 
            {
                configuration.Time.UpdateFixedDeltaTime();

                if (configuration.Time.IsNewFrame())
                {
                    configuration.Time.UpdateTimeStep();

                    for (int i = 0; i < configuration.Time.MaximunAllowedTimeStep; i++)
                    {
                        BeforeUpdate();
                        Update();
                        AfterUpdate();
                    }

                    FixedUpdate();
                    configuration.Time.CounterFrames();
                    //Console.WriteLine($"{configuration.Time.CurrentFrame}");
                }

                configuration.Time.UpdateFixedTime();
                //DebugInput();
            }

            Exit();
        }

        private void DebugInput() 
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine($" key: {key}");

                if (key == ConsoleKey.Escape)
                {
                    isRunning = false;
                }

                if (key == ConsoleKey.LeftArrow)
                {
                    configuration.Time.MaximumFramesPerSecond -= 1.0f;
                }

                if (key == ConsoleKey.RightArrow)
                {
                    configuration.Time.MaximumFramesPerSecond += 1.0f;
                }

                if (key == ConsoleKey.UpArrow)
                {
                    configuration.Time.TimeScale += 1.0f;
                }

                if (key == ConsoleKey.DownArrow)
                {
                    configuration.Time.TimeScale -= 1.0f;
                }
            }
        }

        /// <summary>Awakes this instance.</summary>
        private void Awake()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Awake();
            }
        }

        /// <summary>Starts this instance.</summary>
        private void Start()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Start();
            }
        }

        /// <summary>Befores the update.</summary>
        private void BeforeUpdate()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].BeforeUpdate();
            }
        }

        /// <summary>Updates this instance.</summary>
        private void Update()
        {
            for (int i = 0; i < systems.Length; i++) 
            {
                systems[i].Update();
            }
        }

        /// <summary>Afters the update.</summary>
        private void AfterUpdate()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].AfterUpdate();
            }
        }

        /// <summary>Fixeds the update.</summary>
        private void FixedUpdate()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].FixedUpdate();
            }
        }

        /// <summary>Stops this instance.</summary>
        private void Stop()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Stop();
            }
        }

        /// <summary>Resets this instance.</summary>
        private void Reset()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Reset();
            }
        }

        /// <summary>Exits this instance.</summary>
        private void Exit()
        {
            for (int i = 0; i < systems.Length; i++)
            {
                systems[i].Exit();
            }
        }

        #region Destroyer

        /// <summary>Finalizes an instance of the <see cref="Game" /> class.</summary>
        ~Game() => Console.WriteLine("Destroy game.");

        #endregion
    }
}
