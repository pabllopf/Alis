using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The simplex vertex
    /// </summary>
    internal struct SimplexVertex
    {
        /// <summary>
        /// The 
        /// </summary>
        internal Vec2 Wa;		// support point in shapeA
        /// <summary>
        /// The 
        /// </summary>
        internal Vec2 Wb;		// support point in shapeB
        /// <summary>
        /// The 
        /// </summary>
        internal Vec2 W;		// wB - wA
        /// <summary>
        /// The 
        /// </summary>
        internal float A;		// barycentric coordinate for closest point
        /// <summary>
        /// The index
        /// </summary>
        internal int IndexA;	// wA index
        /// <summary>
        /// The index
        /// </summary>
        internal int IndexB;	// wB index
    }
}