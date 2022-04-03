// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ControllerType.cs
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

namespace Alis.Core.Systems.Physics2D.Extensions.Controllers.ControllerBase
{
    /// <summary>
    ///     The controller type enum
    /// </summary>
    [Flags]
    public enum ControllerType
    {
        /// <summary>
        ///     The gravity controller controller type
        /// </summary>
        GravityController = 1 << 0,

        /// <summary>
        ///     The velocity limit controller controller type
        /// </summary>
        VelocityLimitController = 1 << 1,

        /// <summary>
        ///     The abstract force controller controller type
        /// </summary>
        AbstractForceController = 1 << 2,

        /// <summary>
        ///     The buoyancy controller controller type
        /// </summary>
        BuoyancyController = 1 << 3
    }
}