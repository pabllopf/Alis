namespace Alis.Core.Sfml
{
    using Managers;

    /// <summary>Implement a video game with SFML library. </summary>
    public class VideoGame : Game
    {
        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        public VideoGame() 
        {
            RenderSystem = new RenderManager();
            SceneSystem = new SceneManager();
        }

        /// <summary>Builders this instance.</summary>
        /// <returns> Return a builder of api fluent. </returns>
        public static VideoGameBuilder Builder() => new(); 
    }
}

