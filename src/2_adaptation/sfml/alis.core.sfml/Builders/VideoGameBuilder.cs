namespace Alis.Core.Sfml.Builders
{
    using FluentApi;
    using Settings;
    using System;

    /// <summary>Game builder.</summary>
    public class VideoGameBuilder : 
        IBuild<VideoGame>,
        ISettings<VideoGameBuilder, Func<SettingBuilder, Setting>>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        private VideoGame VideoGame { get; set; } = new VideoGame();

        /// <summary>Configurations the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public VideoGameBuilder Settings(Func<SettingBuilder, Setting> value)
        {
            Game.Setting = value.Invoke(new SettingBuilder());
            return this;
        }

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build() => VideoGame;

        /// <summary>Runs this instance.</summary>
        public void Run() => VideoGame.Run();
    }
}