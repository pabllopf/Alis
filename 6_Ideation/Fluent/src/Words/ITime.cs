

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets the time on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface ITime<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the time on the builder.
        /// </summary>
        /// <param name="value">The time value to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Time(TArgument value);
    }
}