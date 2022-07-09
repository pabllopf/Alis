using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// This structure is used to build a fixture with a circle shape.
    /// </summary>
    public class CircleDef : FixtureDef
    {
        /// <summary>
        /// The local position
        /// </summary>
        public Vec2 LocalPosition;
        /// <summary>
        /// The radius
        /// </summary>
        public float Radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleDef"/> class
        /// </summary>
        public CircleDef()
        {
            Type = ShapeType.CircleShape;
            LocalPosition = Vec2.Zero;
            Radius = 1.0f;
        }
    }
}