

namespace Alis.Core.Aspect.Fluent.Words
{
/// <summary>
    ///     Fluent builder interface that marks a game entity or component for deletion.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The identifier or reference of the entity/component to delete.</typeparam>
    /// <remarks>
    ///     Deletion is typically deferred to the end of the current update cycle to
    ///     maintain structural consistency. The actual removal is handled by the
    ///     <see cref="Scene"/> during its deferred operation resolution phase.
    /// </remarks>
    public interface IDelete<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Deletes the specified entity or component from the scene.
        /// </summary>
        /// <param name="obj">The entity or component reference to mark for deletion.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Delete(TArgument obj);
    }
}