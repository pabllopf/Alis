using Alis.Core;
using Alis.Core.Sfml.Builders;
using Alis.Core.Sfml.Managers;

namespace Alis
{
    /// <summary>
    /// The video game class
    /// </summary>
    /// <seealso cref="Game"/>
    public class VideoGame : Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        public VideoGame()
        {
            RenderSystem = new RenderManager();
            SceneSystem = new SceneManager();
        }

        /// <summary>
        /// Creates
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Create() => new();
    }
}