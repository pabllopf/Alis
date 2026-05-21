

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets trigger collider state on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IIsTrigger<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets trigger collider state to <c>true</c> on the builder (no argument overload).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsTrigger();
    }
}