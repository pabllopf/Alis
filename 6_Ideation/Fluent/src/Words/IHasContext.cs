

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that provides access to a shared context object
    ///     during the entity construction pipeline.
    /// </summary>
    /// <typeparam name="T">The type of context object shared across the build pipeline.</typeparam>
    /// <remarks>
    ///     The context can carry shared state between different fluent builder stages
    ///     (e.g., a level editor reference, a shared resource manager, or a build accumulator).
    ///     This interface exposes the context as a mutable property for read/write access.
    /// </remarks>
    public interface IHasContext<T>
    {
        /// <summary>
        ///     Gets or sets the shared context value available during entity construction.
        /// </summary>
        /// <value>The context object. Can be read or modified by the builder pipeline.</value>
        T Context { get; set; }
    }
}