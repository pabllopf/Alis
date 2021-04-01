namespace Alis.Core.SFML
{
    using Alis.Tools;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class VideoGame : Game
    {
        [JsonConstructor]
        public VideoGame([NotNull] Config config, [NotNull] SceneManager sceneManager) : base(config, sceneManager)
        {
            Input = new InputSFML(Config);
            Render = new RenderSFML(Config);
        }

        public VideoGame([NotNull] Config config, [NotNull] params Scene[] scenes) : base(config, scenes)
        {
            Input = new InputSFML(Config);
            Render = new RenderSFML(Config);
        }

        /// <summary>Loads the of file.</summary>
        /// <param name="file">The file.</param>
        /// <returns>Return game.</returns>
        [return: NotNull]
        public static new VideoGame LoadOfFile(string file) => LocalData.Load<VideoGame>(file);

        /// <summary>Runs the of file.</summary>
        [return: NotNull]
        public static void RunOfFile() => LocalData.Load<VideoGame>("Data", Environment.CurrentDirectory + "/Data").Run();

    }
}

