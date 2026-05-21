

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Collision lifecycle hook called when the owning entity's collider
    ///     ceases contact with another entity's collider.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnCollisionExit"/> fires during the physics update pass when
    ///     collision detection determines two previously overlapping colliders are
    ///     no longer in contact. This signals the end of a collision interaction.
    ///     </para>
    ///     <para>
    ///     Use this for cleanup of collision-specific state — such as removing
    ///     contact damage cooldowns, stopping collision sounds, or resetting
    ///     physical responses that were initiated in <see cref="IOnCollisionEnter"/>.
    ///     </para>
    /// </remarks>
    public interface IOnCollisionExit
    {
        /// <summary>
        ///     Called when this entity's collider stops contacting another entity's collider.
        /// </summary>
        /// <param name="other">The entity that was previously collided with.</param>
        void OnCollisionExit(IGameObject other);
    }
}