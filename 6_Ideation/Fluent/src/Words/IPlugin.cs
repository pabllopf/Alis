

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that registers or configures a plugin
    ///     or extension module on the game engine or a specific subsystem.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The plugin configuration, type, or initialization parameters.</typeparam>
    /// <remarks>
    ///     Plugins extend engine functionality — such as custom physics solvers,
    ///     procedural generation modules, analytics hooks, or third-party SDK integrations.
    ///     The plugin is typically initialized when the builder's <see cref="IBuild{TOrigin}.Build()"/> is called.
    /// </remarks>
    public interface IPlugin<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Registers or configures a plugin on the builder.
        /// </summary>
        /// <param name="value">The plugin configuration, instance, or initialization parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Plugin(TArgument value);
    }
}