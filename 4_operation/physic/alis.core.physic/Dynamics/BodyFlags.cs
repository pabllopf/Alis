// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BodyFlags.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The body flags enum
    /// </summary>
    [Flags]
    public enum BodyFlags
    {
        /// <summary>
        ///     The frozen body flags
        /// </summary>
        Frozen = 0x0002,

        /// <summary>
        ///     The island body flags
        /// </summary>
        Island = 0x0004,

        /// <summary>
        ///     The sleep body flags
        /// </summary>
        Sleep = 0x0008,

        /// <summary>
        ///     The allow sleep body flags
        /// </summary>
        AllowSleep = 0x0010,

        /// <summary>
        ///     The bullet body flags
        /// </summary>
        Bullet = 0x0020,

        /// <summary>
        ///     The fixed rotation body flags
        /// </summary>
        FixedRotation = 0x0040
    }
}