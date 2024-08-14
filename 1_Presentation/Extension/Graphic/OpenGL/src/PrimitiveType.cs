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

namespace Alis.Extension.Graphic.OpenGL
{
    /// <summary>
    ///     The primitive type enum
    /// </summary>
    public enum PrimitiveType
    {
        /// <summary>
        ///     The points primitive type
        /// </summary>
        Points = 0x0000, // GL_POINTS
        
        /// <summary>
        ///     The lines primitive type
        /// </summary>
        Lines = 0x0001, // GL_LINES
        
        /// <summary>
        ///     The line loop primitive type
        /// </summary>
        LineLoop = 0x0002, // GL_LINE_LOOP
        
        /// <summary>
        ///     The line strip primitive type
        /// </summary>
        LineStrip = 0x0003, // GL_LINE_STRIP
        
        /// <summary>
        ///     The triangles primitive type
        /// </summary>
        Triangles = 0x0004, // GL_TRIANGLES
        
        /// <summary>
        ///     The triangle strip primitive type
        /// </summary>
        TriangleStrip = 0x0005, // GL_TRIANGLE_STRIP
        
        /// <summary>
        ///     The triangle fan primitive type
        /// </summary>
        TriangleFan = 0x0006 // GL_TRIANGLE_FAN
    }
}