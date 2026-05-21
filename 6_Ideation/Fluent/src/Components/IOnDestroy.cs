

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called when the owning entity is destroyed and removed from the game loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnDestroy"/> is the last lifecycle event an entity receives.
    ///     Use this to release resources, unsubscribe from events, save state,
    ///     or perform cleanup that prevents memory leaks.
    ///     </para>
    ///     <para>
    ///     Destruction is deferred until after the current update cycle completes
    ///     to avoid structural changes during iteration.
    ///     </para>
    /// </remarks>
    public interface IOnDestroy : IComponentBase
    {
        /// <summary>
        ///     Called when the owning entity is destroyed and removed from the game loop.
        /// </summary>
        void OnDestroy();
    }
}