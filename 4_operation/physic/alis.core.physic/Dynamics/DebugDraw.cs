using System;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// Implement and register this class with a b2World to provide debug drawing of physics
    /// entities in your game.
    /// </summary>
    public abstract class DebugDraw
    {
        /// <summary>
        /// The draw flags enum
        /// </summary>
        [Flags]
        public enum DrawFlags
        {
            /// <summary>
            /// The shape draw flags
            /// </summary>
            Shape = 0x0001, // draw shapes
            /// <summary>
            /// The joint draw flags
            /// </summary>
            Joint = 0x0002, // draw joint connections
            /// <summary>
            /// The core shape draw flags
            /// </summary>
            CoreShape = 0x0004, // draw core (TOI) shapes       // should be removed in this revision?
            /// <summary>
            /// The aabb draw flags
            /// </summary>
            Aabb = 0x0008, // draw axis aligned bounding boxes
            /// <summary>
            /// The obb draw flags
            /// </summary>
            Obb = 0x0010, // draw oriented bounding boxes       // should be removed in this revision?
            /// <summary>
            /// The pair draw flags
            /// </summary>
            Pair = 0x0020, // draw broad-phase pairs
            /// <summary>
            /// The center of mass draw flags
            /// </summary>
            CenterOfMass = 0x0040, // draw center of mass frame
            /// <summary>
            /// The controller draw flags
            /// </summary>
            Controller = 0x0080 // draw center of mass frame
        };

        /// <summary>
        /// The draw flags
        /// </summary>
        protected DrawFlags _drawFlags;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugDraw"/> class
        /// </summary>
        public DebugDraw()
        {
            _drawFlags = 0;
        }

        /// <summary>
        /// Gets or sets the value of the flags
        /// </summary>
        public DrawFlags Flags { get { return _drawFlags; } set { _drawFlags = value; } }

        /// <summary>
        /// Append flags to the current flags.
        /// </summary>
        public void AppendFlags(DrawFlags flags)
        {
            _drawFlags |= flags;
        }

        /// <summary>
        /// Clear flags from the current flags.
        /// </summary>
        public void ClearFlags(DrawFlags flags)
        {
            _drawFlags &= ~flags;
        }

        /// <summary>
        /// Draw a closed polygon provided in CCW order.
        /// </summary>
        public abstract void DrawPolygon(Vec2[] vertices, int vertexCount, Color color);

        /// <summary>
        /// Draw a solid closed polygon provided in CCW order.
        /// </summary>
        public abstract void DrawSolidPolygon(Vec2[] vertices, int vertexCount, Color color);

        /// <summary>
        /// Draw a circle.
        /// </summary>
        public abstract void DrawCircle(Vec2 center, float radius, Color color);

        /// <summary>
        /// Draw a solid circle.
        /// </summary>
        public abstract void DrawSolidCircle(Vec2 center, float radius, Vec2 axis, Color color);

        /// <summary>
        /// Draw a line segment.
        /// </summary>
        public abstract void DrawSegment(Vec2 p1, Vec2 p2, Color color);

        /// <summary>
        /// Draw a transform. Choose your own length scale.
        /// </summary>
        /// <param name="xf">A transform.</param>
        public abstract void DrawXForm(XForm xf);
    }
}