

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per fixed-timestep interval before the <see cref="IOnFixedUpdate.OnFixedUpdate" /> loop.
    ///     Use this for preparing physics parameters or collecting input before fixed updates.
    /// </summary>
    public interface IOnBeforeFixedUpdate
    {
        /// <summary>
        ///     Called every fixed timestep before <see cref="IOnFixedUpdate.OnFixedUpdate" /> hooks execute.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnBeforeFixedUpdate(IGameObject self);
    }
}