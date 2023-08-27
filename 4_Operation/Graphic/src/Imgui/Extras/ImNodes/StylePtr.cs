// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StylePtr.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Graphic.ImGui.Utils;

namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The style ptr
    /// </summary>
    public unsafe struct StylePtr
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