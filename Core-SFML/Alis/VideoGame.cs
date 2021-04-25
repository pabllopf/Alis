namespace Alis.Core.SFML
{
    using Alis.Tools;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <summary>Video game</summary>
    public class VideoGame : Game
    {
        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="sceneManager">The scene manager.</param>
        [JsonConstructor]
        public VideoGame(Config config, SceneManager sceneManager) : base(config, sceneManager)
        {
            this.Config = config;
            this.SceneManager = sceneManager;
            Input = new InputSFML(config);
            Render = new RenderSFML(config);
        }

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scenes">The scene.</param>
        public VideoGame(Config config, params Scene[] scenes) : base(config, scenes)
        {
            Input = new InputSFML(Config);
            Render = new RenderSFML(Config);
        }

        public override byte[] PreviewRender()
        {
            base.PreviewRender();
            return RenderSFML.CurrentRenderSFML.FrameBytes();
        }

        /// <summary>Loads the of file.</summary>
        /// <param name="file">The file.</param>
        /// <returns>Return game.</returns>
        [return: NotNull]
        public static VideoGame LoadOfFile(string file) => LocalData.Load<VideoGame>(file);

        /// <summary>Runs the of file.</summary>
        [return: NotNull]
        public static void RunOfFile() => LocalData.Load<VideoGame>("Data", Environment.CurrentDirectory + "/Data").Run();

        /// <summary>The builder</summary>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();

        /// <summary>Video Game Builder</summary>
        public class VideoGameBuilder
        {
            /// <summary>The current</summary>
            [AllowNull]
            private static VideoGameBuilder current;

            /// <summary>The configuration</summary>
            [AllowNull]
            private Config config;

            /// <summary>The scene manager</summary>
            [AllowNull]
            private SceneManager sceneManager;

            /// <summary>Initializes a new instance of the <see cref="VideoGameBuilder" /> class.</summary>
            public VideoGameBuilder() => current ??= this;

            /// <summary>Configurations the specified configuration.</summary>
            /// <param name="config">The configuration.</param>
            /// <returns>Return the video game builder</returns>
            public VideoGameBuilder Config(Config config) 
            {
                current.config = config;
                return current;
            }

            /// <summary>Scenes the manager.</summary>
            /// <param name="sceneManager">The scene manager.</param>
            /// <returns>Return the scene manager. </returns>
            public VideoGameBuilder SceneManager(SceneManager sceneManager) 
            {
                current.sceneManager = sceneManager;
                return current;
            }

            /// <summary>Builds this instance.</summary>
            /// <returns>Return the build.</returns>
            public VideoGame Build()
            {
                current.config ??= new Config("Default");
                current.sceneManager ??= new SceneManager();

                return new VideoGame(current.config, current.sceneManager);
            }

            /// <summary>Builds the specified game.</summary>
            /// <param name="game">The game.</param>
            /// <returns>Return the build.</returns>
            public VideoGame Build(out VideoGame game)
            {
                current.config ??= new Config("Default");
                current.sceneManager ??= new SceneManager();

                game = new VideoGame(current.config, current.sceneManager);

                return game;
            }

            /// <summary>Runs this instance.</summary>
            public void Run()
            {
                current.config ??= new Config("Default");
                current.sceneManager ??= new SceneManager();

                new VideoGame(current.config, current.sceneManager).Run();
            }
        }
    }
}

