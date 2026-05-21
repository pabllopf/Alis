

using Alis.Core.Ecs.Components.Audio;

namespace Alis.Builder.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio source config
    /// </summary>
    public delegate void AudioSourceConfig<T>(AudioSourceBuilder builder) where T : IAudioSource;
}