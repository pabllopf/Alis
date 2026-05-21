// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendingFactorDest.cs
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
    ///     The blending factor dest enum
    /// </summary>
    public enum BlendingFactorDest
    {
        /// <summary>
        ///     The zero blending factor dest
        /// </summary>
        Zero = 0,

        /// <summary>
        ///     The src color blending factor dest
        /// </summary>
        SrcColor = 0x0300,

        /// <summary>
        ///     The one minus src color blending factor dest
        /// </summary>
        OneMinusSrcColor = 0x0301,

        /// <summary>
        ///     The src alpha blending factor dest
        /// </summary>
        SrcAlpha = 0x0302,

        /// <summary>
        ///     The one minus src alpha blending factor dest
        /// </summary>
        OneMinusSrcAlpha = 0x0303,

        /// <summary>
        ///     The dst alpha blending factor dest
        /// </summary>
        DstAlpha = 0x0304,

        /// <summary>
        ///     The one minus dst alpha blending factor dest
        /// </summary>
        OneMinusDstAlpha = 0x0305,

        /// <summary>
        ///     The dst color blending factor dest
        /// </summary>
        DstColor = 0x0306,

        /// <summary>
        ///     The one minus dst color blending factor dest
        /// </summary>
        OneMinusDstColor = 0x0307,

        /// <summary>
        ///     The constant color blending factor dest
        /// </summary>
        ConstantColor = 0x8001,

        /// <summary>
        ///     The constant color ext blending factor dest
        /// </summary>
        ConstantColorExt = 0x8001,

        /// <summary>
        ///     The one minus constant color blending factor dest
        /// </summary>
        OneMinusConstantColor = 0x8002,

        /// <summary>
        ///     The one minus constant color ext blending factor dest
        /// </summary>
        OneMinusConstantColorExt = 0x8002,

        /// <summary>
        ///     The constant alpha blending factor dest
        /// </summary>
        ConstantAlpha = 0x8003,

        /// <summary>
        ///     The constant alpha ext blending factor dest
        /// </summary>
        ConstantAlphaExt = 0x8003,

        /// <summary>
        ///     The one minus constant alpha blending factor dest
        /// </summary>
        OneMinusConstantAlpha = 0x8004,

        /// <summary>
        ///     The one minus constant alpha ext blending factor dest
        /// </summary>
        OneMinusConstantAlphaExt = 0x8004,

        /// <summary>
        ///     The one blending factor dest
        /// </summary>
        One = 1
    }
}