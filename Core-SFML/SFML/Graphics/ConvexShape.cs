using System;
using SFML.System;

namespace SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Specialized shape representing a convex polygon
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class ConvexShape : Shape
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ConvexShape() : this(0) { }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the shape with an initial point count
        /// </summary>
        /// <param name="pointCount">Number of points of the shape</param>
        ////////////////////////////////////////////////////////////
        public ConvexShape(uint pointCount)
        {
            SetPointCount(pointCount);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the shape from another shape
        /// </summary>
        /// <param name="copy">Shape to copy</param>
        ////////////////////////////////////////////////////////////
        public ConvexShape(ConvexShape copy) : base(copy)
        {
            SetPointCount(copy.GetPointCount());
            for (uint i = 0; i < copy.GetPointCount(); ++i)
            {
                SetPoint(i, copy.GetPoint(i));
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the total number of points of the polygon
        /// </summary>
        /// <returns>The total point count</returns>
        ////////////////////////////////////////////////////////////
        public override uint GetPointCount() => (uint)myPoints.Length;

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Set the number of points of the polygon.
        /// The count must be greater than 2 to define a valid shape.
        /// </summary>
        /// <param name="count">New number of points of the polygon</param>
        ////////////////////////////////////////////////////////////
        public void SetPointCount(uint count)
        {
            Array.Resize(ref myPoints, (int)count);
            Update();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the position of a point
        ///
        /// The returned point is in local coordinates, that is,
        /// the shape's transforms (position, rotation, scale) are
        /// not taken into account.
        /// The result is undefined if index is out of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to get, in range [0 .. PointCount - 1]</param>
        /// <returns>index-th point of the shape</returns>
        ////////////////////////////////////////////////////////////
        public override Vector2f GetPoint(uint index) => myPoints[index];

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Set the position of a point.
        ///
        /// Don't forget that the polygon must remain convex, and
        /// the points need to stay ordered!
        /// PointCount must be set first in order to set the total
        /// number of points. The result is undefined if index is out
        /// of the valid range.
        /// </summary>
        /// <param name="index">Index of the point to change, in range [0 .. PointCount - 1]</param>
        /// <param name="point">New position of the point</param>
        ////////////////////////////////////////////////////////////
        public void SetPoint(uint index, Vector2f point)
        {
            myPoints[index] = point;
            Update();
        }

        private Vector2f[] myPoints;
    }
}
