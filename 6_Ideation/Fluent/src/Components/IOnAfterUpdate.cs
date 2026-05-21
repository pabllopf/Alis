

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per frame after the variable-timestep <see cref="IOnUpdate"/> loop completes.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     Use <see cref="IOnAfterUpdate"/> for logic that must execute after all update
    ///     calculations are complete — for example, synchronizing transform hierarchies,
    ///     applying accumulated forces, or resolving post-update constraints.
    ///     </para>
    ///     <para>
    ///     This hook also executes during deferred entity creation frames, allowing
    ///     newly created entities to receive their first post-update processing.
    ///     </para>
    /// </remarks>
    public interface IOnAfterUpdate
    {
        /// <summary>
        ///     Called every frame after <see cref="IOnUpdate.OnUpdate" /> hooks finish executing.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnAfterUpdate(IGameObject self);
    }
}