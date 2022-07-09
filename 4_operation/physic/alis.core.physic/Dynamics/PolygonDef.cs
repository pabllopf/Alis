using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// Convex polygon. The vertices must be ordered so that the outside of
    /// the polygon is on the right side of the edges (looking along the edge
    /// from start to end).
    /// </summary>
    public class PolygonDef : FixtureDef
    {
        /// <summary>
        /// The number of polygon vertices.
        /// </summary>
        public int VertexCount;

        /// <summary>
        /// The polygon vertices in local coordinates.
        /// </summary>
        public Vec2[] Vertices = new Vec2[Settings.MaxPolygonVertices];

        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonDef"/> class
        /// </summary>
        public PolygonDef()
        {
            Type = ShapeType.PolygonShape;
            VertexCount = 0;
        }

        /// <summary>
        /// Build vertices to represent an axis-aligned box.
        /// </summary>
        /// <param name="hx">The half-width</param>
        /// <param name="hy">The half-height.</param>
        public void SetAsBox(float hx, float hy)
        {
            VertexCount = 4;
            Vertices[0].Set(-hx, -hy);
            Vertices[1].Set(hx, -hy);
            Vertices[2].Set(hx, hy);
            Vertices[3].Set(-hx, hy);
        }


        /// <summary>
        /// Build vertices to represent an oriented box.
        /// </summary>
        /// <param name="hx">The half-width</param>
        /// <param name="hy">The half-height.</param>
        /// <param name="center">The center of the box in local coordinates.</param>
        /// <param name="angle">The rotation of the box in local coordinates.</param>
        public void SetAsBox(float hx, float hy, Vec2 center, float angle)
        {
            SetAsBox(hx, hy);

            XForm xf = new XForm();
            xf.Position = center;
            xf.R.Set(angle);

            for (int i = 0; i < VertexCount; ++i)
            {
                Vertices[i] = Common.Math.Mul(xf, Vertices[i]);
            }
        }
    }
}