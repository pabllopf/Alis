

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures the splash screen
    ///     displayed during application startup.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The splash screen configuration — typically a logo texture, animation, or display duration.</typeparam>
    /// <remarks>
    ///     The splash screen is the first visual element presented to users.
    ///     It may include a company logo, loading progress bar, or animated intro.
    ///     Related interfaces: <see cref="IBackgroundColor"/>, <see cref="ILoadingScreen"/>.
    /// </remarks>
    public interface ISplashScreen<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures the splash screen using the specified value.
        /// </summary>
        /// <param name="value">The splash screen configuration — logo texture, animation descriptor, or display settings.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder SplashScreen(TArgument value);
    }
}