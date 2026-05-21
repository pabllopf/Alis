

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the color used for debug visualization
    ///     overlays such as bounding boxes, collision shapes, and gizmos.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The color type for debug visualization, typically <see cref="Color"/>.</typeparam>
    /// <remarks>
    ///     The debug color affects wireframe overlays, bounding box outlines, and other
    ///     diagnostic visual aids. This only takes effect when debug visualization is enabled
    ///     via <see cref="IDebug{out TBuilder, in TArgument}"/>.
    /// </remarks>
    public interface IDebugColor<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the color used for debug visualization overlays.
        /// </summary>
        /// <param name="value">The debug color value — typically a <see cref="Color"/> struct.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder DebugColor(TArgument value);
    }
}