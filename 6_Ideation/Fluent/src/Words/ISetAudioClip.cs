

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that assigns a specific audio clip
    ///     to a sound source component.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The audio clip reference — typically a loaded <see cref="AudioClip"/> or resource key.</typeparam>
    /// <remarks>
    ///     This selects which audio asset plays when triggered. Combined with
    ///     <see cref="IAudio"/> for volume/pitch control and <see cref="IPlayOnAwake"/>
    ///     for auto-play behavior.
    /// </remarks>
    public interface ISetAudioClip<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Assigns the audio clip to the builder's audio source.
        /// </summary>
        /// <param name="value">The audio clip reference or resource key to assign.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder SetAudioClip(TArgument value);
    }
}