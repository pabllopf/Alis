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
        internal Vec2 wA;		// support point in shapeA
        /// <summary>
        /// The 
        /// </summary>
        internal Vec2 wB;		// support point in shapeB
        /// <summary>
        /// The 
        /// </summary>
        internal Vec2 w;		// wB - wA
        /// <summary>
        /// The 
        /// </summary>
        internal float a;		// barycentric coordinate for closest point
        /// <summary>
        /// The index
        /// </summary>
        internal int indexA;	// wA index
        /// <summary>
        /// The index
        /// </summary>
        internal int indexB;	// wB index
    }
}