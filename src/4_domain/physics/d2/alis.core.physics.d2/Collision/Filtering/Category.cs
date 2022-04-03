// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Category.cs
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

namespace Alis.Core.Systems.Physics2D.Collision.Filtering
{
    /// <summary>
    ///     The category enum
    /// </summary>
    [Flags]
    public enum Category
    {
        /// <summary>
        ///     The none category
        /// </summary>
        None = 0,

        /// <summary>
        ///     The all category
        /// </summary>
        All = int.MaxValue,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat1 = 1,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat2 = 2,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat3 = 4,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat4 = 8,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat5 = 16,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat6 = 32,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat7 = 64,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat8 = 128,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat9 = 256,

        /// <summary>
        ///     The cat 10 category
        /// </summary>
        Cat10 = 512,

        /// <summary>
        ///     The cat 11 category
        /// </summary>
        Cat11 = 1024,

        /// <summary>
        ///     The cat 12 category
        /// </summary>
        Cat12 = 2048,

        /// <summary>
        ///     The cat 13 category
        /// </summary>
        Cat13 = 4096,

        /// <summary>
        ///     The cat 14 category
        /// </summary>
        Cat14 = 8192,

        /// <summary>
        ///     The cat 15 category
        /// </summary>
        Cat15 = 16384,

        /// <summary>
        ///     The cat 16 category
        /// </summary>
        Cat16 = 32768,

        /// <summary>
        ///     The cat 17 category
        /// </summary>
        Cat17 = 65536,

        /// <summary>
        ///     The cat 18 category
        /// </summary>
        Cat18 = 131072,

        /// <summary>
        ///     The cat 19 category
        /// </summary>
        Cat19 = 262144,

        /// <summary>
        ///     The cat 20 category
        /// </summary>
        Cat20 = 524288,

        /// <summary>
        ///     The cat 21 category
        /// </summary>
        Cat21 = 1048576,

        /// <summary>
        ///     The cat 22 category
        /// </summary>
        Cat22 = 2097152,

        /// <summary>
        ///     The cat 23 category
        /// </summary>
        Cat23 = 4194304,

        /// <summary>
        ///     The cat 24 category
        /// </summary>
        Cat24 = 8388608,

        /// <summary>
        ///     The cat 25 category
        /// </summary>
        Cat25 = 16777216,

        /// <summary>
        ///     The cat 26 category
        /// </summary>
        Cat26 = 33554432,

        /// <summary>
        ///     The cat 27 category
        /// </summary>
        Cat27 = 67108864,

        /// <summary>
        ///     The cat 28 category
        /// </summary>
        Cat28 = 134217728,

        /// <summary>
        ///     The cat 29 category
        /// </summary>
        Cat29 = 268435456,

        /// <summary>
        ///     The cat 30 category
        /// </summary>
        Cat30 = 536870912,

        /// <summary>
        ///     The cat 31 category
        /// </summary>
        Cat31 = 1073741824
    }
}