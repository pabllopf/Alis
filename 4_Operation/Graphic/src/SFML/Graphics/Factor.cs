// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Factor.cs
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

namespace Alis.Core.Graphic.SFML.Graphics
{
    /// <summary>
    ///     Enumeration of the blending factors
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum Factor
    {
        /// <summary>(0, 0, 0, 0)</summary>
        Zero,

        /// <summary>(1, 1, 1, 1)</summary>
        One,

        /// <summary>(src.r, src.g, src.b, src.a)</summary>
        SrcColor,

        /// <summary>(1, 1, 1, 1) - (src.r, src.g, src.b, src.a)</summary>
        OneMinusSrcColor,

        /// <summary>(dst.r, dst.g, dst.b, dst.a)</summary>
        DstColor,

        /// <summary>(1, 1, 1, 1) - (dst.r, dst.g, dst.b, dst.a)</summary>
        OneMinusDstColor,

        /// <summary>(src.a, src.a, src.a, src.a)</summary>
        SrcAlpha,

        /// <summary>(1, 1, 1, 1) - (src.a, src.a, src.a, src.a)</summary>
        OneMinusSrcAlpha,

        /// <summary>(dst.a, dst.a, dst.a, dst.a)</summary>
        DstAlpha,

        /// <summary>(1, 1, 1, 1) - (dst.a, dst.a, dst.a, dst.a)</summary>
        OneMinusDstAlpha
    }
}