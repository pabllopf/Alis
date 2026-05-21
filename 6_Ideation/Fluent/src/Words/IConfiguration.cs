

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures general settings on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IConfiguration<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures general settings on the builder.
        /// </summary>
        /// <param name="value">The configuration to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Configuration(TArgument value);
    }
}