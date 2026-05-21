

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Specifies which geometric features define the separation function in continuous collision detection.
    /// </summary>
    public enum SeparationFunctionType
    {
        /// <summary>
        ///     Both shapes contribute a single vertex (point-to-point separation).
        /// </summary>
        Points,

        /// <summary>
        ///     Shape A contributes a face and Shape B contributes a vertex (face A to point B).
        /// </summary>
        FaceA,

        /// <summary>
        ///     Shape B contributes a face and Shape A contributes a vertex (face B to point A).
        /// </summary>
        FaceB
    }
}