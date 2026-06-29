// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestArrayPoolBucketEdgeCaseTest.cs
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
    ///     Edge-case tests for FastestArrayPool targeting specific bucket index boundaries
    ///     in the GetBucketIndex bit-manipulation logic.
    /// </summary>
    public class FastestArrayPoolBucketEdgeCaseTest
    {
        /// <summary>
        ///     Tests that Rent with size at exact MinBucketSize boundary (16) returns a valid pooled array.
        ///     This exercises the first valid bucket index path in GetBucketIndex.
        /// </summary>
        [Fact]
        public void Rent_AtMinBucketSize_ReturnsPooledArray()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array1 = pool.Rent(16);
            pool.Return(array1);

            int[] array2 = pool.Rent(16);

            Assert.Same(array1, array2);
            pool.Return(array2);
        }

        /// <summary>
        ///     Tests that Rent with size 17 exercises the (n &amp; 0xF0) shift-by-4 path.
        ///     This hits a non-power-of-two bucket index, testing partial-nibble lookup.
        /// </summary>
        [Fact]
        public void Rent_Size17_ExercisesNibbleLookup()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(17);

            Assert.NotNull(array);
            Assert.True(array.Length >= 17);
            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Rent with size 33 exercises bit-1 check after nibble shift.
        ///     This covers the (n &amp; 0x2) != 0 branch in GetBucketIndex.
        /// </summary>
        [Fact]
        public void Rent_Size33_ExercisesBitOneCheck()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(33);

            Assert.NotNull(array);
            Assert.True(array.Length >= 33);
            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Rent with size 65 exercises the (n &amp; 0xC) branch.
        ///     This covers the two-bit check after nibble shift in GetBucketIndex.
        /// </summary>
        [Fact]
        public void Rent_Size65_ExercisesTwoBitCheck()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(65);

            Assert.NotNull(array);
            Assert.True(array.Length >= 65);
            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Rent with size 257 exercises the (n &amp; 0xFF00) shift-by-8 path.
        ///     This covers the byte-level bit scan in GetBucketIndex.
        /// </summary>
        [Fact]
        public void Rent_Size257_ExercisesByteShift()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(257);

            Assert.NotNull(array);
            Assert.True(array.Length >= 257);
            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Rent with size 65537 exercises the (n &amp; 0xFFFF0000) shift-by-16 path.
        ///     This covers the word-level bit scan in GetBucketIndex.
        /// </summary>
        [Fact]
        public void Rent_Size65537_ExercisesWordShift()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(65537);

            Assert.NotNull(array);
            Assert.True(array.Length >= 65537);
            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Rent with size just below MinBucketSize (15) creates a non-pooled array.
        /// </summary>
        [Fact]
        public void Rent_BelowMinBucketSize_Size15_CreatesNewArray()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(15);

            Assert.NotNull(array);
            Assert.Equal(15, array.Length);
            pool.Return(array);
        }

        /// <summary>
        ///     Tests that Rent with size zero creates a zero-length array.
        /// </summary>
        [Fact]
        public void Rent_SizeZero_ReturnsZeroLengthArray()
        {
            FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
            int[] array = pool.Rent(0);

            Assert.NotNull(array);
            Assert.Equal(0, array.Length);
            pool.Return(array);
        }
    }
}
