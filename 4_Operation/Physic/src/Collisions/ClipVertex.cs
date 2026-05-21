

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents a vertex used in contact manifold computation during polygon clipping operations.
    /// </summary>
    /// <remarks>
    ///     ClipVertex pairs a geometric position with a contact identifier, enabling the collision
    ///     system to track which original features resulted in each clipped contact point during
    ///     the collision detection pipeline.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ClipVertex
    {
        /// <summary>
        ///     Gets or sets the contact identifier for this vertex.
        /// </summary>
        /// <value>The <see cref="ContactId"/> identifying the geometric features that created this contact point.</value>
        public ContactId Id;

        /// <summary>
        ///     Gets or sets the position of this clipped vertex in world coordinates.
        /// </summary>
        /// <value>A 2D vector representing the vertex position.</value>
        public Vector2F V;
    }
}