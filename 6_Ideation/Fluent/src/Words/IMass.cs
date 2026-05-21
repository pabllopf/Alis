

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the mass of a physics rigid body.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The mass value type, typically <see cref="float"/> (in kilograms).</typeparam>
    /// <remarks>
    ///     Mass determines how much a body resists acceleration from forces.
    ///     Zero mass means the body is static (immovable). Infinite mass means
    ///     the body is not affected by collisions. Combined with <see cref="IDensity"/>,
    ///     the physics system may auto-calculate mass from volume and material density.
    /// </remarks>
    public interface IMass<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the mass on the builder.
        /// </summary>
        /// <param name="value">The mass in kilograms. Use 0 for static/immovable bodies.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Mass(TArgument value);
    }
}