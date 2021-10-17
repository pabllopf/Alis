using Alis.Fluent;
using System;
using System.Collections.Generic;

namespace Alis.Core
{
    public class GameBuilder : 
        IBuild<Game>,
        IRun<Game>,
        IConfiguration<GameBuilder, Func<ConfigurationBuilder, Configuration>>,
        IManagerOf<GameBuilder, Scene, Func<SceneManagerBuilder, SceneManager>>
    {
        private Game game;

        public GameBuilder() => game = new Game(new Core.Configuration());

        public GameBuilder Configuration(Func<ConfigurationBuilder, Configuration> value) 
        {
            game.Configuration = value.Invoke(new ConfigurationBuilder());
            return this;
        }

        public GameBuilder ManagerOf<T>(Func<SceneManagerBuilder, SceneManager> value) where T : Scene
        {
            SceneSystem sceneSystem = new SceneSystem(game.Configuration);
            sceneSystem.sceneManager = value.Invoke(new SceneManagerBuilder());
            game.SceneSystem = sceneSystem;
            return this;
        }

        public Game Build() => game;

        public void Run() => game.Run();
    }
}