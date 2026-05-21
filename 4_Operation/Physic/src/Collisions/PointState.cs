

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Indicates the state of a contact point across simulation updates.
    /// </summary>
    /// <remarks>
    ///     Used by the collision detection system to track contact point lifecycle:
    ///     which points are new, which persist, and which have been removed between frames.
    /// </remarks>
    public enum PointState
    {
        /// <summary>
        ///     The contact point does not exist (null/invalid).
        /// </summary>
        Null,

        /// <summary>
        ///     The contact point was newly added in this update.
        /// </summary>
        Add,

        /// <summary>
        ///     The contact point persisted from the previous update.
        /// </summary>
        Persist,

        /// <summary>
        ///     The contact point was removed in this update.
        /// </summary>
        Remove
    }
}