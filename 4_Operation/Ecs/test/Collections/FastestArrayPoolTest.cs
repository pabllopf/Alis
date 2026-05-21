// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestArrayPoolTest.cs
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
    ///     The fastest array pool test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="FastestArrayPool{T}" /> static class which provides
    ///     fast array pooling for memory-efficient allocation and reuse.
    /// </remarks>
    public class FastestArrayPoolTest
    {
        /// <summary>
        ///     Tests that fastest array pool instance is available
        /// </summary>
        /// <remarks>
        ///     Verifies that the singleton instance is available.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_InstanceIsAvailable()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;

            Assert.NotNull(instance);
        }

        /// <summary>
        ///     Tests that fastest array pool rent returns array
        /// </summary>
        /// <remarks>
        ///     Verifies that Rent method returns a valid array.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_RentReturnsArray()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;
            int[] array = instance.Rent(10);

            Assert.NotNull(array);
            Assert.True(array.Length >= 10);

            instance.Return(array);
        }

        /// <summary>
        ///     Tests that fastest array pool rent with zero size
        /// </summary>
        /// <remarks>
        ///     Tests Rent with zero requested size.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_RentWithZeroSize()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;
            int[] array = instance.Rent(0);

            Assert.NotNull(array);

            instance.Return(array);
        }

        /// <summary>
        ///     Tests that fastest array pool return accepts array
        /// </summary>
        /// <remarks>
        ///     Validates that Return method accepts a rented array.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_ReturnAcceptsArray()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;
            int[] array = instance.Rent(10);

            instance.Return(array);
        }

        /// <summary>
        ///     Tests that fastest array pool rent and return cycle
        /// </summary>
        /// <remarks>
        ///     Tests a complete rent and return cycle.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_RentAndReturnCycle()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;

            int[] array1 = instance.Rent(10);
            instance.Return(array1);
            int[] array2 = instance.Rent(5);

            Assert.NotNull(array1);
            Assert.NotNull(array2);

            instance.Return(array2);
        }

        /// <summary>
        ///     Tests that fastest array pool works with different types
        /// </summary>
        /// <remarks>
        ///     Validates that the pool works with reference types and value types.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_WorksWithDifferentTypes()
        {
            FastestArrayPool<int> intInstance = FastestArrayPool<int>.Instance;
            FastestArrayPool<string> stringInstance = FastestArrayPool<string>.Instance;
            FastestArrayPool<double> doubleInstance = FastestArrayPool<double>.Instance;

            int[] intArray = intInstance.Rent(10);
            string[] stringArray = stringInstance.Rent(10);
            double[] doubleArray = doubleInstance.Rent(10);

            Assert.NotNull(intArray);
            Assert.NotNull(stringArray);
            Assert.NotNull(doubleArray);

            intInstance.Return(intArray);
            stringInstance.Return(stringArray);
            doubleInstance.Return(doubleArray);
        }

        /// <summary>
        ///     Tests that fastest array pool rent multiple times
        /// </summary>
        /// <remarks>
        ///     Tests multiple consecutive rent operations.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_RentMultipleTimes()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;

            int[] array1 = instance.Rent(10);
            int[] array2 = instance.Rent(20);
            int[] array3 = instance.Rent(30);

            Assert.NotNull(array1);
            Assert.NotNull(array2);
            Assert.NotNull(array3);

            instance.Return(array1);
            instance.Return(array2);
            instance.Return(array3);
        }

        /// <summary>
        ///     Tests that fastest array pool rented array is usable
        /// </summary>
        /// <remarks>
        ///     Validates that a rented array can be used normally.
        /// </remarks>
        [Fact]
        public void FastestArrayPool_RentedArrayIsUsable()
        {
            FastestArrayPool<int> instance = FastestArrayPool<int>.Instance;
            int[] array = instance.Rent(5);

            array[0] = 10;
            array[1] = 20;
            array[2] = 30;

            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);
            Assert.Equal(30, array[2]);

            instance.Return(array);
        }
    }
}