

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Audio;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class AudioSettingBuilder :
        IBuild<AudioSetting>
    {
        /// <summary>
        ///     The is mute
        /// </summary>
        private bool isMute;

        /// <summary>
        ///     The volume
        /// </summary>
        private int volume;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public AudioSetting Build() => new AudioSetting(volume, isMute);

        /// <summary>
        ///     Volumes the volume
        /// </summary>
        /// <param name="volume">The volume</param>
        /// <returns>The audio setting builder</returns>
        public AudioSettingBuilder Volume(int volume)
        {
            this.volume = volume;
            return this;
        }

        /// <summary>
        ///     Ises the mute using the specified mute
        /// </summary>
        /// <param name="mute">The mute</param>
        /// <returns>The audio setting builder</returns>
        public AudioSettingBuilder IsMute(bool mute)
        {
            isMute = mute;
            return this;
        }
    }
}