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

namespace Alis.Extension.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The clear buffer mask enum
    /// </summary>
    [Flags]
    public enum ClearBufferMask
    {
        /// <summary>
        ///     The depth buffer bit clear buffer mask
        /// </summary>
        DepthBufferBit = 0x00000100,
        
        /// <summary>
        ///     The accum buffer bit clear buffer mask
        /// </summary>
        AccumBufferBit = 0x00000200,
        
        /// <summary>
        ///     The stencil buffer bit clear buffer mask
        /// </summary>
        StencilBufferBit = 0x00000400,
        
        /// <summary>
        ///     The color buffer bit clear buffer mask
        /// </summary>
        ColorBufferBit = 0x00004000
    }
}