using Alis.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core
{
    public class Game : HasBuilder<GameBuilder>, IDisposable
    {
        private Configuration configuration;

        private Dictionary<string, System> systems;

        public Configuration Configuration { get => configuration; set => configuration = value; }
        internal Dictionary<string, System> Systems { get => systems; set => systems = value; }


        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="Game" /> class.</summary>
        internal Game() 
        {
            configuration = new Configuration();

            systems = new Dictionary<string, System>()
            {
                { "SceneSystem",     new SceneSystem() },
                { "InputSystem",     new InputSystem() },
                { "OutputSystem",    new OutputSystem() },
                { "ParticlesSystem", new ParticlesSystem() },
                { "PhysicsSystem",   new PhysicsSystem() },
                { "RenderSystem",    new RenderSystem() }
            };
        }

        /// <summary>
        /// Constructor of game
        /// </summary>
        /// <param name="configuration">Include the configuration of the game.</param>
        internal Game(Configuration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        public void Run() 
        {
        
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
