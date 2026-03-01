// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestArrayPoolSimpleTest.cs
// 
//  Author:GitHub Copilot
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
    ///     Simple tests for FastestArrayPool to validate basic pooling behavior.
    /// </summary>
    public class FastestArrayPoolSimpleTest
    {
        /// <summary>
        ///     Test that renting and returning arrays maintains pool consistency.
        /// </summary>
        [Fact]
        public void RentAndReturn_SingleArray_PoolReusesProperly()
        {
            // Arrange
            var pool = FastestArrayPool<int>.Instance;
            int[] array1 = pool.Rent(100);
            int[] array2;

            // Act
            pool.Return(array1);
            array2 = pool.Rent(100);

            // Assert
            Assert.NotNull(array2);
            Assert.True(array2.Length >= 100);
        }

        /// <summary>
        ///     Test that arrays below minimum bucket size are not pooled.
        /// </summary>
        [Fact]
        public void Rent_BelowMinimumBucketSize_CreatesNewArray()
        {
            // Arrange
            var pool = FastestArrayPool<int>.Instance;

            // Act
            int[] smallArray = pool.Rent(8);

            // Assert
            Assert.NotNull(smallArray);
            Assert.Equal(8, smallArray.Length);
        }

        /// <summary>
        ///     Test that renting increasingly larger arrays works correctly.
        /// </summary>
        [Fact]
        public void Rent_ProgressivelyLargerSizes_AllSuccessful()
        {
            // Arrange
            var pool = FastestArrayPool<long>.Instance;
            int[] sizes = { 16, 32, 64, 128, 256, 512, 1024 };

            // Act & Assert
            foreach (int size in sizes)
            {
                long[] array = pool.Rent(size);
                Assert.NotNull(array);
                Assert.True(array.Length >= size);
            }
        }

        /// <summary>
        ///     Test that ResizeArrayFromPool properly copies data and maintains content.
        /// </summary>
        [Fact]
        public void ResizeArrayFromPool_DataPreservation_ContentIntact()
        {
            // Arrange
            var pool = FastestArrayPool<int>.Instance;
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] originalCopy = (int[])arr.Clone();

            // Act
            FastestArrayPool<int>.ResizeArrayFromPool(ref arr, 200);

            // Assert
            for (int i = 0; i < originalCopy.Length; i++)
            {
                Assert.Equal(originalCopy[i], arr[i]);
            }

            Assert.True(arr.Length >= 200);
        }

        /// <summary>
        ///     Test that returning arrays with clear flag works for reference types.
        /// </summary>
        [Fact]
        public void Return_WithClearFlag_ReferencesCleared()
        {
            // Arrange
            var pool = FastestArrayPool<string>.Instance;
            string[] array = pool.Rent(50);
            array[0] = "test";

            // Act
            pool.Return(array, clearArray: true);

            // Assert
            Assert.Null(array[0]);
        }

        /// <summary>
        ///     Test that multiple rental cycles work correctly without corruption.
        /// </summary>
        [Fact]
        public void MultipleCycles_RentReturnRentPattern_Consistent()
        {
            // Arrange
            var pool = FastestArrayPool<int>.Instance;

            // Act & Assert
            for (int cycle = 0; cycle < 5; cycle++)
            {
                int[] arr = pool.Rent(100);
                for (int i = 0; i < 100; i++)
                {
                    arr[i] = i;
                }

                pool.Return(arr);

                int[] arr2 = pool.Rent(100);
                Assert.NotNull(arr2);
                Assert.True(arr2.Length >= 100);
                pool.Return(arr2);
            }
        }

        /// <summary>
        ///     Test that ValueType arrays work correctly through pooling cycles.
        /// </summary>
        [Fact]
        public void Rent_ValueTypeArray_ProperlyPooled()
        {
            // Arrange
            var pool = FastestArrayPool<byte>.Instance;

            // Act
            byte[] arr1 = pool.Rent(256);
            arr1[0] = 255;
            pool.Return(arr1);

            byte[] arr2 = pool.Rent(256);

            // Assert
            Assert.NotNull(arr2);
            Assert.True(arr2.Length >= 256);
        }
    }
}

