// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RwOps.cs
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
    ///     The rw ops enum
    /// </summary>
    public enum RwOps : uint
    {
    /// <summary>
    ///     Unknown or unsupported RWops backing storage type
    /// </summary>
    RwOpsUnknown = 0,

    /// <summary>
    ///     RWops backed by a Windows file handle
    /// </summary>
    RwOpsWinFile = 1,

    /// <summary>
    ///     RWops backed by a standard C file descriptor
    /// </summary>
    RwOpsStdFile = 2,

    /// <summary>
    ///     RWops backed by a JNI file on Android
    /// </summary>
    RwOpsJniFile = 3,

    /// <summary>
    ///     RWops backed by a read-write memory buffer
    /// </summary>
    RwOpsMemory = 4,

    /// <summary>
    ///     RWops backed by a read-only memory buffer
    /// </summary>
    RwOpsMemoryRo = 5
    }
}