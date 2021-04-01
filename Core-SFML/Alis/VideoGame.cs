namespace Alis.Core.SFML
{
    using System.Diagnostics.CodeAnalysis;

    public class VideoGame : Game
    {
        public VideoGame([NotNull] Config config, [NotNull] params Scene[] scenes) : base(config, scenes)
        {
            Input = new InputSFML(Config);
            Render = new RenderSFML(Config);
        }
    }
}

