

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called every frame during the variable-timestep update loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnUpdate"/> is the primary per-frame logic hook. Components implementing
    ///     this interface receive the owning entity reference each frame for game logic execution.
    ///     </para>
    ///     <para>
    ///     Only implement one "Update" method across all update-related interfaces to avoid
    ///     duplicate logic. For physics-based updates at a fixed timestep, use
    ///     <see cref="IOnFixedUpdate"/> instead.
    ///     </para>
    /// </remarks>
    public partial interface IOnUpdate : IComponentBase
    {
        /// <summary>
        ///     Called every frame during the variable-timestep update loop with a reference to the owning entity.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnUpdate(IGameObject self);
    }
}