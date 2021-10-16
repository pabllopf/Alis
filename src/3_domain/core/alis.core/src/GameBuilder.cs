using Alis.Fluent;
using System;
using System.Collections.Generic;

namespace Alis.Core
{
    public class GameBuilder : 
        IBuild<Game>,
        IConfiguration<GameBuilder, Func<ConfigurationBuilder, Configuration>>,
        IManager<GameBuilder, Scene, Func<SceneBuilder, SceneManager>>
    {
        private Game game;

        public GameBuilder() => game = new Game();

        public GameBuilder Configuration(Func<ConfigurationBuilder, Configuration> func) 
        {
            game.Configuration = func.Invoke(new ConfigurationBuilder());
            return this;
        }

        public GameBuilder Manager<T>(Func<SceneBuilder, SceneManager> value) where T : Scene
        {
            SceneSystem sceneSystem = new SceneSystem();
            sceneSystem.sceneManager = value.Invoke(new SceneBuilder());
            game.Systems["SceneSystem"] = sceneSystem;
            return this;
        }

        public Game Build() => game;

        public void Run() => game.Run();

       
    }
}