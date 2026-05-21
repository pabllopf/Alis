

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called during initial component construction, before <see cref="IOnAwake.OnAwake" />.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnInit"/> is the earliest lifecycle point — it fires during entity creation,
    ///     before the entity enters the active game loop. Use this for allocating resources,
    ///     initializing internal state, or establishing references that other components may not
    ///     yet have.
    ///     </para>
    ///     <para>
    ///     To ensure proper ordering, implement <see cref="IOnInit"/> rather than putting
    ///     initialization logic in constructors, which may run before the entity is fully
    ///     registered in the scene.
    ///     </para>
    /// </remarks>
    /// <seealso cref="IComponentBase"/>
    public interface IOnInit : IComponentBase
    {
        /// <summary>
        ///     Called once during initial component setup, before <see cref="IOnAwake.OnAwake" />.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnInit(IGameObject self);
    }
}