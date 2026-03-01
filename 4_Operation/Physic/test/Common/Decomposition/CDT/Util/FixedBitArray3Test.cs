// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedBitArray3Test.cs
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

using System.Linq;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Physic.Common.Decomposition.CDT.Util;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The fixed bit array 3 test class
    /// </summary>
    public class FixedBitArray3Test
    {
        /// <summary>
        ///     Tests that default constructor should initialize with false values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithFalseValues()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            Assert.False(array[0]);
            Assert.False(array[1]);
            Assert.False(array[2]);
        }

        /// <summary>
        ///     Tests that indexer should set and get value at index zero
        /// </summary>
        [Fact]
        public void Indexer_ShouldSetAndGetValueAtIndexZero()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            array[0] = true;
            
            Assert.True(array[0]);
        }

        /// <summary>
        ///     Tests that indexer should set and get value at index one
        /// </summary>
        [Fact]
        public void Indexer_ShouldSetAndGetValueAtIndexOne()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            array[1] = true;
            
            Assert.True(array[1]);
        }

        /// <summary>
        ///     Tests that indexer should set and get value at index two
        /// </summary>
        [Fact]
        public void Indexer_ShouldSetAndGetValueAtIndexTwo()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            array[2] = true;
            
            Assert.True(array[2]);
        }

        /// <summary>
        ///     Tests that indexer should throw exception for negative index
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowException_ForNegativeIndex()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[-1]);
        }

        /// <summary>
        ///     Tests that indexer should throw exception for index greater than two
        /// </summary>
        [Fact]
        public void Indexer_ShouldThrowException_ForIndexGreaterThanTwo()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[3]);
        }

        /// <summary>
        ///     Tests that contains should return true when value present
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnTrue_WhenValuePresent()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            
            bool result = array.Contains(true);
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that contains should return false when value not present
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnFalse_WhenValueNotPresent()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            bool result = array.Contains(true);
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that index of should return correct index
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[1] = true;
            
            int index = array.IndexOf(true);
            
            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that index of should return negative one when value not found
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnNegativeOne_WhenValueNotFound()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            int index = array.IndexOf(true);
            
            Assert.Equal(-1, index);
        }

        /// <summary>
        ///     Tests that clear should set all values to false
        /// </summary>
        [Fact]
        public void Clear_ShouldSetAllValuesToFalse()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            array[1] = true;
            array[2] = true;
            
            array.Clear();
            
            Assert.False(array[0]);
            Assert.False(array[1]);
            Assert.False(array[2]);
        }

        /// <summary>
        ///     Tests that clear with value should clear specific value
        /// </summary>
        [Fact]
        public void ClearWithValue_ShouldClearSpecificValue()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            array[1] = false;
            array[2] = true;
            
            array.Clear(true);
            
            Assert.False(array[0]);
            Assert.False(array[1]);
            Assert.False(array[2]);
        }

        /// <summary>
        ///     Tests that get enumerator should enumerate all values
        /// </summary>
        [Fact]
        public void GetEnumerator_ShouldEnumerateAllValues()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            array[1] = false;
            array[2] = true;
            
            var values = array.ToList();
            
            Assert.Equal(3, values.Count);
            Assert.True(values[0]);
            Assert.False(values[1]);
            Assert.True(values[2]);
        }

        /// <summary>
        ///     Tests that fixed bit array should be value type
        /// </summary>
        [Fact]
        public void FixedBitArray_ShouldBeValueType()
        {
            FixedBitArray3 array1 = new FixedBitArray3();
            array1[0] = true;
            FixedBitArray3 array2 = array1;
            
            array2[0] = false;
            
            Assert.NotEqual(array1[0], array2[0]);
        }

        /// <summary>
        ///     Tests that fixed bit array should support foreach iteration
        /// </summary>
        [Fact]
        public void FixedBitArray_ShouldSupportForeachIteration()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            array[1] = false;
            array[2] = true;
            
            int trueCount = 0;
            foreach (bool value in array)
            {
                if (value) trueCount++;
            }
            
            Assert.Equal(2, trueCount);
        }

        /// <summary>
        ///     Tests that index of should return first occurrence
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnFirstOccurrence()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = false;
            array[1] = true;
            array[2] = true;
            
            int index = array.IndexOf(true);
            
            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that contains should work with false value
        /// </summary>
        [Fact]
        public void Contains_ShouldWorkWithFalseValue()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            array[1] = false;
            array[2] = true;
            
            bool result = array.Contains(false);
            
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that clear with false should clear false values
        /// </summary>
        [Fact]
        public void ClearWithFalse_ShouldClearFalseValues()
        {
            FixedBitArray3 array = new FixedBitArray3();
            array[0] = true;
            array[1] = false;
            array[2] = true;
            
            array.Clear(false);
            
            Assert.True(array[0]);
            Assert.False(array[1]);
            Assert.True(array[2]);
        }

        /// <summary>
        ///     Tests that indexer set should throw exception for invalid index
        /// </summary>
        [Fact]
        public void IndexerSet_ShouldThrowException_ForInvalidIndex()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[5] = true);
        }

        /// <summary>
        ///     Tests that fixed bit array should implement i enumerable
        /// </summary>
        [Fact]
        public void FixedBitArray_ShouldImplementIEnumerable()
        {
            FixedBitArray3 array = new FixedBitArray3();
            
            Assert.IsAssignableFrom<System.Collections.Generic.IEnumerable<bool>>(array);
        }
    }
}

