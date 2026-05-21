

namespace Alis.Core.Aspect.Fluent
{
    /// <summary>
    ///     Defines a builder terminal operation that constructs and returns the final object of type
    ///     <typeparamref name="TOrigin"/>.
    /// </summary>
    /// <typeparam name="TOrigin">The type of the object produced by the build operation.</typeparam>
    public interface IBuild<TOrigin>
    {
        /// <summary>
        ///     Constructs and returns the final <typeparamref name="TOrigin"/> instance.
        /// </summary>
        /// <returns>The fully constructed <typeparamref name="TOrigin"/> instance.</returns>
        TOrigin Build();
    }
}