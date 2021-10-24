namespace Alis.Core.Sfml
{
    /// <summary>Implement a video game with SFML library. </summary>
    public class VideoGame : Game
    {
        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="configuration">The configuration of the game.</param>
        public VideoGame(Configuration configuration) : base(configuration)
        {
            RenderSystem = new RenderManager(Config);
            SceneSystem = new SceneManager(Config);
        }

        /// <summary>Builders this instance.</summary>
        /// <returns> Return a builder of api fluent. </returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder(new Configuration()); 
    }
}

