using System;
using Alis.Core.Graphic.ImGui.Structs;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.ImGui.Extras.ImNodes
{
    /// <summary>
    /// The style
    /// </summary>
    public unsafe partial struct Style
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
    /// <summary>
    /// The style ptr
    /// </summary>
    public unsafe partial struct StylePtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public Style* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StylePtr(Style* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="StylePtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public StylePtr(IntPtr nativePtr) => NativePtr = (Style*)nativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StylePtr(Style* nativePtr) => new StylePtr(nativePtr);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator Style* (StylePtr wrappedPtr) => wrappedPtr.NativePtr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator StylePtr(IntPtr nativePtr) => new StylePtr(nativePtr);
        /// <summary>
        /// Gets the value of the grid spacing
        /// </summary>
        public ref float grid_spacing => ref Unsafe.AsRef<float>(&NativePtr->grid_spacing);
        /// <summary>
        /// Gets the value of the node corner rounding
        /// </summary>
        public ref float node_corner_rounding => ref Unsafe.AsRef<float>(&NativePtr->node_corner_rounding);
        /// <summary>
        /// Gets the value of the node padding horizontal
        /// </summary>
        public ref float node_padding_horizontal => ref Unsafe.AsRef<float>(&NativePtr->node_padding_horizontal);
        /// <summary>
        /// Gets the value of the node padding vertical
        /// </summary>
        public ref float node_padding_vertical => ref Unsafe.AsRef<float>(&NativePtr->node_padding_vertical);
        /// <summary>
        /// Gets the value of the node border thickness
        /// </summary>
        public ref float node_border_thickness => ref Unsafe.AsRef<float>(&NativePtr->node_border_thickness);
        /// <summary>
        /// Gets the value of the link thickness
        /// </summary>
        public ref float link_thickness => ref Unsafe.AsRef<float>(&NativePtr->link_thickness);
        /// <summary>
        /// Gets the value of the link line segments per length
        /// </summary>
        public ref float link_line_segments_per_length => ref Unsafe.AsRef<float>(&NativePtr->link_line_segments_per_length);
        /// <summary>
        /// Gets the value of the link hover distance
        /// </summary>
        public ref float link_hover_distance => ref Unsafe.AsRef<float>(&NativePtr->link_hover_distance);
        /// <summary>
        /// Gets the value of the pin circle radius
        /// </summary>
        public ref float pin_circle_radius => ref Unsafe.AsRef<float>(&NativePtr->pin_circle_radius);
        /// <summary>
        /// Gets the value of the pin quad side length
        /// </summary>
        public ref float pin_quad_side_length => ref Unsafe.AsRef<float>(&NativePtr->pin_quad_side_length);
        /// <summary>
        /// Gets the value of the pin triangle side length
        /// </summary>
        public ref float pin_triangle_side_length => ref Unsafe.AsRef<float>(&NativePtr->pin_triangle_side_length);
        /// <summary>
        /// Gets the value of the pin line thickness
        /// </summary>
        public ref float pin_line_thickness => ref Unsafe.AsRef<float>(&NativePtr->pin_line_thickness);
        /// <summary>
        /// Gets the value of the pin hover radius
        /// </summary>
        public ref float pin_hover_radius => ref Unsafe.AsRef<float>(&NativePtr->pin_hover_radius);
        /// <summary>
        /// Gets the value of the pin offset
        /// </summary>
        public ref float pin_offset => ref Unsafe.AsRef<float>(&NativePtr->pin_offset);
        /// <summary>
        /// Gets the value of the flags
        /// </summary>
        public ref StyleFlags flags => ref Unsafe.AsRef<StyleFlags>(&NativePtr->flags);
        /// <summary>
        /// Gets the value of the colors
        /// </summary>
        public RangeAccessor<uint> colors => new RangeAccessor<uint>(NativePtr->colors, 16);
    }
}
