// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Memory.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Helpers
{
    /// <summary>
    ///     The memory class
    /// </summary>
    internal static class Memory
    {
        /// <summary>
        ///     The bytes allocated
        /// </summary>
        private static long _bytesAllocated;

        /// <summary>
        ///     Records
        /// </summary>
        public static void Record()
        {
            GC.Collect();
            _bytesAllocated = GC.GetAllocatedBytesForCurrentThread();
        }

        /// <summary>
        ///     Allocateds the at least using the specified bytes allocated
        /// </summary>
        /// <param name="bytesAllocated">The bytes allocated</param>
        public static void AllocatedAtLeast(long bytesAllocated)
        {
            Assert.True(MeasureAllocated() >= bytesAllocated);
        }

        /// <summary>
        ///     Allocateds the less than using the specified bytes allocated
        /// </summary>
        /// <param name="bytesAllocated">The bytes allocated</param>
        public static void AllocatedLessThan(long bytesAllocated)
        {
            Assert.True(MeasureAllocated() < bytesAllocated);
        }

        /// <summary>
        ///     Allocateds
        /// </summary>
        public static void Allocated()
        {
            Assert.True(MeasureAllocated() > 0);
        }

        /// <summary>
        ///     Nots the allocated
        /// </summary>
        public static void NotAllocated()
        {
            Assert.Equal(0, MeasureAllocated());
        }

        /// <summary>
        ///     Measures the allocated
        /// </summary>
        /// <returns>The allocated</returns>
        private static long MeasureAllocated()
        {
            long allocated = GC.GetAllocatedBytesForCurrentThread() - _bytesAllocated;
            // No equivalente directo para TestContext.WriteLine en xUnit
            return allocated;
        }
    }
}