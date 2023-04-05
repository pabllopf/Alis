// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlBlendFactor.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl blendfactor enum
    /// </summary>
    public enum SdlBlendFactor
    {
        /// <summary>
        ///     The sdl blendfactor zero sdl blendfactor
        /// </summary>
        SdlBlendfactorZero = 0x1,

        /// <summary>
        ///     The sdl blendfactor one sdl blendfactor
        /// </summary>
        SdlBlendfactorOne = 0x2,

        /// <summary>
        ///     The sdl blendfactor src color sdl blendfactor
        /// </summary>
        SdlBlendfactorSrcColor = 0x3,

        /// <summary>
        ///     The sdl blendfactor one minus src color sdl blendfactor
        /// </summary>
        SdlBlendfactorOneMinusSrcColor = 0x4,

        /// <summary>
        ///     The sdl blendfactor src alpha sdl blendfactor
        /// </summary>
        SdlBlendfactorSrcAlpha = 0x5,

        /// <summary>
        ///     The sdl blendfactor one minus src alpha sdl blendfactor
        /// </summary>
        SdlBlendfactorOneMinusSrcAlpha = 0x6,

        /// <summary>
        ///     The sdl blendfactor dst color sdl blendfactor
        /// </summary>
        SdlBlendfactorDstColor = 0x7,

        /// <summary>
        ///     The sdl blendfactor one minus dst color sdl blendfactor
        /// </summary>
        SdlBlendfactorOneMinusDstColor = 0x8,

        /// <summary>
        ///     The sdl blendfactor dst alpha sdl blendfactor
        /// </summary>
        SdlBlendfactorDstAlpha = 0x9,

        /// <summary>
        ///     The sdl blendfactor one minus dst alpha sdl blendfactor
        /// </summary>
        SdlBlendfactorOneMinusDstAlpha = 0xA
    }
}