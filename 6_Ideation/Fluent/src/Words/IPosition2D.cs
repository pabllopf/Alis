

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the 2D position (X, Y coordinates)
    ///     of a game entity in world or local space.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The coordinate component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Sets the entity's position in the 2D plane. For world-space positioning,
    ///     coordinates are relative to the scene origin. For pixel-based games,
    ///     values are typically in pixel units.
    /// </remarks>
    public interface IPosition2D<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the 2D world-space position of the entity.
        /// </summary>
        /// <param name="x">The X-coordinate (horizontal position).</param>
        /// <param name="y">The Y-coordinate (vertical position).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Position(TArgument x, TArgument y);
    }
}