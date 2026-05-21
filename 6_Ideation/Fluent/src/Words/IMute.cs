

namespace Alis.Core.Aspect.Fluent.Words
{
/// <summary>
    ///     Fluent builder interface that toggles the mute state for audio
    ///     output on a game entity or the global audio system.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The mute state — typically <see langword="true"/> (muted) or <see langword="false"/> (unmuted).</typeparam>
    /// <remarks>
    ///     Muting silences all audio from the entity or globally. This affects
    ///     music, sound effects, and ambient audio. Related interfaces:
    ///     <see cref="IAudio"/>.
    /// </remarks>
    public interface IMute<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the mute state on the builder.
        /// </summary>
        /// <param name="value"><see langword="true"/> to mute, <see langword="false"/> to unmute.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Mute(TArgument value);
    }
}