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
    ///     The buffer usage hint enum
    /// </summary>
    public enum BufferUsageHint
    {
        /// <summary>
        ///     The stream draw buffer usage hint
        /// </summary>
        StreamDraw = 0x88E0,

        /// <summary>
        ///     The stream read buffer usage hint
        /// </summary>
        StreamRead = 0x88E1,

        /// <summary>
        ///     The stream copy buffer usage hint
        /// </summary>
        StreamCopy = 0x88E2,

        /// <summary>
        ///     The static draw buffer usage hint
        /// </summary>
        StaticDraw = 0x88E4,

        /// <summary>
        ///     The static read buffer usage hint
        /// </summary>
        StaticRead = 0x88E5,

        /// <summary>
        ///     The static copy buffer usage hint
        /// </summary>
        StaticCopy = 0x88E6,

        /// <summary>
        ///     The dynamic draw buffer usage hint
        /// </summary>
        DynamicDraw = 0x88E8,

        /// <summary>
        ///     The dynamic read buffer usage hint
        /// </summary>
        DynamicRead = 0x88E9,

        /// <summary>
        ///     The dynamic copy buffer usage hint
        /// </summary>
        DynamicCopy = 0x88EA
    }
}