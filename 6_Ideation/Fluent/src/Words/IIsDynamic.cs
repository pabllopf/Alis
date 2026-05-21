

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that toggles whether a physics body
    ///     responds to forces, collisions, and simulation.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The dynamic state — use <see langword="true"/> for dynamic, <see langword="false"/> for kinematic.</typeparam>
    /// <remarks>
    ///     A dynamic body participates fully in physics simulation (gravity, forces, collisions).
    ///     A kinematic body can be moved programmatically but is not affected by forces.
    ///     This is a convenience method equivalent to setting <see cref="IBodyType"/> to
    ///     dynamic or kinematic.
    /// </remarks>
    public interface IIsDynamic<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets whether the physics body is dynamic (affected by simulation).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        /// <remarks>
        ///     Calling this method with <see langword="true"/> is equivalent to setting
        ///     <see cref="IBodyType{out TBuilder, in TArgument}"/> to <c>Dynamic</c>.
        /// </remarks>
        TBuilder IsDynamic();
    }
}