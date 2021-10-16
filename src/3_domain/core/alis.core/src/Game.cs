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


        private Stopwatch timer = new Stopwatch();


        // Tiempo total desde que comenzó el juego
        private double fixedTime = 0.0f;

        // Tiempo total desde que se cargo el nivel/scene actual 
        private double timeSinceLevelLoad = 0.0f;

        // Multiplicador de tiempo que muestra la velocidad del mundo
        // timeScale = 1.0f velocidad normal
        // timeScale = 0.5f a mitad de velocidad 
        private double timeScale = 1.0f;

        // Numero de frames desde que comenzó el juego:
        private double frameCount = 0;
        
        // Frame actual del juego.
        private double currentFrame = 0;

        // Intervalo en segundos en el que se relaiza fixedupdate
        private double fixedDeltaTime = 0.0f;

        // Numero de fps maximo que se lanza el juego.
        private double maximumFramesPerSecond = 60;

        // intervalo de simulación de cada paso por cada frame
        private double timeStep = 0.0f;

        // Numero de pasos por cada frame (tiempo simulado)
        private double maximunAllowedTimeStep = 30.0f;

        

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="Game" /> class.</summary>
        internal Game() 
        {
            isRunning = false;
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
        }

        /// <summary>
        /// Constructor of game
        /// </summary>
        /// <param name="configuration">Include the configuration of the game.</param>
        internal Game(Configuration configuration)
        {
            this.configuration = configuration;
            isRunning = false;
        }

        #endregion

        public void Run() 
        {
            Init();
            Awake();
            Start();
            while (isRunning) 
            {
                fixedDeltaTime = 1_000.0f / maximumFramesPerSecond;

                if ((fixedTime * timeScale / frameCount) > fixedDeltaTime)
                {
                    timeStep = 1 / maximunAllowedTimeStep;

                    for (int i = 0; i < maximunAllowedTimeStep; i++)
                    {
                        BeforeUpdate();
                        Update();
                        AfterUpdate();
                    }

                    FixedUpdate();
                    currentFrame = (frameCount < maximumFramesPerSecond ? frameCount : (frameCount % maximumFramesPerSecond)) + 1;
                    frameCount += 1.0f;
                }

                fixedTime = timer.Elapsed.TotalMilliseconds;

                DebugInput();
            }

            Exit();
        }

        private void Init() 
        {
            timer.Start();
            isRunning = true;
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
