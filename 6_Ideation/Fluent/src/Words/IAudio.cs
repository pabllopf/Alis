

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures audio source properties
    ///     and sound playback settings for a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The audio configuration type, typically containing clip references, volume, pitch, and spatial settings.</typeparam>
    /// <remarks>
    ///     Use this interface to attach audio clips, configure 2D/3D sound settings,
    ///     set looping behavior, or adjust volume and pitch for sound-emitting entities.
    ///     Related interfaces: <see cref="IMute{out TBuilder, in TArgument}"/>, <see cref="ISetAudioClip{out TBuilder, in TArgument}"/>.
    /// </remarks>
    public interface IAudio<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures audio settings on the builder.
        /// </summary>
        /// <param name="value">The audio configuration object containing clip references, volume, pitch, and playback settings.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Audio(TArgument value);
    }
}