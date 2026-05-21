

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per frame before the variable-timestep <see cref="IOnUpdate"/> loop begins.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnBeforeUpdate"/> executes before any <see cref="IOnUpdate"/> hooks fire.
    ///     Use this for time-critical setup that must happen before all game logic — such as
    ///     processing input, updating global state machines, or preparing data for the update pass.
    ///     </para>
    ///     <para>
    ///     This hook is well-suited for frame-time accumulation (e.g., fixed timestep accumulators)
    ///     or batch preparation operations.
    ///     </para>
    /// </remarks>
    public interface IOnBeforeUpdate
    {
        /// <summary>
        ///     Called every frame before <see cref="IOnUpdate.OnUpdate" /> hooks execute.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnBeforeUpdate(IGameObject self);
    }
}