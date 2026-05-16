// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WinRtDeviceFamily.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl winrt device family enum
    /// </summary>
    public enum WinRtDeviceFamily
    {
    /// <summary>
    ///     Unknown or unrecognized WinRT device family
    /// </summary>
    SdlWinrtDeviceFamilyUnknown,

    /// <summary>
    ///     WinRT application running on a desktop Windows system
    /// </summary>
    SdlWinrtDeviceFamilyDesktop,

    /// <summary>
    ///     WinRT application running on a Windows Mobile device
    /// </summary>
    SdlWinrtDeviceFamilyMobile,

    /// <summary>
    ///     WinRT application running on an Xbox console
    /// </summary>
    SdlWinrtDeviceFamilyXbox
    }
}