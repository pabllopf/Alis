// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendingFactorSrc.cs
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
    /// Defines the source blending factors used by glBlendFunc for the source (incoming fragment) color contribution.
    /// These factors determine how the incoming fragment color is weighted when blending with the existing framebuffer color.
    /// </summary>
    public enum BlendingFactorSrc
    {
        /// <summary>Blend factor of zero (GL_ZERO = 0).</summary>
        Zero = 0,

        /// <summary>Uses the source alpha as the blend factor (GL_SRC_ALPHA = 0x0302).</summary>
        SrcAlpha = 0x0302,

        /// <summary>Uses one minus the source alpha as the blend factor (GL_ONE_MINUS_SRC_ALPHA = 0x0303).</summary>
        OneMinusSrcAlpha = 0x0303,

        /// <summary>Uses the destination alpha as the blend factor (GL_DST_ALPHA = 0x0304).</summary>
        DstAlpha = 0x0304,

        /// <summary>Uses one minus the destination alpha as the blend factor (GL_ONE_MINUS_DST_ALPHA = 0x0305).</summary>
        OneMinusDstAlpha = 0x0305,

        /// <summary>Uses the destination color as the blend factor (GL_DST_COLOR = 0x0306).</summary>
        DstColor = 0x0306,

        /// <summary>Uses one minus the destination color as the blend factor (GL_ONE_MINUS_DST_COLOR = 0x0307).</summary>
        OneMinusDstColor = 0x0307,

        /// <summary>Uses the source alpha saturate as the blend factor (GL_SRC_ALPHA_SATURATE = 0x0308).</summary>
        SrcAlphaSaturate = 0x0308,

        /// <summary>Uses a constant color as the blend factor (GL_CONSTANT_COLOR = 0x8001).</summary>
        ConstantColor = 0x8001,

        /// <summary>Extension alias for constant color (GL_CONSTANT_COLOR_EXT = 0x8001).</summary>
        ConstantColorExt = 0x8001,

        /// <summary>Uses one minus the constant color as the blend factor (GL_ONE_MINUS_CONSTANT_COLOR = 0x8002).</summary>
        OneMinusConstantColor = 0x8002,

        /// <summary>Extension alias for one minus constant color (GL_ONE_MINUS_CONSTANT_COLOR_EXT = 0x8002).</summary>
        OneMinusConstantColorExt = 0x8002,

        /// <summary>Uses a constant alpha as the blend factor (GL_CONSTANT_ALPHA = 0x8003).</summary>
        ConstantAlpha = 0x8003,

        /// <summary>Extension alias for constant alpha (GL_CONSTANT_ALPHA_EXT = 0x8003).</summary>
        ConstantAlphaExt = 0x8003,

        /// <summary>Uses one minus the constant alpha as the blend factor (GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004).</summary>
        OneMinusConstantAlpha = 0x8004,

        /// <summary>Extension alias for one minus constant alpha (GL_ONE_MINUS_CONSTANT_ALPHA_EXT = 0x8004).</summary>
        OneMinusConstantAlphaExt = 0x8004,

        /// <summary>Blend factor of one (GL_ONE = 1).</summary>
        One = 1
    }
}
