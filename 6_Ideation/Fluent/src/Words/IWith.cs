

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that applies a general-purpose configuration or value
    ///     to the target builder using a context-dependent semantic.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The configuration or value type accepted by the builder.</typeparam>
    /// <remarks>
    ///     This is an extensible catch-all interface — the exact meaning of "with" depends on
    ///     the builder implementation. It can be used for dependency injection, state passing,
    ///     or any custom configuration that doesn't fit a more specific interface.
    /// </remarks>
    public interface IWith<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a context-dependent configuration or value to the builder.
        /// </summary>
        /// <param name="value">The configuration or value to apply. Semantics depend on the builder type.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder With(TArgument value);
    }
}