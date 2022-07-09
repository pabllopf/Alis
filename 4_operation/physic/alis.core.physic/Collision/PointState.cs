namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// This is used for determining the state of contact points.
    /// </summary>
    public enum PointState
    {
        /// <summary>
        /// Point does not exist.
        /// </summary>
        NullState,
        /// <summary>
        /// Point was added in the update.
        /// </summary>
        AddState,
        /// <summary>
        /// Point persisted across the update.
        /// </summary>
        PersistState,
        /// <summary>
        ///Point was removed in the update.
        /// </summary>
        RemoveState
    }
}