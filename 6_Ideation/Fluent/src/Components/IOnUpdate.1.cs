

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook invoked each frame during the update loop, providing the
    ///     owning entity and 1 additional component reference of type <typeparamref name="TArg"/>.
    /// </summary>
    /// <typeparam name="TArg">The type of the additional component or data argument passed to the update method.</typeparam>
    /// <remarks>
    ///     Only implement one "Update" method per entity to avoid duplicate execution.
    ///     For zero-argument updates, use <see cref="IOnUpdate"/> directly.
    /// </remarks>
    public partial interface IOnUpdate<TArg> : IComponentBase
    {
        /// <summary>
        ///     Invokes the update logic with the owning entity and the additional component reference.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        /// <param name="arg">The additional component reference of type <typeparamref name="TArg"/>.</param>
        void Update(IGameObject self, ref TArg arg);
    }
}
