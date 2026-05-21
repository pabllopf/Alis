

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that toggles or configures debug visualization
    ///     and diagnostic overlays for development builds.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The debug configuration type — a boolean toggle, debug flags enum, or debug settings object.</typeparam>
    /// <remarks>
    ///     Debug options may include bounding box visualization, collision wireframes,
    ///     FPS counters, or entity inspector panels. Debug features are typically
    ///     compiled out in release builds. Related interface: <see cref="IDebugColor"/>.
    /// </remarks>
    public interface IDebug<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures debug visualization settings on the builder.
        /// </summary>
        /// <param name="value">The debug configuration — enable/disable toggle, debug flags, or settings object.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Debug(TArgument value);
    }
}