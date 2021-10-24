namespace Alis.Core.Sfml
{
    public class VideoGameBuilder : VideoGame,
        Fluent.IBuild<VideoGame>,
        Fluent.IRun<VideoGame>,
        Fluent.IConfiguration<VideoGameBuilder, System.Func<ConfigurationBuilder, Configuration>>,
        Fluent.IManagerOf<VideoGameBuilder, Scene, System.Func<SceneManagerBuilder, SceneManager>>
    {
        public VideoGameBuilder(Configuration configuration) : base(configuration) => Config = configuration;

        public VideoGameBuilder Configuration(System.Func<ConfigurationBuilder, Configuration> value)
        {
            Config = value.Invoke(new ConfigurationBuilder());
            return this;
        }

        public VideoGameBuilder ManagerOf<T>(System.Func<SceneManagerBuilder, SceneManager> value) where T : Scene
        {
            SceneSystem = value.Invoke(new SceneManagerBuilder(new Core.Configuration()));
            return this;
        }

        public VideoGame Build() => this;
    }
}