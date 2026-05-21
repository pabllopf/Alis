

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Builder.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio clip builder class
    /// </summary>
    /// <seealso cref="IBuild{AudioClip}" />
    public class AudioSourceBuilder :
        IBuild<AudioSource>,
        IFilePath<AudioSourceBuilder, string>,
        IVolume<AudioSourceBuilder, float>,
        IMute<AudioSourceBuilder, bool>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     The is mute
        /// </summary>
        private bool isMute;

        /// <summary>
        ///     The loop
        /// </summary>
        private bool loop;

        /// <summary>
        ///     The empty
        /// </summary>
        private string nameFile = string.Empty;

        /// <summary>
        ///     The play on awake
        /// </summary>
        private bool playOnAwake;

        /// <summary>
        ///     The volume
        /// </summary>
        private float volume = 100;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSourceBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public AudioSourceBuilder(Context context) => this.context = context;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio clip</returns>
        public AudioSource Build() => new AudioSource(context, nameFile, volume, isMute, playOnAwake, loop);

        /// <summary>
        ///     Files the path using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioSourceBuilder File(string value)
        {
            nameFile = value;
            return this;
        }

        /// <summary>
        ///     Mutes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioSourceBuilder Mute(bool value)
        {
            isMute = value;
            return this;
        }

        /// <summary>
        ///     Volumes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio clip builder</returns>
        public AudioSourceBuilder Volume(float value)
        {
            volume = value;
            return this;
        }

        /// <summary>
        ///     Plays the on awake using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder PlayOnAwake(bool value)
        {
            playOnAwake = value;
            return this;
        }

        /// <summary>
        ///     Loops the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder Loop(bool value)
        {
            loop = value;
            return this;
        }
    }
}