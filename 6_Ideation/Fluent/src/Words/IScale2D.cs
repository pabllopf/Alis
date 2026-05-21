

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the 2D scale (width and height)
    ///     of a game entity's transform or visual representation.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The scale component type, typically <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Sets the local scale along the X and Y axes. This affects rendering size
    ///     and physics collider dimensions. A scale of (1, 1) is the default (identity).
    ///     For 3D scaling, additional overloads or interfaces may be required.
    /// </remarks>
    public interface IScale2D<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the 2D non-uniform scale on the builder.
        /// </summary>
        /// <param name="x">The horizontal (X-axis) scale factor.</param>
        /// <param name="y">The vertical (Y-axis) scale factor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Scale(TArgument x, TArgument y);
    }
}