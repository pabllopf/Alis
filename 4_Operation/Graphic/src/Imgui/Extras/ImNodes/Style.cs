using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The style
    /// </summary>
    public unsafe struct Style
    {
        /// <summary>
        /// The grid spacing
        /// </summary>
        public float GridSpacing;
        /// <summary>
        /// The node corner rounding
        /// </summary>
        public float NodeCornerRounding;
        /// <summary>
        /// The node padding horizontal
        /// </summary>
        public float NodePaddingHorizontal;
        /// <summary>
        /// The node padding vertical
        /// </summary>
        public float NodePaddingVertical;
        /// <summary>
        /// The node border thickness
        /// </summary>
        public float NodeBorderThickness;
        /// <summary>
        /// The link thickness
        /// </summary>
        public float LinkThickness;
        /// <summary>
        /// The link line segments per length
        /// </summary>
        public float LinkLineSegmentsPerLength;
        /// <summary>
        /// The link hover distance
        /// </summary>
        public float LinkHoverDistance;
        /// <summary>
        /// The pin circle radius
        /// </summary>
        public float PinCircleRadius;
        /// <summary>
        /// The pin quad side length
        /// </summary>
        public float PinQuadSideLength;
        /// <summary>
        /// The pin triangle side length
        /// </summary>
        public float PinTriangleSideLength;
        /// <summary>
        /// The pin line thickness
        /// </summary>
        public float PinLineThickness;
        /// <summary>
        /// The pin hover radius
        /// </summary>
        public float PinHoverRadius;
        /// <summary>
        /// The pin offset
        /// </summary>
        public float PinOffset;
        /// <summary>
        /// The flags
        /// </summary>
        public StyleFlags Flags;
        /// <summary>
        /// The colors
        /// </summary>
        public fixed uint Colors[16];
    }
}
