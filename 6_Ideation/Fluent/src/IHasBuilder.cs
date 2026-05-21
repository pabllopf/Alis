

namespace Alis.Core.Aspect.Fluent
{
    /// <summary>
    ///     Provides access to a builder instance used to construct or configure an object of type
    ///     <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TOut">The type produced or configured by the builder.</typeparam>
    public interface IHasBuilder<out TOut>
    {
        /// <summary>
        ///     Returns the builder instance used to construct or configure a <typeparamref name="TOut"/>.
        /// </summary>
        /// <returns>The builder instance.</returns>
        TOut Builder();
    }
}