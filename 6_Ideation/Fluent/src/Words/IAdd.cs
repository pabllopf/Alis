

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that appends or adds an element to a collection
    ///     or composite property on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type being added to the builder's target collection or property.</typeparam>
    /// <remarks>
    ///     Commonly used to add components, children, or configuration entries to a game entity or system.
    ///     The exact semantics depend on the builder implementation.
    /// </remarks>
    public interface IAdd<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Adds the specified value to the builder's target collection or property.
        /// </summary>
        /// <param name="value">The value to append or add. Must not be null unless the argument type is nullable.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Add(TArgument value);
    }
}