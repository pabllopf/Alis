// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateModelFlags.cs
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

namespace Alis.Core.Ecs.Generator.Models
{
    /// <summary>
    ///     The update model flags enum
    /// </summary>
    [Flags]
    public enum UpdateModelFlags
    {
        /// <summary>
        ///     The none update model flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The is update model flags
        /// </summary>
        IsClass = 1 << 0,

        /// <summary>
        ///     The is struct update model flags
        /// </summary>
        IsStruct = 1 << 1,

        /// <summary>
        ///     The is generic update model flags
        /// </summary>
        IsGeneric = 1 << 2,

        /// <summary>
        ///     The initable update model flags
        /// </summary>
        Initable = 1 << 3,

        /// <summary>
        ///     The destroyable update model flags
        /// </summary>
        Destroyable = 1 << 4,

        /// <summary>
        ///     The is record update model flags
        /// </summary>
        IsRecord = 1 << 5,

        /// <summary>
        ///     The is self init update model flags
        /// </summary>
        IsSelfInit = 1 << 6
    }
}