

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per frame before the rendering <see cref="IOnDraw"/> pass begins.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnBeforeDraw"/> is the ideal place for preparing transform matrices,
    ///     performing visibility culling, sorting draw calls, or setting up rendering state
    ///     before any draw hooks execute.
    ///     </para>
    ///     <para>
    ///     This hook fires after <see cref="IOnAfterUpdate"/> but before <see cref="IOnDraw"/>,
    ///     giving it a window to influence how the frame is rendered without being part
    ///     of the actual drawing commands.
    ///     </para>
    /// </remarks>
    public interface IOnBeforeDraw
    {
        /// <summary>
        ///     Called every frame before <see cref="IOnDraw.OnDraw" /> hooks execute.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnBeforeDraw(IGameObject self);
    }
}