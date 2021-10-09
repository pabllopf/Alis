namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Newtonsoft;

    public class Game
    {
        public Configuration configuration;

        public SceneManager sceneManager;

        public RenderManager renderManager;

        public PhysicsManager physicsManager;

        public ParticlesManager particlesManager;

        public InputManager inputManager;

        public OutputManager outputManager;
        private int isRunning;

        /// <summary>
        /// Constructor of game
        /// </summary>
        /// <param name="configuration">Include the configuration of the game.</param>
        public Game(Configuration configuration)
        {
            throw new System.NotImplementedException();
        }

        ~Game()
        {
            throw new System.NotImplementedException();
        }
    }
}
