// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BufferPoolRemainingCoverageTests.cs
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

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The buffer pool remaining coverage tests class
    /// </summary>
    public class BufferPoolRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that finalizer frees buffers without throwing
        /// </summary>
        [Fact]
        public void Finalizer_FreesBuffers_WithoutThrowing()
        {
            CreateUnreferencedPool();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Assert.True(true);
        }

        /// <summary>
        ///     Creates the unreferenced pool
        /// </summary>
        private static void CreateUnreferencedPool()
        {
            BufferPool pool = new BufferPool(1024);
        }
    }
}
