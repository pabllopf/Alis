// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlMessageBoxFlags.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl messageboxflags enum
    /// </summary>
    [Flags]
    public enum SdlMessageBoxFlags : uint
    {
        /// <summary>
        ///     The sdl messagebox error sdl messageboxflags
        /// </summary>
        SdlMessageboxError = 0x00000010,

        /// <summary>
        ///     The sdl messagebox warning sdl messageboxflags
        /// </summary>
        SdlMessageboxWarning = 0x00000020,

        /// <summary>
        ///     The sdl messagebox information sdl messageboxflags
        /// </summary>
        SdlMessageboxInformation = 0x00000040
    }
}