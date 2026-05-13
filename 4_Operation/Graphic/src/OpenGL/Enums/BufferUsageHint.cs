// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BufferUsageHint.cs
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
    /// Defines the expected usage patterns for OpenGL buffer objects via glBufferData.
    /// Provides hints to the OpenGL driver for optimal memory placement and performance.
    /// The pattern is: access (Stream/Static/Dynamic) x nature (Draw/Read/Copy).
    /// </summary>
    public enum BufferUsageHint
    {
        /// <summary>Data modified once, used briefly for drawing (GL_STREAM_DRAW = 0x88E0).</summary>
        StreamDraw = 0x88E0,

        /// <summary>Data modified once, used briefly for reading (GL_STREAM_READ = 0x88E1).</summary>
        StreamRead = 0x88E1,

        /// <summary>Data modified once, used briefly for copying (GL_STREAM_COPY = 0x88E2).</summary>
        StreamCopy = 0x88E2,

        /// <summary>Data modified once, used many times for drawing (GL_STATIC_DRAW = 0x88E4).</summary>
        StaticDraw = 0x88E4,

        /// <summary>Data modified once, used many times for reading (GL_STATIC_READ = 0x88E5).</summary>
        StaticRead = 0x88E5,

        /// <summary>Data modified once, used many times for copying (GL_STATIC_COPY = 0x88E6).</summary>
        StaticCopy = 0x88E6,

        /// <summary>Data modified repeatedly, used many times for drawing (GL_DYNAMIC_DRAW = 0x88E8).</summary>
        DynamicDraw = 0x88E8,

        /// <summary>Data modified repeatedly, used many times for reading (GL_DYNAMIC_READ = 0x88E9).</summary>
        DynamicRead = 0x88E9,

        /// <summary>Data modified repeatedly, used many times for copying (GL_DYNAMIC_COPY = 0x88EA).</summary>
        DynamicCopy = 0x88EA
    }
}
