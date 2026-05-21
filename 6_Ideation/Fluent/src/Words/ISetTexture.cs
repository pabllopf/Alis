

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that sets a texture on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface ISetTexture<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets a texture on the builder.
        /// </summary>
        /// <param name="value">The texture to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder SetTexture(TArgument value);
    }
}