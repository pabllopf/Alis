

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the density property
    ///     of a physics collider or material.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The density value type, typically <see cref="float"/> (kg/m²).</typeparam>
    /// <remarks>
    ///     Density affects the mass calculation of a physics body. Higher density
    ///     results in greater mass for the same volume, influencing how the body
    ///     responds to forces and collisions. Used with <see cref="IBodyType"/>
    ///     and <see cref="IShape"/> to define physical properties.
    /// </remarks>
    public interface IDensity<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the density value on the builder.
        /// </summary>
        /// <param name="value">The density value in kg/m². Typical range: 0 (massless) to ~1000 (very dense).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Density(TArgument value);
    }
}