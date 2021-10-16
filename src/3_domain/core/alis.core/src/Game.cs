using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Alis.Core
{
    public class Game : HasBuilder<GameBuilder>, IDisposable
    {
        private Configuration configuration;

        private Dictionary<string, System> systems;

        public Configuration Configuration { get => configuration; set => configuration = value; }
        internal Dictionary<string, System> Systems { get => systems; set => systems = value; }

        private bool isRunning;

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="Game" /> class.</summary>
        internal Game() 
        {
            configuration = new Configuration();

            systems = new Dictionary<string, System>()
            {
                { "SceneSystem",     new SceneSystem() },
                //{ "InputSystem",     new InputSystem() },
                //{ "OutputSystem",    new OutputSystem() },
                //{ "ParticlesSystem", new ParticlesSystem() },
                //{ "PhysicsSystem",   new PhysicsSystem() },
                //{ "RenderSystem",    new RenderSystem() }
            };

            isRunning = true;
        }

        /// <summary>
        /// Constructor of game
        /// </summary>
        /// <param name="configuration">Include the configuration of the game.</param>
        internal Game(Configuration configuration)
        {
            this.configuration = configuration;
            isRunning = true;
        }

        #endregion

        public void Run() 
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

                    Console.WriteLine($"FPS={configuration.Time.CurrentFrame} |" +
                                      $"Count FPS = {configuration.Time.FrameCount} | " +
                                      $"TimeFixed={configuration.Time.FixedTime} | " +
                                      $"TimeScale={configuration.Time.TimeScale} |" +
                                      $"TimeStep={configuration.Time.TimeStep} | " +
                                      $"FixedDeltaTime={configuration.Time.FixedDeltaTime} |" +
                                      $"maxfps={configuration.Time.MaximumFramesPerSecond} | " +
                                      $"maxTimeStep={configuration.Time.MaximunAllowedTimeStep}"
                                      );

                    FixedUpdate();
                    configuration.Time.CounterFrames();
                }

                configuration.Time.UpdateFixedTime();
                DebugInput();
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
        private void Awake() => systems.Values.ToList().ForEach(system => system.Awake());

        /// <summary>Starts this instance.</summary>
        private void Start() => systems.Values.ToList().ForEach(system => system.Start());

        /// <summary>Befores the update.</summary>
        private void BeforeUpdate() => systems.Values.ToList().ForEach(system => system.BeforeUpdate());

        /// <summary>Updates this instance.</summary>
        private void Update() => systems.Values.ToList().ForEach(system => system.Update());

        /// <summary>Afters the update.</summary>
        private void AfterUpdate() => systems.Values.ToList().ForEach(system => system.AfterUpdate());

        /// <summary>Fixeds the update.</summary>
        private void FixedUpdate() => systems.Values.ToList().ForEach(system => system.FixedUpdate());

        /// <summary>Stops this instance.</summary>
        private void Stop() => systems.Values.ToList().ForEach(system => system.Stop());

        /// <summary>Resets this instance.</summary>
        private void Reset() => systems.Values.ToList().ForEach(system => system.Reset());

        /// <summary>Exits this instance.</summary>
        private void Exit() => systems.Values.ToList().ForEach(system => system.Exit());

        #region Dispose 

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose() => Console.WriteLine("Dispose class.");

        #endregion

        #region Destroyer

        /// <summary>Finalizes an instance of the <see cref="Game" /> class.</summary>
        ~Game() => Console.WriteLine("Destroy game.");
        
        #endregion
    }
}
