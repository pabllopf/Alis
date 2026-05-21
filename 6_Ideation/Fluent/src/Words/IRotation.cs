

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the absolute rotation angle
    ///     of a game entity's transform.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The rotation angle type, typically <see cref="float"/> in degrees.</typeparam>
    /// <remarks>
    ///     Sets the entity's world-space rotation. For incremental rotation,
    ///     apply the delta to the current rotation value. Related interfaces:
    ///     <see cref="IFixedRotation"/>.
    /// </remarks>
    public interface IRotation<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the rotation angle on the builder.
        /// </summary>
        /// <param name="angle">The absolute rotation angle in degrees (0–360).</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Rotation(TArgument angle);
    }
}