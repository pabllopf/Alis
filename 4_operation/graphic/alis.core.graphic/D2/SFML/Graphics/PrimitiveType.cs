// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PrimitiveType.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Types of primitives that a VertexArray can render.
    ///     Points and lines have no area, therefore their thickness
    ///     will always be 1 pixel, regardless the current transform
    ///     and view.
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum PrimitiveType
    {
        /// List of individual points
        Points,

        /// List of individual lines
        Lines,

        /// List of connected lines, a point uses the previous point to form a line
        LineStrip,

        /// List of individual triangles
        Triangles,

        /// List of connected triangles, a point uses the two previous points to form a triangle
        TriangleStrip,

        /// List of connected triangles, a point uses the common center and the previous point to form a triangle
        TriangleFan,

        /// List of individual quads
        Quads,

        /// List of connected lines, a point uses the previous point to form a line
        [Obsolete("LinesStrip is deprecated, please use LineStrip")]
        LinesStrip = LineStrip,

        /// List of connected triangles, a point uses the two previous points to form a triangle
        [Obsolete("TrianglesStrip is deprecated, please use TriangleStrip")]
        TrianglesStrip = TriangleStrip,

        /// List of connected triangles, a point uses the common center and the previous point to form a triangle
        [Obsolete("TrianglesFan is deprecated, please use TriangleFan")]
        TrianglesFan = TriangleFan
    }
}