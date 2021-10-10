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

        public SceneSystem sceneSystem;

        public RenderSystem renderSystem;

        public ParticlesSystem particlesSystem;

        public InputSystem inputSystem;

        public OutputSystem outputSystem;

        public PhysicsSystem physicsSystem;

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
