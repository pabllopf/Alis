using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// This structure is used to build a chain of edges.
    /// </summary>
    public class EdgeDef : FixtureDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDef"/> class
        /// </summary>
        public EdgeDef()
        {
            Type = ShapeType.EdgeShape;
        }

        /// <summary>
        /// The start vertex.
        /// </summary>
        public Vec2 Vertex1;

        /// <summary>
        /// The end vertex.
        /// </summary>
        public Vec2 Vertex2;
    }
}