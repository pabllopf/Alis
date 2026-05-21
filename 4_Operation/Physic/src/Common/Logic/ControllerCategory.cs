// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCategory.cs
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

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     The controller category enum
    /// </summary>
    [Flags]
    public enum ControllerCategory
    {
        /// <summary>
        ///     The none controller category
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The cat 01 controller category
        /// </summary>
        Cat01 = 0x00000001,

        /// <summary>
        ///     The cat 02 controller category
        /// </summary>
        Cat02 = 0x00000002,

        /// <summary>
        ///     The cat 03 controller category
        /// </summary>
        Cat03 = 0x00000004,

        /// <summary>
        ///     The cat 04 controller category
        /// </summary>
        Cat04 = 0x00000008,

        /// <summary>
        ///     The cat 05 controller category
        /// </summary>
        Cat05 = 0x00000010,

        /// <summary>
        ///     The cat 06 controller category
        /// </summary>
        Cat06 = 0x00000020,

        /// <summary>
        ///     The cat 07 controller category
        /// </summary>
        Cat07 = 0x00000040,

        /// <summary>
        ///     The cat 08 controller category
        /// </summary>
        Cat08 = 0x00000080,

        /// <summary>
        ///     The cat 09 controller category
        /// </summary>
        Cat09 = 0x00000100,

        /// <summary>
        ///     The cat 10 controller category
        /// </summary>
        Cat10 = 0x00000200,

        /// <summary>
        ///     The cat 11 controller category
        /// </summary>
        Cat11 = 0x00000400,

        /// <summary>
        ///     The cat 12 controller category
        /// </summary>
        Cat12 = 0x00000800,

        /// <summary>
        ///     The cat 13 controller category
        /// </summary>
        Cat13 = 0x00001000,

        /// <summary>
        ///     The cat 14 controller category
        /// </summary>
        Cat14 = 0x00002000,

        /// <summary>
        ///     The cat 15 controller category
        /// </summary>
        Cat15 = 0x00004000,

        /// <summary>
        ///     The cat 16 controller category
        /// </summary>
        Cat16 = 0x00008000,

        /// <summary>
        ///     The cat 17 controller category
        /// </summary>
        Cat17 = 0x00010000,

        /// <summary>
        ///     The cat 18 controller category
        /// </summary>
        Cat18 = 0x00020000,

        /// <summary>
        ///     The cat 19 controller category
        /// </summary>
        Cat19 = 0x00040000,

        /// <summary>
        ///     The cat 20 controller category
        /// </summary>
        Cat20 = 0x00080000,

        /// <summary>
        ///     The cat 21 controller category
        /// </summary>
        Cat21 = 0x00100000,

        /// <summary>
        ///     The cat 22 controller category
        /// </summary>
        Cat22 = 0x00200000,

        /// <summary>
        ///     The cat 23 controller category
        /// </summary>
        Cat23 = 0x00400000,

        /// <summary>
        ///     The cat 24 controller category
        /// </summary>
        Cat24 = 0x00800000,

        /// <summary>
        ///     The cat 25 controller category
        /// </summary>
        Cat25 = 0x01000000,

        /// <summary>
        ///     The cat 26 controller category
        /// </summary>
        Cat26 = 0x02000000,

        /// <summary>
        ///     The cat 27 controller category
        /// </summary>
        Cat27 = 0x04000000,

        /// <summary>
        ///     The cat 28 controller category
        /// </summary>
        Cat28 = 0x08000000,

        /// <summary>
        ///     The cat 29 controller category
        /// </summary>
        Cat29 = 0x10000000,

        /// <summary>
        ///     The cat 30 controller category
        /// </summary>
        Cat30 = 0x20000000,

        /// <summary>
        ///     The cat 31 controller category
        /// </summary>
        Cat31 = 0x40000000,

        /// <summary>
        ///     The all controller category
        /// </summary>
        All = int.MaxValue
    }
}