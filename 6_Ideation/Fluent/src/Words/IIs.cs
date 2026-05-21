

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets a boolean flag on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IIs<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets a boolean flag on the builder.
        /// </summary>
        /// <typeparam name="T">The specific type parameter for this operation.</typeparam>
        /// <param name="value">The is value to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Is<T>(TArgument value);
    }
}