// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlSyswmType.cs
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
    ///     The sdl syswm type enum
    /// </summary>
    public enum SdlSyswmType
    {
        /// <summary>
        ///     The sdl syswm unknown sdl syswm type
        /// </summary>
        SdlSyswmUnknown,

        /// <summary>
        ///     The sdl syswm windows sdl syswm type
        /// </summary>
        SdlSyswmWindows,

        /// <summary>
        ///     The sdl syswm x11 sdl syswm type
        /// </summary>
        SdlSyswmX11,

        /// <summary>
        ///     The sdl syswm directfb sdl syswm type
        /// </summary>
        SdlSyswmDirectfb,

        /// <summary>
        ///     The sdl syswm cocoa sdl syswm type
        /// </summary>
        SdlSyswmCocoa,

        /// <summary>
        ///     The sdl syswm uikit sdl syswm type
        /// </summary>
        SdlSyswmUikit,

        /// <summary>
        ///     The sdl syswm wayland sdl syswm type
        /// </summary>
        SdlSyswmWayland,

        /// <summary>
        ///     The sdl syswm mir sdl syswm type
        /// </summary>
        SdlSyswmMir,

        /// <summary>
        ///     The sdl syswm winrt sdl syswm type
        /// </summary>
        SdlSyswmWinrt,

        /// <summary>
        ///     The sdl syswm android sdl syswm type
        /// </summary>
        SdlSyswmAndroid,

        /// <summary>
        ///     The sdl syswm vivante sdl syswm type
        /// </summary>
        SdlSyswmVivante,

        /// <summary>
        ///     The sdl syswm os2 sdl syswm type
        /// </summary>
        SdlSyswmOs2,

        /// <summary>
        ///     The sdl syswm haiku sdl syswm type
        /// </summary>
        SdlSyswmHaiku,

        /// <summary>
        ///     The sdl syswm kmsdrm sdl syswm type
        /// </summary>
        SdlSyswmKmsdrm /* requires >= 2.0.16 */
    }
}