

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets a maximum limit or cap on a
    ///     builder property such as entity count, resource pool size, or buffer capacity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The maximum value type — typically <see cref="int"/> or <see cref="float"/>.</typeparam>
    /// <remarks>
    ///     Prevents a value from exceeding a specified upper bound. Useful for configuring
    ///     pool sizes, batch limits, or throttling thresholds.
    /// </remarks>
    public interface ISetMax<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the upper bound on a builder property.
        /// </summary>
        /// <typeparam name="T">The specific type of value being capped.</typeparam>
        /// <param name="value">The maximum allowed value.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder SetMax<T>(TArgument value);
    }
}