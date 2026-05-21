

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the rendering depth (z-order)
    ///     for a sprite, UI element, or scene layer.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The depth value type, typically <see cref="float"/> or <see cref="int"/>.</typeparam>
    /// <remarks>
    ///     Depth controls the draw order of entities. Higher depth values are drawn
    ///     on top of lower values. For UI, this maps to z-order sorting; for 2D scenes,
    ///     it determines sprite layering. Related interfaces: <see cref="IOrder"/>.
    /// </remarks>
    public interface IDepth<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the rendering depth (z-order) on the builder.
        /// </summary>
        /// <param name="value">The depth value. Higher values render on top of lower values.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Depth(TArgument value);
    }
}