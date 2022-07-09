namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// This holds contact filtering data.
    /// </summary>
    public struct FilterData
    {
        /// <summary>
        /// The collision category bits. Normally you would just set one bit.
        /// </summary>
        public ushort CategoryBits;

        /// <summary>
        /// The collision mask bits. This states the categories that this
        /// shape would accept for collision.
        /// </summary>
        public ushort MaskBits;

        /// <summary>
        /// Collision groups allow a certain group of objects to never collide (negative)
        /// or always collide (positive). Zero means no collision group. Non-zero group
        /// filtering always wins against the mask bits.
        /// </summary>
        public short GroupIndex;
    }
}