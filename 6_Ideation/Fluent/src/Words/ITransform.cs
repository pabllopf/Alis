

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures the local or world transform
    ///     (position, rotation, and scale) of a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The transform configuration type — typically a <see cref="Transform"/> struct or descriptor.</typeparam>
    /// <remarks>
    ///     This applies a complete transform. For individual properties,
    ///     use <see cref="IPosition2D"/>, <see cref="IRotation"/>, or <see cref="IScale2D"/>.
    /// </remarks>
    public interface ITransform<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures the transform on the builder.
        /// </summary>
        /// <param name="value">The transform descriptor containing position, rotation, and/or scale.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Transform(TArgument value);
    }
}