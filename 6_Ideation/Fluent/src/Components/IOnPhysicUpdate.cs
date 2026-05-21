

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called during the dedicated physics update pass.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnPhysicUpdate"/> runs in the physics loop, separate from the standard
    ///     <see cref="IOnUpdate"/> and <see cref="IOnFixedUpdate"/> cycles. Use this for
    ///     collision detection callbacks, physics-based movement, raycasting, or any logic
    ///     that must execute within the physics simulation step.
    ///     </para>
    ///     <para>
    ///     This hook receives a reference to the owning <see cref="IGameObject"/> for
    ///     accessing sibling components or performing entity-level operations.
    ///     </para>
    /// </remarks>
    public interface IOnPhysicUpdate
    {
        /// <summary>
        ///     Called during the physics update pass with a reference to the owning entity.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnPhysicUpdate(IGameObject self);
    }
}