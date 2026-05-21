

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that selects or configures an operational profile
    ///     for the game or a subsystem.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The profile type — typically an enum, string key, or profile descriptor object.</typeparam>
    /// <remarks>
    ///     Profiles bundle multiple settings into a named configuration. Examples:
    ///     "HighPerformance" (high FPS, reduced effects), "Cinematic" (high quality, lower FPS),
    ///     "Mobile" (touch input, reduced resolution). This may affect rendering quality,
    ///     physics accuracy, and input mappings simultaneously.
    /// </remarks>
    public interface IProfile<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies the selected profile to the builder.
        /// </summary>
        /// <param name="value">The profile identifier or configuration object.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Profile(TArgument value);
    }
}