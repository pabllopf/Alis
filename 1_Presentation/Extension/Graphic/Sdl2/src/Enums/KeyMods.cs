// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyMods.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl key mod enum
    /// </summary>
    [Flags]
    public enum KeyMods : ushort
    {
    /// <summary>
    ///     No key modifier is pressed
    /// </summary>
    None = 0x0000,

    /// <summary>
    ///     Left Shift key is held
    /// </summary>
    KModLShift = 0x0001,

    /// <summary>
    ///     Right Shift key is held
    /// </summary>
    KModRShift = 0x0002,

    /// <summary>
    ///     Left Ctrl key is held
    /// </summary>
    KModLCtrl = 0x0040,

    /// <summary>
    ///     Right Ctrl key is held
    /// </summary>
    KModRCtrl = 0x0080,

    /// <summary>
    ///     Left Alt key is held
    /// </summary>
    KModLAlt = 0x0100,

    /// <summary>
    ///     Right Alt key is held
    /// </summary>
    KModRAlt = 0x0200,

    /// <summary>
    ///     Left GUI key (Windows/Command/Meta) is held
    /// </summary>
    KModLGui = 0x0400,

    /// <summary>
    ///     Right GUI key (Windows/Command/Meta) is held
    /// </summary>
    KModRGui = 0x0800,

    /// <summary>
    ///     Num Lock key is active
    /// </summary>
    KModNum = 0x1000,

    /// <summary>
    ///     Caps Lock key is active
    /// </summary>
    KModCaps = 0x2000,

    /// <summary>
    ///     Mode key is active (AltGr on some keyboards)
    /// </summary>
    KModMode = 0x4000,

    /// <summary>
    ///     Scroll Lock key is active
    /// </summary>
    KModScroll = 0x8000,

    /// <summary>
    ///     Either left or right Ctrl is held (combined mask)
    /// </summary>
    KModCtrl = KModLCtrl | KModRCtrl,

    /// <summary>
    ///     Either left or right Shift is held (combined mask)
    /// </summary>
    KModShift = KModLShift | KModRShift,

    /// <summary>
    ///     Either left or right Alt is held (combined mask)
    /// </summary>
    KModAlt = KModLAlt | KModRAlt,

    /// <summary>
    ///     Either left or right GUI is held (combined mask)
    /// </summary>
    KModGui = KModLGui | KModRGui,

    /// <summary>
    ///     Reserved modifier flag mapped to Scroll Lock
    /// </summary>
    KModReserved = KModScroll
    }
}