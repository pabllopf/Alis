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
        ///     Factor of zero (GL_ZERO)
        /// </summary>
        Zero = 0,

        /// <summary>
        ///     Multiplies by the source color (GL_SRC_COLOR)
        /// </summary>
        SrcColor = 0x0300,

        /// <summary>
        ///     Multiplies by one minus source color (GL_ONE_MINUS_SRC_COLOR)
        /// </summary>
        OneMinusSrcColor = 0x0301,

        /// <summary>
        ///     Multiplies by source alpha (GL_SRC_ALPHA)
        /// </summary>
        SrcAlpha = 0x0302,

        /// <summary>
        ///     Multiplies by one minus source alpha (GL_ONE_MINUS_SRC_ALPHA)
        /// </summary>
        OneMinusSrcAlpha = 0x0303,

        /// <summary>
        ///     Multiplies by destination alpha (GL_DST_ALPHA)
        /// </summary>
        DstAlpha = 0x0304,

        /// <summary>
        ///     Multiplies by one minus destination alpha (GL_ONE_MINUS_DST_ALPHA)
        /// </summary>
        OneMinusDstAlpha = 0x0305,

        /// <summary>
        ///     Multiplies by destination color (GL_DST_COLOR)
        /// </summary>
        DstColor = 0x0306,

        /// <summary>
        ///     Multiplies by one minus destination color (GL_ONE_MINUS_DST_COLOR)
        /// </summary>
        OneMinusDstColor = 0x0307,

        /// <summary>
        ///     Uses a constant color as the blend factor (GL_CONSTANT_COLOR)
        /// </summary>
        ConstantColor = 0x8001,

        /// <summary>
        ///     Uses a constant color as the blend factor, EXT version (GL_CONSTANT_COLOR_EXT)
        /// </summary>
        ConstantColorExt = 0x8001,

        /// <summary>
        ///     Uses one minus constant color as the blend factor (GL_ONE_MINUS_CONSTANT_COLOR)
        /// </summary>
        OneMinusConstantColor = 0x8002,

        /// <summary>
        ///     Uses one minus constant color as the blend factor, EXT version (GL_ONE_MINUS_CONSTANT_COLOR_EXT)
        /// </summary>
        OneMinusConstantColorExt = 0x8002,

        /// <summary>
        ///     Uses constant alpha as the blend factor (GL_CONSTANT_ALPHA)
        /// </summary>
        ConstantAlpha = 0x8003,

        /// <summary>
        ///     Uses constant alpha as the blend factor, EXT version (GL_CONSTANT_ALPHA_EXT)
        /// </summary>
        ConstantAlphaExt = 0x8003,

        /// <summary>
        ///     Uses one minus constant alpha as the blend factor (GL_ONE_MINUS_CONSTANT_ALPHA)
        /// </summary>
        OneMinusConstantAlpha = 0x8004,

        /// <summary>
        ///     Uses one minus constant alpha as the blend factor, EXT version (GL_ONE_MINUS_CONSTANT_ALPHA_EXT)
        /// </summary>
        OneMinusConstantAlphaExt = 0x8004,

        /// <summary>
        ///     Factor of one (GL_ONE)
        /// </summary>
        One = 1
    }
}