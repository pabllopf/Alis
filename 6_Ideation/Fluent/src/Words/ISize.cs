

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the size on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface ISize<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the size on the builder.
        /// </summary>
        /// <param name="x">The X-coordinate or first component value.</param>
        /// <param name="y">The Y-coordinate or second component value.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Size(TArgument x, TArgument y);
    }
}