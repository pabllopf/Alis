

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Collision lifecycle hook called when the owning entity's collider first
    ///     makes contact with another entity's collider.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnCollisionEnter"/> fires during the physics update pass when
    ///     collision detection determines two colliders are overlapping for the first time.
    ///     For continuous collision response, use <see cref="IOnCollisionExit"/> for separation.
    ///     </para>
    ///     <para>
    ///     The <paramref name="other"/> parameter provides access to the colliding entity,
    ///     allowing inspection of its components or triggering reactions like damage, bouncing,
    ///     or sound effects.
    ///     </para>
    /// </remarks>
    public interface IOnCollisionEnter
    {
        /// <summary>
        ///     Called when this entity's collider first contacts another entity's collider.
        /// </summary>
        /// <param name="other">The entity that was collided with.</param>
        void OnCollisionEnter(IGameObject other);
    }
}