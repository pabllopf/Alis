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
        public float grid_spacing;
        /// <summary>
        /// The node corner rounding
        /// </summary>
        public float node_corner_rounding;
        /// <summary>
        /// The node padding horizontal
        /// </summary>
        public float node_padding_horizontal;
        /// <summary>
        /// The node padding vertical
        /// </summary>
        public float node_padding_vertical;
        /// <summary>
        /// The node border thickness
        /// </summary>
        public float node_border_thickness;
        /// <summary>
        /// The link thickness
        /// </summary>
        public float link_thickness;
        /// <summary>
        /// The link line segments per length
        /// </summary>
        public float link_line_segments_per_length;
        /// <summary>
        /// The link hover distance
        /// </summary>
        public float link_hover_distance;
        /// <summary>
        /// The pin circle radius
        /// </summary>
        public float pin_circle_radius;
        /// <summary>
        /// The pin quad side length
        /// </summary>
        public float pin_quad_side_length;
        /// <summary>
        /// The pin triangle side length
        /// </summary>
        public float pin_triangle_side_length;
        /// <summary>
        /// The pin line thickness
        /// </summary>
        public float pin_line_thickness;
        /// <summary>
        /// The pin hover radius
        /// </summary>
        public float pin_hover_radius;
        /// <summary>
        /// The pin offset
        /// </summary>
        public float pin_offset;
        /// <summary>
        /// The flags
        /// </summary>
        public StyleFlags flags;
        /// <summary>
        /// The colors
        /// </summary>
        public fixed uint colors[16];
    }
}
