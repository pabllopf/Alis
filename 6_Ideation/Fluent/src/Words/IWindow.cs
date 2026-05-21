

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures window settings on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IWindow<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures window settings on the builder.
        /// </summary>
        /// <param name="value">The window configuration to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Window(TArgument value);
    }
}