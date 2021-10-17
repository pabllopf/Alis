namespace Alis.Core.SFML
{
    /// <summary>Video game</summary>
    public class VideoGame : Game
    {
        private Configuration configuration;

        public VideoGame() : base()
        {
            configuration = Configuration;
            Render = new RenderManager(Configuration);
        }

        public VideoGame(Configuration configuration) : base(configuration)
        {
            this.configuration = Configuration;
            Render = new RenderManager(Configuration);
        }

        public new Configuration Configuration
        {
            get => configuration; 
            set
            {
                configuration = value;
                Render.Configuration = value;
            }
        }



        public new static VideoGameBuilder Builder() => new();
    }
}

