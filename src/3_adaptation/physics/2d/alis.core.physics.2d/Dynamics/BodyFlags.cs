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

namespace Alis.Core.Systems.Physics2D.Dynamics
{
    /// <summary>
    ///     The body flags enum
    /// </summary>
    [Flags]
    public enum BodyFlags : byte
    {
        /// <summary>
        ///     The unknown body flags
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     The island flag body flags
        /// </summary>
        IslandFlag = 1,

        /// <summary>
        ///     The awake flag body flags
        /// </summary>
        AwakeFlag = 2,

        /// <summary>
        ///     The auto sleep flag body flags
        /// </summary>
        AutoSleepFlag = 4,

        /// <summary>
        ///     The bullet flag body flags
        /// </summary>
        BulletFlag = 8,

        /// <summary>
        ///     The fixed rotation flag body flags
        /// </summary>
        FixedRotationFlag = 16,

        /// <summary>
        ///     The enabled body flags
        /// </summary>
        Enabled = 32,

        /// <summary>
        ///     The ignore ccd body flags
        /// </summary>
        IgnoreCcd = 64
    }
}