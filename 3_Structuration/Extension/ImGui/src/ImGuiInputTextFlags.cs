// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiInputTextFlags.cs
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

namespace Alis.Core.Extension.ImGui
{
    /// <summary>
    ///     The im gui input text flags enum
    /// </summary>
    [Flags]
    public enum ImGuiInputTextFlags
    {
        /// <summary>
        ///     The none im gui input text flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The chars decimal im gui input text flags
        /// </summary>
        CharsDecimal = 1,

        /// <summary>
        ///     The chars hexadecimal im gui input text flags
        /// </summary>
        CharsHexadecimal = 2,

        /// <summary>
        ///     The chars uppercase im gui input text flags
        /// </summary>
        CharsUppercase = 4,

        /// <summary>
        ///     The chars no blank im gui input text flags
        /// </summary>
        CharsNoBlank = 8,

        /// <summary>
        ///     The auto select all im gui input text flags
        /// </summary>
        AutoSelectAll = 16,

        /// <summary>
        ///     The enter returns true im gui input text flags
        /// </summary>
        EnterReturnsTrue = 32,

        /// <summary>
        ///     The callback completion im gui input text flags
        /// </summary>
        CallbackCompletion = 64,

        /// <summary>
        ///     The callback history im gui input text flags
        /// </summary>
        CallbackHistory = 128,

        /// <summary>
        ///     The callback always im gui input text flags
        /// </summary>
        CallbackAlways = 256,

        /// <summary>
        ///     The callback char filter im gui input text flags
        /// </summary>
        CallbackCharFilter = 512,

        /// <summary>
        ///     The allow tab input im gui input text flags
        /// </summary>
        AllowTabInput = 1024,

        /// <summary>
        ///     The ctrl enter for new line im gui input text flags
        /// </summary>
        CtrlEnterForNewLine = 2048,

        /// <summary>
        ///     The no horizontal scroll im gui input text flags
        /// </summary>
        NoHorizontalScroll = 4096,

        /// <summary>
        ///     The always overwrite im gui input text flags
        /// </summary>
        AlwaysOverwrite = 8192,

        /// <summary>
        ///     The read only im gui input text flags
        /// </summary>
        ReadOnly = 16384,

        /// <summary>
        ///     The password im gui input text flags
        /// </summary>
        Password = 32768,

        /// <summary>
        ///     The no undo redo im gui input text flags
        /// </summary>
        NoUndoRedo = 65536,

        /// <summary>
        ///     The chars scientific im gui input text flags
        /// </summary>
        CharsScientific = 131072,

        /// <summary>
        ///     The callback resize im gui input text flags
        /// </summary>
        CallbackResize = 262144,

        /// <summary>
        ///     The callback edit im gui input text flags
        /// </summary>
        CallbackEdit = 524288,

        /// <summary>
        ///     The escape clears all im gui input text flags
        /// </summary>
        EscapeClearsAll = 1048576
    }
}