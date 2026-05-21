

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called at a fixed timestep, independent of frame rate.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnFixedUpdate"/> is designed for physics calculations and other
    ///     simulation that requires deterministic, consistent timing. It executes at a
    ///     fixed interval regardless of render frame rate.
    ///     </para>
    ///     <para>
    ///     On slow machines, <see cref="IOnFixedUpdate"/> may fire multiple times per frame
    ///     to catch up. On fast machines, it may fire less frequently than <see cref="IOnUpdate"/>.
    ///     This ensures stable physics simulation across different hardware.
    ///     </para>
    /// </remarks>
    public interface IOnFixedUpdate
    {
        /// <summary>
        ///     Called at each fixed timestep interval with a reference to the owning entity.
        ///     Executes less frequently than <see cref="IOnUpdate.OnUpdate" /> on low-frame machines
        ///     and more frequently on high-frame machines, ensuring consistent simulation speed.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnFixedUpdate(IGameObject self);
    }
}