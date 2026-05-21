

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once when the entity is first activated and enters the main game loop.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnStart"/> fires after <see cref="IOnAwake.OnAwake" /> and <see cref="IOnInit.OnInit" />,
    ///     and before any <see cref="IOnUpdate.OnUpdate" /> calls. It is the ideal place for one-time
    ///     initialization that depends on other systems being ready (e.g., registering with managers,
    ///     acquiring references, or starting coroutines).
    ///     </para>
    ///     <para>
    ///     Unlike <see cref="IOnInit"/>, <see cref="IOnStart"/> is called only when the entity
    ///     transitions from inactive to active state, not during initial scene population.
    ///     </para>
    /// </remarks>
    public interface IOnStart
    {
        /// <summary>
        ///     Called once when the owning entity becomes active and enters the main update loop.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnStart(IGameObject self);
    }
}