using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PhysicsLogic
{
    /// <summary>
    /// The shape data
    /// </summary>
    internal struct ShapeData
    {
        /// <summary>
        /// The body
        /// </summary>
        public Body Body;
        /// <summary>
        /// The max
        /// </summary>
        public float Max;
        /// <summary>
        /// The min
        /// </summary>
        public float Min; // absolute angles
    }
}