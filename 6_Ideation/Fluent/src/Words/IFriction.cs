

namespace Alis.Core.Aspect.Fluent.Words
{
/// <summary>
    ///     Fluent builder interface that sets the friction coefficient
    ///     of a physics collider or material.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The friction value type, typically <see cref="float"/> (0 = frictionless, 1 = high friction).</typeparam>
    /// <remarks>
    ///     Friction affects how sliding bodies decelerate when in contact with surfaces.
    ///     Combined with <see cref="IRestitution"/>, it defines the physical material
    ///     properties of colliders.
    /// </remarks>
    public interface IFriction<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the friction coefficient on the builder.
        /// </summary>
        /// <param name="value">The friction coefficient. 0 = no friction (ice), 1 = high friction (rough surface).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Friction(TArgument value);
    }
}