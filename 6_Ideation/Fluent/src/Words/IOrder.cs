

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the order on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IOrder<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the order on the builder.
        /// </summary>
        /// <param name="value">The order value to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Order(TArgument value);
    }
}