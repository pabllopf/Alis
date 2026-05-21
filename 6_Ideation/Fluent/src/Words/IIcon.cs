

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets an icon or thumbnail image
    ///     for a game entity, editor node, or UI element.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The icon representation — typically a texture reference, sprite, or image path.</typeparam>
    /// <remarks>
    ///     Icons are used primarily in editor UIs, scene hierarchy panels,
    ///     or minimap elements. Does not affect in-game rendering of the entity.
    /// </remarks>
    public interface IIcon<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the icon image on the builder.
        /// </summary>
        /// <param name="value">The icon — a texture, sprite, or path to an image asset.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Icon(TArgument value);
    }
}