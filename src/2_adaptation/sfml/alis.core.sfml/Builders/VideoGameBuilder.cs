namespace Alis.Core.Sfml
{
    using FluentApi;
    using Settings;

    /// <summary>Game builder.</summary>
    public class VideoGameBuilder : 
        IBuild<VideoGame>,
        IConfiguration<VideoGameBuilder, string>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        private VideoGame VideoGame { get; set; } = new VideoGame();

        /// <summary>Configurations the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns> </returns>
        public VideoGameBuilder Configuration(string value)
        {
            Game.Setting.General.Author = value;
            return this;
        }

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build() => VideoGame;

        /// <summary>Runs this instance.</summary>
        public void Run() => VideoGame.Run();
    }
}