

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets a property on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface ISet<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets a property on the builder.
        /// </summary>
        /// <typeparam name="T">The specific type parameter for this operation.</typeparam>
        /// <param name="value">The value to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Set<T>(TArgument value);
    }
}