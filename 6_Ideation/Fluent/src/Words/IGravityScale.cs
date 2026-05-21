

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets a per-entity gravity scale multiplier.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The gravity scale type, typically <see cref="float"/> (default = 1.0).</typeparam>
    /// <remarks>
    ///     Multiplies the global gravity for this entity. A scale of 0 makes the entity
    ///     immune to gravity; negative values reverse gravity direction. This is useful
    ///     for flying enemies, floating objects, or anti-gravity power-ups.
    ///     Related interfaces: <see cref="IGravity"/>.
    /// </remarks>
    public interface IGravityScale<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the gravity scale multiplier on the builder.
        /// </summary>
        /// <param name="value">The gravity scale factor. 1.0 = normal gravity, 0.0 = no gravity, &lt;0 = reversed gravity.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder GravityScale(TArgument value);
    }
}