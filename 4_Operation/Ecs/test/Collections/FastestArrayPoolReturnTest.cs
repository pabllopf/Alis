// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestArrayPoolReturnTest.cs
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

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Tests for <see cref="FastestArrayPool{T}.Return" /> edge paths.
    /// </summary>
    public class FastestArrayPoolReturnTest
    {
        /// <summary>
        ///     Tests that Return with a small array less than min bucket size does not add to buckets.
        /// </summary>
        [Fact]
        public void Return_WithSmallArray_DoesNotThrow()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = new int[4];

            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Return with clearArray true and reference type clears the array.
        /// </summary>
        [Fact]
        public void Return_WithClearArrayAndReferenceType_ClearsContent()
        {
            FastestArrayPool<string> pool = FastestArrayPool<string>.Instance;
            string[] array = pool.Rent(100);
            array[0] = "hello";

            pool.Return(array, clearArray: true);

            Assert.Null(array[0]);
        }

        /// <summary>
        ///     Tests that Rent after Return with clear reuses slot and returns clean array.
        /// </summary>
        [Fact]
        public void RentAfterReturnWithClear_ReturnsCleanArray()
        {
            FastestArrayPool<string> pool = FastestArrayPool<string>.Instance;
            string[] array = pool.Rent(100);
            array[0] = "hello";
            pool.Return(array, clearArray: true);

            string[] rented = pool.Rent(100);

            Assert.Null(rented[0]);
        }
    }
}
