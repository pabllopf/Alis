// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClearBufferMask.cs
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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The clear buffer mask enum
    /// </summary>
    [Flags]
    public enum ClearBufferMask
    {
        /// <summary>
        ///     Clears the depth buffer (GL_DEPTH_BUFFER_BIT)
        /// </summary>
        DepthBufferBit = 0x00000100,

        /// <summary>
        ///     Clears the accumulation buffer (GL_ACCUM_BUFFER_BIT)
        /// </summary>
        AccumBufferBit = 0x00000200,

        /// <summary>
        ///     Clears the stencil buffer (GL_STENCIL_BUFFER_BIT)
        /// </summary>
        StencilBufferBit = 0x00000400,

        /// <summary>
        ///     Clears the color buffer (GL_COLOR_BUFFER_BIT)
        /// </summary>
        ColorBufferBit = 0x00004000
    }
}