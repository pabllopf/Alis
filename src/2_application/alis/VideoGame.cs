using Alis.Core;
using Alis.Core.Sfml.Builders;
using Alis.Core.Sfml.Managers;

namespace Alis
{
    public class VideoGame : Game
    {
        public VideoGame()
        {
            RenderSystem = new RenderManager();
            SceneSystem = new SceneManager();
        }

        public static VideoGameBuilder Create() => new();
    }
}