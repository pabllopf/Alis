using Alis.Fluent;
using System;

namespace Alis.Core.SFML
{
    public class VideoGameBuilder : GameBuilder, 
        IBuild<VideoGame>,
        IRun<VideoGame>,
        IConfiguration<VideoGameBuilder, Func<ConfigurationBuilder, Configuration>>,
        IManagerOf<VideoGameBuilder, Scene, Func<SceneManagerBuilder, SceneManager>>
    {
        private VideoGame game;

        public VideoGameBuilder() => game = new VideoGame();

        public new VideoGameBuilder Configuration(Func<ConfigurationBuilder, Configuration> value)
        {
            game.Configuration = value.Invoke(new ConfigurationBuilder());
            return this;
        }

        public new VideoGameBuilder ManagerOf<T>(Func<SceneManagerBuilder, SceneManager> value) where T : Scene
        {
            SceneSystem sceneSystem = new SceneSystem();
            sceneSystem.sceneManager = value.Invoke(new SceneManagerBuilder());
            game.SceneSystem = sceneSystem;
            return this;
        }

        public new VideoGame Build() => game;

        public new void Run() => game.Run();
    }
}