// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlKeymod.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl keymod enum
    /// </summary>
    [Flags]
    public enum SdlKeymod : ushort
    {
        /// <summary>
        ///     The kmod none sdl keymod
        /// </summary>
        KmodNone = 0x0000,

        /// <summary>
        ///     The kmod lshift sdl keymod
        /// </summary>
        KmodLshift = 0x0001,

        /// <summary>
        ///     The kmod rshift sdl keymod
        /// </summary>
        KmodRshift = 0x0002,

        /// <summary>
        ///     The kmod lctrl sdl keymod
        /// </summary>
        KmodLctrl = 0x0040,

        /// <summary>
        ///     The kmod rctrl sdl keymod
        /// </summary>
        KmodRctrl = 0x0080,

        /// <summary>
        ///     The kmod lalt sdl keymod
        /// </summary>
        KmodLalt = 0x0100,

        /// <summary>
        ///     The kmod ralt sdl keymod
        /// </summary>
        KmodRalt = 0x0200,

        /// <summary>
        ///     The kmod lgui sdl keymod
        /// </summary>
        KmodLgui = 0x0400,

        /// <summary>
        ///     The kmod rgui sdl keymod
        /// </summary>
        KmodRgui = 0x0800,

        /// <summary>
        ///     The kmod num sdl keymod
        /// </summary>
        KmodNum = 0x1000,

        /// <summary>
        ///     The kmod caps sdl keymod
        /// </summary>
        KmodCaps = 0x2000,

        /// <summary>
        ///     The kmod mode sdl keymod
        /// </summary>
        KmodMode = 0x4000,

        /// <summary>
        ///     The kmod scroll sdl keymod
        /// </summary>
        KmodScroll = 0x8000,

        /* These are defines in the SDL headers */
        /// <summary>
        ///     The kmod ctrl sdl keymod
        /// </summary>
        KmodCtrl = KmodLctrl | KmodRctrl,

        /// <summary>
        ///     The kmod shift sdl keymod
        /// </summary>
        KmodShift = KmodLshift | KmodRshift,

        /// <summary>
        ///     The kmod alt sdl keymod
        /// </summary>
        KmodAlt = KmodLalt | KmodRalt,

        /// <summary>
        ///     The kmod gui sdl keymod
        /// </summary>
        KmodGui = KmodLgui | KmodRgui,

        /// <summary>
        ///     The kmod reserved sdl keymod
        /// </summary>
        KmodReserved = KmodScroll
    }
}