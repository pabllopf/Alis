

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per fixed-timestep interval after the <see cref="IOnFixedUpdate.OnFixedUpdate"/> loop.
    ///     Use this for post-physics cleanup, interpolation, or finalizing state after fixed-step simulation.
    /// </summary>
    public interface IOnAfterFixedUpdate
    {
        /// <summary>
        ///     Called every fixed timestep after all <see cref="IOnFixedUpdate.OnFixedUpdate"/> hooks have executed.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnAfterFixedUpdate(IGameObject self);
    }
}