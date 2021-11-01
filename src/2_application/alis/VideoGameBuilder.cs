using System;
using Alis.Core.Builders;
using Alis.Core.Entities;
using Alis.Core.Settings;
using Alis.FluentApi;

namespace Alis.Core.Sfml.Builders
{
    /// <summary>Game builder.</summary>
    public class VideoGameBuilder :
        IBuild<VideoGame>,
        ISettings<VideoGameBuilder, Func<SettingBuilder, Setting>>
    {
        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        private VideoGame VideoGame { get; } = new();

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public VideoGame Build()
        {
            return VideoGame;
        }

        /// <summary>Configurations the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public VideoGameBuilder Settings(Func<SettingBuilder, Setting> value)
        {
            Game.Setting = value.Invoke(new SettingBuilder());
            return this;
        }

        public VideoGameBuilder Manager<T>(Func<SceneBuilder, Scene> value) where T : Scene
        {
            VideoGame.SceneSystem.Add(value.Invoke(new SceneBuilder()));
            return this;
        }

        /// <summary>Runs this instance.</summary>
        public void Run()
        {
            VideoGame.Run();
        }
    }
}