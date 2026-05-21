

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the solid background color
    ///     for a scene, camera, or UI element.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The color type, typically <see cref="Color"/> or a platform-specific color representation.</typeparam>
    /// <remarks>
    ///     This sets a flat background color. For textured or gradient backgrounds,
    ///     use <see cref="IBackground{out TBuilder, in TArgument}"/> instead.
    /// </remarks>
    public interface IBackgroundColor<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the solid background color on the builder.
        /// </summary>
        /// <param name="value">The background color value to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder BackgroundColor(TArgument value);
    }
}