// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MessageBoxButtonFlags.cs
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl message box button flags enum
    /// </summary>
    [Flags]
    public enum MessageBoxButton : uint
    {
        /// <summary>
        ///     The sdl messagebox button return key default sdl message box button flags
        /// </summary>
        SdlMessageboxButtonReturnKeyDefault = 0x00000001,

        /// <summary>
        ///     The sdl messagebox button escape key default sdl message box button flags
        /// </summary>
        SdlMessageboxButtonEscapeKeyDefault = 0x00000002
    }
}