

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures update behavior on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IUpdate<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures update behavior on the builder.
        /// </summary>
        /// <param name="obj">The update configuration to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Update(TArgument obj);
    }
}