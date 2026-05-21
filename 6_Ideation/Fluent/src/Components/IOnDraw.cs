

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called every frame during the rendering pass.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     Components implementing <see cref="IOnDraw"/> are responsible for drawing their
    ///     visual representation. This fires after all <see cref="IOnBeforeDraw"/> hooks
    ///     and before <see cref="IOnAfterDraw"/> hooks, within the render pipeline.
    ///     </para>
    ///     <para>
    ///     Drawing commands issued here should be limited to the owning entity's own visual.
    ///     For batch rendering or sprite sorting, consider using a system-based approach instead.
    ///     </para>
    /// </remarks>
    public interface IOnDraw
    {
        /// <summary>
        ///     Called every frame during the rendering pass with a reference to the owning entity.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnDraw(IGameObject self);
    }
}