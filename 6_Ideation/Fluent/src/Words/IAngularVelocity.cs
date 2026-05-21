

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the angular velocity
    ///     (rotational speed) of a physics rigid body.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The angular velocity type, typically <see cref="float"/> (radians or degrees per second).</typeparam>
    /// <remarks>
    ///     Angular velocity causes the entity to spin. Positive values typically rotate
    ///     counter-clockwise. For instant rotation, use <see cref="IRotation"/> instead.
    ///     Related interfaces: <see cref="ILinearVelocity"/>.
    /// </remarks>
    public interface IAngularVelocity<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the angular velocity on the builder.
        /// </summary>
        /// <param name="value">The angular velocity — positive values rotate counter-clockwise.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AngularVelocity(TArgument value);
    }
}