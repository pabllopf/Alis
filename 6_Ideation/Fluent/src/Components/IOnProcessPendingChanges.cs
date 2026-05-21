

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called when the entity has accumulated pending state changes
    ///     that need to be processed in a batch.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnProcessPendingChanges"/> is invoked during the deferred operation
    ///     resolution phase, allowing entities to apply batched modifications, deferred
    ///     actions, or queued state transitions in a controlled manner.
    ///     </para>
    ///     <para>
    ///     This is especially useful for bulk updates that would be expensive if processed
    ///     one-by-one during the normal update loop.
    ///     </para>
    /// </remarks>
    public interface IOnProcessPendingChanges
    {
        /// <summary>
        ///     Called when the owning entity has pending state changes to process.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnProcessPendingChanges(IGameObject self);
    }
}