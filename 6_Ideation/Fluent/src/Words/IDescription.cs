

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the description on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IDescription<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the description on the builder.
        /// </summary>
        /// <param name="value">The description text to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Description(TArgument value);
    }
}