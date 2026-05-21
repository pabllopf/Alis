

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures whether an audio clip,
    ///     animation, or system starts playing automatically when activated.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The play-on-awake setting — typically <see langword="true"/> or <see langword="false"/>.</typeparam>
    /// <remarks>
    ///     Commonly used for audio sources (music, ambient sounds) and animations
    ///     that should begin without an explicit <c>Play()</c> call. When <c>false</c>,
    ///     the asset remains paused until manually triggered.
    /// </remarks>
    public interface IPlayOnAwake<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets whether the asset should begin playing automatically when activated.
        /// </summary>
        /// <param name="value"><see langword="true"/> to play immediately on activation; <see langword="false"/> to remain paused.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder PlayOnAwake(TArgument value);
    }
}