

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the gravity vector applied
    ///     to physics bodies in the game world or a specific scene.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The gravity magnitude type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Gravity is a global physics setting that affects all dynamic bodies.
    ///     Common values: Earth-like gravity ≈ 9.81, zero-gravity = 0, platformer ≈ 15–30.
    ///     For per-entity gravity, use <see cref="IGravityScale"/> instead.
    /// </remarks>
    public interface IGravity<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the global gravity magnitude.
        /// </summary>
        /// <param name="x">The horizontal gravity component (typically 0 for standard platformers).</param>
        /// <param name="y">The vertical gravity component (negative values pull downward).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Gravity(TArgument x, TArgument y);
    }
}