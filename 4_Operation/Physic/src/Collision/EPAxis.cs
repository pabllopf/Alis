namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     This structure is used to keep track of the best separating axis.
    /// </summary>
    public struct EPAxis
    {
        /// <summary>
        /// The index
        /// </summary>
        public int Index;
        /// <summary>
        /// The separation
        /// </summary>
        public float Separation;
        /// <summary>
        /// The type
        /// </summary>
        public EPAxisType Type;
    }
}