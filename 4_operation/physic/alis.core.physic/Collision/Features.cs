using System;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The features that intersect to form the contact point.
    /// </summary>
    public struct Features
    {
        /// <summary>
        /// The edge that defines the outward contact normal.
        /// </summary>
        public Byte ReferenceEdge;

        /// <summary>
        /// The edge most anti-parallel to the reference edge.
        /// </summary>
        public Byte IncidentEdge;

        /// <summary>
        /// The vertex (0 or 1) on the incident edge that was clipped.
        /// </summary>
        public Byte IncidentVertex;

        /// <summary>
        /// A value of 1 indicates that the reference edge is on shape2.
        /// </summary>
        public Byte Flip;
    }
}