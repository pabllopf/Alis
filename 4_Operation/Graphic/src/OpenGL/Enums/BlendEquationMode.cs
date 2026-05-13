// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlendEquationMode.cs
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
    /// Defines the blend equation modes used by glBlendEquation to determine how source and destination colors are combined.
    /// Controls the arithmetic operation applied during color blending.
    /// </summary>
    public enum BlendEquationMode
    {
        /// <summary>Source and destination colors are added together (GL_FUNC_ADD = 0x8006).</summary>
        FuncAdd = 0x8006,

        /// <summary>The minimum of source and destination color components is used (GL_MIN = 0x8007).</summary>
        Min = 0x8007,

        /// <summary>The maximum of source and destination color components is used (GL_MAX = 0x8008).</summary>
        Max = 0x8008,

        /// <summary>Destination color is subtracted from source color (GL_FUNC_SUBTRACT = 0x800A).</summary>
        FuncSubtract = 0x800A,

        /// <summary>Source color is subtracted from destination color (GL_FUNC_REVERSE_SUBTRACT = 0x800B).</summary>
        FuncReverseSubtract = 0x800B
    }
}
