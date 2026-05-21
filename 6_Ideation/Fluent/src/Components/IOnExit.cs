

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called when the owning entity is deactivated or leaves the active game loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnExit"/> fires when an entity transitions from active to inactive state,
    ///     but before <see cref="IOnDestroy"/> is called. The entity is still logically present
    ///     in the scene but no longer receives update, draw, or physics callbacks.
    ///     </para>
    ///     <para>
    ///     Use this for cleanup that should happen on deactivation but not permanent destruction —
    ///     such as unsubscribing from active-only events, pausing animations, or saving transient state.
    ///     </para>
    /// </remarks>
    public interface IOnExit
    {
        /// <summary>
        ///     Called when the owning entity is deactivated or removed from the active update loop.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnExit(IGameObject self);
    }
}