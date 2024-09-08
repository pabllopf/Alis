using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Reference face used for clipping
    /// </summary>
    public struct ReferenceFace
    {
        /// <summary>
        /// The 
        /// </summary>
        public int i1, i2;

        /// <summary>
        /// The 
        /// </summary>
        public Vector2 v1, v2;

        /// <summary>
        /// The normal
        /// </summary>
        public Vector2 normal;

        /// <summary>
        /// The side normal
        /// </summary>
        public Vector2 sideNormal1;
        /// <summary>
        /// The side offset
        /// </summary>
        public float sideOffset1;

        /// <summary>
        /// The side normal
        /// </summary>
        public Vector2 sideNormal2;
        /// <summary>
        /// The side offset
        /// </summary>
        public float sideOffset2;
    }
}