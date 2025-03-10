// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryStats.cs
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

using System.Threading;

namespace Alis.Core.Graphic.Stb.Hebron.Runtime
{
    /// <summary>
    ///     The memory stats class
    /// </summary>
    internal static class MemoryStats
    {
        /// <summary>
        ///     The allocations
        /// </summary>
        private static int _allocations;

        /// <summary>
        ///     Gets the value of the allocations
        /// </summary>
        public static int Allocations => _allocations;

        /// <summary>
        ///     Allocateds
        /// </summary>
        internal static void Allocated()
        {
            Interlocked.Increment(ref _allocations);
        }

        /// <summary>
        ///     Freeds
        /// </summary>
        internal static void Freed()
        {
            Interlocked.Decrement(ref _allocations);
        }
    }
}