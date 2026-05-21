

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that offsets the entity's position
    ///     by a relative delta from its current location.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The offset component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Unlike <see cref="IPosition2D"/>, which sets an absolute position,
    ///     this adds a delta to the current position. Useful for knockback,
    ///     projectile spawning offsets, or gradual movement.
    /// </remarks>
    public interface IRelativePosition<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a relative position offset to the entity.
        /// </summary>
        /// <param name="x">The horizontal offset to add to the current X position.</param>
        /// <param name="y">The vertical offset to add to the current Y position.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder RelativePosition(TArgument x, TArgument y);
    }
}