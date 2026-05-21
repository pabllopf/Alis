

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that applies generic configuration settings
    ///     to the builder or its target entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The settings type — a configuration object, dictionary, or preset enum.</typeparam>
    /// <remarks>
    ///     A catch-all for builder-level configuration that doesn't fit a more specific interface.
    ///     May contain rendering quality, physics timestep, audio mixer, or other subsystem preferences.
    /// </remarks>
    public interface ISettings<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies configuration settings to the builder.
        /// </summary>
        /// <param name="value">The settings object or configuration to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Settings(TArgument value);
    }
}