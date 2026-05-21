

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets static body state on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IIsStatic<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets static body state to <c>true</c> on the builder (no argument overload).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsStatic();
    }
}