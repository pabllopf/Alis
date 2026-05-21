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
        ///     The sdl rw ops unknown
        /// </summary>
        RwOpsUnknown = 0,

        /// <summary>
        ///     The sdl rw ops win file
        /// </summary>
        RwOpsWinFile = 1,

        /// <summary>
        ///     The sdl rw ops std file
        /// </summary>
        RwOpsStdFile = 2,

        /// <summary>
        ///     The sdl rw ops jni file
        /// </summary>
        RwOpsJniFile = 3,

        /// <summary>
        ///     The sdl rw ops memory
        /// </summary>
        RwOpsMemory = 4,

        /// <summary>
        ///     The sdl rw ops memory ro
        /// </summary>
        RwOpsMemoryRo = 5
    }
}