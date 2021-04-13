namespace Alis.Core.SFML
{
    using Alis.Tools;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class VideoGame : Game
    {
        

        [JsonConstructor]
        public VideoGame(Config config, SceneManager sceneManager) : base(config, sceneManager)
        {
            this.Config = config;
            this.SceneManager = sceneManager;
            Input = new InputSFML(config);
            Render = new RenderSFML(config);
        }

        public VideoGame(Config config, params Scene[] scenes) : base(config, scenes)
        {
            Input = new InputSFML(Config);
            Render = new RenderSFML(Config);
        }

    }
}

