// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyMod.cs
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
    ///     The sdl key mod enum
    /// </summary>
    [Flags]
    public enum KeyMod : ushort
    {
        /// <summary>
        ///     The k mod none sdl key mod
        /// </summary>
        None = 0x0000,

        /// <summary>
        ///     The k mod l shift sdl key mod
        /// </summary>
        KModLShift = 0x0001,

        /// <summary>
        ///     The k mod r shift sdl key mod
        /// </summary>
        KModRShift = 0x0002,

        /// <summary>
        ///     The k mod l ctrl sdl key mod
        /// </summary>
        KModLCtrl = 0x0040,

        /// <summary>
        ///     The k mod r ctrl sdl key mod
        /// </summary>
        KModRCtrl = 0x0080,

        /// <summary>
        ///     The k mod l alt sdl key mod
        /// </summary>
        KModLAlt = 0x0100,

        /// <summary>
        ///     The k mod r alt sdl key mod
        /// </summary>
        KModRAlt = 0x0200,

        /// <summary>
        ///     The k mod l gui sdl key mod
        /// </summary>
        KModLGui = 0x0400,

        /// <summary>
        ///     The k mod r gui sdl key mod
        /// </summary>
        KModRGui = 0x0800,

        /// <summary>
        ///     The k mod num sdl key mod
        /// </summary>
        KModNum = 0x1000,

        /// <summary>
        ///     The k mod caps sdl key mod
        /// </summary>
        KModCaps = 0x2000,

        /// <summary>
        ///     The k mod mode sdl key mod
        /// </summary>
        KModMode = 0x4000,

        /// <summary>
        ///     The k mod scroll sdl key mod
        /// </summary>
        KModScroll = 0x8000,

        /// <summary>
        ///     The k mod ctrl sdl key mod
        /// </summary>
        KModCtrl = KModLCtrl | KModRCtrl,

        /// <summary>
        ///     The k mod shift sdl key mod
        /// </summary>
        KModShift = KModLShift | KModRShift,

        /// <summary>
        ///     The k mod alt sdl key mod
        /// </summary>
        KModAlt = KModLAlt | KModRAlt,

        /// <summary>
        ///     The k mod gui sdl key mod
        /// </summary>
        KModGui = KModLGui | KModRGui,

        /// <summary>
        ///     The k mod reserved sdl key mod
        /// </summary>
        KModReserved = KModScroll
    }
}