

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the movement speed
    ///     for a game entity or character controller.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The speed value type, typically <see cref="float"/> (units per second).</typeparam>
    /// <remarks>
    ///     Speed is used by character controllers, AI pathfinding, and custom movement systems.
    ///     For physics-based movement, <see cref="ILinearVelocity"/> or <see cref="IForce"/>
    ///     may be more appropriate.
    /// </remarks>
    public interface ISpeed<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the movement speed on the builder.
        /// </summary>
        /// <param name="value">The speed in units per second.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Speed(TArgument value);
    }
}