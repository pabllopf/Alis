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
    /// Defines the geometric primitive modes used with glBegin in legacy OpenGL immediate mode.
    /// Specifies how vertex data between glBegin and glEnd is interpreted and rendered.
    /// </summary>
    public enum BeginMode
    {
        /// <summary>Each vertex is rendered as an individual point (GL_POINTS = 0x0000).</summary>
        Points = 0x0000,

        /// <summary>Each pair of vertices defines an independent line segment (GL_LINES = 0x0001).</summary>
        Lines = 0x0001,

        /// <summary>A continuous line strip that closes back to the first vertex (GL_LINE_LOOP = 0x0002).</summary>
        LineLoop = 0x0002,

        /// <summary>A continuous line strip from first to last vertex (GL_LINE_STRIP = 0x0003).</summary>
        LineStrip = 0x0003,

        /// <summary>Each group of three vertices defines an independent triangle (GL_TRIANGLES = 0x0004).</summary>
        Triangles = 0x0004,

        /// <summary>A triangle strip where each new vertex forms a triangle with the two previous ones (GL_TRIANGLE_STRIP = 0x0005).</summary>
        TriangleStrip = 0x0005,

        /// <summary>A triangle fan where all triangles share the first vertex (GL_TRIANGLE_FAN = 0x0006).</summary>
        TriangleFan = 0x0006,

        /// <summary>Lines with adjacency information for geometry shaders (GL_LINES_ADJACENCY = 0xA).</summary>
        LinesAdjacency = 0xA,

        /// <summary>Line strip with adjacency information for geometry shaders (GL_LINE_STRIP_ADJACENCY = 0xB).</summary>
        LineStripAdjacency = 0xB,

        /// <summary>Triangles with adjacency information for geometry shaders (GL_TRIANGLES_ADJACENCY = 0xC).</summary>
        TrianglesAdjacency = 0xC,

        /// <summary>Triangle strip with adjacency information for geometry shaders (GL_TRIANGLE_STRIP_ADJACENCY = 0xD).</summary>
        TriangleStripAdjacency = 0xD,

        /// <summary>Patches for tessellation shaders (GL_PATCHES = 0xE).</summary>
        Patches = 0xE
    }
}
