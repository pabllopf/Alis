

namespace Alis.Core.Aspect.Fluent.Words
{
/// <summary>
    ///     Fluent builder interface that configures the display mode
    ///     for the game window.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The screen mode type, typically a <see cref="ScreenMode"/> enum value.</typeparam>
    /// <remarks>
    ///     Screen modes include: <c>Windowed</c>, <c>Fullscreen</c>, <c>BorderlessWindowed</c>.
    ///     Changing the screen mode may affect resolution, monitor selection, and
    ///     input capture behavior.
    /// </remarks>
    public interface IScreenMode<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures the display mode on the builder.
        /// </summary>
        /// <param name="value">The desired screen mode — windowed, fullscreen, or borderless.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder ScreenMode(TArgument value);
    }
}