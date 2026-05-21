

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Specifies the type of contact manifold generated during collision detection.
    /// </summary>
    public enum ManifoldType
    {
        /// <summary>
        ///     Circle-to-circle contact manifold. Both shapes are circles, producing a single contact point at the midpoint.
        /// </summary>
        Circles,

        /// <summary>
        ///     Face-to-face contact manifold where shape A's face is the reference face.
        /// </summary>
        /// <remarks>
        ///     The contact normal points from shape B toward shape A. Typically used when shape A has a larger face
        ///     or more vertices than the penetrating features of shape B.
        /// </remarks>
        FaceA,

        /// <summary>
        ///     Face-to-face contact manifold where shape B's face is the reference face.
        /// </summary>
        /// <remarks>
        ///     The contact normal points from shape A toward shape B. Typically used when shape B has a larger face
        ///     or more vertices than the penetrating features of shape A.
        /// </remarks>
        FaceB
    }
}