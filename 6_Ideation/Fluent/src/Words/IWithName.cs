

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the name on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IWithName<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the name on the builder.
        /// </summary>
        /// <param name="value">The name to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder WithName(TArgument value);
    }
}