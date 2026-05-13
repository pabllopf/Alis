// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrimitiveType.cs
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

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    /// Defines the geometric primitive types used by OpenGL drawing commands such as glDrawArrays and glDrawElements.
    /// Each value corresponds to a standard OpenGL primitive type constant that specifies how vertex data is interpreted.
    /// </summary>
    public enum PrimitiveType
    {
        /// <summary>
        /// Each vertex is rendered as an individual point (GL_POINTS = 0x0000).
        /// </summary>
        Points = 0x0000,

        /// <summary>
        /// Each pair of consecutive vertices defines an independent line segment (GL_LINES = 0x0001).
        /// </summary>
        Lines = 0x0001,

        /// <summary>
        /// A continuous line is drawn from the first vertex to the last, with the last vertex connected back to the first (GL_LINE_LOOP = 0x0002).
        /// </summary>
        LineLoop = 0x0002,

        /// <summary>
        /// A continuous line is drawn from the first vertex to the last without closing back to the first (GL_LINE_STRIP = 0x0003).
        /// </summary>
        LineStrip = 0x0003,

        /// <summary>
        /// Each group of three consecutive vertices defines an independent triangle (GL_TRIANGLES = 0x0004).
        /// </summary>
        Triangles = 0x0004,

        /// <summary>
        /// A strip of triangles where each new vertex forms a triangle with the two previous vertices (GL_TRIANGLE_STRIP = 0x0005).
        /// </summary>
        TriangleStrip = 0x0005,

        /// <summary>
        /// A fan of triangles where all triangles share the first vertex (GL_TRIANGLE_FAN = 0x0006).
        /// </summary>
        TriangleFan = 0x0006,

        /// <summary>
        /// Each group of four consecutive vertices defines an independent quadrilateral (GL_QUADS = 0x0007).
        /// </summary>
        Quads = 0x0007
    }
}
