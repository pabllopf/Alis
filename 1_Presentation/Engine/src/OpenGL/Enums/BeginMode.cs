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

namespace Alis.App.Engine.OpenGL.Enums
{
    /// <summary>
    ///     The begin mode enum
    /// </summary>
    public enum BeginMode
    {
        /// <summary>
        ///     The points begin mode
        /// </summary>
        Points = 0x0000,

        /// <summary>
        ///     The lines begin mode
        /// </summary>
        Lines = 0x0001,

        /// <summary>
        ///     The line loop begin mode
        /// </summary>
        LineLoop = 0x0002,

        /// <summary>
        ///     The line strip begin mode
        /// </summary>
        LineStrip = 0x0003,

        /// <summary>
        ///     The triangles begin mode
        /// </summary>
        Triangles = 0x0004,

        /// <summary>
        ///     The triangle strip begin mode
        /// </summary>
        TriangleStrip = 0x0005,

        /// <summary>
        ///     The triangle fan begin mode
        /// </summary>
        TriangleFan = 0x0006,

        /// <summary>
        ///     The lines adjacency begin mode
        /// </summary>
        LinesAdjacency = 0xA,

        /// <summary>
        ///     The line strip adjacency begin mode
        /// </summary>
        LineStripAdjacency = 0xB,

        /// <summary>
        ///     The triangles adjacency begin mode
        /// </summary>
        TrianglesAdjacency = 0xC,

        /// <summary>
        ///     The triangle strip adjacency begin mode
        /// </summary>
        TriangleStripAdjacency = 0xD,

        /// <summary>
        ///     The patches begin mode
        /// </summary>
        Patches = 0xE
    }
}