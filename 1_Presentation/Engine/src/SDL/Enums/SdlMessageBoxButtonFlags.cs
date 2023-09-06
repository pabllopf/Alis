// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlMessageBoxButtonFlags.cs
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

namespace Alis.Core.Graphic.SDL.Enums
{
    /// <summary>
    ///     The sdl messageboxbuttonflags enum
    /// </summary>
    [Flags]
    public enum SdlMessageBoxButtonFlags : uint
    {
        /// <summary>
        ///     The sdl messagebox button returnkey default sdl messageboxbuttonflags
        /// </summary>
        SdlMessageboxButtonReturnkeyDefault = 0x00000001,

        /// <summary>
        ///     The sdl messagebox button escapekey default sdl messageboxbuttonflags
        /// </summary>
        SdlMessageboxButtonEscapekeyDefault = 0x00000002
    }
}