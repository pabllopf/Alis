

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the restitution (bounciness) coefficient
    ///     of a physics collider.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The restitution value type, typically <see cref="float"/> (0 = no bounce, 1 = perfect bounce).</typeparam>
    /// <remarks>
    ///     Restitution determines how much kinetic energy is preserved during a collision.
    ///     A value of 0 means completely inelastic (no bounce), 1 means perfectly elastic
    ///     (full energy conservation). Values greater than 1 can create "explosive" bouncing
    ///     effects but may cause instability in the physics simulation.
    /// </remarks>
    public interface IRestitution<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the restitution coefficient on the builder.
        /// </summary>
        /// <param name="value">The restitution coefficient. Range: 0 (no bounce) to 1 (perfect bounce).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Restitution(TArgument value);
    }
}