

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that applies a spatial or logical filter
    ///     to constrain which entities are affected by subsequent operations.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The filter criteria — a predicate, region, tag, or query descriptor.</typeparam>
    /// <remarks>
    ///     Used to narrow down entity sets before applying actions. The filter semantics
    ///     depend on context: spatial bounds, component presence, tag matching, or
    ///     custom predicates.
    /// </remarks>
    public interface IWhere<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a filter condition on the builder.
        /// </summary>
        /// <param name="value">The filter criteria — predicate, region, tag, or query descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Where(TArgument value);
    }
}