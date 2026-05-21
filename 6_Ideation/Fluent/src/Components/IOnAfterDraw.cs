

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per frame after the rendering <see cref="IOnDraw"/> pass completes.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     Use <see cref="IOnAfterDraw"/> for post-render cleanup, overlay drawing,
    ///     or UI elements that must appear on top of the scene. This hook fires after
    ///     all <see cref="IOnDraw"/> implementations have completed.
    ///     </para>
    ///     <para>
    ///     Drawing commands issued here are typically rendered on top of the scene's
    ///     main visual layer.
    ///     </para>
    /// </remarks>
    public interface IOnAfterDraw
    {
        /// <summary>
        ///     Called every frame after <see cref="IOnDraw.OnDraw" /> hooks finish executing.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnAfterDraw(IGameObject self);
    }
}