// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BeginMode.cs
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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The begin mode enum
    /// </summary>
    public enum BeginMode
    {
        /// <summary>
        ///     Individual points primitive (GL_POINTS)
        /// </summary>
        Points = 0x0000,

        /// <summary>
        ///     Individual line segments primitive (GL_LINES)
        /// </summary>
        Lines = 0x0001,

        /// <summary>
        ///     Connected line loop primitive (GL_LINE_LOOP)
        /// </summary>
        LineLoop = 0x0002,

        /// <summary>
        ///     Connected line strip primitive (GL_LINE_STRIP)
        /// </summary>
        LineStrip = 0x0003,

        /// <summary>
        ///     Individual triangles primitive (GL_TRIANGLES)
        /// </summary>
        Triangles = 0x0004,

        /// <summary>
        ///     Connected triangle strip primitive (GL_TRIANGLE_STRIP)
        /// </summary>
        TriangleStrip = 0x0005,

        /// <summary>
        ///     Connected triangle fan primitive (GL_TRIANGLE_FAN)
        /// </summary>
        TriangleFan = 0x0006,

        /// <summary>
        ///     Lines with adjacency information (GL_LINES_ADJACENCY)
        /// </summary>
        LinesAdjacency = 0xA,

        /// <summary>
        ///     Line strip with adjacency information (GL_LINE_STRIP_ADJACENCY)
        /// </summary>
        LineStripAdjacency = 0xB,

        /// <summary>
        ///     Triangles with adjacency information (GL_TRIANGLES_ADJACENCY)
        /// </summary>
        TrianglesAdjacency = 0xC,

        /// <summary>
        ///     Triangle strip with adjacency information (GL_TRIANGLE_STRIP_ADJACENCY)
        /// </summary>
        TriangleStripAdjacency = 0xD,

        /// <summary>
        ///     Tessellation patches primitive (GL_PATCHES)
        /// </summary>
        Patches = 0xE
    }
}