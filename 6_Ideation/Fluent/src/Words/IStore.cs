

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that stores a value on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IStore<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Stores a value on the builder.
        /// </summary>
        /// <param name="value">The value to store.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Store(TArgument value);
    }
}